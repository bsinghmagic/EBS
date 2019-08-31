using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorUI
{
    [Serializable()]
    public class ConnectorConfiguration
    {
        public int id { get; set; }
        public string company { get; set; }
        public string connectorKey { get; set; }
        public string connectorSecret { get; set; }
        public string serverName { get; set; }
        public string dsn { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string port { get; set; }
        public bool selectCheckbox { get; set; }
        public bool autoRun { get; set; }
        public int everyMinutes { get; set; }
        public string lastRun { get; set; }
        public string lastResult { get; set; }
        public string moreInformation { get; set; }
        public string dataBase { get; set; }
        public string connectionString
        {
            get
            {
                return string.Format("DATA SOURCE =" + "{0}" + ":" + "{1}" +
                "/{2};PERSIST SECURITY INFO=True;USER ID=" + "{3}" + "; password= " +
                "{4}" + "; Pooling = False;",serverName, port , dataBase, userName, password);

            }

        }

    }
}
