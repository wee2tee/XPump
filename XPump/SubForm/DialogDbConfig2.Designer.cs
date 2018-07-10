namespace XPump.SubForm
{
    partial class DialogDbConfig2
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbDepcod = new System.Windows.Forms.ComboBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.btnDefaultPort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.txtConfPwd = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(257, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Image = global::XPump.Properties.Resources.save_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(167, 272);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnOK.Size = new System.Drawing.Size(84, 34);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "บันทึก";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cbDepcod
            // 
            this.cbDepcod.FormattingEnabled = true;
            this.cbDepcod.Location = new System.Drawing.Point(198, 55);
            this.cbDepcod.Name = "cbDepcod";
            this.cbDepcod.Size = new System.Drawing.Size(64, 24);
            this.cbDepcod.TabIndex = 35;
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(198, 114);
            this.txtDbName.MaxLength = 20;
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(249, 23);
            this.txtDbName.TabIndex = 37;
            // 
            // btnDefaultPort
            // 
            this.btnDefaultPort.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnDefaultPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDefaultPort.Location = new System.Drawing.Point(300, 142);
            this.btnDefaultPort.Name = "btnDefaultPort";
            this.btnDefaultPort.Size = new System.Drawing.Size(148, 25);
            this.btnDefaultPort.TabIndex = 50;
            this.btnDefaultPort.Text = "ใช้พอร์ทมาตรฐาน (3306)";
            this.btnDefaultPort.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(104, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "ยืนยันรหัสผ่าน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(98, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "หมายเลขพอร์ท";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(136, 204);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 16);
            this.label22.TabIndex = 44;
            this.label22.Text = "รหัสผ่าน";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(116, 175);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 45;
            this.label23.Text = "รหัสผู้ใช้งาน";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(111, 117);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 16);
            this.label24.TabIndex = 46;
            this.label24.Text = "ชื่อฐานข้อมูล";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(126, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "รหัสแผนก";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "ชื่อสถานีบริการฯ (สาขา)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(112, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(76, 16);
            this.label25.TabIndex = 48;
            this.label25.Text = "ชื่อเซิร์ฟเวอร์";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(198, 143);
            this.numPort.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(100, 23);
            this.numPort.TabIndex = 38;
            this.numPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // txtConfPwd
            // 
            this.txtConfPwd.Location = new System.Drawing.Point(198, 230);
            this.txtConfPwd.Name = "txtConfPwd";
            this.txtConfPwd.PasswordChar = '*';
            this.txtConfPwd.Size = new System.Drawing.Size(249, 23);
            this.txtConfPwd.TabIndex = 41;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(198, 201);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(249, 23);
            this.txtPwd.TabIndex = 40;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(198, 172);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(249, 23);
            this.txtUserId.TabIndex = 39;
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(198, 26);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(249, 23);
            this.txtBranch.TabIndex = 34;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(198, 85);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(249, 23);
            this.txtServerName.TabIndex = 36;
            // 
            // DialogDbConfig2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 321);
            this.Controls.Add(this.cbDepcod);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.btnDefaultPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.txtConfPwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogDbConfig2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เพิ่ม/แก้ไข สถานีบริการฯ (สาขา)";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbDepcod;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Button btnDefaultPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TextBox txtConfPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtServerName;
    }
}