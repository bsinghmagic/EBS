using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using ConnectorLib.Processing.Actions.ConnectorActions.Factory;
using WebClientUtility.API;

namespace ConnectorLib.Processing.Actions
{
    /// <summary>
    /// Polls EBSConnector endpoint to check if new actions appeareds
    /// </summary>

  public  class PollConnectorJob 
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(PollConnectorJob));
        private readonly ConnectorApi api;
        public PollConnectorJob(ConnectorApi api)
        {
            this.api = api;
        }
        public void Execute()
        {
            try
            {
                Log.Info(" ------------------------------------------------------------------------------------------------------------------------------");
                Log.Info("| Poll Job Started |");
                Log.Info(" ------------------------------------------------------------------------------------------------------------------------------");
                Log.Info("Get ActionsJson from XPC...");                
                while (true)
                {
                    var jsonString = api.GetActionsJson();
                    Log.Info(string.Format("Received JSON: '{0}'", jsonString));

                    //jsonString = "[{\r\n  \"id\": \"faf5ba98-c306-4dd8-9e19-e02785b93bb0\",\r\n  \"type\": \"CreatePurchaseInvoice\",\r\n  \"source\": \"MineralTree\",\r\n  \"payload\": {\r\n    \"purchaseInvoice\": {\r\n      \"ReferenceNumber\": \"5533\",\r\n      \"TotalAmount\": 3000,\r\n      \"TermsDescription\": \"ABNEY-Payment term\",\r\n      \"Date\": \"2018-10-09T00:00:00Z\",\r\n      \"DateDue\": \"2018-11-08T00:00:00Z\",\r\n      \"vendor\": {\r\n        \"Name\": \"Abney and Son Contractors\",\r\n        \"ExternalId\": \"ABNEY\"\r\n      },\r\n      \"AP_Account\": {\r\n        \"Id\": \"2000\"\r\n      },\r\n      \"PurchaseInvoiceLines\": [\r\n        {\r\n          \"ReceivedQty\": 30,\r\n          \"UnitPrice\": 100,\r\n          \"ItemRecordNumber\": \"151\",\r\n          \"Amount\": 3000,\r\n          \"Description\": null,\r\n          \"Account\": {\r\n            \"Id\": \"147\"\r\n          }\r\n        }\r\n      ]\r\n    }\r\n  }\r\n}]";


                    if (jsonString == null)
                        return;


                    // Splits actions to array and put them in context.JobDetail.JobDataMap
                    dynamic actionsDynamic = JsonConvert.DeserializeObject(jsonString);

                    var actionsStrings = (actionsDynamic.Root as Newtonsoft.Json.Linq.JArray).Select(i => i.ToString());

                    if (actionsStrings == null)
                        return;

                    //var ConnectorActionsJson = (IEnumerable<string>)actionsStrings;
                    var ConnectorActionsJson = (IEnumerable<string>)actionsStrings;
                    Log.Debug("Creating EBS actions from JSON ...");

                    ActionFromJsonFactory actionFactory = new ActionFromJsonFactory();
                    var ConnectorActions = ConnectorActionsJson.Select(actionJson => actionFactory.Create(actionJson));

                    ActionsProcessor ConnectorActionsProcessor = new ActionsProcessor();
                    ActionsProcessor.ProcessConnectorActions(ConnectorActions, api);


                }
               //return actionsStrings;
      }
            catch (Exception ex)
            {
                Log.Error("Unknown exception was handled while getting JSON from XPC: ", ex);
            }


        }
    }
}