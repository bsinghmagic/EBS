using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Phone
  {
    public bool fax { get; set; } 
    public string countryCode { get; set; } 
    public string number { get; set; }
    public string location { get; set; } 
    public string name { get; set; } 
     public int? externalId { get; set; }
    public string id { get; set; } 
    public DateTime? created { get; set; }
     public DateTime? modified { get; set; } 
  }
}
