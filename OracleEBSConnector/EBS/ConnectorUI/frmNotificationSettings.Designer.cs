namespace ConnectorUI
{
    partial class frmNotificationSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotificationSettings));
            this.chkIsRightToLeft = new System.Windows.Forms.CheckBox();
            this.txtPaddingTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAnimationDuration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkScroll = new System.Windows.Forms.CheckBox();
            this.txtPaddingContent = new System.Windows.Forms.TextBox();
            this.txtPaddingIcon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkGrip = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMenu = new System.Windows.Forms.CheckBox();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.chkIcon = new System.Windows.Forms.CheckBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkIsRightToLeft
            // 
            this.chkIsRightToLeft.AutoSize = true;
            this.chkIsRightToLeft.Location = new System.Drawing.Point(17, 184);
            this.chkIsRightToLeft.Name = "chkIsRightToLeft";
            this.chkIsRightToLeft.Size = new System.Drawing.Size(147, 17);
            this.chkIsRightToLeft.TabIndex = 47;
            this.chkIsRightToLeft.Text = "Right to Left/ راست به چپ";
            this.chkIsRightToLeft.UseVisualStyleBackColor = true;
            // 
            // txtPaddingTitle
            // 
            this.txtPaddingTitle.Location = new System.Drawing.Point(325, 142);
            this.txtPaddingTitle.Name = "txtPaddingTitle";
            this.txtPaddingTitle.Size = new System.Drawing.Size(100, 20);
            this.txtPaddingTitle.TabIndex = 43;
            this.txtPaddingTitle.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Content padding [px]:";
            // 
            // txtAnimationDuration
            // 
            this.txtAnimationDuration.Location = new System.Drawing.Point(325, 116);
            this.txtAnimationDuration.Name = "txtAnimationDuration";
            this.txtAnimationDuration.Size = new System.Drawing.Size(100, 20);
            this.txtAnimationDuration.TabIndex = 46;
            this.txtAnimationDuration.Text = "1000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "AnimationDuration [ms]:";
            // 
            // chkScroll
            // 
            this.chkScroll.AutoSize = true;
            this.chkScroll.Checked = true;
            this.chkScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScroll.Location = new System.Drawing.Point(20, 161);
            this.chkScroll.Name = "chkScroll";
            this.chkScroll.Size = new System.Drawing.Size(83, 17);
            this.chkScroll.TabIndex = 40;
            this.chkScroll.Text = "Scroll in/out";
            this.chkScroll.UseVisualStyleBackColor = true;
            // 
            // txtPaddingContent
            // 
            this.txtPaddingContent.Location = new System.Drawing.Point(325, 168);
            this.txtPaddingContent.Name = "txtPaddingContent";
            this.txtPaddingContent.Size = new System.Drawing.Size(100, 20);
            this.txtPaddingContent.TabIndex = 41;
            this.txtPaddingContent.Text = "0";
            // 
            // txtPaddingIcon
            // 
            this.txtPaddingIcon.Location = new System.Drawing.Point(325, 194);
            this.txtPaddingIcon.Name = "txtPaddingIcon";
            this.txtPaddingIcon.Size = new System.Drawing.Size(100, 20);
            this.txtPaddingIcon.TabIndex = 39;
            this.txtPaddingIcon.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Icon padding [px]:";
            // 
            // chkGrip
            // 
            this.chkGrip.AutoSize = true;
            this.chkGrip.Checked = true;
            this.chkGrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGrip.Location = new System.Drawing.Point(20, 138);
            this.chkGrip.Name = "chkGrip";
            this.chkGrip.Size = new System.Drawing.Size(73, 17);
            this.chkGrip.TabIndex = 37;
            this.chkGrip.Text = "Show grip";
            this.chkGrip.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Title padding [px]:";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(325, 64);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(100, 20);
            this.txtDelay.TabIndex = 35;
            this.txtDelay.Text = "3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Animation interval [ms]:";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(325, 90);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 36;
            this.txtInterval.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Delay [ms]:";
            // 
            // chkMenu
            // 
            this.chkMenu.AutoSize = true;
            this.chkMenu.Checked = true;
            this.chkMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMenu.Location = new System.Drawing.Point(20, 115);
            this.chkMenu.Name = "chkMenu";
            this.chkMenu.Size = new System.Drawing.Size(114, 17);
            this.chkMenu.TabIndex = 32;
            this.chkMenu.Text = "Show option menu";
            this.chkMenu.UseVisualStyleBackColor = true;
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(20, 92);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(114, 17);
            this.chkClose.TabIndex = 31;
            this.chkClose.Text = "Show close button";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // chkIcon
            // 
            this.chkIcon.AutoSize = true;
            this.chkIcon.Checked = true;
            this.chkIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIcon.Location = new System.Drawing.Point(20, 69);
            this.chkIcon.Name = "chkIcon";
            this.chkIcon.Size = new System.Drawing.Size(76, 17);
            this.chkIcon.TabIndex = 30;
            this.chkIcon.Text = "Show icon";
            this.chkIcon.UseVisualStyleBackColor = true;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(54, 34);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(371, 20);
            this.txtText.TabIndex = 29;
            this.txtText.Text = "This is the notification text!";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(53, 8);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(372, 20);
            this.txtTitle.TabIndex = 28;
            this.txtTitle.Text = "Notification Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Text:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Title:";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(17, 216);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 25;
            this.btnShow.Text = "Show!";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(430, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // popupNotifier1
            // 
            this.popupNotifier1.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.popupNotifier1.ContentText = null;
            this.popupNotifier1.Image = null;
            this.popupNotifier1.IsRightToLeft = false;
            this.popupNotifier1.OptionsMenu = this.contextMenuStrip1;
            this.popupNotifier1.Size = new System.Drawing.Size(400, 100);
            this.popupNotifier1.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.popupNotifier1.TitleText = null;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 70);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // frmNotificationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 249);
            this.Controls.Add(this.chkIsRightToLeft);
            this.Controls.Add(this.txtPaddingTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAnimationDuration);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkScroll);
            this.Controls.Add(this.txtPaddingContent);
            this.Controls.Add(this.txtPaddingIcon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkGrip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkMenu);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.chkIcon);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNotificationSettings";
            this.Text = "Notification Window Settings";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsRightToLeft;
        private System.Windows.Forms.TextBox txtPaddingTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAnimationDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkScroll;
        private System.Windows.Forms.TextBox txtPaddingContent;
        private System.Windows.Forms.TextBox txtPaddingIcon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkGrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMenu;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.CheckBox chkIcon;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExit;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}