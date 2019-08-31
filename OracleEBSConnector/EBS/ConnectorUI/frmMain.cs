using log4net;
using log4net.Config;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ConnectorLib.API;
using System.Linq;
using ConnectorEntity;

namespace ConnectorUI
{
    public partial class frmMain : Form
    {
        public bool isEnableNotiication = true;
        private bool allowshowdisplay = false;
        public List<QueryRequest> queryRequests = new List<QueryRequest>();

        public frmMain()
        {
            InitializeComponent();
        }
        private void ODBCConnectorControl_btnRemoveClick(object sender, EventArgs e)
        {
            ConnectorControl ctr = sender as ConnectorControl;
            DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure want to remove {0}?", ctr.EBSConfiguration.company), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                ctr.AutoRun = false;
                pnlContainer.Controls.Remove(ctr);
                Save();
            }
        }
        private void notificationPopupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewConfiguration();
        }
        private void frmODBC_Load(object sender, EventArgs e)
        {

            LocalDbApi localDbApi = new LocalDbApi();

            List<ConnectorConfiguration> listEBSConfiguration = localDbApi.Get<ConnectorConfiguration>("configuration").ToList();

            foreach (ConnectorConfiguration ebsConfiguration in listEBSConfiguration)
            {

                ConnectorControl connectorControl = new ConnectorControl();
                connectorControl.mainForm = this;
                connectorControl.Width = 889;
                connectorControl.EBSConfiguration = ebsConfiguration;
                connectorControl.EBSCompanyName = ebsConfiguration.dataBase;
                connectorControl.SelectCheckbox = ebsConfiguration.selectCheckbox;
                connectorControl.AutoRun = ebsConfiguration.autoRun;
                connectorControl.EveryMinutes = ebsConfiguration.everyMinutes;
                connectorControl.LastRun = ebsConfiguration.lastRun;
                connectorControl.LastResult = ebsConfiguration.lastResult;
                connectorControl.lblLastResult.ForeColor = ebsConfiguration.lastResult == "Failed" ? Color.Red : Color.Green;
                connectorControl.id = ebsConfiguration.id;
                connectorControl.btnRemoveEventClick += ODBCConnectorControl_btnRemoveClick;
                connectorControl.btnEditEventClick += ODBCConnectorControl_btnEditEventClick;
                connectorControl.chkAutoSelectEventStateChanged += ODBCConnectorControl_chkAutoSelectEventStateChanged;
                connectorControl.chkSelectEventStateChanged += ODBCConnectorControl_chkSelectEventStateChanged;
                connectorControl.everyMinEventValueChanged += ODBCConnectorControl_everyMinEventValueChanged;
                connectorControl.Dock = DockStyle.Top;
                pnlContainer.Controls.Add(connectorControl);
                connectorControl.UpdateEBSConfiguration();
            }

        }

        private void ODBCConnectorControl_everyMinEventValueChanged(object sender, EventArgs e)
        {

        }

        private void ODBCConnectorControl_chkSelectEventStateChanged(object sender, EventArgs e)
        {

        }
        private void ODBCConnectorControl_chkAutoSelectEventStateChanged(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNotificationSettings f = new frmNotificationSettings();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            popupNotifier1.TitleText = "Service Information";
            popupNotifier1.ContentText = "Service Stoped";
            popupNotifier1.Popup();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void ddlInterval_ValueChanged(object sender, EventArgs e)
        {
            // timer1.Interval = (60000 * 1);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var control in pnlContainer.Controls)
            {
                if (control is ConnectorControl)
                {
                    ConnectorControl connectorControl = control as ConnectorControl;
                    connectorControl.SelectCheckbox = true;

                }
            }
        }
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (var control in pnlContainer.Controls)
            {
                if (control is ConnectorControl)
                {
                    ConnectorControl connectorControl = control as ConnectorControl;
                    connectorControl.SelectCheckbox = false;

                }
            }
        }
        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            AddNewConfiguration();
        }

        private void AddNewConfiguration()
        {
            try
            {
                frmAddCompany frmAddCompany = new frmAddCompany();
                frmAddCompany.StartPosition = FormStartPosition.CenterScreen;
                frmAddCompany.ShowDialog();
                if (frmAddCompany.isOK)
                {
                    ConnectorControl connectorControl = new ConnectorControl();
                    connectorControl.mainForm = this;
                    connectorControl.Width = 889;
                    connectorControl.EBSConfiguration = frmAddCompany.ebsConfiguration;
                    connectorControl.EBSCompanyName = frmAddCompany.ebsConfiguration.company;
                    connectorControl.SelectCheckbox = false;
                    connectorControl.id = frmAddCompany.ebsConfiguration.id;
                    connectorControl.btnRemoveEventClick += ODBCConnectorControl_btnRemoveClick;
                    connectorControl.btnEditEventClick += ODBCConnectorControl_btnEditEventClick;
                    pnlContainer.Controls.Add(connectorControl);
                    connectorControl.UpdateEBSConfiguration();
                    Save();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ODBCConnectorControl_btnEditEventClick(object sender, EventArgs e)
        {

            ConnectorControl connectorControl = sender as ConnectorControl;
            ConnectorConfiguration ebsConfiguration = connectorControl.EBSConfiguration;
            frmAddCompany frmAddCompany = new frmAddCompany(ebsConfiguration);
            frmAddCompany.StartPosition = FormStartPosition.CenterScreen;
            frmAddCompany.ShowDialog();
            if (frmAddCompany.isOK)
            {
                connectorControl.EBSConfiguration = frmAddCompany.ebsConfiguration;
                connectorControl.EBSCompanyName = frmAddCompany.ebsConfiguration.company;
                Save();
            }
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void Save()
        {

            LocalDbApi LocalDbApi = new LocalDbApi();
            LocalDbApi.drop("configuration");
            foreach (var control in pnlContainer.Controls)
            {
                if (control is ConnectorControl)
                {
                    ConnectorControl connectorControl = control as ConnectorControl;
                    LocalDbApi.Save<ConnectorConfiguration>("configuration", connectorControl.EBSConfiguration);
                }
            }
        }
        private void syncSelected_Click(object sender, EventArgs e)
        {

            if (!IsAnySelected() && (pnlContainer.Controls.Count > 0))
            {
                Util.ShowMessage("Please select at least one database", this.Text);
                return;
            }

            SyncSelected();

        }

        private async void SyncSelected()
        {
            foreach (var control in pnlContainer.Controls)
            {
                if (control is ConnectorControl)
                {
                    ConnectorControl connectorControl = control as ConnectorControl;

                    ConnectorConfiguration ebsConfiguration = connectorControl.EBSConfiguration;
                    Connector.mainForm = this;
                    LogRecord logRecord = await Connector.start(ebsConfiguration);
                    connectorControl.SetConnectorLogDetails(logRecord);

                }
            }           
        }
        private bool IsAnySelected()
        {
            foreach (var control in pnlContainer.Controls)
            {
                if (control is ConnectorControl)
                {
                    ConnectorControl connectorControl = control as ConnectorControl;
                    if (connectorControl.chkSelect.Checked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            string logPath = Path.Combine(Application.StartupPath, "Logs", "log.txt");
            if (File.Exists(logPath))
            {
                Process.Start(logPath);
            }
            else
            {
                MessageBox.Show("Log file does not exit");
            }
        }

        private void menuEnableNotification_Click(object sender, EventArgs e)
        {
            if (isEnableNotiication)
            {
                MessageBox.Show("Notification has been disabled.");
            }
            else
            {
                MessageBox.Show("Notification has been enabled.");
            }
            isEnableNotiication = !isEnableNotiication;


        }
        private void ShowNotification(string title, string description)
        {

            popupNotifier1.ShowCloseButton = true;
            popupNotifier1.ShowOptionsButton = false;
            popupNotifier1.ShowGrip = false;
            popupNotifier1.Delay = 3000;
            popupNotifier1.AnimationInterval = 10;
            popupNotifier1.AnimationDuration = 1000;
            popupNotifier1.Scroll = true;
            popupNotifier1.IsRightToLeft = false;
            popupNotifier1.Image = Properties.Resources.mt;
            popupNotifier1.TitleText = title;
            popupNotifier1.ContentText = description;
            popupNotifier1.Popup();


        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.allowshowdisplay = true;
            this.Visible = !this.Visible;

        }

        private void menuClearLog_Click(object sender, EventArgs e)
        {
            string logPath = Path.Combine(Application.StartupPath, "Logs", "log.txt");
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }
        }
    }

}
