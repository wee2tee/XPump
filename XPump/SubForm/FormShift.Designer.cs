namespace XPump.SubForm
{
    partial class FormShift
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShift));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnChangeCode = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_siv = new CC.XDropdownList();
            this.inline_shs = new CC.XDropdownList();
            this.inline_sai = new CC.XDropdownList();
            this.inline_prr = new CC.XDropdownList();
            this.inline_php = new CC.XDropdownList();
            this.inline_pae = new CC.XDropdownList();
            this.inline_end = new CC.XTimePicker();
            this.inline_start = new CC.XTimePicker();
            this.inline_desc = new CC.XTextEdit();
            this.inline_name = new CC.XTextEdit();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paeprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phpprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_prrprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_saiprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shsprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sivprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
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
            this.btnChangeCode,
            this.btnRefresh});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::XPump.Properties.Resources.first;
            resources.ApplyResources(this.btnFirst, "btnFirst");
            this.btnFirst.Name = "btnFirst";
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::XPump.Properties.Resources.previous;
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.Name = "btnPrevious";
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::XPump.Properties.Resources.next;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::XPump.Properties.Resources.last;
            resources.ApplyResources(this.btnLast, "btnLast");
            this.btnLast.Name = "btnLast";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnChangeCode
            // 
            this.btnChangeCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChangeCode.Image = global::XPump.Properties.Resources.rename;
            resources.ApplyResources(this.btnChangeCode, "btnChangeCode");
            this.btnChangeCode.Margin = new System.Windows.Forms.Padding(2, 1, 1, 2);
            this.btnChangeCode.Name = "btnChangeCode";
            this.btnChangeCode.Click += new System.EventHandler(this.btnChangeCode_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inline_siv);
            this.panel1.Controls.Add(this.inline_shs);
            this.panel1.Controls.Add(this.inline_sai);
            this.panel1.Controls.Add(this.inline_prr);
            this.panel1.Controls.Add(this.inline_php);
            this.panel1.Controls.Add(this.inline_pae);
            this.panel1.Controls.Add(this.inline_end);
            this.panel1.Controls.Add(this.inline_start);
            this.panel1.Controls.Add(this.inline_desc);
            this.panel1.Controls.Add(this.inline_name);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.dgv);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // inline_siv
            // 
            this.inline_siv._ReadOnly = false;
            this.inline_siv._SelectedItem = null;
            this.inline_siv._Text = "";
            this.inline_siv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_siv, "inline_siv");
            this.inline_siv.Name = "inline_siv";
            this.inline_siv._SelectedItemChanged += new System.EventHandler(this.inline_siv__SelectedItemChanged);
            // 
            // inline_shs
            // 
            this.inline_shs._ReadOnly = false;
            this.inline_shs._SelectedItem = null;
            this.inline_shs._Text = "";
            this.inline_shs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_shs, "inline_shs");
            this.inline_shs.Name = "inline_shs";
            this.inline_shs._SelectedItemChanged += new System.EventHandler(this.inline_shs__SelectedItemChanged);
            // 
            // inline_sai
            // 
            this.inline_sai._ReadOnly = false;
            this.inline_sai._SelectedItem = null;
            this.inline_sai._Text = "";
            this.inline_sai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_sai, "inline_sai");
            this.inline_sai.Name = "inline_sai";
            this.inline_sai._SelectedItemChanged += new System.EventHandler(this.inline_sai__SelectedItemChanged);
            // 
            // inline_prr
            // 
            this.inline_prr._ReadOnly = false;
            this.inline_prr._SelectedItem = null;
            this.inline_prr._Text = "";
            this.inline_prr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_prr, "inline_prr");
            this.inline_prr.Name = "inline_prr";
            this.inline_prr._SelectedItemChanged += new System.EventHandler(this.inline_prr__SelectedItemChanged);
            // 
            // inline_php
            // 
            this.inline_php._ReadOnly = false;
            this.inline_php._SelectedItem = null;
            this.inline_php._Text = "";
            this.inline_php.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_php, "inline_php");
            this.inline_php.Name = "inline_php";
            this.inline_php._SelectedItemChanged += new System.EventHandler(this.inline_php__SelectedItemChanged);
            // 
            // inline_pae
            // 
            this.inline_pae._ReadOnly = false;
            this.inline_pae._SelectedItem = null;
            this.inline_pae._Text = "";
            this.inline_pae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.inline_pae, "inline_pae");
            this.inline_pae.Name = "inline_pae";
            this.inline_pae._SelectedItemChanged += new System.EventHandler(this.inline_pae__SelectedItemChanged);
            // 
            // inline_end
            // 
            resources.ApplyResources(this.inline_end, "inline_end");
            this.inline_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inline_end.Name = "inline_end";
            this.inline_end.ShowUpDown = true;
            this.inline_end.ValueChanged += new System.EventHandler(this.inline_end_ValueChanged);
            // 
            // inline_start
            // 
            resources.ApplyResources(this.inline_start, "inline_start");
            this.inline_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inline_start.Name = "inline_start";
            this.inline_start.ShowUpDown = true;
            this.inline_start.ValueChanged += new System.EventHandler(this.inline_start_ValueChanged);
            // 
            // inline_desc
            // 
            this.inline_desc._BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inline_desc._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_desc._MaxLength = 50;
            this.inline_desc._ReadOnly = false;
            this.inline_desc._Text = "";
            this.inline_desc._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_desc.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.inline_desc, "inline_desc");
            this.inline_desc.Name = "inline_desc";
            this.inline_desc._TextChanged += new System.EventHandler(this.inline_desc__TextChanged);
            // 
            // inline_name
            // 
            this.inline_name._BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inline_name._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_name._MaxLength = 20;
            this.inline_name._ReadOnly = false;
            this.inline_name._Text = "";
            this.inline_name._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_name.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.inline_name, "inline_name");
            this.inline_name.Name = "inline_name";
            this.inline_name._TextChanged += new System.EventHandler(this.inline_name__TextChanged);
            this.inline_name._Leave += new System.EventHandler(this.inline_name__Leave);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::XPump.Properties.Resources.up_16;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::XPump.Properties.Resources.down_16;
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Name = "btnDown";
            this.toolTip1.SetToolTip(this.btnDown, resources.GetString("btnDown.ToolTip"));
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = true;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_seq,
            this.col_name,
            this.col_start,
            this.col_end,
            this.col_desc,
            this.col_paeprefix,
            this.col_phpprefix,
            this.col_prrprefix,
            this.col_saiprefix,
            this.col_shsprefix,
            this.col_sivprefix,
            this.col_remark,
            this.col_state,
            this.col_shift,
            this.col_working_express_db,
            this.col_creby,
            this.col_cretime,
            this.col_chgby,
            this.col_chgtime});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.StandardTab = true;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            resources.ApplyResources(this.col_id, "col_id");
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_seq
            // 
            this.col_seq.DataPropertyName = "seq";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_seq.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.col_seq, "col_seq");
            this.col_seq.Name = "col_seq";
            this.col_seq.ReadOnly = true;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "name";
            resources.ApplyResources(this.col_name, "col_name");
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // col_start
            // 
            this.col_start.DataPropertyName = "starttime";
            dataGridViewCellStyle3.NullValue = null;
            this.col_start.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.col_start, "col_start");
            this.col_start.Name = "col_start";
            this.col_start.ReadOnly = true;
            // 
            // col_end
            // 
            this.col_end.DataPropertyName = "endtime";
            dataGridViewCellStyle4.NullValue = null;
            this.col_end.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.col_end, "col_end");
            this.col_end.Name = "col_end";
            this.col_end.ReadOnly = true;
            // 
            // col_desc
            // 
            this.col_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_desc.DataPropertyName = "description";
            resources.ApplyResources(this.col_desc, "col_desc");
            this.col_desc.Name = "col_desc";
            this.col_desc.ReadOnly = true;
            // 
            // col_paeprefix
            // 
            this.col_paeprefix.DataPropertyName = "paeprefix";
            resources.ApplyResources(this.col_paeprefix, "col_paeprefix");
            this.col_paeprefix.Name = "col_paeprefix";
            this.col_paeprefix.ReadOnly = true;
            // 
            // col_phpprefix
            // 
            this.col_phpprefix.DataPropertyName = "phpprefix";
            resources.ApplyResources(this.col_phpprefix, "col_phpprefix");
            this.col_phpprefix.Name = "col_phpprefix";
            this.col_phpprefix.ReadOnly = true;
            // 
            // col_prrprefix
            // 
            this.col_prrprefix.DataPropertyName = "prrprefix";
            resources.ApplyResources(this.col_prrprefix, "col_prrprefix");
            this.col_prrprefix.Name = "col_prrprefix";
            this.col_prrprefix.ReadOnly = true;
            // 
            // col_saiprefix
            // 
            this.col_saiprefix.DataPropertyName = "saiprefix";
            resources.ApplyResources(this.col_saiprefix, "col_saiprefix");
            this.col_saiprefix.Name = "col_saiprefix";
            this.col_saiprefix.ReadOnly = true;
            // 
            // col_shsprefix
            // 
            this.col_shsprefix.DataPropertyName = "shsprefix";
            resources.ApplyResources(this.col_shsprefix, "col_shsprefix");
            this.col_shsprefix.Name = "col_shsprefix";
            this.col_shsprefix.ReadOnly = true;
            // 
            // col_sivprefix
            // 
            this.col_sivprefix.DataPropertyName = "sivprefix";
            resources.ApplyResources(this.col_sivprefix, "col_sivprefix");
            this.col_sivprefix.Name = "col_sivprefix";
            this.col_sivprefix.ReadOnly = true;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "remark";
            resources.ApplyResources(this.col_remark, "col_remark");
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "record_state";
            resources.ApplyResources(this.col_state, "col_state");
            this.col_state.Name = "col_state";
            this.col_state.ReadOnly = true;
            // 
            // col_shift
            // 
            this.col_shift.DataPropertyName = "shift";
            resources.ApplyResources(this.col_shift, "col_shift");
            this.col_shift.Name = "col_shift";
            this.col_shift.ReadOnly = true;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            resources.ApplyResources(this.col_working_express_db, "col_working_express_db");
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            // 
            // col_creby
            // 
            this.col_creby.DataPropertyName = "creby";
            resources.ApplyResources(this.col_creby, "col_creby");
            this.col_creby.Name = "col_creby";
            this.col_creby.ReadOnly = true;
            // 
            // col_cretime
            // 
            this.col_cretime.DataPropertyName = "cretime";
            resources.ApplyResources(this.col_cretime, "col_cretime");
            this.col_cretime.Name = "col_cretime";
            this.col_cretime.ReadOnly = true;
            // 
            // col_chgby
            // 
            this.col_chgby.DataPropertyName = "chgby";
            resources.ApplyResources(this.col_chgby, "col_chgby");
            this.col_chgby.Name = "col_chgby";
            this.col_chgby.ReadOnly = true;
            // 
            // col_chgtime
            // 
            this.col_chgtime.DataPropertyName = "chgtime";
            resources.ApplyResources(this.col_chgtime, "col_chgtime");
            this.col_chgtime.Name = "col_chgtime";
            this.col_chgtime.ReadOnly = true;
            // 
            // FormShift
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "FormShift";
            this.ShowIcon = false;
            this.Tag = "ShiftSetup";
            this.Load += new System.EventHandler(this.ShiftForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Panel panel1;
        private CC.XTimePicker inline_end;
        private CC.XTimePicker inline_start;
        private CC.XTextEdit inline_desc;
        private CC.XTextEdit inline_name;
        private CC.XDropdownList inline_siv;
        private CC.XDropdownList inline_shs;
        private CC.XDropdownList inline_sai;
        private CC.XDropdownList inline_prr;
        private CC.XDropdownList inline_php;
        private CC.XDropdownList inline_pae;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paeprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phpprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prrprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_saiprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shsprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sivprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgtime;
        private System.Windows.Forms.ToolStripButton btnChangeCode;
    }
}