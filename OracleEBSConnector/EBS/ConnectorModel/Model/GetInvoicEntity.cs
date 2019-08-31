using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class GetInvoicEntity
    {
        public decimal BILL_ID { get; set; }
        public int TERMS_ID { get; set; }
        public string INVOICE_CURRENCY_CODE { get; set; }
        public DateTime? TRANSACTION_DATE { get; set; }
        public string INVOICE_NUM { get; set; }
        public decimal? INVOICE_AMOUNT { get; set; }
        public decimal? BALANCE { get; set; }
        public decimal? TOTAL_TAX_AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public int PONUMBER { get; set; }
        public int VENDOR_ID { get; set; }
        public decimal? INVENTORY_ITEM_ID { get; set; }
        public decimal? ITEM_QUANTITY { get; set; }
        public decimal? COST_AMOUNT { get; set; }
        public decimal? TAX_RATE { get; set; }
        public string TAX_CODE { get; set; }
        public decimal? LINE_NUMBER { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public string LINE_TYPE_LOOKUP_CODE { get; set; }
        public decimal? NETAMOUNT { get; set; }
        public decimal? PO_HEADER_ID { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime INVOICE_DATE { get; set; }
        public decimal PARTY_ID { get; set; }
        public int INVOICE_ID { get; set; }
        public int? PA_QUANTITY { get; set; }
        public decimal? UNIT_PRICE { get; set; }
        public string HISTORICAL_FLAG { get; set; }
        public decimal? AMOUNT { get; set; }
        public string VENDOR_NAME { get; set; }
        public string VENDOR_TYPE { get; set; }
        public string VENDOR_SITE { get; set; }
        public string PAY_GROUP { get; set; }
        public string INV_TYPE { get; set; }
        public string VOUCHER { get; set; }
        public DateTime CREATION_DATE { get; set; }
    }
}
