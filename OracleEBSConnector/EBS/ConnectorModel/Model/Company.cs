using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Company
  {
    public object paymentMethods { get; set; }
    public object subsidiaries { get; set; }
    public object parent { get; set; }
    public List<Phone> phones { get; set; }
    public Address address { get; set; }
    public object externalParentId { get; set; }
    public object emails { get; set; }
    public object vendorType { get; set; }
    public string dBAName { get; set; }
    public object legalName { get; set; }
    public string name { get; set; }
    public object description { get; set; }
    public object memo { get; set; }
    public string externalId { get; set; }
    public int id { get; set; }
    public DateTime created { get; set; }
    public DateTime modified { get; set; }
  }
}
