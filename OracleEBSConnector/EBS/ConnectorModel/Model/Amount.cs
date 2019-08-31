using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Amount
  {
    public string currency { get; set; }
    public string precision { get; set; }
    public decimal? amount { get; set; }
    public DateTime created { get; set; }
     public DateTime modified { get; set; }
  }
}
