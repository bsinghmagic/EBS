using ConnectorModel.Model;
using EBS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using WebClientUtility.Core;
using log4net;
using log4net.Config;

namespace ConnectorLib.API
{
  /// <summary>
  /// ConnectorApi
  /// </summary>
  public class ConnectorApi:IDisposable
  {

        private readonly string actionSource;

        public static readonly log4net.ILog Log = LogManager.GetLogger(typeof(ConnectorApi));
        private static string connectionString { get; set; }

        public ConnectorApi()
        {
        }

        public ConnectorApi(string actionSource)
        {
          this.actionSource = actionSource;
        }

        public void ConnectorConfig(string connectionString) {
            ConnectorApi.connectionString = connectionString;
        }

        public async void UpdateVendor(Vendor vendor)
        {
  
            // foreach (var vendor in vendors)
            //{

            string command1 = "" +
            "Update apps.AP_SUPPLIERS SET VENDOR_NAME='" + vendor.name + "', VENDOR_TYPE_LOOKUP_CODE='" + vendor.vendorType + "' " +
                "Where VENDOR_ID ='" + vendor.externalId + "'";
            var returndata1 = await ODBCDataAccess.GetResultNonQuery(connectionString, command1);
           await ODBCDataAccess.GetResultNonQuery(connectionString, "commit");           
            if (returndata1.Equals("true"))
            {

                string command2 = "select * FROM apps.AP_SUPPLIER_SITES_ALL Where VENDOR_ID = '" + vendor.externalId + "'";
                var returndata2 = await ODBCDataAccess.GetResult(connectionString, command2);
                if (returndata2.Count >= 1)
                {
                    //Vendor Site Exist
                    string command3 = "" + "Update apps.AP_SUPPLIER_SITES_ALL SET VENDOR_SITE_CODE ='" + vendor.address.name + "', ADDRESS_LINE1 ='" + vendor.address.address1 +
               "', ADDRESS_LINE2 ='" + vendor.address.address2 + "', ADDRESS_LINE3 ='" + vendor.address.address3 + "' ," +
               "ADDRESS_LINE4 ='" + vendor.address.address4 + "', CITY ='" + vendor.address.town + "', STATE ='" + vendor.address.ctrySubDivision +
               "', ZIP = '" + vendor.address.postalCode + "' ,COUNTRY ='" + vendor.address.country + "', " +
               "VAT_REGISTRATION_NUM = '" + vendor.vatNumber + "', VAT_CODE = '" + vendor.taxId + "' " +
               "Where VENDOR_ID ='" + vendor.externalId + "'";
                    var returndata3 = await ODBCDataAccess.GetResultNonQuery(connectionString, command3);
                    await ODBCDataAccess.GetResultNonQuery(connectionString, "commit");
                }
                else
                {
                    string command3 = "Select CREATED_BY from AP.AP_SUPPLIERS Where VENDOR_ID='" + vendor.externalId + "'";
                    var returndata3 = await ODBCDataAccess.GetResult(connectionString, command3);
                    var CREATED_BY = returndata3[0].Substring(returndata3[0].IndexOf(":") + 1, ((returndata3[0].IndexOf(".") - 1) - returndata3[0].IndexOf(":")));

                    string command4 = "Select max(VENDOR_SITE_ID) from apps.AP_SUPPLIER_SITES_ALL";
                    var returndata4 = await ODBCDataAccess.GetResult(connectionString, command4);
                    
                    var LAST_VENDOR_SITE_ID = returndata4[0].Substring(returndata4[0].IndexOf(":") + 1, ((returndata4[0].IndexOf(".") - 1) - returndata4[0].IndexOf(":")));
                    int new_LAST_VENDOR_SITE_ID = Convert.ToInt32(LAST_VENDOR_SITE_ID) + 1;             

                    string command5 = "Insert into apps.AP_SUPPLIER_SITES_ALL (VENDOR_SITE_ID, LAST_UPDATE_DATE,LAST_UPDATED_BY, CREATED_BY, CREATION_DATE, VENDOR_SITE_CODE , ADDRESS_LINE1 , ADDRESS_LINE2 ,ADDRESS_LINE3 ,ADDRESS_LINE4 , CITY, STATE, ZIP  " +
                        " ,COUNTRY , VAT_REGISTRATION_NUM ,VAT_CODE ,VENDOR_ID) VALUES ('" + new_LAST_VENDOR_SITE_ID + "',TO_CHAR(SYSDATE , 'DD-MON-YYYY'),"
                        + CREATED_BY + ","  + CREATED_BY + "," + "TO_CHAR(SYSDATE , 'DD-MON-YYYY'),' " + vendor.address.name + "','" + vendor.address.address1 + "','" + vendor.address.address2 + "','" + vendor.address.address3
                        + "','" + vendor.address.address4 + "','" + vendor.address.town + "','" + vendor.address.ctrySubDivision
                        + "','" + vendor.address.postalCode + "','" + vendor.address.country + "','" + vendor.vatNumber + "','" +
                        vendor.taxId + "','" + vendor.externalId + "')";
                    var returndata5 = await ODBCDataAccess.GetResult(connectionString, command5);
                    await ODBCDataAccess.GetResultNonQuery(connectionString, "commit");
                }
            }
       
           // }
        }

