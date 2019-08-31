using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class Expens
    {
        public Classification classification { get; set; }
        public Department department { get; set; }
        public Location location { get; set; }
        public GLAccount glAccount { get; set; }
        public TaxRate taxRate { get; set; }
        public TaxAmount taxAmount { get; set; }
        public NetAmount netAmount { get; set; }
        public AmountDue amountDue { get; set; }
        public string lineNumber { get; set; }
        public bool closed { get; set; }
        public string memo { get; set; }
    }
}
