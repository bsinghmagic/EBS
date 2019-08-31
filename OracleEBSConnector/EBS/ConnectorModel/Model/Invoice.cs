using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class Invoice 
    {
        
            public Bills bill { get; set; }
            public List<PurchaseOrder> purchaseOrders { get; set; }
       
    }
      
}
