using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
  public class GLAccount
  {
    public Company company { get; set; }
    public object subsidiaries { get; set; }
    public object accountBalance { get; set; }
    public bool active { get; set; }
    public string ledgerType { get; set; }
    public string status { get; set; }
    public bool vendorRequired { get; set; }
    public bool projectRequired { get; set; }
    public bool locationRequired { get; set; }
    public bool itemRequired { get; set; }
    public bool employeeRequired { get; set; }
    public bool departmentRequired { get; set; }
    public bool customerRequired { get; set; }
    public bool classRequired { get; set; }
    public object accountTypeLabel { get; set; }
    public string accountNumber { get; set; }
    public string name { get; set; }
    public object description { get; set; }
    public object memo { get; set; }
     public string externalId { get; set; }
    public int id { get; set; }
    public DateTime created { get; set; }
    public DateTime modified { get; set; }
  }
}
