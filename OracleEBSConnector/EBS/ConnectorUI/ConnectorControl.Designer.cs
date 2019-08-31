namespace ConnectorUI
{
    partial class ConnectorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLastResult = new System.Windows.Forms.Label();
            this.lblLastRun = new System.Windows.Forms.Label();
            this.linkMoreInformation = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAutoRun = new System.Windows.Forms.Panel();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.pnlEveryMin = new System.Windows.Forms.Panel();
            this.numericEveryMin = new System.Windows.Forms.NumericUpDown();
            this.pnlRemove = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlAutoRun.SuspendLayout();
            this.pnlEveryMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEveryMin)).BeginInit();
            this.pnlRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.51515F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.48485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkSelect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlStatus, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlAutoRun, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlEveryMin, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlRemove, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 65);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(43, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 57);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "For Support:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 6;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(3, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(92, 12);
            this.lblCompany.TabIndex = 5;
            this.lblCompany.Text = "[Company Name]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(64, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(64, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://support.mineraltree.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkSelect
            // 
            this.chkSelect.Location = new System.Drawing.Point(4, 4);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(19, 50);
            this.chkSelect.TabIndex = 4;
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckStateChanged += new System.EventHandler(this.chkSelect_CheckStateChanged);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblAuthorization);
            this.pnlStatus.Controls.Add(this.label3);
            this.pnlStatus.Controls.Add(this.lblLastResult);
            this.pnlStatus.Controls.Add(this.lblLastRun);
            this.pnlStatus.Controls.Add(this.linkMoreInformation);
            this.pnlStatus.Controls.Add(this.label2);
            this.pnlStatus.Controls.Add(this.label1);
            this.pnlStatus.Location = new System.Drawing.Point(492, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(228, 57);
            this.pnlStatus.TabIndex = 6;
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorization.Location = new System.Drawing.Point(64, 0);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(0, 12);
            this.lblAuthorization.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Authorization:";
            // 
            // lblLastResult
            // 
            this.lblLastResult.AutoSize = true;
            this.lblLastResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblLastResult.Location = new System.Drawing.Point(64, 26);
            this.lblLastResult.Name = "lblLastResult";
            this.lblLastResult.Size = new System.Drawing.Size(0, 12);
            this.lblLastResult.TabIndex = 4;
            // 
            // lblLastRun
            // 
            this.lblLastRun.AutoSize = true;
            this.lblLastRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblLastRun.Location = new System.Drawing.Point(64, 14);
            this.lblLastRun.Name = "lblLastRun";
            this.lblLastRun.Size = new System.Drawing.Size(0, 12);
            this.lblLastRun.TabIndex = 3;
            // 
            // linkMoreInformation
            // 
            this.linkMoreInformation.AutoSize = true;
            this.linkMoreInformation.Location = new System.Drawing.Point(1, 39);
            this.linkMoreInformation.Name = "linkMoreInformation";
            this.linkMoreInformation.Size = new System.Drawing.Size(125, 13);
            this.linkMoreInformation.TabIndex = 2;
            this.linkMoreInformation.TabStop = true;
            this.linkMoreInformation.Text = "Click for more information";
            this.linkMoreInformation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMoreInformation_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Run:";
            // 
            // pnlAutoRun
            // 
            this.pnlAutoRun.Controls.Add(this.chkAutoRun);
            this.pnlAutoRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAutoRun.Location = new System.Drawing.Point(341, 4);
            this.pnlAutoRun.Name = "pnlAutoRun";
            this.pnlAutoRun.Size = new System.Drawing.Size(59, 57);
            this.pnlAutoRun.TabIndex = 10;
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.Location = new System.Drawing.Point(19, 0);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(19, 52);
            this.chkAutoRun.TabIndex = 3;
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckStateChanged += new System.EventHandler(this.chkAutoRun_CheckStateChanged);
            // 
            // pnlEveryMin
            // 
            this.pnlEveryMin.Controls.Add(this.numericEveryMin);
            this.pnlEveryMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEveryMin.Location = new System.Drawing.Point(407, 4);
            this.pnlEveryMin.Name = "pnlEveryMin";
            this.pnlEveryMin.Size = new System.Drawing.Size(78, 57);
            this.pnlEveryMin.TabIndex = 11;
            // 
            // numericEveryMin
            // 
            this.numericEveryMin.Location = new System.Drawing.Point(12, 16);
            this.numericEveryMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericEveryMin.Name = "numericEveryMin";
            this.numericEveryMin.Size = new System.Drawing.Size(49, 20);
            this.numericEveryMin.TabIndex = 6;
            this.numericEveryMin.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericEveryMin.ValueChanged += new System.EventHandler(this.numericEveryMin_ValueChanged_1);
            // 
            // pnlRemove
            // 
            this.pnlRemove.Controls.Add(this.btnEdit);
            this.pnlRemove.Controls.Add(this.btnRemove);
            this.pnlRemove.Location = new System.Drawing.Point(727, 4);
            this.pnlRemove.Name = "pnlRemove";
            this.pnlRemove.Size = new System.Drawing.Size(120, 50);
            this.pnlRemove.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(58, 15);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // popupNotifier1
            // 
            this.popupNotifier1.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.popupNotifier1.ContentText = null;
            this.popupNotifier1.Image = null;
            this.popupNotifier1.IsRightToLeft = false;
            this.popupNotifier1.OptionsMenu = null;
            this.popupNotifier1.Size = new System.Drawing.Size(400, 100);
            this.popupNotifier1.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.popupNotifier1.TitleText = null;
            // 
            // ConnectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectorControl";
            this.Size = new System.Drawing.Size(878, 71);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlAutoRun.ResumeLayout(false);
            this.pnlEveryMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericEveryMin)).EndInit();
            this.pnlRemove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.LinkLabel linkMoreInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAutoRun;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Panel pnlEveryMin;
        private System.Windows.Forms.NumericUpDown numericEveryMin;
        private System.Windows.Forms.Panel pnlRemove;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Timer timer1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        public System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblCompany;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    public System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblAuthorization;
    public System.Windows.Forms.Label lblLastResult;
    private System.Windows.Forms.Label lblLastRun;
  }
}
