namespace XPump.SubForm
{
    partial class DialogSellQty
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
            this.lblStkdes = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cQty = new CC.XNumEdit();
            this.SuspendLayout();
            // 
            // lblStkdes
            // 
            this.lblStkdes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStkdes.Location = new System.Drawing.Point(119, 24);
            this.lblStkdes.Name = "lblStkdes";
            this.lblStkdes.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblStkdes.Size = new System.Drawing.Size(276, 44);
            this.lblStkdes.TabIndex = 13;
            this.lblStkdes.Text = "_stkdes";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 34);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(103, 129);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 34);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ตกลง <F5>";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "จำนวน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "สินค้า";
            // 
            // cQty
            // 
            this.cQty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cQty._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cQty._DecimalDigit = 2;
            this.cQty._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.cQty._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.cQty._MaxLength = 30;
            this.cQty._ReadOnly = false;
            this.cQty._SelectionLength = 0;
            this.cQty._SelectionStart = 4;
            this.cQty._Text = "0.00";
            this.cQty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cQty._UseThoundsandSeparate = true;
            this.cQty._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.cQty.BackColor = System.Drawing.Color.White;
            this.cQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cQty.Location = new System.Drawing.Point(120, 74);
            this.cQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cQty.Name = "cQty";
            this.cQty.Size = new System.Drawing.Size(127, 23);
            this.cQty.TabIndex = 6;
            this.cQty._ValueChanged += new System.EventHandler(this.cQty__ValueChanged);
            // 
            // DialogSellQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 180);
            this.Controls.Add(this.lblStkdes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cQty);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSellQty";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ป้อนจำนวนขายสินค้า";
            this.Load += new System.EventHandler(this.DialogSellQty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStkdes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CC.XNumEdit cQty;
    }
}