namespace XPump.SubForm
{
    partial class FormIslog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIslog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_logcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_expressdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xpumpdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xpumpuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_modcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_docnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_islog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSearchByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearchByCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrintAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnUnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnApproveMulti = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
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
            this.btnSearch,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator4,
            this.btnItem,
            this.btnApprove,
            this.btnUnApprove,
            this.btnApproveMulti,
            this.btnRefresh});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // dgv
            // 
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_cretime,
            this.col_logcode,
            this.col_expressdata,
            this.col_xpumpdata,
            this.col_xpumpuser,
            this.col_modcod,
            this.col_docnum,
            this.col_description,
            this.col_username,
            this.col_islog});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            resources.ApplyResources(this.col_id, "col_id");
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_cretime
            // 
            this.col_cretime.DataPropertyName = "cretime";
            dataGridViewCellStyle5.Format = "dd/MM/yy HH:mm:ss";
            dataGridViewCellStyle5.NullValue = null;
            this.col_cretime.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.col_cretime, "col_cretime");
            this.col_cretime.Name = "col_cretime";
            this.col_cretime.ReadOnly = true;
            // 
            // col_logcode
            // 
            this.col_logcode.DataPropertyName = "logcode";
            resources.ApplyResources(this.col_logcode, "col_logcode");
            this.col_logcode.Name = "col_logcode";
            this.col_logcode.ReadOnly = true;
            // 
            // col_expressdata
            // 
            this.col_expressdata.DataPropertyName = "expressdata";
            resources.ApplyResources(this.col_expressdata, "col_expressdata");
            this.col_expressdata.Name = "col_expressdata";
            this.col_expressdata.ReadOnly = true;
            // 
            // col_xpumpdata
            // 
            this.col_xpumpdata.DataPropertyName = "xpumpdata";
            resources.ApplyResources(this.col_xpumpdata, "col_xpumpdata");
            this.col_xpumpdata.Name = "col_xpumpdata";
            this.col_xpumpdata.ReadOnly = true;
            // 
            // col_xpumpuser
            // 
            this.col_xpumpuser.DataPropertyName = "xpumpuser";
            resources.ApplyResources(this.col_xpumpuser, "col_xpumpuser");
            this.col_xpumpuser.Name = "col_xpumpuser";
            this.col_xpumpuser.ReadOnly = true;
            // 
            // col_modcod
            // 
            this.col_modcod.DataPropertyName = "modcod";
            resources.ApplyResources(this.col_modcod, "col_modcod");
            this.col_modcod.Name = "col_modcod";
            this.col_modcod.ReadOnly = true;
            // 
            // col_docnum
            // 
            this.col_docnum.DataPropertyName = "docnum";
            resources.ApplyResources(this.col_docnum, "col_docnum");
            this.col_docnum.Name = "col_docnum";
            this.col_docnum.ReadOnly = true;
            // 
            // col_description
            // 
            this.col_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_description.DataPropertyName = "description";
            resources.ApplyResources(this.col_description, "col_description");
            this.col_description.Name = "col_description";
            this.col_description.ReadOnly = true;
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "username";
            resources.ApplyResources(this.col_username, "col_username");
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            // 
            // col_islog
            // 
            this.col_islog.DataPropertyName = "islog";
            resources.ApplyResources(this.col_islog, "col_islog");
            this.col_islog.Name = "col_islog";
            this.col_islog.ReadOnly = true;
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.Name = "btnStop";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
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
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownButtonWidth = 12;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchByDate,
            this.btnSearchByCondition});
            this.btnSearch.Image = global::XPump.Properties.Resources.search;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_ButtonClick);
            // 
            // btnSearchByDate
            // 
            resources.ApplyResources(this.btnSearchByDate, "btnSearchByDate");
            this.btnSearchByDate.Name = "btnSearchByDate";
            this.btnSearchByDate.Click += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // btnSearchByCondition
            // 
            resources.ApplyResources(this.btnSearchByCondition, "btnSearchByCondition");
            this.btnSearchByCondition.Name = "btnSearchByCondition";
            this.btnSearchByCondition.Click += new System.EventHandler(this.btnSearchByCondition_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.DropDownButtonWidth = 12;
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintAll,
            this.btnPrintCondition});
            this.btnPrint.Image = global::XPump.Properties.Resources.printer;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ButtonClick += new System.EventHandler(this.btnPrint_ButtonClick);
            // 
            // btnPrintAll
            // 
            resources.ApplyResources(this.btnPrintAll, "btnPrintAll");
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrintCondition
            // 
            resources.ApplyResources(this.btnPrintCondition, "btnPrintCondition");
            this.btnPrintCondition.Name = "btnPrintCondition";
            this.btnPrintCondition.Click += new System.EventHandler(this.btnPrintCondition_Click);
            // 
            // btnItem
            // 
            resources.ApplyResources(this.btnItem, "btnItem");
            this.btnItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            // 
            // btnApprove
            // 
            resources.ApplyResources(this.btnApprove, "btnApprove");
            this.btnApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApprove.Image = global::XPump.Properties.Resources.approve;
            this.btnApprove.Name = "btnApprove";
            // 
            // btnUnApprove
            // 
            resources.ApplyResources(this.btnUnApprove, "btnUnApprove");
            this.btnUnApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnApprove.Image = global::XPump.Properties.Resources.unapprove;
            this.btnUnApprove.Name = "btnUnApprove";
            // 
            // btnApproveMulti
            // 
            resources.ApplyResources(this.btnApproveMulti, "btnApproveMulti");
            this.btnApproveMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApproveMulti.Image = global::XPump.Properties.Resources.approve_multiple;
            this.btnApproveMulti.Name = "btnApproveMulti";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormIslog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "FormIslog";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormIslog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnUnApprove;
        private System.Windows.Forms.ToolStripButton btnApproveMulti;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnSearchByDate;
        private System.Windows.Forms.ToolStripMenuItem btnSearchByCondition;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintAll;
        private System.Windows.Forms.ToolStripMenuItem btnPrintCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_logcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_expressdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xpumpdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xpumpuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_modcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_docnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_islog;
    }
}