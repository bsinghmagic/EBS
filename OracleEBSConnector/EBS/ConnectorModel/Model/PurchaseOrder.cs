using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorModel.Model
{
    public class PurchaseOrder
    {
        public Department department { get; set; }
        public Classification classification { get; set; }
        public Location location { get; set; }
        public Expens expenses { get; set; }
        public List<Item> items { get; set; }
        public Term terms { get; set; }
        public string subsidiary { get; set; }
        public string company { get; set; }
        public Vendor vendor { get; set; }
        public object dimensions { get; set; }
        public int? lineNo { get; set; }
        public bool active { get; set; }
        public string poType { get; set; }
        public string state { get; set; }
        public string term { get; set; }
        public DateTime? dueDate { get; set; }
        public string poNumber { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string memo { get; set; }
        public int externalId { get; set; }
        public string id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

    }
    public class GetPurchaseOrderEntity
    {        
        public string SEGMENT1{ get; set; }
        public string PO_NUM { get; set; }
        public string AUTHORIZATION_STATUS { get; set; }
        public string LINE_LOCATION_DESCP { get; set; }
        public decimal PO_HEADER_ID { get; set; }
        public decimal TERMS_ID { get; set; }
        public string TYPE_LOOKUP_CODE { get; set; }
        public string PO_TYPE { get; set; }
        public decimal? LINE_NUM { get; set; }
        public decimal? ITEM_ID { get; set; }
        public String ITEM_DESCRIPTION { get; set; }
        public String ITEM_NAME { get; set; }
        public string LINE_LOCATION_ID { get; set; }
        public string CLOSED_FLAG { get; set; }
        public string CLOSED_DATE { get; set; }
        public decimal? QUANTITY { get; set; }
        public decimal? QUANTITY_RECEIVED { get; set; }
        public decimal? QUANTITY_BILLED { get; set; }
        public decimal? ITEM_AMOUNT { get; set; }       
        public decimal? AMOUNT_RECEIVED { get; set; }
        public decimal? AMOUNT_BILLED { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal VENDOR_ID { get; set; }
        public string VENDOR_NAME { get; set; }
        public decimal? CostAmount { get; set; }
        public DateTime? NEED_BY_DATE { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public DateTime? CREATION_DATE { get; set; }
        public decimal? AMOUNT { get; set; }
        public decimal PO_LINE_ID { get; set; }
        public decimal? LIST_PRICE_PER_UNIT { get; set; }
    }
}