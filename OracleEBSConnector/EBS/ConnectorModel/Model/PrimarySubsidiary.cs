using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class PrimarySubsidiary
    {
        public string paymentMethods { get; set; }
        public string subsidiaries { get; set; }
        public string parent { get; set; }
        public string phones { get; set; }
        public string address { get; set; }
        public int? externalParentId { get; set; }
        public string emails { get; set; }
        public string vendorType { get; set; }
        public string dBAName { get; set; }
        public string legalName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string memo { get; set; }
        public int? externalId { get; set; }
        public string id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
    }
}
