namespace XPump
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSellRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShiftTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDailyClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTankSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShift = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIstab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDotherMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSecure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsersFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEventLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYearEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChangeCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblExpressDataPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMysqlDbName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDaily,
            this.mnuSetup,
            this.mnuOther});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // mnuDaily
            // 
            this.mnuDaily.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSellRecord,
            this.toolStripSeparator3,
            this.mnuShiftTransaction,
            this.mnuDailyClose});
            this.mnuDaily.Name = "mnuDaily";
            resources.ApplyResources(this.mnuDaily, "mnuDaily");
            this.mnuDaily.Tag = "1";
            // 
            // mnuSellRecord
            // 
            this.mnuSellRecord.Name = "mnuSellRecord";
            resources.ApplyResources(this.mnuSellRecord, "mnuSellRecord");
            this.mnuSellRecord.Click += new System.EventHandler(this.mnuSellRecord_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // mnuShiftTransaction
            // 
            this.mnuShiftTransaction.Name = "mnuShiftTransaction";
            resources.ApplyResources(this.mnuShiftTransaction, "mnuShiftTransaction");
            this.mnuShiftTransaction.Tag = "11";
            this.mnuShiftTransaction.Click += new System.EventHandler(this.MnuShiftTransaction_Click);
            // 
            // mnuDailyClose
            // 
            this.mnuDailyClose.Name = "mnuDailyClose";
            resources.ApplyResources(this.mnuDailyClose, "mnuDailyClose");
            this.mnuDailyClose.Tag = "12";
            this.mnuDailyClose.Click += new System.EventHandler(this.mnuDailyClose_Click);
            // 
            // mnuSetup
            // 
            this.mnuSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBranch,
            this.mnuSettings,
            this.mnuTankSetup,
            this.mnuShift,
            this.mnuIstab});
            this.mnuSetup.Name = "mnuSetup";
            resources.ApplyResources(this.mnuSetup, "mnuSetup");
            this.mnuSetup.Tag = "2";
            // 
            // mnuBranch
            // 
            this.mnuBranch.Name = "mnuBranch";
            resources.ApplyResources(this.mnuBranch, "mnuBranch");
            this.mnuBranch.Click += new System.EventHandler(this.mnuBranch_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            resources.ApplyResources(this.mnuSettings, "mnuSettings");
            this.mnuSettings.Tag = "21";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuTankSetup
            // 
            this.mnuTankSetup.Name = "mnuTankSetup";
            resources.ApplyResources(this.mnuTankSetup, "mnuTankSetup");
            this.mnuTankSetup.Tag = "22";
            this.mnuTankSetup.Click += new System.EventHandler(this.MnuTankSetup_Click);
            // 
            // mnuShift
            // 
            this.mnuShift.Name = "mnuShift";
            resources.ApplyResources(this.mnuShift, "mnuShift");
            this.mnuShift.Tag = "23";
            this.mnuShift.Click += new System.EventHandler(this.MnuShift_Click);
            // 
            // mnuIstab
            // 
            this.mnuIstab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDotherMessage});
            this.mnuIstab.Name = "mnuIstab";
            resources.ApplyResources(this.mnuIstab, "mnuIstab");
            this.mnuIstab.Tag = "24";
            // 
            // mnuDotherMessage
            // 
            this.mnuDotherMessage.Name = "mnuDotherMessage";
            resources.ApplyResources(this.mnuDotherMessage, "mnuDotherMessage");
            this.mnuDotherMessage.Click += new System.EventHandler(this.mnuDotherMessage_Click);
            // 
            // mnuOther
            // 
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataManage,
            this.mnuSecure,
            this.mnuYearEnd,
            this.toolStripSeparator2,
            this.mnuChangeCompany});
            this.mnuOther.Name = "mnuOther";
            resources.ApplyResources(this.mnuOther, "mnuOther");
            this.mnuOther.Tag = "3";
            // 
            // mnuDataManage
            // 
            this.mnuDataManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBackup,
            this.mnuRestore});
            this.mnuDataManage.Name = "mnuDataManage";
            resources.ApplyResources(this.mnuDataManage, "mnuDataManage");
            this.mnuDataManage.Tag = "31";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            resources.ApplyResources(this.mnuBackup, "mnuBackup");
            this.mnuBackup.Tag = "311";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            resources.ApplyResources(this.mnuRestore, "mnuRestore");
            this.mnuRestore.Tag = "312";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // mnuSecure
            // 
            this.mnuSecure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsersFile,
            this.toolStripSeparator1,
            this.mnuEventLog});
            this.mnuSecure.Name = "mnuSecure";
            resources.ApplyResources(this.mnuSecure, "mnuSecure");
            this.mnuSecure.Tag = "32";
            // 
            // mnuUsersFile
            // 
            this.mnuUsersFile.Name = "mnuUsersFile";
            resources.ApplyResources(this.mnuUsersFile, "mnuUsersFile");
            this.mnuUsersFile.Tag = "321";
            this.mnuUsersFile.Click += new System.EventHandler(this.mnuUsersFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // mnuEventLog
            // 
            this.mnuEventLog.Name = "mnuEventLog";
            resources.ApplyResources(this.mnuEventLog, "mnuEventLog");
            this.mnuEventLog.Tag = "322";
            this.mnuEventLog.Click += new System.EventHandler(this.mnuEventLog_Click);
            // 
            // mnuYearEnd
            // 
            this.mnuYearEnd.Name = "mnuYearEnd";
            resources.ApplyResources(this.mnuYearEnd, "mnuYearEnd");
            this.mnuYearEnd.Tag = "33";
            this.mnuYearEnd.Click += new System.EventHandler(this.mnuYearEnd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // mnuChangeCompany
            // 
            this.mnuChangeCompany.Name = "mnuChangeCompany";
            resources.ApplyResources(this.mnuChangeCompany, "mnuChangeCompany");
            this.mnuChangeCompany.Tag = "34";
            this.mnuChangeCompany.Click += new System.EventHandler(this.mnuChangeCompany_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.lblUserID,
            this.toolStripStatusLabel1,
            this.lblExpressDataPath,
            this.toolStripStatusLabel2,
            this.lblMysqlDbName,
            this.lblVersion});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            // 
            // lblUserID
            // 
            this.lblUserID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUserID.Name = "lblUserID";
            resources.ApplyResources(this.lblUserID, "lblUserID");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // lblExpressDataPath
            // 
            this.lblExpressDataPath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblExpressDataPath.Name = "lblExpressDataPath";
            resources.ApplyResources(this.lblExpressDataPath, "lblExpressDataPath");
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // lblMysqlDbName
            // 
            this.lblMysqlDbName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMysqlDbName.Name = "lblMysqlDbName";
            resources.ApplyResources(this.lblMysqlDbName, "lblMysqlDbName");
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Spring = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDaily;
        private System.Windows.Forms.ToolStripMenuItem mnuShiftTransaction;
        private System.Windows.Forms.ToolStripMenuItem mnuSetup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuShift;
        private System.Windows.Forms.ToolStripMenuItem mnuTankSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuOther;
        private System.Windows.Forms.ToolStripMenuItem mnuDailyClose;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblExpressDataPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblMysqlDbName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUserID;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeCompany;
        private System.Windows.Forms.ToolStripMenuItem mnuIstab;
        private System.Windows.Forms.ToolStripMenuItem mnuDotherMessage;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuDataManage;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuYearEnd;
        private System.Windows.Forms.ToolStripMenuItem mnuSecure;
        private System.Windows.Forms.ToolStripMenuItem mnuUsersFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEventLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuBranch;
        private System.Windows.Forms.ToolStripMenuItem mnuSellRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

