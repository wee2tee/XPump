namespace XPump.SubForm
{
    partial class DialogSettings
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseExpressData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrgname = new CC.XTextEdit();
            this.txtExpressData = new CC.XTextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditMysqlConnection = new System.Windows.Forms.Button();
            this.lblNotConnect = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnSave,
            this.btnStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(542, 43);
            this.toolStrip1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "ที่เก็บข้อมูลโปรแกรม Express";
            // 
            // btnBrowseExpressData
            // 
            this.btnBrowseExpressData.Location = new System.Drawing.Point(463, 35);
            this.btnBrowseExpressData.Name = "btnBrowseExpressData";
            this.btnBrowseExpressData.Size = new System.Drawing.Size(28, 25);
            this.btnBrowseExpressData.TabIndex = 3;
            this.btnBrowseExpressData.Text = "...";
            this.btnBrowseExpressData.UseVisualStyleBackColor = true;
            this.btnBrowseExpressData.Click += new System.EventHandler(this.btnBrowseExpressData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "ชื่อสถานีบริการน้ำมัน";
            // 
            // txtOrgname
            // 
            this.txtOrgname._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname._MaxLength = 32767;
            this.txtOrgname._ReadOnly = false;
            this.txtOrgname._Text = "";
            this.txtOrgname._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOrgname.BackColor = System.Drawing.Color.White;
            this.txtOrgname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOrgname.Location = new System.Drawing.Point(204, 9);
            this.txtOrgname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrgname.Name = "txtOrgname";
            this.txtOrgname.Size = new System.Drawing.Size(287, 23);
            this.txtOrgname.TabIndex = 1;
            this.txtOrgname._TextChanged += new System.EventHandler(this.txtOrgname__TextChanged);
            this.txtOrgname._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // txtExpressData
            // 
            this.txtExpressData._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpressData._MaxLength = 32767;
            this.txtExpressData._ReadOnly = true;
            this.txtExpressData._Text = "";
            this.txtExpressData._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtExpressData.BackColor = System.Drawing.Color.White;
            this.txtExpressData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpressData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtExpressData.Location = new System.Drawing.Point(204, 36);
            this.txtExpressData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExpressData.Name = "txtExpressData";
            this.txtExpressData.Size = new System.Drawing.Size(260, 23);
            this.txtExpressData.TabIndex = 2;
            this.txtExpressData._TextChanged += new System.EventHandler(this.txtExpressData__TextChanged);
            this.txtExpressData._DoubleClicked += new System.EventHandler(this.txtExpressData__DoubleClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "กำหนดการเชื่อมต่อฐานข้อมูล MySql";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = ":";
            // 
            // btnEditMysqlConnection
            // 
            this.btnEditMysqlConnection.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEditMysqlConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditMysqlConnection.Location = new System.Drawing.Point(341, 64);
            this.btnEditMysqlConnection.Name = "btnEditMysqlConnection";
            this.btnEditMysqlConnection.Padding = new System.Windows.Forms.Padding(3);
            this.btnEditMysqlConnection.Size = new System.Drawing.Size(178, 30);
            this.btnEditMysqlConnection.TabIndex = 8;
            this.btnEditMysqlConnection.Text = "แก้ไขการเชื่อมต่อ MySql";
            this.btnEditMysqlConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditMysqlConnection.UseVisualStyleBackColor = true;
            this.btnEditMysqlConnection.Click += new System.EventHandler(this.btnEditMysqlConnection_Click);
            // 
            // lblNotConnect
            // 
            this.lblNotConnect.Image = global::XPump.Properties.Resources.exclaimation_16;
            this.lblNotConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotConnect.Location = new System.Drawing.Point(230, 71);
            this.lblNotConnect.Name = "lblNotConnect";
            this.lblNotConnect.Size = new System.Drawing.Size(110, 16);
            this.lblNotConnect.TabIndex = 7;
            this.lblNotConnect.Text = "ไม่มีการเชื่อมต่อ";
            this.lblNotConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConnected
            // 
            this.lblConnected.Image = global::XPump.Properties.Resources.ok_16;
            this.lblConnected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConnected.Location = new System.Drawing.Point(230, 71);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(94, 16);
            this.lblConnected.TabIndex = 7;
            this.lblConnected.Text = "เชื่อมต่อแล้ว";
            this.lblConnected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConnected.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(36, 40);
            this.btnEdit.Text = "แก้ไขข้อมูล <Alt+E>";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "บันทึกข้อมูล <F9>";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "ยกเลิกการแก้ไขข้อมูล <Esc>";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOrgname);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnBrowseExpressData);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtExpressData);
            this.panel1.Location = new System.Drawing.Point(17, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 71);
            this.panel1.TabIndex = 9;
            // 
            // DialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 198);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditMysqlConnection);
            this.Controls.Add(this.lblNotConnect);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตั้งค่าระบบ";
            this.Load += new System.EventHandler(this.DialogSettings_Load);
            this.Shown += new System.EventHandler(this.DialogSettings_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label label1;
        private CC.XTextEdit txtExpressData;
        private System.Windows.Forms.Button btnBrowseExpressData;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtOrgname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditMysqlConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label lblNotConnect;
        private System.Windows.Forms.Panel panel1;
    }
}