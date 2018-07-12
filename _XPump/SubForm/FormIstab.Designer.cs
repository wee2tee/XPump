namespace XPump.SubForm
{
    partial class FormIstab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIstab));
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_isdayend = new CC.XDropdownList();
            this.inline_isshiftsales = new CC.XDropdownList();
            this.inline_typdes2 = new CC.XTextEdit();
            this.inline_typdes = new CC.XTextEdit();
            this.inline_shortnam2 = new CC.XTextEdit();
            this.inline_shortnam = new CC.XTextEdit();
            this.inline_typcod = new CC.XTextEdit();
            this.dgv = new CC.XDatagrid();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_istab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tabtyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shortnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shortnam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typdes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_shiftsales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_dayend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnRefresh});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.Name = "btnStop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // btnFirst
            // 
            resources.ApplyResources(this.btnFirst, "btnFirst");
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::XPump.Properties.Resources.first;
            this.btnFirst.Name = "btnFirst";
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::XPump.Properties.Resources.previous;
            this.btnPrevious.Name = "btnPrevious";
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::XPump.Properties.Resources.next;
            this.btnNext.Name = "btnNext";
            // 
            // btnLast
            // 
            resources.ApplyResources(this.btnLast, "btnLast");
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::XPump.Properties.Resources.last;
            this.btnLast.Name = "btnLast";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.inline_isdayend);
            this.panel1.Controls.Add(this.inline_isshiftsales);
            this.panel1.Controls.Add(this.inline_typdes2);
            this.panel1.Controls.Add(this.inline_typdes);
            this.panel1.Controls.Add(this.inline_shortnam2);
            this.panel1.Controls.Add(this.inline_shortnam);
            this.panel1.Controls.Add(this.inline_typcod);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Name = "panel1";
            // 
            // inline_isdayend
            // 
            this.inline_isdayend._ReadOnly = false;
            this.inline_isdayend._SelectedItem = null;
            this.inline_isdayend._Text = "";
            resources.ApplyResources(this.inline_isdayend, "inline_isdayend");
            this.inline_isdayend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_isdayend.Name = "inline_isdayend";
            this.inline_isdayend._SelectedItemChanged += new System.EventHandler(this.inline_isdayend__SelectedItemChanged);
            // 
            // inline_isshiftsales
            // 
            this.inline_isshiftsales._ReadOnly = false;
            this.inline_isshiftsales._SelectedItem = null;
            this.inline_isshiftsales._Text = "";
            resources.ApplyResources(this.inline_isshiftsales, "inline_isshiftsales");
            this.inline_isshiftsales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_isshiftsales.Name = "inline_isshiftsales";
            this.inline_isshiftsales._SelectedItemChanged += new System.EventHandler(this.inline_isshiftsales__SelectedItemChanged);
            // 
            // inline_typdes2
            // 
            this.inline_typdes2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes2._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typdes2._MaxLength = 50;
            this.inline_typdes2._ReadOnly = false;
            this.inline_typdes2._Text = "";
            this.inline_typdes2._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.inline_typdes2, "inline_typdes2");
            this.inline_typdes2.BackColor = System.Drawing.Color.White;
            this.inline_typdes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes2.Name = "inline_typdes2";
            this.inline_typdes2._TextChanged += new System.EventHandler(this.inline_typdes2__TextChanged);
            // 
            // inline_typdes
            // 
            this.inline_typdes._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typdes._MaxLength = 50;
            this.inline_typdes._ReadOnly = false;
            this.inline_typdes._Text = "";
            this.inline_typdes._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.inline_typdes, "inline_typdes");
            this.inline_typdes.BackColor = System.Drawing.Color.White;
            this.inline_typdes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes.Name = "inline_typdes";
            this.inline_typdes._TextChanged += new System.EventHandler(this.inline_typdes__TextChanged);
            // 
            // inline_shortnam2
            // 
            this.inline_shortnam2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam2._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_shortnam2._MaxLength = 15;
            this.inline_shortnam2._ReadOnly = false;
            this.inline_shortnam2._Text = "";
            this.inline_shortnam2._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.inline_shortnam2, "inline_shortnam2");
            this.inline_shortnam2.BackColor = System.Drawing.Color.White;
            this.inline_shortnam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam2.Name = "inline_shortnam2";
            this.inline_shortnam2._TextChanged += new System.EventHandler(this.inline_shortnam2__TextChanged);
            // 
            // inline_shortnam
            // 
            this.inline_shortnam._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_shortnam._MaxLength = 15;
            this.inline_shortnam._ReadOnly = false;
            this.inline_shortnam._Text = "";
            this.inline_shortnam._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.inline_shortnam, "inline_shortnam");
            this.inline_shortnam.BackColor = System.Drawing.Color.White;
            this.inline_shortnam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam.Name = "inline_shortnam";
            this.inline_shortnam._TextChanged += new System.EventHandler(this.inline_shortnam__TextChanged);
            // 
            // inline_typcod
            // 
            this.inline_typcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typcod._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typcod._MaxLength = 4;
            this.inline_typcod._ReadOnly = false;
            this.inline_typcod._Text = "";
            this.inline_typcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.inline_typcod, "inline_typcod");
            this.inline_typcod.BackColor = System.Drawing.Color.White;
            this.inline_typcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typcod.Name = "inline_typcod";
            this.inline_typcod._TextChanged += new System.EventHandler(this.inline_typcod__TextChanged);
            // 
            // dgv
            // 
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_working_express_db,
            this.col_istab,
            this.col_id,
            this.col_tabtyp,
            this.col_typcod,
            this.col_shortnam,
            this.col_shortnam2,
            this.col_typdes,
            this.col_typdes2,
            this.col_is_shiftsales,
            this.col_is_dayend,
            this.col_creby,
            this.col_cretime,
            this.col_chgby,
            this.col_chgtime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            resources.ApplyResources(this.col_working_express_db, "col_working_express_db");
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            // 
            // col_istab
            // 
            this.col_istab.DataPropertyName = "istab";
            resources.ApplyResources(this.col_istab, "col_istab");
            this.col_istab.Name = "col_istab";
            this.col_istab.ReadOnly = true;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            resources.ApplyResources(this.col_id, "col_id");
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_tabtyp
            // 
            this.col_tabtyp.DataPropertyName = "tabtyp";
            resources.ApplyResources(this.col_tabtyp, "col_tabtyp");
            this.col_tabtyp.Name = "col_tabtyp";
            this.col_tabtyp.ReadOnly = true;
            // 
            // col_typcod
            // 
            this.col_typcod.DataPropertyName = "typcod";
            resources.ApplyResources(this.col_typcod, "col_typcod");
            this.col_typcod.Name = "col_typcod";
            this.col_typcod.ReadOnly = true;
            // 
            // col_shortnam
            // 
            this.col_shortnam.DataPropertyName = "shortnam";
            resources.ApplyResources(this.col_shortnam, "col_shortnam");
            this.col_shortnam.Name = "col_shortnam";
            this.col_shortnam.ReadOnly = true;
            // 
            // col_shortnam2
            // 
            this.col_shortnam2.DataPropertyName = "shortnam2";
            resources.ApplyResources(this.col_shortnam2, "col_shortnam2");
            this.col_shortnam2.Name = "col_shortnam2";
            this.col_shortnam2.ReadOnly = true;
            // 
            // col_typdes
            // 
            this.col_typdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_typdes.DataPropertyName = "typdes";
            resources.ApplyResources(this.col_typdes, "col_typdes");
            this.col_typdes.Name = "col_typdes";
            this.col_typdes.ReadOnly = true;
            // 
            // col_typdes2
            // 
            this.col_typdes2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_typdes2.DataPropertyName = "typdes2";
            resources.ApplyResources(this.col_typdes2, "col_typdes2");
            this.col_typdes2.Name = "col_typdes2";
            this.col_typdes2.ReadOnly = true;
            // 
            // col_is_shiftsales
            // 
            this.col_is_shiftsales.DataPropertyName = "is_shiftsales";
            resources.ApplyResources(this.col_is_shiftsales, "col_is_shiftsales");
            this.col_is_shiftsales.Name = "col_is_shiftsales";
            this.col_is_shiftsales.ReadOnly = true;
            // 
            // col_is_dayend
            // 
            this.col_is_dayend.DataPropertyName = "is_dayend";
            resources.ApplyResources(this.col_is_dayend, "col_is_dayend");
            this.col_is_dayend.Name = "col_is_dayend";
            this.col_is_dayend.ReadOnly = true;
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
            // FormIstab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "FormIstab";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormIstab_Load);
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
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private CC.XDatagrid dgv;
        private CC.XTextEdit inline_typdes2;
        private CC.XTextEdit inline_typdes;
        private CC.XTextEdit inline_shortnam2;
        private CC.XTextEdit inline_shortnam;
        private CC.XTextEdit inline_typcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_istab;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tabtyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shortnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shortnam2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typdes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_shiftsales;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_dayend;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgtime;
        private CC.XDropdownList inline_isdayend;
        private CC.XDropdownList inline_isshiftsales;
    }
}