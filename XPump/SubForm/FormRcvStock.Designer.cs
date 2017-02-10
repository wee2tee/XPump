namespace XPump.SubForm
{
    partial class FormRcvStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnInquiryAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInquiryRest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnItem = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inline_vatamt = new CC.XNumEdit();
            this.inline_trnval = new CC.XNumEdit();
            this.inline_trnqty = new CC.XNumEdit();
            this.inline_stkcod = new CC.XTextEdit();
            this.inline_section = new CC.XBrowseBox();
            this.dgv = new CC.XDatagrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVatnum = new CC.XTextEdit();
            this.dtRcvdat = new CC.XDatePicker();
            this.dtVatdat = new CC.XDatePicker();
            this.brSupcod = new CC.XBrowseBox();
            this.lblSupnam = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnStopItem = new System.Windows.Forms.Button();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.brShift = new CC.XBrowseBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnStop,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.toolStripSeparator2,
            this.btnSearch,
            this.toolStripSeparator4,
            this.btnItem,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(781, 43);
            this.toolStrip1.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 40);
            this.btnAdd.Text = "เพิ่มข้อมูล <Alt+A>";
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
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 40);
            this.btnDelete.Text = "ลบข้อมูล <Alt+D>";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "ยกเลิกการเพิ่ม/แก้ไขข้อมูล <Esc>";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "บันทึกข้อมูล <F9>";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::XPump.Properties.Resources.first;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(36, 40);
            this.btnFirst.Text = "ข้อมูลแรก <Ctrl+Home>";
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::XPump.Properties.Resources.previous;
            this.btnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 40);
            this.btnPrevious.Text = "ข้อมูลที่แล้ว <PageUp>";
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::XPump.Properties.Resources.next;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 40);
            this.btnNext.Text = "ข้อมูลถัดไป <PageDown>";
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::XPump.Properties.Resources.last;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(36, 40);
            this.btnLast.Text = "ข้อมูลสุดท้าย <Ctrl+End>";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownButtonWidth = 15;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInquiryAll,
            this.btnInquiryRest});
            this.btnSearch.Image = global::XPump.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 40);
            this.btnSearch.Text = "ค้นหา <Alt+S>";
            // 
            // btnInquiryAll
            // 
            this.btnInquiryAll.Name = "btnInquiryAll";
            this.btnInquiryAll.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryAll.Text = "เรียกดูข้อมูล ตั้งแต่ต้น <Ctrl+L>";
            // 
            // btnInquiryRest
            // 
            this.btnInquiryRest.Name = "btnInquiryRest";
            this.btnInquiryRest.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryRest.Text = "เรียกดูข้อมูล ตั้งแต่รายการนี้ <Alt+L>";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // btnItem
            // 
            this.btnItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(36, 40);
            this.btnItem.Text = "toolStripDropDownButton1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 40);
            this.btnRefresh.Text = "โหลดข้อมูลปัจจุบันใหม่ <Ctrl+F5>";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 407);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inline_vatamt);
            this.tabPage1.Controls.Add(this.inline_trnval);
            this.tabPage1.Controls.Add(this.inline_trnqty);
            this.tabPage1.Controls.Add(this.inline_stkcod);
            this.tabPage1.Controls.Add(this.inline_section);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายการรับสินค้า <F8>";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inline_vatamt
            // 
            this.inline_vatamt._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_vatamt._DecimalDigit = 2;
            this.inline_vatamt._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inline_vatamt._MaxLength = 30;
            this.inline_vatamt._ReadOnly = false;
            this.inline_vatamt._SelectionLength = 0;
            this.inline_vatamt._SelectionStart = 4;
            this.inline_vatamt._Text = "0.00";
            this.inline_vatamt._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_vatamt._UseThoundsandSeparate = true;
            this.inline_vatamt._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_vatamt.BackColor = System.Drawing.Color.White;
            this.inline_vatamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_vatamt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_vatamt.Location = new System.Drawing.Point(505, 58);
            this.inline_vatamt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_vatamt.Name = "inline_vatamt";
            this.inline_vatamt.Size = new System.Drawing.Size(98, 23);
            this.inline_vatamt.TabIndex = 3;
            // 
            // inline_trnval
            // 
            this.inline_trnval._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_trnval._DecimalDigit = 2;
            this.inline_trnval._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inline_trnval._MaxLength = 30;
            this.inline_trnval._ReadOnly = false;
            this.inline_trnval._SelectionLength = 0;
            this.inline_trnval._SelectionStart = 4;
            this.inline_trnval._Text = "0.00";
            this.inline_trnval._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_trnval._UseThoundsandSeparate = true;
            this.inline_trnval._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_trnval.BackColor = System.Drawing.Color.White;
            this.inline_trnval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_trnval.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_trnval.Location = new System.Drawing.Point(401, 58);
            this.inline_trnval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_trnval.Name = "inline_trnval";
            this.inline_trnval.Size = new System.Drawing.Size(98, 23);
            this.inline_trnval.TabIndex = 3;
            // 
            // inline_trnqty
            // 
            this.inline_trnqty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_trnqty._DecimalDigit = 2;
            this.inline_trnqty._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inline_trnqty._MaxLength = 30;
            this.inline_trnqty._ReadOnly = false;
            this.inline_trnqty._SelectionLength = 0;
            this.inline_trnqty._SelectionStart = 4;
            this.inline_trnqty._Text = "0.00";
            this.inline_trnqty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_trnqty._UseThoundsandSeparate = true;
            this.inline_trnqty._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_trnqty.BackColor = System.Drawing.Color.White;
            this.inline_trnqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_trnqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_trnqty.Location = new System.Drawing.Point(295, 58);
            this.inline_trnqty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_trnqty.Name = "inline_trnqty";
            this.inline_trnqty.Size = new System.Drawing.Size(98, 23);
            this.inline_trnqty.TabIndex = 3;
            // 
            // inline_stkcod
            // 
            this.inline_stkcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_stkcod._MaxLength = 32767;
            this.inline_stkcod._ReadOnly = false;
            this.inline_stkcod._Text = "";
            this.inline_stkcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_stkcod.BackColor = System.Drawing.Color.White;
            this.inline_stkcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_stkcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_stkcod.Location = new System.Drawing.Point(157, 63);
            this.inline_stkcod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_stkcod.Name = "inline_stkcod";
            this.inline_stkcod.Size = new System.Drawing.Size(90, 23);
            this.inline_stkcod.TabIndex = 2;
            // 
            // inline_section
            // 
            this.inline_section._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_section._ReadOnly = false;
            this.inline_section._Text = "";
            this.inline_section._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_section._UseImage = true;
            this.inline_section.BackColor = System.Drawing.Color.White;
            this.inline_section.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_section.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_section.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_section.Location = new System.Drawing.Point(14, 57);
            this.inline_section.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_section.Name = "inline_section";
            this.inline_section.Size = new System.Drawing.Size(118, 23);
            this.inline_section.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = false;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(761, 372);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "ผู้ค้าน้ำมัน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "วันที่รับสินค้า";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "เลขที่ใบจ่ายน้ำมัน/ใบกำกับภาษี";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "วันที่";
            // 
            // txtVatnum
            // 
            this.txtVatnum._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatnum._MaxLength = 32767;
            this.txtVatnum._ReadOnly = true;
            this.txtVatnum._Text = "";
            this.txtVatnum._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVatnum.BackColor = System.Drawing.Color.White;
            this.txtVatnum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatnum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVatnum.Location = new System.Drawing.Point(203, 140);
            this.txtVatnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVatnum.Name = "txtVatnum";
            this.txtVatnum.Size = new System.Drawing.Size(166, 23);
            this.txtVatnum.TabIndex = 7;
            // 
            // dtRcvdat
            // 
            this.dtRcvdat._ReadOnly = true;
            this.dtRcvdat._SelectedDate = null;
            this.dtRcvdat.BackColor = System.Drawing.Color.White;
            this.dtRcvdat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtRcvdat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtRcvdat.Location = new System.Drawing.Point(102, 84);
            this.dtRcvdat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtRcvdat.Name = "dtRcvdat";
            this.dtRcvdat.Size = new System.Drawing.Size(103, 23);
            this.dtRcvdat.TabIndex = 11;
            // 
            // dtVatdat
            // 
            this.dtVatdat._ReadOnly = true;
            this.dtVatdat._SelectedDate = null;
            this.dtVatdat.BackColor = System.Drawing.Color.White;
            this.dtVatdat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtVatdat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtVatdat.Location = new System.Drawing.Point(409, 141);
            this.dtVatdat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtVatdat.Name = "dtVatdat";
            this.dtVatdat.Size = new System.Drawing.Size(103, 23);
            this.dtVatdat.TabIndex = 11;
            // 
            // brSupcod
            // 
            this.brSupcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brSupcod._ReadOnly = true;
            this.brSupcod._Text = "";
            this.brSupcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.brSupcod._UseImage = true;
            this.brSupcod.BackColor = System.Drawing.Color.White;
            this.brSupcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brSupcod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.brSupcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.brSupcod.Location = new System.Drawing.Point(102, 110);
            this.brSupcod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brSupcod.Name = "brSupcod";
            this.brSupcod.Size = new System.Drawing.Size(145, 23);
            this.brSupcod.TabIndex = 13;
            // 
            // lblSupnam
            // 
            this.lblSupnam.AutoSize = true;
            this.lblSupnam.Location = new System.Drawing.Point(253, 113);
            this.lblSupnam.Name = "lblSupnam";
            this.lblSupnam.Size = new System.Drawing.Size(26, 16);
            this.lblSupnam.TabIndex = 8;
            this.lblSupnam.Text = "xxx";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddItem.Image = global::XPump.Properties.Resources.add_16;
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(423, 179);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(50, 24);
            this.btnAddItem.TabIndex = 14;
            this.btnAddItem.Text = "เพิ่ม";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteItem.Image = global::XPump.Properties.Resources.delete_16;
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(532, 179);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(45, 24);
            this.btnDeleteItem.TabIndex = 16;
            this.btnDeleteItem.Text = "ลบ";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            // 
            // btnEditItem
            // 
            this.btnEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEditItem.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditItem.Location = new System.Drawing.Point(474, 179);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(57, 24);
            this.btnEditItem.TabIndex = 15;
            this.btnEditItem.Text = "แก้ไข";
            this.btnEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // btnStopItem
            // 
            this.btnStopItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStopItem.Image = global::XPump.Properties.Resources.stop_16;
            this.btnStopItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopItem.Location = new System.Drawing.Point(649, 179);
            this.btnStopItem.Name = "btnStopItem";
            this.btnStopItem.Size = new System.Drawing.Size(129, 24);
            this.btnStopItem.TabIndex = 18;
            this.btnStopItem.Text = "ยกเลิกการเพิ่ม/แก้ไข";
            this.btnStopItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopItem.UseVisualStyleBackColor = true;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSaveItem.Image = global::XPump.Properties.Resources.save_16;
            this.btnSaveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveItem.Location = new System.Drawing.Point(588, 179);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(60, 24);
            this.btnSaveItem.TabIndex = 17;
            this.btnSaveItem.Text = "บันทึก";
            this.btnSaveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveItem.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ผลัด";
            // 
            // brShift
            // 
            this.brShift._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brShift._ReadOnly = true;
            this.brShift._Text = "";
            this.brShift._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.brShift._UseImage = true;
            this.brShift.BackColor = System.Drawing.Color.White;
            this.brShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brShift.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.brShift.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.brShift.Location = new System.Drawing.Point(102, 58);
            this.brShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brShift.Name = "brShift";
            this.brShift.Size = new System.Drawing.Size(145, 23);
            this.brShift.TabIndex = 13;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(253, 61);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(26, 16);
            this.lblShift.TabIndex = 8;
            this.lblShift.Text = "xxx";
            // 
            // FormRcvStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 590);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnStopItem);
            this.Controls.Add(this.btnSaveItem);
            this.Controls.Add(this.dtVatdat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.brShift);
            this.Controls.Add(this.brSupcod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtRcvdat);
            this.Controls.Add(this.txtVatnum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.lblSupnam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRcvStock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "บันทึกรายการรับเข้าน้ำมัน";
            this.Load += new System.EventHandler(this.FormRcvStock_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryAll;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryRest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnItem;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CC.XTextEdit txtVatnum;
        private CC.XDatePicker dtVatdat;
        private CC.XDatePicker dtRcvdat;
        private CC.XBrowseBox brSupcod;
        private System.Windows.Forms.Label lblSupnam;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnStopItem;
        private System.Windows.Forms.Button btnSaveItem;
        private CC.XBrowseBox inline_section;
        private CC.XNumEdit inline_vatamt;
        private CC.XNumEdit inline_trnval;
        private CC.XNumEdit inline_trnqty;
        private CC.XTextEdit inline_stkcod;
        private System.Windows.Forms.Label label2;
        private CC.XBrowseBox brShift;
        private System.Windows.Forms.Label lblShift;
    }
}