using ConnectorEntity;
using Newtonsoft.Json;
using System;
using WebClientUtility.Core;

namespace WebClientUtility.API
{
    /// <summary>
    /// Sage50Connector interface wrapper
    /// </summary>
    public class ConnectorApi
    {
        // ReSharper disable once InconsistentNaming
        private readonly IHttpUtility httpUtility;

        private readonly Config config;

        private string  webHookURL;

        public ConnectorApi(IHttpUtility httpUtility, Config config, string connectorKey)
        {
            this.httpUtility = httpUtility;
            this.config = config;
            this.webHookURL = connectorKey;
        }

        /// <summary>
        ///  Gets actions JSON data from EBSConnector endpoint
        /// </summary>
        /// <returns></returns>
        public string GetActionsJson()
        {
            var data = "{\"route\":\"actions\"}";
            var json = httpUtility.Post(webHookURL, data, "application/json");
            return json; 
        }

        public string ReportProcessingStatus(string jsonBody)
        {                                        

            string routData = "{\"route\":\"status\",\"data\":\'{0}\'}";
            string data = routData.Replace("'{0}'", jsonBody);

            return httpUtility.Post(webHookURL, data, "application/json");
            //  return httpUtility.Patch(config.Sage50ConnectorActionEndpointUrl, jsonBody, "application/json");
        }


    public string PostResponse(string module,string jsonBody)
    {

      string routData = "{\"route\":\"response\",\"action\":\"{0}\",\"data\":\'{1}\'}";
      string data = routData.Replace("{0}", module).Replace("'{1}'", jsonBody);

      return httpUtility.Post(webHookURL, data, "application/json");

    }


    public Config GetConnectorConfig()
        {
            var data = "{\"route\":\"config\"}";
            var json = httpUtility.Post(webHookURL, data, "application/json");
            return JsonConvert.DeserializeObject<Config>(json);

        }

        /// <summary>
        /// Send handshake to Sage50Connector from HeartBeat Job
        /// </summary>
   public bool Handshake()
    {
      try
      {
        var data = "{\"route\":\"handshake\"}";
        var json = httpUtility.Post(webHookURL, data, "application/json");
        return true;

      }
      catch (Exception ex)
      {
        return false;
        // throw new Exception("Please enter a valid connector Key");
      }
    }

 
    /// <summary>
    /// Send log to Sage50Connector 
    /// </summary>
    public void Log(LogRecord log)
        {
            var logJson = JsonConvert.SerializeObject(log);

            string routData = "{\"route\":\"log\",\"data\":\'{0}\'}";
            string data = routData.Replace("'{0}'", logJson);

           // var data = string.Format("{\"route\":\"log\",\"data\":\"{0}\"}", logJson);
            httpUtility.Post(webHookURL, data, "application/json");
        }
    }
}

