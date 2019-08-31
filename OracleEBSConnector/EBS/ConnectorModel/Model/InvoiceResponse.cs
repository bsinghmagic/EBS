using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
      
        public class InvoiceResponse
        {

            public DateTime modified { get; set; }
            public DateTime created { get; set; }
            public string id { get; set; }
            public int externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string parent { get; set; }
            public string state { get; set; }
            public string started { get; set; }
            public string ended { get; set; }
            public DateTime transactionDate { get; set; }
            public DateTime dueDate { get; set; }
            public string invoiceNumber { get; set; }
            public bool expenseReport { get; set; }
            public bool active { get; set; }
            public string dataSource { get; set; }
            public string poNumber { get; set; }
            public string popType { get; set; }
            public string currency { get; set; }
            public string status { get; set; }
            public string dimensions { get; set; }
            public Vendor1 vendor { get; set; }
            public Company1 company { get; set; }
            public Amount1 amount { get; set; }
            public Balance1 balance { get; set; }
            public TotalTaxAmount1 totalTaxAmount { get; set; }
            public string discountAmount { get; set; }
            public string appliedDiscountAmount { get; set; }
            public List<Item1> items { get; set; }
            public string expenses { get; set; }
            public string accountingPeriod { get; set; }
            public string apAccount { get; set; }
            public string classification { get; set; }
            public string department { get; set; }
            public string location { get; set; }
            public string subsidiary { get; set; }
            public Term1 term { get; set; }
            public string billCredits { get; set; }
            public string purchaseOrders { get; set; }
            public string appliedPaymentAmount { get; set; }
        }
        public class Vendor1
        {
            public DateTime? modified { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public int externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string legalName { get; set; }
            public string dBAName { get; set; }
            public string vendorType { get; set; }
            public string emails { get; set; }
            public string form1099Enabled { get; set; }
            public string active { get; set; }
            public string taxId { get; set; }
            public string vatNumber { get; set; }
            public string customerAccount { get; set; }
            public string remittanceEnabled { get; set; }
            public string remittanceEmails { get; set; }
            public string primaryCurrency { get; set; }
            public string currencies { get; set; }
            public string address { get; set; }
            public string phones { get; set; }
            public string parent { get; set; }
            public string defaultTerms { get; set; }
            public string defaultExpenseAccount { get; set; }
            public string defaultAPAccount { get; set; }
            public string fundingMethods { get; set; }
            public string primarySubsidiary { get; set; }
            public string subsidiaries { get; set; }
            public string vendorCompanyDefault { get; set; }
            public string company { get; set; }
        }

        public class Company1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public string externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string legalName { get; set; }
            public string dBAName { get; set; }
            public string vendorType { get; set; }
            public string emails { get; set; }
            public string externalParentId { get; set; }
            public string address { get; set; }
            public string phones { get; set; }
            public string parent { get; set; }
            public string subsidiaries { get; set; }
            public string paymentMethods { get; set; }
        }

        public class Amount1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public decimal amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class Balance1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public decimal amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class TotalTaxAmount1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class AmountDue1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class TaxRate1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class TaxAmount1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class NetAmount1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class GlAccount1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public string externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string accountNumber { get; set; }
            public string accountTypeLabel { get; set; }
            public string classRequired { get; set; }
            public string customerRequired { get; set; }
            public string departmentRequired { get; set; }
            public string employeeRequired { get; set; }
            public string itemRequired { get; set; }
            public string locationRequired { get; set; }
            public string projectRequired { get; set; }
            public string vendorRequired { get; set; }
            public string status { get; set; }
            public string ledgerType { get; set; }
            public string active { get; set; }
            public string accountBalance { get; set; }
            public string subsidiaries { get; set; }
            public string company { get; set; }
        }

        public class CompanyItem1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public int externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string active { get; set; }
            public string cost { get; set; }
            public string accounts { get; set; }
            public string residual { get; set; }
            public string amortization { get; set; }
            public string subsidiaries { get; set; }
            public string company { get; set; }
        }

        public class Cost1
        {
            public string modified { get; set; }
            public string created { get; set; }
            public int amount { get; set; }
            public int precision { get; set; }
            public string currency { get; set; }
        }

        public class Quantity1
        {
            public int value { get; set; }
            public int precision { get; set; }
            public string fieldOfMeasure { get; set; }
        }

        public class Item1
        {

            public Nullable<DateTime> modified { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public int externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string form1099Enabled { get; set; }
            public int lineNumber { get; set; }
            public bool billable { get; set; }
            public string closed { get; set; }
            public string poItemStatus { get; set; }
            public string dimensions { get; set; }
            public AmountDue amountDue { get; set; }
            public TaxRate taxRate { get; set; }
            public TaxAmount taxAmount { get; set; }
            public NetAmount netAmount { get; set; }
            public string vendor { get; set; }
            public GlAccount1 glAccount { get; set; }
            public string relatedPOExpenses { get; set; }
            public string amortization { get; set; }
            public string location { get; set; }
            public string department { get; set; }
            public string classification { get; set; }
            public string project { get; set; }
            public string purchaseOrder { get; set; }
            public string taxDetail { get; set; }
            public CompanyItem1 companyItem { get; set; }
            public Cost1 cost { get; set; }
            public Quantity1 quantity { get; set; }
            public string billedQuantity { get; set; }
            public string quantityReceived { get; set; }
        }

        public class Term1
        {
            public DateTime modified { get; set; }
            public DateTime created { get; set; }
            public string id { get; set; }
            public int externalId { get; set; }
            public string memo { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public bool active { get; set; }
            public int discountDays { get; set; }
            public int discountPercent { get; set; }
            public int discountAmount { get; set; }
            public int dueDays { get; set; }
            public string status { get; set; }
            public List<string> subsidiaries { get; set; }
            public string company { get; set; }
        }

}
