using System;
using log4net;
using log4net.Config;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using ODBC;
using ConnectorLib.API;
using WebClientUtility;
using WebClientUtility.API;
using WebClientUtility.Core;
using EBS;
using Oracle.ManagedDataAccess.Client;

namespace ConnectorUI
{
    public partial class frmAddCompany : Form
    {

        public ConnectorConfiguration ebsConfiguration;

        public static readonly log4net.ILog Log = LogManager.GetLogger(typeof(frmAddCompany));
        private List<ConnectorConfiguration> ebsConfigurationsList { get; set; }
        public bool isOK = false;

        private frmLoader loaderForm = new frmLoader();
        public frmAddCompany(ConnectorConfiguration configuration)
        {
            InitializeComponent();
            //LoadODBCDriver();
            ebsConfiguration = configuration;
            txtUserName.Text = ebsConfiguration.userName;
            txtPassword.Text = ebsConfiguration.password;
            txtConnectorKey.Text = ebsConfiguration.connectorKey;
            txtConnectorSecret.Text = ebsConfiguration.connectorSecret;
            txtServerName.Text = ebsConfiguration.serverName;
            txtDatabaseName.Text = ebsConfiguration.dataBase;
            txtport.Text = ebsConfiguration.port;          
        }
        public frmAddCompany()
        {
          InitializeComponent();
          //LoadODBCDriver();
          ebsConfiguration = new ConnectorConfiguration();
          Guid guid = Guid.NewGuid();
          Random random = new Random();
          int iGuid = random.Next();
          ebsConfiguration.id = iGuid;            
        }
        private async void btnSaveClose_Click(object sender, EventArgs e)
        {

            try
            {
                Log.Info("Configuration init");
                await AddCompany();
                Log.Info("Configuration Added");
            }
            catch (Exception ex)
            {
                Log.Info("Exception from AddCompany {0}" + ex);
                MessageBox.Show(ex.Message);
            }

        }

        private async Task AddCompany()
        {
           
            try
            {

                if (!(isValid() && CheckWebhookHandshake()  && CheckEBSConnection() )) return;                              

                loaderForm.StartPosition = FormStartPosition.CenterScreen;
                loaderForm.Show();

                List<string> result = new List<string>();
                loaderForm.Close();        
                ebsConfiguration.company = "Magic Oracle EBS";
                ebsConfiguration.userName = txtUserName.Text;
                ebsConfiguration.password = txtPassword.Text;
                ebsConfiguration.connectorKey = txtConnectorKey.Text;
                ebsConfiguration.connectorSecret = txtConnectorSecret.Text;
                ebsConfiguration.dataBase = txtDatabaseName.Text;
                ebsConfiguration.serverName = txtServerName.Text;
                ebsConfiguration.port = txtport.Text;
   
                isOK = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Util.ShowMessage("Please enter valid EBS configuration details.", this.Text);
                Log.FatalFormat("Invalid EBS configuration details.");
                loaderForm.Close();
                return;
            }
        }

        private bool isValid()
        {

            if (IsAlreadyExistsConnectorKey(txtConnectorKey.Text))
            {
                txtConnectorKey.Focus();
                Util.ShowMessage(string.Format("This connector key '{0}' already exists.", txtConnectorKey.Text), this.Text);
                return false;
            }
            if (string.IsNullOrEmpty(txtConnectorKey.Text))
            {
                txtConnectorKey.Focus();
                Util.ShowMessage("Please enter Connector Key", this.Text);
                return false;
            }
            
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                Util.ShowMessage("Please fill Server Name.", this.Text);
                return false;
            }

            if (string.IsNullOrEmpty(txtport.Text))
            {
                Util.ShowMessage("Please fill Port Number.", this.Text);
                return false;
            }
            
            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                Util.ShowMessage("Please fill Database Name.", this.Text);
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                txtUserName.Focus();
                Util.ShowMessage("Please enter User Name", this.Text);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                Util.ShowMessage("Please enter Password", this.Text);
                return false;
            }
           
            return true;
        }

        private bool IsAlreadyExistsConnectorKey(string connectorKey)
        {
            if (ebsConfigurationsList != null)
            {
                return ebsConfigurationsList.Where(c => c.connectorKey == connectorKey && string.IsNullOrEmpty(ebsConfiguration.company)).Count() > 0;
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isOK = false;
            this.Close();
        }
        private void frmAddCompany_Load(object sender, EventArgs e)
        {
            Log.Info("Add Form frmAddCompany_Load List");

            LocalDbApi localDbApi = new LocalDbApi();
            ebsConfigurationsList = localDbApi.Get<ConnectorConfiguration>("configuration").ToList();           
        }

        private void LoadODBCDriver()
        {
            try
            {
                List<ODBCDSN> userDSNList = new List<ODBCDSN>();
                ODBCDSN[] UserODBCDSNList = ODBCManager.GetUserDSNList();              
                Log.Info("List of ODBC Driver {0}" + UserODBCDSNList);
                userDSNList.AddRange(UserODBCDSNList);
            }
            catch (Exception ex) {
                Util.ShowMessage("Please Configure ODBC Driver.", this.Text);
                Log.Error("Exception in Loading ODBC Driver {0}" + ex);
            }
        }

        private bool CheckEBSConnection()
        {
            //Checking EBS Connection           
            ConnectorConfiguration connetorConfiguration = new ConnectorConfiguration { serverName = txtServerName.Text, port = txtport.Text, dataBase = txtDatabaseName.Text, userName = txtUserName.Text, password = txtPassword.Text };
            OracleConnection oracleConnection = new OracleConnection(connetorConfiguration.connectionString);
            try
            {
                oracleConnection.Open();
                if (oracleConnection.State == ConnectionState.Open)
                {
                    oracleConnection.Close();
                }
                Log.Info("EBS Connection can be establish.");
                return true;
            }
            catch (OracleException)
            {
                Util.ShowMessage("EBS Connection cannot be estabished.", this.Text);
                return false;
            }
        }

        private bool CheckWebhookHandshake()
        {
            //Checking WebHook Handhake
            WebClientUtility.API.ConnectorApi mtWebhookURLConnectorApi = new WebClientUtility.API.ConnectorApi(new WebClientHttpUtility(), null, txtConnectorKey.Text);

            if (!mtWebhookURLConnectorApi.Handshake())
            {
                Util.ShowMessage("Please enter a valid connector Key", this.Text);
                loaderForm.Close();
                return false;
            }
            else
            {
                Log.Info("Magic XPC Webhook can be establish.");
                return true;
            }

        }

        
    }
}
