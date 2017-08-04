using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using System.Threading;
using CC;

namespace XPump.SubForm
{
    public partial class FormIslog : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingList<islogVM> islogs;

        public FormIslog(MainForm main_form)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
        }

        private void FormIslog_Load(object sender, EventArgs e)
        {
            this.ResetControlState(FORM_MODE.READ_ITEM);
            this.islogs = new BindingList<islogVM>(this.GetLog(null, 300).ToViewModel());
            this.dgv.DataSource = this.islogs;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnPrint.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
        }

        private List<islog> GetLog(int? start_id = null, int take_item = 5)
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                if (!start_id.HasValue)
                {
                    var logs = sec.islog.OrderByDescending(i => i.id).Take(take_item).ToList();
                    return logs.OrderBy(i => i.id).ToList();
                }
                else
                {
                    var logs = sec.islog.OrderByDescending(i => i.id).Where(i => i.id < start_id.Value).Take(take_item).ToList();
                    return logs.OrderBy(i => i.id).ToList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchByCondition_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintCondition_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.islogs = new BindingList<islogVM>(this.GetLog(null, 300).ToViewModel());
            this.dgv.DataSource = this.islogs;
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            //{

            //    if (e.OldValue < e.NewValue) // scroll down
            //        return;

            //    var first_display_row_index = ((XDatagrid)sender).FirstDisplayedScrollingRowIndex;
            //    var first_id = this.islogs.OrderBy(i => i.id).First().id;

            //    if ((int)((XDatagrid)sender).Rows[first_display_row_index].Cells[this.col_id.Name].Value == first_id)
            //    {
            //        foreach (var item in this.GetLog(first_id, 5).ToViewModel().OrderByDescending(i => i.id))
            //        {
            //            this.islogs.Insert(0, item);
            //        }
            //    }
            //}
            int curr_row_index = ((XDatagrid)sender).CurrentCell.RowIndex;
            if(curr_row_index > 0)
            {
                ((XDatagrid)sender).Rows[curr_row_index - 1].Cells[this.col_logcode.Name].Selected = true;
            }
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (this.islogs.Count > 0)
            //    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_logcode.Name].Selected = true;
        }
    }
}
