using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectorModel.Model;
namespace ODBCConnector.PopulateModul
{
    public static class PopulateModule
    {
        public static List<PurchaseOrder> PopulatePoModel(List<GetPurchaseOrderEntity> objectList)
        {
            List<PurchaseOrder> purchaseOrderList = new List<PurchaseOrder>();
            List<Item> itemList;
            List<int> poHeaderIdList = new List<int>();
            PurchaseOrder newPurchaseOrder;
            Item newItem;

            foreach (var purchaseOrder in objectList)
            {
                if (!poHeaderIdList.Contains(Convert.ToInt32(purchaseOrder.PO_HEADER_ID)))
                {
                    itemList = new List<Item>();
                    newPurchaseOrder = new PurchaseOrder();
                    //newPurchaseOrder.name = purchaseOrder.VENDOR_NAME;                    
                    newPurchaseOrder.externalId = Convert.ToInt32(purchaseOrder.PO_HEADER_ID);
                    poHeaderIdList.Add(Convert.ToInt32(purchaseOrder.PO_HEADER_ID));
                    newPurchaseOrder.lineNo = Convert.ToInt32(purchaseOrder.LINE_NUM);
                    newPurchaseOrder.dueDate = purchaseOrder.NEED_BY_DATE==null?DateTime.Now:purchaseOrder.NEED_BY_DATE;
                    newPurchaseOrder.poNumber = purchaseOrder.PO_NUM; // purchaseOrder.SEGMENT1;
                    newPurchaseOrder.poType = purchaseOrder.PO_TYPE; //PO_TYPE
                    newPurchaseOrder.created = purchaseOrder.CREATION_DATE;
                    newPurchaseOrder.vendor = new Vendor { name = purchaseOrder.VENDOR_NAME, externalId = Convert.ToInt32(purchaseOrder.VENDOR_ID) };
                    newPurchaseOrder.state = "New";
                    List<GetPurchaseOrderEntity> listItem = objectList.Where(x => x.SEGMENT1 == purchaseOrder.SEGMENT1 && x.LINE_NUM != null
                    && x.PO_HEADER_ID == purchaseOrder.PO_HEADER_ID).ToList();
                    foreach (var perItem in listItem)
                    {
                        //new Item { externalId = Convert.ToInt32(perItem.ITEM_ID) }
                        if (itemList.Where(x => x.externalId == perItem.ITEM_ID).ToList().Count == 0)
                        {

                            newItem = new Item();
                            newItem.externalId = Convert.ToInt32(perItem.ITEM_ID);
                            newItem.name = perItem.ITEM_NAME;
                            newItem.quantity = new Quantity { value = perItem.QUANTITY == null ? 0 : perItem.QUANTITY, fieldOfMeasure = "", precision = 1 };
                            //newItem.quantityReceived = new QuantityReceived { value = perItem.QUANTITY_RECEIVED == null ? 0 : perItem.QUANTITY_RECEIVED, fieldOfMeasure = "", precision = 1 };
                            //newItem.billedQuantity = new BilledQuantity { value = perItem.QUANTITY_BILLED == null ? 0 : perItem.QUANTITY_BILLED, fieldOfMeasure = "", precision = 1 };
                            newItem.cost = new Cost { amount = perItem.ITEM_AMOUNT, precision = 2 };
                            // newItem.amountDue = new AmountDue { amount = perItem.ITEM_AMOUNT, created = perItem.CREATION_DATE, precision = 2 };
                            newItem.lineNumber = Convert.ToInt32(perItem.LINE_NUM);
                            newItem.closed = true;
                            newItem.description = perItem.ITEM_DESCRIPTION;
                            newItem.poItemStatus = "New";

                            List<GetPurchaseOrderEntity> lineItemsWithDiffLocation = listItem.Where(x => x.PO_LINE_ID == perItem.PO_LINE_ID).ToList();
                            decimal? QUANTITY_RECEIVED = 0, QUANTITY_BILLED = 0;
                            foreach (var perlocation in lineItemsWithDiffLocation)
                            {
                                QUANTITY_RECEIVED = QUANTITY_RECEIVED + (perlocation.QUANTITY_RECEIVED == null ? 0 : perlocation.QUANTITY_RECEIVED);
                                QUANTITY_BILLED = QUANTITY_BILLED + (perlocation.QUANTITY_BILLED == null ? 0 : perlocation.QUANTITY_BILLED);
                                

                            }
                            newItem.quantityReceived = new QuantityReceived { value = QUANTITY_RECEIVED, fieldOfMeasure = "", precision = 1 };
                            newItem.billedQuantity = new BilledQuantity { value = QUANTITY_BILLED, fieldOfMeasure = "", precision = 1 };

                            //newItem.netAmount = new NetAmount { amount = perItem.CostAmount };
                            //newItem.taxAmount = new TaxAmount { amount = perItem.AMOUNT_RECEIVED };
                            //newItem.purchaseOrder = perItem.SEGMENT1;                     

                            itemList.Add(newItem);
                        }
                    }
                    newPurchaseOrder.items = itemList;
                    purchaseOrderList.Add(newPurchaseOrder);
                }
            }
            return purchaseOrderList;
        }


