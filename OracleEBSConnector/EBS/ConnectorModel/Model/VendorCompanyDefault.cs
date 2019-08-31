using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class VendorCompanyDefault
  {
    public string defaultTaxComponentId { get; set; }
    public string defaultPaymentChannelCode { get; set; }
    public string defaultExpenseAccountId { get; set; }
    public string defaultAPAccountId { get; set; }
    public string defaultDebitAccountId { get; set; }
    public string defaultTermsId { get; set; }
    public string defaultProjectId { get; set; }
    public string defaultLocationId { get; set; }
    public string defaultItemId { get; set; }
    public string defaultEmployeeId { get; set; }
    public string defaultDepartmentId { get; set; }
    public string defaultCustomerId { get; set; }
    public string defaultClassId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string memo { get; set; }
     public int? externalId { get; set; }
    public string id { get; set; }
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; }
  }
}
