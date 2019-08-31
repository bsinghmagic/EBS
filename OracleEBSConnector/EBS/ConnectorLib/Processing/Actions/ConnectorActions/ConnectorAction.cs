using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
  public class ConnectorAction
  {

        [JsonProperty(propertyName: "id")]
        public int id { get; set; }
        public string type { get; set; }
        public string mainLogId { get; set; }
        public string source { get; set; }
        public string triggerId { get; set; }
        public string companyName { get; set; }


        public static Type GetActionClassType(string actionType)
        {
            var typeName = typeof(ConnectorAction).FullName;
            var lastPointPosition = typeName.LastIndexOf('.');
            return Type.GetType(typeName.Insert(lastPointPosition + 1, actionType));
        }

    }
}