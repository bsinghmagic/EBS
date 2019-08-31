using Newtonsoft.Json;
using System;


namespace ConnectorEntity
{
    public class Action<T>
    {
        [JsonProperty(propertyName: "_id")]
        public Guid id { get; set; }
        public string PayloadId { get; set; }
        public string type { get; set; }
        public string mainLogId { get; set; }
        public string source { get; set; }
        public int userId { get; set; }
        public int workflowId { get; set; }
        public string triggerId { get; set; }

        public T payload { get; set; }
    }
}
