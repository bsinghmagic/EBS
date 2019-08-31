using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class CompanyItem
  {
    public string company { get; set; }
    public string subsidiaries { get; set; }
    public object amortization { get; set; }
    public object residual { get; set; }
    public object accounts { get; set; }
    public object cost { get; set; }
    public bool? active { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string memo { get; set; }
    public int externalId { get; set; }
    public string id { get; set; }
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; }
  }
}
