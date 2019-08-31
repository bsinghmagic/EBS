using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Cost
  {
        public DateTime? modified { get; set; }
        public DateTime? created { get; set; }       
        public int precision { get; set; }
        public string currency { get; set; }
        public decimal? amount { get; set; }
  }
}
