using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class Bills
    {
        public int id { get; set; }
        public int externalId { get; set; }
        public Term term { get; set; }
        public string currency { get; set; }
        public Classification classification { get; set; }
        public Department department { get; set; }
        public Location location { get; set; }
        public Subsidiary subsidiary { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? transactionDate { get; set; }
        public string invoiceNumber { get; set; }
        public Amount amount { get; set; }
        public Balance balance { get; set; }
        public TotalTaxAmount totalTaxAmount { get; set; }
        public string memo { get; set; }
        public int poNumber { get; set; }
        public string state { get; set; }
        public Vendor vendor { get; set; }
        public List<Expens> expenses { get; set; }
        public List<Item> items { get; set; }
    }
}
