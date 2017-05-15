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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripDailyTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuShiftTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDailyClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStmas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.อนๆToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblExpressDataPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMysqlDbName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.ตารางขอมลToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDotherMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDailyTransaction,
            this.ToolStripStock,
            this.อนๆToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripDailyTransaction
            // 
            this.ToolStripDailyTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuShiftTransaction,
            this.mnuDailyClose});
            this.ToolStripDailyTransaction.Name = "ToolStripDailyTransaction";
            this.ToolStripDailyTransaction.Size = new System.Drawing.Size(107, 20);
            this.ToolStripDailyTransaction.Text = "รายการประจำวัน";
            // 
            // MnuShiftTransaction
            // 
            this.MnuShiftTransaction.Name = "MnuShiftTransaction";
            this.MnuShiftTransaction.Size = new System.Drawing.Size(206, 22);
            this.MnuShiftTransaction.Text = "บันทึกรายการประจำผลัด";
            this.MnuShiftTransaction.Click += new System.EventHandler(this.MnuShiftTransaction_Click);
            // 
            // mnuDailyClose
            // 
            this.mnuDailyClose.Name = "mnuDailyClose";
            this.mnuDailyClose.Size = new System.Drawing.Size(206, 22);
            this.mnuDailyClose.Text = "ปิดยอดขายประจำวัน";
            this.mnuDailyClose.Click += new System.EventHandler(this.mnuDailyClose_Click);
            // 
            // ToolStripStock
            // 
            this.ToolStripStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStmas,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.ตารางขอมลToolStripMenuItem});
            this.ToolStripStock.Name = "ToolStripStock";
            this.ToolStripStock.Size = new System.Drawing.Size(107, 20);
            this.ToolStripStock.Text = "ฐานข้อมูลเริ่มต้น";
            // 
            // MnuStmas
            // 
            this.MnuStmas.Name = "MnuStmas";
            this.MnuStmas.Size = new System.Drawing.Size(195, 22);
            this.MnuStmas.Text = "รายละเอียดสินค้า";
            this.MnuStmas.Visible = false;
            this.MnuStmas.Click += new System.EventHandler(this.MnuStmas_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem2.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.MnuTank_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem1.Text = "กำหนดผลัดพนักงาน";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MnuShift_Click);
            // 
            // อนๆToolStripMenuItem
            // 
            this.อนๆToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuChangeCompany});
            this.อนๆToolStripMenuItem.Name = "อนๆToolStripMenuItem";
            this.อนๆToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.อนๆToolStripMenuItem.Text = "อื่น ๆ";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(145, 22);
            this.mnuSettings.Text = "ตั้งค่าระบบ";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuChangeCompany
            // 
            this.mnuChangeCompany.Name = "mnuChangeCompany";
            this.mnuChangeCompany.Size = new System.Drawing.Size(145, 22);
            this.mnuChangeCompany.Text = "เปลี่ยนบริษัท";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 19);
            this.toolStripStatusLabel3.Text = "รหัสผูใช้ : ";
            // 
            // lblUserID
            // 
            this.lblUserID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(22, 19);
            this.lblUserID.Text = " - ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(117, 19);
            this.toolStripStatusLabel1.Text = ", ที่เก็บข้อมูลเอ็กซ์เพรส : ";
            // 
            // lblExpressDataPath
            // 
            this.lblExpressDataPath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblExpressDataPath.Name = "lblExpressDataPath";
            this.lblExpressDataPath.Size = new System.Drawing.Size(22, 19);
            this.lblExpressDataPath.Text = " - ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(107, 19);
            this.toolStripStatusLabel2.Text = ", ฐานข้อมูล MySQL : ";
            // 
            // lblMysqlDbName
            // 
            this.lblMysqlDbName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMysqlDbName.Name = "lblMysqlDbName";
            this.lblMysqlDbName.Size = new System.Drawing.Size(22, 19);
            this.lblMysqlDbName.Text = " - ";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(728, 19);
            this.lblVersion.Spring = true;
            this.lblVersion.Text = "version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ตารางขอมลToolStripMenuItem
            // 
            this.ตารางขอมลToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDotherMessage});
            this.ตารางขอมลToolStripMenuItem.Name = "ตารางขอมลToolStripMenuItem";
            this.ตารางขอมลToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ตารางขอมลToolStripMenuItem.Text = "ตารางข้อมูล";
            // 
            // mnuDotherMessage
            // 
            this.mnuDotherMessage.Name = "mnuDotherMessage";
            this.mnuDotherMessage.Size = new System.Drawing.Size(235, 22);
            this.mnuDotherMessage.Text = "หักยอดขายประจำผลัด (อื่น ๆ)";
            this.mnuDotherMessage.Click += new System.EventHandler(this.mnuDotherMessage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XPump";
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripDailyTransaction;
        private System.Windows.Forms.ToolStripMenuItem MnuShiftTransaction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripStock;
        private System.Windows.Forms.ToolStripMenuItem MnuStmas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem อนๆToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuDailyClose;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblExpressDataPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblMysqlDbName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUserID;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeCompany;
        private System.Windows.Forms.ToolStripMenuItem ตารางขอมลToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDotherMessage;
    }
}

