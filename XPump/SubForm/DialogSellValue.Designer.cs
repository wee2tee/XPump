namespace XPump.SubForm
{
    partial class DialogSellValue
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
            this.cNozzle = new CC.XDropdownList();
            this.cAmount = new CC.XNumEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSellDate = new System.Windows.Forms.Label();
            this.lblStkdes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cNozzle
            // 
            this.cNozzle._ReadOnly = false;
            this.cNozzle._SelectedItem = null;
            this.cNozzle._Text = "";
            this.cNozzle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cNozzle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cNozzle.Location = new System.Drawing.Point(165, 136);
            this.cNozzle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cNozzle.Name = "cNozzle";
            this.cNozzle.Size = new System.Drawing.Size(127, 23);
            this.cNozzle.TabIndex = 1;
            this.cNozzle._SelectedItemChanged += new System.EventHandler(this.cNozzle__SelectedItemChanged);
            // 
            // cAmount
            // 
            this.cAmount._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cAmount._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cAmount._DecimalDigit = 0;
            this.cAmount._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.cAmount._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.cAmount._MaxLength = 30;
            this.cAmount._ReadOnly = false;
            this.cAmount._SelectionLength = 0;
            this.cAmount._SelectionStart = 1;
            this.cAmount._Text = "0";
            this.cAmount._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cAmount._UseThoundsandSeparate = true;
            this.cAmount._Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cAmount.BackColor = System.Drawing.Color.White;
            this.cAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cAmount.Location = new System.Drawing.Point(165, 109);
            this.cAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cAmount.Name = "cAmount";
            this.cAmount.Size = new System.Drawing.Size(127, 23);
            this.cAmount.TabIndex = 0;
            this.cAmount._ValueChanged += new System.EventHandler(this.cAmount__ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "หัวจ่าย";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "จำนวนเงินรวม";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(125, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(238, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 34);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชนิดน้ำมัน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "วันที่จำหน่าย";
            // 
            // lblSellDate
            // 
            this.lblSellDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSellDate.Location = new System.Drawing.Point(164, 22);
            this.lblSellDate.Name = "lblSellDate";
            this.lblSellDate.Size = new System.Drawing.Size(117, 21);
            this.lblSellDate.TabIndex = 4;
            this.lblSellDate.Text = "_selldate";
            this.lblSellDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStkdes
            // 
            this.lblStkdes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStkdes.Location = new System.Drawing.Point(164, 48);
            this.lblStkdes.Name = "lblStkdes";
            this.lblStkdes.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblStkdes.Size = new System.Drawing.Size(276, 44);
            this.lblStkdes.TabIndex = 4;
            this.lblStkdes.Text = "_stkdes";
            // 
            // DialogSellValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 238);
            this.Controls.Add(this.lblStkdes);
            this.Controls.Add(this.lblSellDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cAmount);
            this.Controls.Add(this.cNozzle);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogSellValue";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ป้อนมูลค่าขายสินค้า";
            this.Load += new System.EventHandler(this.DialogSellValue_Load);
            this.Shown += new System.EventHandler(this.DialogSellValue_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CC.XDropdownList cNozzle;
        private CC.XNumEdit cAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSellDate;
        private System.Windows.Forms.Label lblStkdes;
    }
}