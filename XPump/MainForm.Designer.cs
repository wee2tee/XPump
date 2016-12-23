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
            this.ToolStripStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStmas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuShift = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTank = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNozzle = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDailyTransaction,
            this.ToolStripStock,
            this.ToolStripSetup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripDailyTransaction
            // 
            this.ToolStripDailyTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuShiftTransaction});
            this.ToolStripDailyTransaction.Name = "ToolStripDailyTransaction";
            this.ToolStripDailyTransaction.Size = new System.Drawing.Size(107, 20);
            this.ToolStripDailyTransaction.Text = "รายการประจำวัน";
            // 
            // MnuShiftTransaction
            // 
            this.MnuShiftTransaction.Name = "MnuShiftTransaction";
            this.MnuShiftTransaction.Size = new System.Drawing.Size(206, 22);
            this.MnuShiftTransaction.Text = "บันทึกรายการประจำผลัด";
            // 
            // ToolStripStock
            // 
            this.ToolStripStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStmas,
            this.MnuPrice});
            this.ToolStripStock.Name = "ToolStripStock";
            this.ToolStripStock.Size = new System.Drawing.Size(50, 20);
            this.ToolStripStock.Text = "สินค้า";
            // 
            // MnuStmas
            // 
            this.MnuStmas.Name = "MnuStmas";
            this.MnuStmas.Size = new System.Drawing.Size(168, 22);
            this.MnuStmas.Text = "รายละเอียดสินค้า";
            // 
            // MnuPrice
            // 
            this.MnuPrice.Name = "MnuPrice";
            this.MnuPrice.Size = new System.Drawing.Size(168, 22);
            this.MnuPrice.Text = "กำหนดราคาขาย";
            // 
            // ToolStripSetup
            // 
            this.ToolStripSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuShift,
            this.MnuTank,
            this.MnuNozzle});
            this.ToolStripSetup.Name = "ToolStripSetup";
            this.ToolStripSetup.Size = new System.Drawing.Size(66, 20);
            this.ToolStripSetup.Text = "เริ่มระบบ";
            // 
            // MnuShift
            // 
            this.MnuShift.Name = "MnuShift";
            this.MnuShift.Size = new System.Drawing.Size(195, 22);
            this.MnuShift.Text = "กำหนดผลัดพนักงาน";
            this.MnuShift.Click += new System.EventHandler(this.MnuShift_Click);
            // 
            // MnuTank
            // 
            this.MnuTank.Name = "MnuTank";
            this.MnuTank.Size = new System.Drawing.Size(195, 22);
            this.MnuTank.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            // 
            // MnuNozzle
            // 
            this.MnuNozzle.Name = "MnuNozzle";
            this.MnuNozzle.Size = new System.Drawing.Size(195, 22);
            this.MnuNozzle.Text = "กำหนดหัวจ่ายน้ำมัน";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 578);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripDailyTransaction;
        private System.Windows.Forms.ToolStripMenuItem MnuShiftTransaction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripStock;
        private System.Windows.Forms.ToolStripMenuItem MnuStmas;
        private System.Windows.Forms.ToolStripMenuItem MnuPrice;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSetup;
        private System.Windows.Forms.ToolStripMenuItem MnuShift;
        private System.Windows.Forms.ToolStripMenuItem MnuTank;
        private System.Windows.Forms.ToolStripMenuItem MnuNozzle;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

