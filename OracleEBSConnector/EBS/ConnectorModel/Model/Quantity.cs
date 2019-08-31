using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Quantity
  {
    public string fieldOfMeasure { get; set; }
    public int precision { get; set; }
    public decimal? value { get; set; }
  }
}
