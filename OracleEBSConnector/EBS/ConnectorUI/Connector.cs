using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ConnectorLib.API;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConnectorLib.Processing.Actions;
using ConnectorEntity;
using WebClientUtility.Core;
using WebClientUtility.API;
using ConnectorModel.Model;
using EBS;
using ODBCConnector.PopulateModul;

namespace ConnectorUI
{
  public class Connector
  {
    public static readonly log4net.ILog Log = LogManager.GetLogger(typeof(Connector));
    public static frmMain mainForm;
    public static string currentCompany = string.Empty;

    public Connector()
    {
      XmlConfigurator.Configure();
    }
    public static async Task<LogRecord> start(ConnectorConfiguration configuration)
    {
      currentCompany = configuration.company;
      log4net.Config.XmlConfigurator.Configure();
      Log.Info("********************************************************************************************************************");
      Log.Info(string.Format("Company Name : {0} ", currentCompany));
      LogRecord ebsConnectorLog = new LogRecord();
      try
            { 
        Config config = new Config();
        WebClientUtility.API.ConnectorApi ebsConnectorApi = new WebClientUtility.API.ConnectorApi(new WebClientHttpUtility(), config, configuration.connectorKey);
        config = ebsConnectorApi.GetConnectorConfig();
        await Task.Run(() =>
                {
            
                    try
                    {
                    ConnectorLib.API.ConnectorApi ebsApi = new ConnectorLib.API.ConnectorApi();
                    //sending ebsApi configuration to ConnectorLib.API.ConnectorApi
                    ebsApi.ConnectorConfig(configuration.connectionString);
                    Log.Info(string.Format("{0} Sync started..", currentCompany));
                    ebsConnectorLog.Date = DateTime.Now;
                    SetProgress(20, "Sync started retrieving connector config ...");
                    Log.Info(string.Format("Retrieved Connector Config ...", config.ToString()));                    
                    foreach (QueryRequest queryRequest in config.autoScheduleRequest)
       {                   
                      //Log.Info(string.Format("queryRequest.SQLquery :: {0}", queryRequest.SQLquery.ToString()));
                        //if (queryRequest.Module == "INVOICE") //INVOICE //TERMS //PURCHASE_ORDER //VENDOR //ITEMS
                      //  {
                                SendRequestEBSToMT(configuration, queryRequest, ebsConnectorApi);
                       //  }
                       
                    }

                    PollConnectorJob PollEBSConnectorJob = new ConnectorLib.Processing.Actions.PollConnectorJob(ebsConnectorApi);
                    PollEBSConnectorJob.Execute();

                    ebsConnectorLog.Status = "Success";
                    SetProgress(100, string.Empty);

                  }
                  catch (Exception ex)
                  {
                    SetProgress(0, string.Empty);
                    Log.FatalFormat("Request failed {0}. Trace: {1}", ex.Message, ex);
                  }

                });

                Log.Info(string.Format("{0} Sync Stopped..", currentCompany));
                return ebsConnectorLog;
      }
      catch (Exception ex)
      {
        Log.FatalFormat("{0} sync failed: {1}. Trace: {2}", currentCompany, ex.Message, ex);
        ebsConnectorLog.Status = "Failed";
        ebsConnectorLog.Message = string.Format("{0} sync failed: {1}. Trace: {2}", currentCompany, ex.Message, ex);
        ebsConnectorLog.Date = DateTime.Now;

      }
      return ebsConnectorLog;
    }
    private static async void SendRequestEBSToMT(ConnectorConfiguration configuration, QueryRequest queryRequest, WebClientUtility.API.ConnectorApi ConnectorApi)
     {

      try
      {        
        Log.Info(string.Format("Get data from database for '{0}' Query ", queryRequest.Module));
        List<string> list = await GetApiResult(queryRequest, configuration.connectionString);

        if (list.Count == 0)
        {

            Log.Info("No Data Found................");
        }

       for (var i = 0; i < list.Count; i++)
        {       
          Log.Info(string.Format("Request Module: {0}", queryRequest.Module));
          Log.Info(string.Format("\nRequest Query: {0}", queryRequest.SQLquery));
          Log.DebugFormat(string.Format("\nModule Result data: {0}", list[i]));
          var response = ConnectorApi.PostResponse(queryRequest.Module, list[i]);
          var statusResult = (JObject)JsonConvert.DeserializeObject(response);
          SetProgress(20*i, string.Format("Syncing {0} ", queryRequest.Module));
          Log.Info(string.Format("Status: {0}", queryRequest.Module + " Success"));
        }

      }
      catch (Exception ex)
      {

        SetProgress(0, string.Empty);
        Log.FatalFormat("Request failed {0}. Trace: {1}", ex.Message, ex);
      }


    }
        private async static Task<List<string>> GetApiResult(QueryRequest queryRequest, string ConnectionString, int chunkSize = 100)
        {

            string LastSync;

            if (queryRequest.PoolingColumnType == "DateTime")
            {
                LastSync = Convert.ToDateTime(queryRequest.LastSync).ToString("yyyy-MM-dd HH:mm:ss");

            }
            else
            {
                LastSync = queryRequest.LastSync;        
            }

            Log.Info(string.Format("LASTSYNC FROM CONNECTOR :: {0}", LastSync ));

            List<string> result = new List<string>();
            switch (queryRequest.Module)
            {
                case "PROJECT":
                    {
                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                    }
                    break;
                case "GL_ACCOUNT":
                    {
                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                    }
                    break;
                case "TERMS":
                    {
                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                    }
                    break;
                case "VENDOR":
                    {

                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);

                    }
                    break;
                case "ITEMS":
                    {
                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                    }
                    break;
                case "PURCHASE_ORDER":
                    {
                        try
                        {
                            result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                            string stringPOJson = string.Join(",", result.ToArray());
                            List<GetPurchaseOrderEntity> objectListPO = JsonConvert.DeserializeObject<List<GetPurchaseOrderEntity>>(stringPOJson);
                            List<PurchaseOrder> purchaseOrder = PopulateModule.PopulatePoModel(objectListPO);
                            stringPOJson = JsonConvert.SerializeObject(purchaseOrder);
                            result.Clear();
                            result.Add(stringPOJson);
                        }
                        catch (Exception ex){
                            Log.Info("Purchase Order Exception" + ex);
                        }
                    }
                    break;              
                case "INVOICE":
                    {
                        try
                        {
                        result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                        string stringInvoiceJson = string.Join(",", result.ToArray());
                        List<GetInvoicEntity> objectListInvoice = JsonConvert.DeserializeObject<List<GetInvoicEntity>>(stringInvoiceJson);
                        List<Invoice> invoice = PopulateModule.PopulateInvoiceModel(objectListInvoice);
                        stringInvoiceJson = JsonConvert.SerializeObject(invoice);
                        result.Clear();
                        result.Add(stringInvoiceJson);
                        }
                          catch (Exception ex)
                        {
                            Log.Info("Invoice Exception");
                        }
                    }
                    break;
               
                case "PAYMENT":
                    {
                        try
                        {
                            result = await ODBCDataAccess.GetResult(ConnectionString, queryRequest.SQLquery, LastSync);
                            string strinPaymentJson = string.Join(",", result.ToArray());
                            List<GetPaymentEntity> objectListPayment = JsonConvert.DeserializeObject<List<GetPaymentEntity>>(strinPaymentJson);
                            List<Payment> payment = PopulateModule.PopulatePaymentModel(objectListPayment);
                            strinPaymentJson = JsonConvert.SerializeObject(payment);
                            result.Clear();
                            result.Add(strinPaymentJson);
                        }
                        catch (Exception ex)
                        {
                            Log.Info("Payment Exception");
                        }
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            return result;
        }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      Log.Info("********************************************************************************************************************");
      Log.FatalFormat("* UnhandledException: ExceptionObject = {0}, IsTerminating = {1}", e.ExceptionObject, e.IsTerminating);
      Log.Info("********************************************************************************************************************");
    }

    protected void OnStop()
    {
      Log.Info("********************************************************************************************************************");
      Log.Info("* EBSConnector Service stopped");
      Log.Info("********************************************************************************************************************");
    }

    public static void SetProgress(int value, string message)
    {
      mainForm.applicationProgress.Invoke((Action)(() => mainForm.applicationProgress.Value = value));
      mainForm.lblApplicationProgress.Invoke((Action)(() => mainForm.lblApplicationProgress.Text = value.ToString() + "%"));
      mainForm.lblProgressLog.Invoke((Action)(() => mainForm.lblProgressLog.Text = string.Format("{0} : {1}", value == 0 ? "" : currentCompany, message)));
    }

    public static List<T> Deserialize<T>(string path)
    {
        return JsonConvert.DeserializeObject<List<T>>(path);
    }

  }

}
