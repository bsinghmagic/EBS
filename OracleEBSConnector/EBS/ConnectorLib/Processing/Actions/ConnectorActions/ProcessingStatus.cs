﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        SUCCESS, 
        FAIL,
        NOT_PROCESSED
    }
    public class ProcessingStatus
    {
        public ProcessingStatus()
        {
            processingStatus = Status.NOT_PROCESSED;
            processedAt = DateTime.Now;
            error = "";
        }

        public dynamic id { get; set; }

        [JsonProperty(propertyName: "processingStatus")]
        public Status processingStatus { get; set; }

        [JsonProperty(propertyName: "error")]
        public string error { get; set; }

        [JsonProperty(propertyName: "processedAt")]
        public DateTime processedAt { get; set; }
    }
}

/*
 { 
  _id: '...',
  processed: true,
  processingStatus: ['SUCCESS', 'FAIL', 'NOT PROCESSED'],
  processedAt: date,
  error: 'error message if processing fails'
}
 */
