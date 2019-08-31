using System;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectorLib.Processing.Actions.ConnectorActions.Factory
{
    /// <summary>
    /// Creates EBS Actions from JSON strings
    /// </summary>
    public class ActionFromJsonFactory : IActionFactory
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(ActionFromJsonFactory));

        public ConnectorAction Create(string jsonString)
        {           
            //jsonString = "{\r\n \"id\":\"1\" ,\r\n \"source\":\"MineralTree\" , \r\n \"type\":\"UpsertVendor\", \r\n \"payload\":{\"vendor\":" + jsonString + "\r\n}\r\n}";

            Log.DebugFormat("Creating EBS Action from JSON: {0}", jsonString);

            dynamic connectorAction = JObject.Parse(jsonString);

            var actionTypePrefix = (string)connectorAction.type;
            var actionType = ConnectorAction.GetActionClassType(actionTypePrefix);
            if (actionType == null)
            {
                throw new Exception($"Can not found action type for '{actionTypePrefix}' type");
            }

            return (ConnectorAction)JsonConvert.DeserializeObject(jsonString, actionType);
        }

    }
}