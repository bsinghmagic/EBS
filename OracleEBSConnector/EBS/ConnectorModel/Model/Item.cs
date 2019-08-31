using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Item
  {  
        public QuantityReceived quantityReceived { get; set; }
        public BilledQuantity billedQuantity { get; set; }
        public Quantity quantity { get; set; }
        public Cost cost { get; set; }
        public CompanyItem companyItem { get; set; }
        public object taxDetail { get; set; }
        public object purchaseOrder { get; set; }
        public object project { get; set; }
        public Classification classification { get; set; }
        public Department department { get; set; }
        public Location location { get; set; }
        public object amortization { get; set; }
        public object relatedPOExpenses { get; set; }
        public GLAccount glAccount { get; set; }
        public Vendor vendor { get; set; }
        public NetAmount netAmount { get; set; }
        public TaxAmount taxAmount { get; set; }
        public TaxRate taxRate { get; set; }
        public AmountDue amountDue { get; set; }
        public string dimensions { get; set; }
        public string poItemStatus { get; set; }
        public bool? closed { get; set; }
        public bool? billable { get; set; }
        public decimal lineNumber { get; set; }    //// ail.LINE_NUMBER
        public string form1099Enabled { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string memo { get; set; }
        public int? externalId { get; set; }
        public string id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

    }
     
}
