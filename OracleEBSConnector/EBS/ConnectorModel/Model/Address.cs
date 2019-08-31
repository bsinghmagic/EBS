using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
  public class Address
  {
    public string country { get; set; }
    public string ctrySubDivision { get; set; }
    public string town { get; set; }
    public string postalCode { get; set; }
    public string address5 { get; set; }
    public string address4 { get; set; }
    public string address3 { get; set; }
    public string address2 { get; set; }
    public string address1 { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string memo { get; set; }
    public string externalId { get; set; }
    public int? id { get; set; }
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; }
  }
}