        public static List<Invoice> PopulateInvoiceModel(List<GetInvoicEntity> objectList)
        {
            List<Invoice> InvoiceList = new List<Invoice>();
            Invoice invoiceObj;
            List<Item> items;
            Item newVal;
            foreach (var invoice in objectList)
            {


                //if (invoice.LINE_NUMBER == 1)//&& purchaseOrder.LINE_NUM != null
                //{
                invoiceObj = new Invoice();
                invoiceObj.bill = new Bills();
                items = new List<Item>();
                invoiceObj.bill.externalId = Convert.ToInt32(invoice.BILL_ID);
                //bill.AMOUNT = item.INVOICE_AMOUNT;
                // bill.CREATION_DATE = item.INVOICE_DATE;
                invoiceObj.bill.memo = invoice.DESCRIPTION;
                invoiceObj.bill.poNumber = invoice.PONUMBER;
                invoiceObj.bill.vendor = new Vendor { externalId = Convert.ToInt32(invoice.VENDOR_ID) };
                invoiceObj.bill.totalTaxAmount = new TotalTaxAmount { amount = invoice.TOTAL_TAX_AMOUNT };
                invoiceObj.bill.balance = new Balance { amount = invoice.BALANCE, precision = 2 };
                invoiceObj.bill.amount = new Amount { amount = invoice.INVOICE_AMOUNT };
                invoiceObj.bill.term = new Term { externalId = invoice.TERMS_ID };
                invoiceObj.bill.currency = invoice.INVOICE_CURRENCY_CODE;
                invoiceObj.bill.dueDate = invoice.DUE_DATE;
                invoiceObj.bill.transactionDate = invoice.TRANSACTION_DATE;
                invoiceObj.bill.invoiceNumber = invoice.INVOICE_NUM;
                List<GetInvoicEntity> listItem = objectList.Where(x => x.BILL_ID == invoice.BILL_ID).ToList();
                foreach (var item in listItem)
                {
                    newVal = new Item();
                    newVal.externalId = Convert.ToInt32(item.INVENTORY_ITEM_ID);
                    newVal.name = item.ITEM_DESCRIPTION;
                    newVal.quantity = new Quantity { value = item.ITEM_QUANTITY, precision = 2 };
                    newVal.taxRate = new TaxRate { amount = item.TAX_RATE };
                    newVal.lineNumber = Convert.ToInt32(item.LINE_NUMBER);
                    newVal.cost = new Cost { amount = item.COST_AMOUNT, precision = 2 };
                    //newVal.taxAmount = new TaxAmount { amount = item.TOTAL_TAX_AMOUNT };
                    newVal.netAmount = new NetAmount { amount = item.NETAMOUNT };
                    items.Add(newVal);
                }

                invoiceObj.purchaseOrders = new List<PurchaseOrder> { new PurchaseOrder { externalId =
                    Convert.ToInt32(invoice.PO_HEADER_ID) } };

                invoiceObj.bill.items = items;
                //invoiceObj.bill = bill;
                InvoiceList.Add(invoiceObj);
                // }
            }
            return InvoiceList;
        }



        /* public static List<Invoice> PopulateInvoiceModel(List<GetInvoicEntity> objectList)
         {
             List<Invoice> InvoiceList = new List<Invoice>();
             Invoice invoiceObj = new Invoice();
             Bills bill = new Bills();
             List<Item> items = new List<Item>();
             Item newVal = new Item();
             foreach (var item in objectList)
             {
                 bill.id = item.INVOICE_ID;
                 //bill.AMOUNT = item.INVOICE_AMOUNT;
                 // bill.CREATION_DATE = item.INVOICE_DATE;
                 bill.memo = item.DESCRIPTION;
                 bill.poNumber = item.PO_NUMBER;
                 bill.vendor = new Vendor { externalId = Convert.ToInt32(item.PARTY_ID) };
                 bill.totalTaxAmount = new TotalTaxAmount { amount = item.TOTAL_TAX_AMOUNT };
                 bill.balance = new Balance { };
                 bill.amount = new Amount { amount = item.AMOUNT };
                 bill.term = new Term { externalId = item.TERMS_ID };
                 bill.currency = item.INVOICE_CURRENCY_CODE;
                 bill.dueDate = item.DUE_DATE;
                 bill.transactionDate = item.INVOICE_DATE;
                 bill.invoiceNumber = item.INVOICE_NUM;
                 List<GetInvoicEntity> listItem = objectList.Where(x => x.INVOICE_ID == item.INVOICE_ID).ToList();
                 foreach (var getItem in listItem)
                 {
                     newVal.externalId =  Convert.ToInt32(getItem.INVENTORY_ITEM_ID);
                     newVal.name = getItem.DESCRIPTION;
                     newVal.taxRate = new TaxRate { amount = getItem.TAX_RATE };
                     newVal.lineNumber = getItem.LINE_NUMBER;
                     newVal.cost = new Cost { amount = getItem.UNIT_PRICE };
                     newVal.taxAmount = new TaxAmount { amount = getItem.TOTAL_TAX_AMOUNT };
                     newVal.netAmount = new NetAmount { amount = getItem.AMOUNT };
                     items.Add(newVal);
                 }
                 bill.items = items;
                 invoiceObj.bill = bill;
                 InvoiceList.Add(invoiceObj);
             }
             return InvoiceList;
         }*/
        public static List<Payment> PopulatePaymentModel(List<GetPaymentEntity> objectList)
        {
            List<Payment> paymentList = new List<Payment>();
            Payment payment = new Payment();
            List<Bill> bills = new List<Bill>();
            Bill bill = new Bill();
            foreach (var item in objectList)
            {
                payment.paymentMethod = new PaymentMethod { id = item.PAYMENT_ID };
                payment.fundMethod = new FundMethod { type = item.FUNDMETHOD.ToString() };
                bill = new Bill { id = item.INVOICE_ID, appliedPaymentAmount = new AppliedPaymentAmount { amount = item.AppliedPaymentAmount } };
                bills.Add(bill);
                payment.bills = bills;
                payment.checkNumber = item.CHECK_NUMBER.ToString();
                paymentList.Add(payment);
            }
            return paymentList;
        }

    }
}
