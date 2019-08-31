using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
 public class Payment
  {
    public PaymentMethod paymentMethod { get; set; }
    public FundMethod fundMethod { get; set; }
    public List<Bill> bills { get; set; }
    public Amount amount { get; set; }
    public AccountingPeriod accountingPeriod { get; set; }
    public string transactionDate { get; set; }
     public string externalId { get; set; }
    public string checkNumber { get; set; }
    public string sequenceText { get; set; }
  }
  public class PaymentMethod
  {
    public int id { get; set; }
  }

  public class FundMethod
  {
    public string type { get; set; }
  }

  public class AppliedPaymentAmount
  {
    public decimal amount { get; set; }
  }

  public class Bill
  {
    public int id { get; set; }
    public AppliedPaymentAmount appliedPaymentAmount { get; set; }
  }

 

  public class AccountingPeriod
  {
    public int id { get; set; }
  }
    public class GetPaymentEntity
    {

        public int PAYMENT_ID { get; set; }
        public string FUNDMETHOD { get; set; }
        public double AMOUNT { get; set; }
        public DateTime? TRANSACTION_DATE { get; set; }
        public DateTime ACCOUNTING_DATE { get; set; }
        public string ACCOUNTING_PERIOD { get; set; }
        public int INVOICE_ID { get; set; }
        public decimal AppliedPaymentAmount { get; set; }
        public int CHECK_NUMBER { get; set; }
    }
}
