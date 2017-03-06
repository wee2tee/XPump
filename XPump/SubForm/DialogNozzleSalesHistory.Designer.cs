namespace XPump.SubForm
{
    partial class DialogNozzleSalesHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_saldat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mitbeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mitend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unitpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pricelist_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salessummary_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_saleshistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 24;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_saldat,
            this.col_tank_name,
            this.col_section_name,
            this.col_nozzle_name,
            this.col_shift_name,
            this.col_mitbeg,
            this.col_mitend,
            this.col_salqty,
            this.col_unitpr,
            this.col_salval,
            this.col_shift_id,
            this.col_nozzle_id,
            this.col_stmas_id,
            this.col_pricelist_id,
            this.col_salessummary_id,
            this.col_price_date,
            this.col_stkcod,
            this.col_stkdes,
            this.col_saleshistory});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(714, 194);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_saldat
            // 
            this.col_saldat.DataPropertyName = "saldat";
            this.col_saldat.HeaderText = "วันที่";
            this.col_saldat.MinimumWidth = 80;
            this.col_saldat.Name = "col_saldat";
            this.col_saldat.ReadOnly = true;
            this.col_saldat.Visible = false;
            this.col_saldat.Width = 80;
            // 
            // col_tank_name
            // 
            this.col_tank_name.DataPropertyName = "tank_name";
            this.col_tank_name.HeaderText = "Tank Name";
            this.col_tank_name.Name = "col_tank_name";
            this.col_tank_name.ReadOnly = true;
            this.col_tank_name.Visible = false;
            // 
            // col_section_name
            // 
            this.col_section_name.DataPropertyName = "section_name";
            this.col_section_name.HeaderText = "Section Name";
            this.col_section_name.Name = "col_section_name";
            this.col_section_name.ReadOnly = true;
            this.col_section_name.Visible = false;
            // 
            // col_nozzle_name
            // 
            this.col_nozzle_name.DataPropertyName = "nozzle_name";
            this.col_nozzle_name.HeaderText = "เลขที่หัวจ่าย";
            this.col_nozzle_name.Name = "col_nozzle_name";
            this.col_nozzle_name.ReadOnly = true;
            this.col_nozzle_name.Visible = false;
            // 
            // col_shift_name
            // 
            this.col_shift_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_shift_name.DataPropertyName = "shift_name";
            this.col_shift_name.HeaderText = "ผลัด";
            this.col_shift_name.MinimumWidth = 80;
            this.col_shift_name.Name = "col_shift_name";
            this.col_shift_name.ReadOnly = true;
            // 
            // col_mitbeg
            // 
            this.col_mitbeg.DataPropertyName = "mitbeg";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_mitbeg.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_mitbeg.HeaderText = "มิเตอร์เริ่มต้น";
            this.col_mitbeg.MinimumWidth = 120;
            this.col_mitbeg.Name = "col_mitbeg";
            this.col_mitbeg.ReadOnly = true;
            this.col_mitbeg.Width = 120;
            // 
            // col_mitend
            // 
            this.col_mitend.DataPropertyName = "mitend";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_mitend.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_mitend.HeaderText = "มิเตอร์สิ้นสุด";
            this.col_mitend.MinimumWidth = 120;
            this.col_mitend.Name = "col_mitend";
            this.col_mitend.ReadOnly = true;
            this.col_mitend.Width = 120;
            // 
            // col_salqty
            // 
            this.col_salqty.DataPropertyName = "salqty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_salqty.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_salqty.HeaderText = "ปริมาณขาย(ลิตร)";
            this.col_salqty.MinimumWidth = 130;
            this.col_salqty.Name = "col_salqty";
            this.col_salqty.ReadOnly = true;
            this.col_salqty.Width = 130;
            // 
            // col_unitpr
            // 
            this.col_unitpr.DataPropertyName = "unitpr";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_unitpr.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_unitpr.HeaderText = "ราคาขาย/ลิตร";
            this.col_unitpr.MinimumWidth = 120;
            this.col_unitpr.Name = "col_unitpr";
            this.col_unitpr.ReadOnly = true;
            this.col_unitpr.Width = 120;
            // 
            // col_salval
            // 
            this.col_salval.DataPropertyName = "salval";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_salval.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_salval.HeaderText = "มูลค่าขาย(บาท)";
            this.col_salval.MinimumWidth = 120;
            this.col_salval.Name = "col_salval";
            this.col_salval.ReadOnly = true;
            this.col_salval.Width = 120;
            // 
            // col_shift_id
            // 
            this.col_shift_id.DataPropertyName = "shift_id";
            this.col_shift_id.HeaderText = "Shift Id";
            this.col_shift_id.Name = "col_shift_id";
            this.col_shift_id.ReadOnly = true;
            this.col_shift_id.Visible = false;
            // 
            // col_nozzle_id
            // 
            this.col_nozzle_id.DataPropertyName = "nozzle_id";
            this.col_nozzle_id.HeaderText = "Nozzle Id";
            this.col_nozzle_id.Name = "col_nozzle_id";
            this.col_nozzle_id.ReadOnly = true;
            this.col_nozzle_id.Visible = false;
            // 
            // col_stmas_id
            // 
            this.col_stmas_id.DataPropertyName = "stmas_id";
            this.col_stmas_id.HeaderText = "Stmas Id";
            this.col_stmas_id.Name = "col_stmas_id";
            this.col_stmas_id.ReadOnly = true;
            this.col_stmas_id.Visible = false;
            // 
            // col_pricelist_id
            // 
            this.col_pricelist_id.DataPropertyName = "pricelist_id";
            this.col_pricelist_id.HeaderText = "Price List Id";
            this.col_pricelist_id.Name = "col_pricelist_id";
            this.col_pricelist_id.ReadOnly = true;
            this.col_pricelist_id.Visible = false;
            // 
            // col_salessummary_id
            // 
            this.col_salessummary_id.DataPropertyName = "salessummary_id";
            this.col_salessummary_id.HeaderText = "Sales Summary Id";
            this.col_salessummary_id.Name = "col_salessummary_id";
            this.col_salessummary_id.ReadOnly = true;
            this.col_salessummary_id.Visible = false;
            // 
            // col_price_date
            // 
            this.col_price_date.DataPropertyName = "price_date";
            this.col_price_date.HeaderText = "Price Date";
            this.col_price_date.Name = "col_price_date";
            this.col_price_date.ReadOnly = true;
            this.col_price_date.Visible = false;
            // 
            // col_stkcod
            // 
            this.col_stkcod.DataPropertyName = "stkcod";
            this.col_stkcod.HeaderText = "Stkcod";
            this.col_stkcod.Name = "col_stkcod";
            this.col_stkcod.ReadOnly = true;
            this.col_stkcod.Visible = false;
            // 
            // col_stkdes
            // 
            this.col_stkdes.DataPropertyName = "stkdes";
            this.col_stkdes.HeaderText = "Stkdes";
            this.col_stkdes.Name = "col_stkdes";
            this.col_stkdes.ReadOnly = true;
            this.col_stkdes.Visible = false;
            // 
            // col_saleshistory
            // 
            this.col_saleshistory.DataPropertyName = "saleshistory";
            this.col_saleshistory.HeaderText = "Sales History";
            this.col_saleshistory.Name = "col_saleshistory";
            this.col_saleshistory.ReadOnly = true;
            this.col_saleshistory.Visible = false;
            // 
            // DialogNozzleSalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(714, 194);
            this.ControlBox = false;
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 200);
            this.MinimizeBox = false;
            this.Name = "DialogNozzleSalesHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.DialogNozzleSalesHistory_Deactivate);
            this.Load += new System.EventHandler(this.DialogNozzleSalesHistory_Load);
            this.Shown += new System.EventHandler(this.DialogNozzleSalesHistory_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CC.XDatagrid dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_saldat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mitbeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mitend;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unitpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salval;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pricelist_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salessummary_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_saleshistory;
    }
}