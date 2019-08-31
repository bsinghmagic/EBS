using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConnectorEntity
{
    /// <summary>
    /// Connector config
    /// </summary>
    [Serializable]
    public class Config
    {
       public List<QueryRequest> autoScheduleRequest { get; set; }

     

    /// <summary>
    /// Serialize object to JSON string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        {
            using (var writer = new StringWriter())
            {
                JsonSerializer.Create().Serialize(writer, this);
                return writer.ToString();
            }
        }
    }
}
