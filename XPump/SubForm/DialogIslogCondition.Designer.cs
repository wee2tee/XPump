namespace XPump.SubForm
{
    partial class DialogIslogCondition
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAllDate = new System.Windows.Forms.CheckBox();
            this.chkAllCode = new System.Windows.Forms.CheckBox();
            this.chkAllData = new System.Windows.Forms.CheckBox();
            this.chkAllModule = new System.Windows.Forms.CheckBox();
            this.chkAllUser = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelPrintOutput = new System.Windows.Forms.GroupBox();
            this.radPrinter = new System.Windows.Forms.RadioButton();
            this.radScreen = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogUser = new CC.XTextEdit();
            this.txtLogModule = new CC.XTextEdit();
            this.txtLogData = new CC.XTextEdit();
            this.txtLogCode = new CC.XTextEdit();
            this.dtLogDateTo = new CC.XDatePicker();
            this.dtLogDateFrom = new CC.XDatePicker();
            this.panelPrintOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Date  =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Log Code  =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Express Data  =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Module  =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "User Name  =";
            // 
            // chkAllDate
            // 
            this.chkAllDate.AutoSize = true;
            this.chkAllDate.Checked = true;
            this.chkAllDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkAllDate.Location = new System.Drawing.Point(134, 24);
            this.chkAllDate.Name = "chkAllDate";
            this.chkAllDate.Size = new System.Drawing.Size(41, 20);
            this.chkAllDate.TabIndex = 0;
            this.chkAllDate.Text = "All";
            this.chkAllDate.UseVisualStyleBackColor = true;
            this.chkAllDate.CheckedChanged += new System.EventHandler(this.chkAllDate_CheckedChanged);
            // 
            // chkAllCode
            // 
            this.chkAllCode.AutoSize = true;
            this.chkAllCode.Checked = true;
            this.chkAllCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkAllCode.Location = new System.Drawing.Point(134, 52);
            this.chkAllCode.Name = "chkAllCode";
            this.chkAllCode.Size = new System.Drawing.Size(41, 20);
            this.chkAllCode.TabIndex = 3;
            this.chkAllCode.Text = "All";
            this.chkAllCode.UseVisualStyleBackColor = true;
            this.chkAllCode.CheckedChanged += new System.EventHandler(this.chkAllLog_CheckedChanged);
            // 
            // chkAllData
            // 
            this.chkAllData.AutoSize = true;
            this.chkAllData.Checked = true;
            this.chkAllData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkAllData.Location = new System.Drawing.Point(134, 80);
            this.chkAllData.Name = "chkAllData";
            this.chkAllData.Size = new System.Drawing.Size(41, 20);
            this.chkAllData.TabIndex = 5;
            this.chkAllData.Text = "All";
            this.chkAllData.UseVisualStyleBackColor = true;
            this.chkAllData.CheckedChanged += new System.EventHandler(this.chkAllData_CheckedChanged);
            // 
            // chkAllModule
            // 
            this.chkAllModule.AutoSize = true;
            this.chkAllModule.Checked = true;
            this.chkAllModule.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllModule.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkAllModule.Location = new System.Drawing.Point(134, 108);
            this.chkAllModule.Name = "chkAllModule";
            this.chkAllModule.Size = new System.Drawing.Size(41, 20);
            this.chkAllModule.TabIndex = 7;
            this.chkAllModule.Text = "All";
            this.chkAllModule.UseVisualStyleBackColor = true;
            this.chkAllModule.CheckedChanged += new System.EventHandler(this.chkAllModule_CheckedChanged);
            // 
            // chkAllUser
            // 
            this.chkAllUser.AutoSize = true;
            this.chkAllUser.Checked = true;
            this.chkAllUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkAllUser.Location = new System.Drawing.Point(134, 136);
            this.chkAllUser.Name = "chkAllUser";
            this.chkAllUser.Size = new System.Drawing.Size(41, 20);
            this.chkAllUser.TabIndex = 9;
            this.chkAllUser.Text = "All";
            this.chkAllUser.UseVisualStyleBackColor = true;
            this.chkAllUser.CheckedChanged += new System.EventHandler(this.chkAllUser_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(293, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(374, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panelPrintOutput
            // 
            this.panelPrintOutput.Controls.Add(this.radPrinter);
            this.panelPrintOutput.Controls.Add(this.radScreen);
            this.panelPrintOutput.Location = new System.Drawing.Point(28, 167);
            this.panelPrintOutput.Name = "panelPrintOutput";
            this.panelPrintOutput.Size = new System.Drawing.Size(173, 87);
            this.panelPrintOutput.TabIndex = 12;
            this.panelPrintOutput.TabStop = false;
            this.panelPrintOutput.Text = "แสดงผลทาง";
            this.panelPrintOutput.Visible = false;
            // 
            // radPrinter
            // 
            this.radPrinter.AutoSize = true;
            this.radPrinter.Enabled = false;
            this.radPrinter.Location = new System.Drawing.Point(22, 51);
            this.radPrinter.Name = "radPrinter";
            this.radPrinter.Size = new System.Drawing.Size(84, 20);
            this.radPrinter.TabIndex = 12;
            this.radPrinter.TabStop = true;
            this.radPrinter.Text = "เครื่องพิมพ์";
            this.radPrinter.UseVisualStyleBackColor = true;
            this.radPrinter.CheckedChanged += new System.EventHandler(this.radPrinter_CheckedChanged);
            // 
            // radScreen
            // 
            this.radScreen.AutoSize = true;
            this.radScreen.Enabled = false;
            this.radScreen.Location = new System.Drawing.Point(22, 25);
            this.radScreen.Name = "radScreen";
            this.radScreen.Size = new System.Drawing.Size(64, 20);
            this.radScreen.TabIndex = 11;
            this.radScreen.TabStop = true;
            this.radScreen.Text = "จอภาพ";
            this.radScreen.UseVisualStyleBackColor = true;
            this.radScreen.CheckedChanged += new System.EventHandler(this.radScreen_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "To";
            // 
            // txtLogUser
            // 
            this.txtLogUser._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogUser._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLogUser._MaxLength = 32767;
            this.txtLogUser._ReadOnly = true;
            this.txtLogUser._Text = "";
            this.txtLogUser._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLogUser.BackColor = System.Drawing.Color.White;
            this.txtLogUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLogUser.Location = new System.Drawing.Point(174, 133);
            this.txtLogUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogUser.Name = "txtLogUser";
            this.txtLogUser.Size = new System.Drawing.Size(275, 23);
            this.txtLogUser.TabIndex = 10;
            this.txtLogUser._TextChanged += new System.EventHandler(this.txtLogUser__TextChanged);
            // 
            // txtLogModule
            // 
            this.txtLogModule._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogModule._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLogModule._MaxLength = 32767;
            this.txtLogModule._ReadOnly = true;
            this.txtLogModule._Text = "";
            this.txtLogModule._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLogModule.BackColor = System.Drawing.Color.White;
            this.txtLogModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogModule.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLogModule.Location = new System.Drawing.Point(174, 105);
            this.txtLogModule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogModule.Name = "txtLogModule";
            this.txtLogModule.Size = new System.Drawing.Size(275, 23);
            this.txtLogModule.TabIndex = 8;
            this.txtLogModule._TextChanged += new System.EventHandler(this.txtLogModule__TextChanged);
            // 
            // txtLogData
            // 
            this.txtLogData._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogData._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLogData._MaxLength = 32767;
            this.txtLogData._ReadOnly = true;
            this.txtLogData._Text = "";
            this.txtLogData._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLogData.BackColor = System.Drawing.Color.White;
            this.txtLogData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLogData.Location = new System.Drawing.Point(174, 77);
            this.txtLogData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogData.Name = "txtLogData";
            this.txtLogData.Size = new System.Drawing.Size(275, 23);
            this.txtLogData.TabIndex = 6;
            this.txtLogData._TextChanged += new System.EventHandler(this.txtLogData__TextChanged);
            // 
            // txtLogCode
            // 
            this.txtLogCode._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogCode._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLogCode._MaxLength = 32767;
            this.txtLogCode._ReadOnly = true;
            this.txtLogCode._Text = "";
            this.txtLogCode._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLogCode.BackColor = System.Drawing.Color.White;
            this.txtLogCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLogCode.Location = new System.Drawing.Point(174, 49);
            this.txtLogCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogCode.Name = "txtLogCode";
            this.txtLogCode.Size = new System.Drawing.Size(275, 23);
            this.txtLogCode.TabIndex = 4;
            this.txtLogCode._TextChanged += new System.EventHandler(this.txtLogCode__TextChanged);
            // 
            // dtLogDateTo
            // 
            this.dtLogDateTo._ReadOnly = true;
            this.dtLogDateTo._SelectedDate = null;
            this.dtLogDateTo.BackColor = System.Drawing.Color.White;
            this.dtLogDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtLogDateTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtLogDateTo.Location = new System.Drawing.Point(346, 21);
            this.dtLogDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtLogDateTo.Name = "dtLogDateTo";
            this.dtLogDateTo.Size = new System.Drawing.Size(103, 23);
            this.dtLogDateTo.TabIndex = 2;
            this.dtLogDateTo._SelectedDateChanged += new System.EventHandler(this.dtLogDateTo__SelectedDateChanged);
            // 
            // dtLogDateFrom
            // 
            this.dtLogDateFrom._ReadOnly = true;
            this.dtLogDateFrom._SelectedDate = null;
            this.dtLogDateFrom.BackColor = System.Drawing.Color.White;
            this.dtLogDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtLogDateFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtLogDateFrom.Location = new System.Drawing.Point(213, 21);
            this.dtLogDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtLogDateFrom.Name = "dtLogDateFrom";
            this.dtLogDateFrom.Size = new System.Drawing.Size(103, 23);
            this.dtLogDateFrom.TabIndex = 1;
            this.dtLogDateFrom._SelectedDateChanged += new System.EventHandler(this.dtLogDateFrom__SelectedDateChanged);
            // 
            // DialogIslogCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 274);
            this.Controls.Add(this.panelPrintOutput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLogUser);
            this.Controls.Add(this.txtLogModule);
            this.Controls.Add(this.txtLogData);
            this.Controls.Add(this.txtLogCode);
            this.Controls.Add(this.dtLogDateTo);
            this.Controls.Add(this.dtLogDateFrom);
            this.Controls.Add(this.chkAllUser);
            this.Controls.Add(this.chkAllModule);
            this.Controls.Add(this.chkAllData);
            this.Controls.Add(this.chkAllCode);
            this.Controls.Add(this.chkAllDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogIslogCondition";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กำหนดเงื่อนไข";
            this.Load += new System.EventHandler(this.DialogIslogCondition_Load);
            this.panelPrintOutput.ResumeLayout(false);
            this.panelPrintOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAllDate;
        private System.Windows.Forms.CheckBox chkAllCode;
        private System.Windows.Forms.CheckBox chkAllData;
        private System.Windows.Forms.CheckBox chkAllModule;
        private System.Windows.Forms.CheckBox chkAllUser;
        private CC.XDatePicker dtLogDateFrom;
        private CC.XTextEdit txtLogCode;
        private CC.XTextEdit txtLogData;
        private CC.XTextEdit txtLogModule;
        private CC.XTextEdit txtLogUser;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox panelPrintOutput;
        private System.Windows.Forms.RadioButton radPrinter;
        private System.Windows.Forms.RadioButton radScreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CC.XDatePicker dtLogDateTo;
    }
}