        public async void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                StringBuilder command1 = new StringBuilder();
                command1.AppendLine(@" UPDATE apps.PO_HEADERS_ALL set SEGMENT1 ='" + purchaseOrder.poNumber + "', " +
                    "TYPE_LOOKUP_CODE ='" + purchaseOrder.poType + "' WHERE PO_HEADER_ID ='" + purchaseOrder.externalId + "'");

                var returndata1 = await ODBCDataAccess.GetResultNonQuery(connectionString, command1.ToString());
                await ODBCDataAccess.GetResultNonQuery(connectionString, "commit");
               
                if (returndata1.Equals("true"))
                {
                    //List<Item> listItem = purchaseOrder.items.Where(x => x.id == purchaseOrder.id).ToList();
                    foreach (Item itm in purchaseOrder.items)
                    {
                        StringBuilder command2 = new StringBuilder();
                        command2.AppendLine(@"Select PO_LINE_ID from apps.PO_LINES_ALL WHERE PO_HEADER_ID ='" +
                            purchaseOrder.externalId + "' and LINE_NUM ='" + itm.lineNumber + "'");
                        var returndata2 = await ODBCDataAccess.GetResult(connectionString, command2.ToString());
                        var PO_LINE_ID = returndata2[0].Substring(returndata2[0].IndexOf(":") + 1, ((returndata2[0].IndexOf(".") - 1) - returndata2[0].IndexOf(":")));
                        
                        StringBuilder command3 = new StringBuilder();
                        command3.AppendLine(@"UPDATE apps.PO_LINES_ALL set ITEM_ID = '" + itm.externalId +
                              "', LINE_NUM ='" + itm.lineNumber + "', ITEM_DESCRIPTION = '"+ itm.description+"', " +
                              "LIST_PRICE_PER_UNIT = '"+ itm.cost.amount +"' WHERE PO_HEADER_ID ='" + purchaseOrder.externalId +
                              "' and LINE_NUM ='" + itm.lineNumber + "'");
                        var returndata3 = await ODBCDataAccess.GetResultNonQuery(connectionString, command3.ToString());               

                        StringBuilder command4 = new StringBuilder();
                        command4.AppendLine(@" UPDATE apps.PO_LINE_LOCATIONS_ALL SET CLOSED_FLAG = '', QUANTITY ='" + itm.quantity.value +
                            "', AMOUNT_RECEIVED ='', AMOUNT_BILLED ='" + itm.netAmount + "'," +
                            " DESCRIPTION ='" + purchaseOrder.description + "' WHERE PO_HEADER_ID ='" + purchaseOrder.externalId +
                            "' and  PO_LINE_ID = '"+ PO_LINE_ID + "' ");
                        var returndata4 = await ODBCDataAccess.GetResultNonQuery(connectionString, command4.ToString());
                        await ODBCDataAccess.GetResultNonQuery(connectionString, "commit");                        
                    }

                }
            }catch(Exception ex) {

                Log.Info(string.Format("PO MT to EBS Exception ", ex));
            }

        }

        //public async void UpdateVendorIntoEBSFromMT(Vendor customer)
        //{
        
        //    StringBuilder ParametersToUpdateWithValue = new StringBuilder();

        //    ParametersToUpdateWithValue.Append(" " + "PARTY_NAME='" + customer.Name + "',");
        //    ParametersToUpdateWithValue.Append(" " + "ADDRESS1='" + customer.PurchaseOrdersContact.address.Address1 + "',");
        //    ParametersToUpdateWithValue.Append(" " + "ADDRESS2='" + customer.PurchaseOrdersContact.address.Address2 + "',");
        //    ParametersToUpdateWithValue.Append(" " + "POSTAL_CODE='" + customer.PurchaseOrdersContact.address.Zip + "',");
        //    ParametersToUpdateWithValue.Append(" " + "CITY='" + customer.PurchaseOrdersContact.address.City + "',");
        //    ParametersToUpdateWithValue.Append(" " + "STATE='" + customer.PurchaseOrdersContact.address.State + "',");
        //    ParametersToUpdateWithValue.Append(" " + "COUNTRY='" + customer.PurchaseOrdersContact.address.Country + "',");

        //    StringBuilder concatenatedAreaCode = new StringBuilder();
        //    StringBuilder concatenatedPhone = new StringBuilder();

        //    foreach (var item in customer.PhoneNumbers)
        //    {
        //        concatenatedAreaCode.Append(item.Key);
        //        concatenatedPhone.Append(item.Number);
        //    }
        //    ParametersToUpdateWithValue.Append(" " + "EMAIL_ADDRESS='" + customer.Email + "',");
        //    ParametersToUpdateWithValue.Append(" " + "PRIMARY_PHONE_AREA_CODE='" + concatenatedAreaCode + "',");
        //    ParametersToUpdateWithValue.Append(" " + "PRIMARY_PHONE_NUMBER='" + concatenatedPhone + "',");
        //    ParametersToUpdateWithValue.Append(" " + "TAX_REFERENCE='" + customer.TaxIDNumber + "',");
        //    //ParametersToUpdateWithValue.Append(" " + "TAX_NAME='" + customer.taxId + "'");

        //    string command = "Update apps.HZ_PARTIES SET" + ParametersToUpdateWithValue + "where Party_id='" + customer.ExternalId + "'";
        //    var returndata = await ODBCDataAccess.GetResultNonQuery(connectionString, command);

        //}





        //public async void UpsertInvoiceIntoEBSFromMT(InvoiceResponse invoice)
        //{

        //    //foreach (InvoiceResponce invoice in invoiceResponce)
        //    //{
        //    string DESCRIPTION = invoice.memo; //varchar
        //    int TERMS_ID = invoice.term.externalId;  //number
        //    //int num_TERMS_ID = Convert.ToInt32(TERMS_ID);
        //    int? INVOICE_ID = invoice.externalId;  //number
        //    //int num_INVOICE_ID = Convert.ToInt32(INVOICE_ID);

        //    string INVOICE_NUM = invoice.invoiceNumber; //varchar
        //    DateTime INVOICE_DATE = invoice.transactionDate; //DateTime
        //    decimal TOTAL_TAX_AMOUNT = invoice.totalTaxAmount.amount;  //number
        //    int VENDOR_ID = invoice.vendor.externalId;  //number
        //    //int num_VENDOR_ID = Convert.ToInt32(VENDOR_ID);

        //    /*----------------needed fields but not coming  from mt-----------*/
        //    string PAY_GROUP_LOOKUP_CODE = "";   //varchar
        //    string INVOICE_TYPE_LOOKUP_CODE = "";  //varchar
        //    int DOC_SEQUENCE_VALUE = 0;  //number

        //    decimal INVOICE_AMOUNT = 0;   //number  //present in item

        //    DateTime TERMS_DATE = DateTime.Now;  //Date
        //    DateTime LAST_UPDATE_DATE = DateTime.Now;   //Date
        //    int LAST_UPDATED_BY = 0;  //number
        //    int SET_OF_BOOKS_ID = 0;   //number
        //    string INVOICE_CURRENCY_CODE = "";//varchar
        //    string PAYMENT_CURRENCY_CODE = "";   //varchar
        //    decimal PAYMENT_CROSS_RATE = 0;  //number
        //    DateTime GL_DATE = DateTime.Now; //Date
        //    string APPROVAL_READY_FLAG = ""; //varchar
        //    string WFAPPROVAL_STATUS = ""; //varchar
        //                                   /* ----------------needed fields but not coming from mt -----------*/

        //    /*----------------extra fields coming  from mt-----------*/
        //    string SEGMENT1 = invoice.poNumber;  //varchar
        //    DateTime DUE_DATE = invoice.dueDate; //Date
        //    int? external_id = invoice.externalId;  //number
        //    string vendor_type_lookup_code = invoice.vendor.vendorType;  //varchar
        //                                                                 ///string VENDOR_NAME = invoice.vendor.name; //varchar needed in item
        //    decimal BALANCE_AMOUNT = invoice.balance.amount;   //number         
        //    //string VENDOR_NAME = invoice.company.name;
        //    /*----------------extra fields coming  from mt-----------*/


        //    string command_AP_INVOICES_ALL = "Insert into apps.AP_INVOICES_ALL(" +
        //        "DESCRIPTION, TERMS_ID, INVOICE_ID," + "INVOICE_NUM, PAY_GROUP_LOOKUP_CODE, " +
        //        "INVOICE_DATE, INVOICE_TYPE_LOOKUP_CODE," + "DOC_SEQUENCE_VALUE, INVOICE_AMOUNT, TERMS_DATE, " +
        //        "TOTAL_TAX_AMOUNT, VENDOR_ID," + "LAST_UPDATE_DATE, LAST_UPDATED_BY, SET_OF_BOOKS_ID, " +
        //        "INVOICE_CURRENCY_CODE, PAYMENT_CURRENCY_CODE," + "PAYMENT_CROSS_RATE, GL_DATE, APPROVAL_READY_FLAG, " +
        //        "WFAPPROVAL_STATUS) values('" +
        //    DESCRIPTION + "'," + TERMS_ID + "," + INVOICE_ID + ",'" + INVOICE_NUM + "','" + PAY_GROUP_LOOKUP_CODE + "','" +
        //    INVOICE_DATE + "','" + INVOICE_TYPE_LOOKUP_CODE + "'," + DOC_SEQUENCE_VALUE + "," + INVOICE_AMOUNT + ",'" + TERMS_DATE +
        //    "'," + TOTAL_TAX_AMOUNT + "," + VENDOR_ID + ",'" + LAST_UPDATE_DATE + "'," + LAST_UPDATED_BY + "," + SET_OF_BOOKS_ID +
        //    ",'" + INVOICE_CURRENCY_CODE + "','" + PAYMENT_CURRENCY_CODE + "'," + PAYMENT_CROSS_RATE + ",'" + GL_DATE + "','" +
        //    APPROVAL_READY_FLAG + "','" + WFAPPROVAL_STATUS + "')" +
        //                "returning INVOICE_ID into :INVOICE_ID;";

        //    var returndata = await ODBCDataAccess.GetResultNonQuery(connectionString, command_AP_INVOICES_ALL);

        //    foreach (var itm in invoice.items)
        //    {
        //        int LINE_NUMBER = itm.lineNumber; //number
        //        decimal AMOUNT = itm.amountDue.amount;  //number
        //        int TAX_RATE = itm.taxRate.amount;  //number
        //        int INVENTORY_ITEM_ID = itm.companyItem.externalId; //number
        //        int num_INVENTORY_ITEM_ID = Convert.ToInt32(INVENTORY_ITEM_ID);

        //        /*--------------extra fields coming from MT----------*/
        //        decimal INVOICE_AMOUNT_NetAmount = itm.netAmount.amount;  //number    //needed
        //        string VENDOR_NAME = invoice.vendor.name; //varchar   //needed
        //        /*--------------extra fields coming from MT----------*/

        //        /*----------------needed fields but not coming  from mt-----------*/
        //        string LINE_TYPE_LOOKUP_CODE = ""; //varchar
        //        DateTime ACCOUNTING_DATE = DateTime.Now;
        //        /*----------------needed fields but not coming  from mt-----------*/

        //        string command_AP_INVOICE_LINES_ALL = "Insert into ap.AP_INVOICE_LINES_ALL(INVOICE_ID, TAX_RATE, " +
        //        "AMOUNT, LAST_UPDATE_DATE, LINE_NUMBER, LINE_TYPE_LOOKUP_CODE, ACCOUNTING_DATE, SET_OF_BOOKS_ID," +
        //        "LAST_UPDATED_BY" + ")values(" +
        //        INVOICE_ID + "," + TAX_RATE + "," + AMOUNT + ",'" + LAST_UPDATE_DATE + "'," + LINE_NUMBER + ",'" +
        //        LINE_TYPE_LOOKUP_CODE + "','" + ACCOUNTING_DATE + "'," + SET_OF_BOOKS_ID + "," + LAST_UPDATED_BY + ")";

        //        var returndata_command_AP_INVOICE_LINES_ALL = await ODBCDataAccess.GetResultNonQuery(connectionString, command_AP_INVOICE_LINES_ALL);
        //    }
        //    // }foreach


        //}

        //public async void UpdateInvoiceIntoEBSFromMT(InvoiceResponse invoice)
        //{

        //    string SEGMENT1 = invoice.poNumber;
        //    string INVOICE_NUM = invoice.invoiceNumber;
        //    DateTime DUE_DATE = invoice.dueDate;
        //    DateTime INVOICE_DATE = invoice.transactionDate;
        //    string DESCRIPTION = invoice.memo;
        //    string vendor_type_lookup_code = invoice.vendor.vendorType;
        //    string VENDOR_NAME = invoice.vendor.name;
        //    int INVOICE_ID = invoice.externalId;
        //    int VENDOR_ID = invoice.vendor.externalId;
        //    decimal AMOUNT = invoice.balance.amount;
        //    decimal TOTAL_TAX_AMOUNT = invoice.totalTaxAmount.amount;
        //    int TERMS_ID = invoice.term.externalId;
        //    DateTime TERMS_DATE = invoice.term.created;
        //    int INVENTORY_ITEM_ID = invoice.items.FirstOrDefault().externalId;
        //    decimal INVOICE_AMOUNT = invoice.amount.amount;


        //    string command_ap_invoices_all = "update apps.ap_invoices_all set DESCRIPTION = '" + DESCRIPTION + "'," +
        //        "TERMS_ID = " + TERMS_ID + ", INVOICE_NUM ='" + INVOICE_NUM + "', INVOICE_DATE = '" + INVOICE_DATE + "'," +
        //        "INVOICE_AMOUNT = '" + INVOICE_AMOUNT + "'," + "TERMS_DATE = '" + TERMS_DATE + "',TOTAL_TAX_AMOUNT = " +
        //        TOTAL_TAX_AMOUNT + "where INVOICE_ID = " + INVOICE_ID + "";


        //    var returndata_ap_invoices_all = await ODBCDataAccess.GetResultNonQuery(connectionString, command_ap_invoices_all);



        //    string command_AP_PAYMENT_SCHEDULES_ALL = "update apps.AP_PAYMENT_SCHEDULES_ALL set DUE_DATE = '" + DUE_DATE + "'" +
        //                        "where INVOICE_ID = " + INVOICE_ID + "";
        //    var returndata_AP_PAYMENT_SCHEDULES_ALL = await ODBCDataAccess.GetResultNonQuery(connectionString, command_AP_PAYMENT_SCHEDULES_ALL);


        //    foreach (var itm in invoice.items)
        //    {
        //        StringBuilder ParametersToUpdateWithValue = new StringBuilder();

        //        int LINE_NUMBER = itm.lineNumber;
        //        decimal item_AMOUNT = itm.amountDue.amount;
        //        int TAX_RATE = itm.taxRate.amount;

        //        //string INVENTORY_ITEM_ID = invoice.bill.items.FirstOrDefault().id;

        //        string command_AP_INVOICE_LINES_ALL = "update apps.AP_INVOICE_LINES_ALL set TAX_RATE = " + TAX_RATE + "," +
        //            "AMOUNT = " + item_AMOUNT + " , LINE_NUMBER = " + LINE_NUMBER + "" +
        //            "where INVOICE_ID = '" + INVOICE_ID + "'";


        //    }

        //    string command_PO_VENDORS = "update apps.PO_VENDORS set VENDOR_NAME = '" + VENDOR_NAME + "'," +
        //                "vendor_type_lookup_code = '" + vendor_type_lookup_code + "' " +
        //                "where VENDOR_ID = (select Vendor_id from apps.ap_invoices_all where INVOICE_ID='" + INVOICE_ID + "')";

        //    var returndata_PO_VENDORS = await ODBCDataAccess.GetResultNonQuery(connectionString, command_PO_VENDORS);


        //}

        //public async void UpdatePurchaseOrderIntoEBSFromMT(PurchaseOrder po)
        //{
        //    string connectionString = "DATA SOURCE =" + "192.168.1.249" + ":" + "1521" + "/EBSDB;PERSIST SECURITY INFO=True;USER ID=" + "system" + "; password= " + "manager" + "; Pooling = False;";
        //    string SEGMENT1 = po.poNumber;  //"poNumber": "123412",     //SEGMENT1  
        //    object DESCRIPTION = po.description; ///  C.DESCRIPTION 
        //    foreach (var itm in po.items)
        //    {
        //        decimal QUANTITY_RECEIVED = itm.quantityReceived.value; ///"value": 4  C.QUANTITY_RECEIVED item.quantityReceived.value
        //        decimal QUANTITY = itm.quantityReceived.value;    ///"value": 1 C.QUANTITY   item.quantityReceived.value
        //        string ITEM_ID = itm.companyItem.externalId; /// "externalId": "138" B.ITEM_ID  item.companyItem.externalId
        //        decimal AMOUNT = itm.netAmount.amount;   //// "netAmount": null C.AMOUNT  item.netAmount
        //        decimal AMOUNT_RECEIVED = itm.amountDue.amount;    ////  "amount": 56 C.AMOUNT_RECEIVED item.amountDue.amount
        //        string line_number = itm.lineNumber;  //// ail.LINE_NUMBER
        //        int VendorId = po.vendor.externalId;      /// "externalId": "26",   d.Vendor_ID 
        //        string command = "update apps.PO_HEADERS_ALL set SEGMENT1='' , TYPE_LOOKUP_CODE='' WHERE PO_HEADER_ID = '' " +
        //                        "update apps.PO_LINES_ALL set LINE_NUM = '' , ITEM_ID = '' WHERE PO_HEADER_ID = '21' " +
        //                        "Update apps.PO_LINE_LOCATIONS_ALL set LINE_LOCATION_ID = '', CLOSED_FLAG = '', QUANTITY = '', AMOUNT_RECEIVED = '', AMOUNT_BILLED = '',DESCRIPTION = '' WHERE PO_HEADER_ID = '21' ";
        //        var returndata = await ODBCDataAccess.GetResultNonQuery(connectionString, command);
        //    }

        //}
        //public async void UpdatePaymentIntoEBSFromMT(Payment payment)
        //    {
        //        string connectionString = "DATA SOURCE =" + "192.168.1.249" + ":" + "1521" +
        //            "/EBSDB;PERSIST SECURITY INFO=True;USER ID=" + "system" + "; password= "
        //            + "manager" + "; Pooling = False;";

        //        string jsonData = "{" +
        //                        "'accountingPeriod': null," +
        //                        "'credits': null," +
        //                        "'bills': [" +
        //                          "{" +
        //                            "'appliedPaymentAmount': {" +
        //                              "'currency': 'USD'," +
        //                              "'precision': 2," +
        //                              "'amount': 0," +
        //                              "'created': null," +
        //                              "'modified': null" +
        //                            "}," +
        //                            "'purchaseOrders': null," +
        //                            "'billCredits': null," +
        //                            "'term': null," +
        //                            "'subsidiary': null," +
        //                            "'location': null," +
        //                            "'department': null," +
        //                            "'classification': null," +
        //                            "'apAccount': null," +
        //                            "'accountingPeriod': null," +
        //                            "'expenses': null," +
        //                            "'items': null," +
        //                            "'appliedDiscountAmount': {" +
        //                              "'currency': 'USD'," +
        //                              "'precision': 2," +
        //                              "'amount': 0," +
        //                              "'created': null," +
        //                              "'modified': null" +
        //                            "}," +
        //                            "'discountAmount': null," +
        //                            "'totalTaxAmount': null," +
        //                            "'balance': {" +
        //                              "'currency': 'USD'," +
        //                              "'precision': 2," +
        //                              "'amount': 0," +
        //                              "'created': null," +
        //                              "'modified': null" +
        //                           " }," +
        //                            "'amount': {" +
        //                              "'currency': 'USD'," +
        //                              "'precision': 2," +
        //                              "'amount': 0," +
        //                              "'created': null," +
        //                              "'modified': null" +
        //                            "}," +
        //                            "'company': null," +
        //                            "'vendor': null," +
        //                            "'dimensions': null," +
        //                            "'status': 'Open'," +
        //                            "'currency': null," +
        //                            "'popType': null," +
        //                            "'poNumber': null," +
        //                            "'dataSource': null," +
        //                            "'active': null," +
        //                            "'expenseReport': false," +
        //                            "'invoiceNumber': null," +
        //                            "'dueDate': null," +
        //                            "'transactionDate': null," +
        //                            "'ended': null," +
        //                            "'started': null," +
        //                            "'state': null," +
        //                            "'parent': null," +
        //                            "'name': null," +
        //                            "'description': null," +
        //                            "'memo': null," +
        //                            "'id': 788," +
        //                            "'externalId': '7746b033-998e-44e9-9ca5-f2231e36be1c'," +
        //                            "'created': null," +
        //                            "'modified': null" +
        //                          "}" +
        //                        "]," +
        //                        "'fundMethod': {" +
        //                          "'subsidiary': null," +
        //                          "'company': null," +
        //                          "'account': null," +
        //                          "'card': null," +
        //                          "'bankAccount': null," +
        //                          "'currency': null," +
        //                          "'status': null," +
        //                          "'active': null," +
        //                          "'type': null," +
        //                          "'name': null," +
        //                          "'description': null," +
        //                          "'memo': null," +
        //                          "'externalId': '1eed715f-17da-42df-bd31-f4365cf43ac9'," +
        //                          "'id': 54," +
        //                          "'created': null," +
        //                          "'modified': null" +
        //                        "}," +
        //                        "'paymentMethod': {" +
        //                          "'subsidiary': null," +
        //                          "'company': null," +
        //                          "'account': null," +
        //                          "'card': null," +
        //                          "'bankAccount': null," +
        //                          "'currency': null," +
        //                          "'status': null," +
        //                          "'active': null," +
        //                          "'type': null," +
        //                          "'name': null," +
        //                          "'description': null," +
        //                          "'memo': null," +
        //                          "'externalId': '1eed715f-17da-42df-bd31-f4365cf43ac9'," +
        //                          "'id': 3," +
        //                          "'created': null," +
        //                          "'modified': null" +
        //                        "}," +
        //                        "'amount': {" +
        //                          "'currency': 'USD'," +
        //                          "'precision': 2," +
        //                          "'amount': 0," +
        //                          "'created': null," +
        //                          "'modified': null" +
        //                        "}," +
        //                        "'company': null," +
        //                        "'vendor': {" +
        //                          "'company': null," +
        //                          "'vendorCompanyDefault': null," +
        //                          "'subsidiaries': null," +
        //                          "'primarySubsidiary': null," +
        //                          "'fundingMethods': null," +
        //                          "'defaultAPAccount': null," +
        //                          "'defaultExpenseAccount': null," +
        //                          "'defaultTerms': null," +
        //                          "'parent': null," +
        //                          "'phones': null," +
        //                          "'address': null," +
        //                          "'currencies': null," +
        //                          "'primaryCurrency': null," +
        //                          "'remittanceEmails': null," +
        //                          "'remittanceEnabled': null," +
        //                          "'customerAccount': null," +
        //                          "'vatNumber': null," +
        //                          "'taxId': null," +
        //                          "'active': null," +
        //                          "'form1099Enabled': null," +
        //                          "'emails': null," +
        //                          "'vendorType': null," +
        //                          "'dBAName': null," +
        //                          "'legalName': null," +
        //                          "'name': null," +
        //                          "'description': null," +
        //                          "'memo': null," +
        //                          "'externalId': '49653d6b-79b7-43c7-b181-e40480f4cbaf'," +
        //                          "'id': 31," +
        //                          "'created': null," +
        //                          "'modified': null" +
        //                        "}," +
        //                        "'dimensions': null," +
        //                        "'sequenceText': '217081'," +
        //                        "'checkNumber': 217081," +
        //                        "'status': 'LegacyPaymentClosed'," +
        //                        "'voided': false," +
        //                        "'confirmation': null," +
        //                        "'transactionDate': '2019-03-15T00:00:00Z'," +
        //                        "'ended': null," +
        //                        "'started': null," +
        //                        "'state': null," +
        //                        "'parent': null," +
        //                        "'name': null," +
        //                        "'description': null," +
        //                        "'memo': null," +
        //                        "'externalId': '0ffe2579-b302-44f7-890a-30ead8ae59c4'," +
        //                        "'id': 789," +
        //                        "'created': '2018-10-29T12:19:20Z'," +
        //                        "'modified': '2018-11-09T14:50:51Z'" +
        //                        "}";

        //        string command = "";

        //        var returndata = await ODBCDataAccess.GetResultNonQuery(connectionString, command);

        //    }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
