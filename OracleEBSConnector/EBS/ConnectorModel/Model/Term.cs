using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
  public class Term
  {
    public Company company { get; set; }
    public List<object> subsidiaries { get; set; }
    public string status { get; set; }
    public int dueDays { get; set; }
    public object discountAmount { get; set; }
    public int discountPercent { get; set; }
    public int discountDays { get; set; }
    public bool active { get; set; }
    public string name { get; set; }
    public object description { get; set; }
    public object memo { get; set; }
    public int externalId { get; set; }
    public string id { get; set; }
    public DateTime created { get; set; }
    public DateTime modified { get; set; }
  }
}
