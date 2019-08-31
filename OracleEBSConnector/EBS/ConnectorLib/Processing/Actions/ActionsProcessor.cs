using System;
using System.Collections.Generic;
using System.Linq;
using ConnectorEntity;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ConnectorLib.Processing.Actions.ActionHandlers.Factory;
using ConnectorLib.Processing.Actions.ConnectorActions;
using WebClientUtility.API;
using WebClientUtility.Core;

namespace ConnectorLib.Processing.Actions
{
    /// <summary>
    /// Provides operational interface for EBSConnector Actions
    /// </summary>
    public class ActionsProcessor 
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActionsProcessor));


        private static string GetJArrayValue(JObject yourJArray, string key)
        {
            foreach (KeyValuePair<string, JToken> keyValuePair in yourJArray)
            {
                if (key == keyValuePair.Key)
                {
                    return keyValuePair.Value.ToString();
                }
            }
            return "";
        }
        public static void ProcessConnectorActions(IEnumerable<ConnectorAction> ConnectorActions, ConnectorApi ebsConnectorApi)
        {
            // actions can be handled in any order, this is the right place to put this logic
            // most of the time it will be just 1-1 action to handler assocciation
            try
            {
                var actions = ConnectorActions.ToArray();
                if (actions.Length == 0)
                    return;
              
                foreach (var ConnectorAction in actions)
                {
                
                    try
                    {
                        

                        Log.InfoFormat("Create handler for action (type: {0}, id: {1}) ...", ConnectorAction.type,
                            ConnectorAction.id);
                         dynamic handler = ConnectorActionHandlerFactory.CreateHandler(ConnectorAction.type);
                       
                            Log.InfoFormat("Handling action (type: {0}, id: {1}) ...", ConnectorAction.type, ConnectorAction.id);
                            // dynamic ActionHandler generic type require derived type, not base ConnectorAction type
                            handler.Handle((dynamic) ConnectorAction);
                            Log.InfoFormat("Handling action successful (type: {0}, id: {1}) ...", ConnectorAction.type,
                            ConnectorAction.id);

                          // sending Success log to EBSConnector ....
                            ebsConnectorApi.Log(new LogRecord
                            {
                                Status = "Success",
                                TriggerId = ConnectorAction.triggerId,
                                Uid = ConnectorAction.mainLogId,
                                Data = "{}",
                                Date = DateTime.Now

                            });
                        
                    }
                    catch (AbortException ex)
                    {
                        Log.Error("Handling action failed", ex);
                        //ConnectorAction.ProcessingStatus = new ProcessingStatus
                        //{
                        //    id = ConnectorAction.mangodbObject,
                        //    processingStatus = Status.FAIL,
                        //    error = ex.Message
                        //};

                        // sending ex log to Sage50Connector ....
                        var exJson = JsonConvert.SerializeObject(ex);
                        ebsConnectorApi.Log(new LogRecord
                        {
                            Message = ex.Message,
                            Status = ex.StatusCode.ToString("G"),
                            TriggerId = ConnectorAction.triggerId,
                            Uid = ConnectorAction.mainLogId,
                            Data = exJson,
                            Date = DateTime.Now,
                            requestbody = JsonConvert.SerializeObject(ConnectorAction)
                    });
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Handling action failed", ex);
                        //ConnectorAction.ProcessingStatus = new ProcessingStatus
                        //{
                        //    id = ConnectorAction.id,
                        //    processingStatus = Status.FAIL,
                        //    error = ex.Message
                        //};

                        // sending ex log to Sage50Connector ....
                        var exJson = JsonConvert.SerializeObject(ex);
                        ebsConnectorApi.Log(new LogRecord
                        {
                            Message = ex.Message,
                            Status = "Fail",
                            TriggerId = ConnectorAction.triggerId,
                            Uid = ConnectorAction.mainLogId,
                            Data = exJson,
                            Date = DateTime.Now,
                            requestbody = JsonConvert.SerializeObject(ConnectorAction)
                        });
                    }
                }


            }
            catch (Exception ex)
            {
                Log.Error("Process EBS actions failed", ex);
            }
        }

   
    }
}

