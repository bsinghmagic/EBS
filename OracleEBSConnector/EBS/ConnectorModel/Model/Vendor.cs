using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Vendor
  {
    public string company { get; set; } 
    public VendorCompanyDefault vendorCompanyDefault { get; set; }
    public string subsidiaries { get; set; } 
    public PrimarySubsidiary primarySubsidiary { get; set; } 
    public string fundingMethods { get; set; } 
    public string defaultAPAccount { get; set; } 
    public string defaultExpenseAccount { get; set; } 
    public string defaultTerms { get; set; } 
    public string parent { get; set; } 
    public List<Phone> phones { get; set; } 
    public Address address { get; set; } 
    public string currencies { get; set; } 
    public string primaryCurrency { get; set; } 
    public List<string> remittanceEmails { get; set; } 
    public bool? remittanceEnabled { get; set; } = false;
    public string customerAccount { get; set; } 
    public string vatNumber { get; set; } 
    public string taxId { get; set; } 
    public bool? active { get; set; } = false;
    public bool? form1099Enabled { get; set; } = false;
    public List<string> emails { get; set; } 
    public string vendorType { get; set; } 
    public string dBAName { get; set; } 
    public string legalName { get; set; } 
    public string name { get; set; } 
    public string description { get; set; } 
    public string memo { get; set; } 
    public int externalId { get; set; } 
    public string id { get; set; } 
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; } = DateTime.Now;
  }

}
