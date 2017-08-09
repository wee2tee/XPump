using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using System.Threading;
using CC;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormIslog : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingList<islogVM> islogs;
        private int? focused_id;
        private DateTime? condLogDateFrom = null;
        private DateTime? condLogDateTo = null;
        private string condLogCode = string.Empty;
        private string condLogData = string.Empty;
        private string condLogModule = string.Empty;
        private string condLogUser = string.Empty;
        private SORT sort;
        private enum SORT
        {
            ASC,
            DESC
        }

        public FormIslog(MainForm main_form)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
        }

        private void FormIslog_Load(object sender, EventArgs e)
        {
            this.ResetControlState(FORM_MODE.READ_ITEM);
            this.sort = SORT.DESC;
            
            this.btnRefresh.PerformClick();
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

        private List<islog> GetPreviousLog(int? start_id = null, int take_item = 20)
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

        private List<islog> GetNextLog(int? start_id = null, int take_item = 20)
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                if (!start_id.HasValue)
                {
                    var logs = sec.islog.OrderBy(i => i.id).Take(take_item).ToList();
                    return logs;
                }
                else
                {
                    var logs = sec.islog.OrderBy(i => i.id).Where(i => i.id > start_id.Value).Take(take_item).ToList();
                    return logs;
                }
            }
        }

        private List<dynamic> GetLogByCondition(DateTime? logDateFrom = null, DateTime? logDateTo = null, string logCode = "", string logData = "", string logModule = "", string logUser = "")
        {
            List<dynamic> logs = new List<dynamic>();
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                string condition = string.Empty;
                condition += logCode.Trim().Length > 0 ? " logcode=\"" + logCode.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logData.Trim().Length > 0 ? " AND " : "";
                condition += logData.Trim().Length > 0 ? " expressdata=\"" + logData.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logModule.Trim().Length > 0 ? " AND " : "";
                condition += logModule.Trim().Length > 0 ? " modcod=\"" + logModule.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logUser.Trim().Length > 0 ? " AND " : "";
                condition += logUser.Trim().Length > 0 ? " username=\"" + logUser.Trim() + "\" " : "";

                if (logDateFrom.HasValue && logDateTo.HasValue)
                {
                    var from_date = logDateFrom.Value;
                    var to_date = logDateTo.Value.AddDays(1); // adding 1 day to support time suffix

                    if (condition.Trim().Length > 0)
                    {
                        logs = sec.islog.Where(i => i.cretime.CompareTo(from_date) >= 0 && i.cretime.CompareTo(to_date) < 0).Where(condition).ToViewModel().ToList<dynamic>();
                    }
                    else
                    {
                        logs = sec.islog.Where(i => i.cretime.CompareTo(from_date) >= 0 && i.cretime.CompareTo(to_date) < 0).ToViewModel().ToList<dynamic>();
                    }
                }
                else
                {
                    logs = condition.Trim().Length > 0 ? sec.islog.Where(condition).ToViewModel().ToList<dynamic>() : sec.islog.ToViewModel().ToList<dynamic>();
                }
            }
            return logs;
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
            this.btnSearchByDate.PerformClick();
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            DialogDateSelector d = new DialogDateSelector("ดูเหตุการณ์วันที่", DateTime.Now);
            if(d.ShowDialog() == DialogResult.OK)
            {
                List<dynamic> logs;
                using (xpumpsecureEntities sec = DBX.DataSecureSet())
                {
                    var date = d.selected_date.Date;
                    var next_date = d.selected_date.Date.AddDays(1);
                    logs = sec.islog.Where(i => i.cretime.CompareTo(date) >= 0 && i.cretime.CompareTo(next_date) < 0).ToViewModel().ToList<dynamic>();

                    List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn col in this.dgv.Columns.Cast<DataGridViewColumn>())
                    {
                        var c = (DataGridViewColumn)col.Clone();
                        c.DisplayIndex = ((DataGridViewColumn)col).DisplayIndex;
                        cols.Add(c);
                    }

                    cols.Where(c => c.Name == this.col_description.Name).First().MinimumWidth = 300;

                    DialogInquiry inq = new DialogInquiry(logs, cols, cols.Where(c => c.Name == this.col_cretime.Name).First(), null, false, this.main_form.c_info);
                    inq.ShowDialog();
                }
            }
        }

        private void btnSearchByCondition_Click(object sender, EventArgs e)
        {
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser);
            if(cond.ShowDialog() == DialogResult.OK)
            {
                this.condLogDateFrom = cond.logDateFrom;
                this.condLogDateTo = cond.logDateTo;
                this.condLogCode = cond.logCode;
                this.condLogData = cond.logData;
                this.condLogModule = cond.logModule;
                this.condLogUser = cond.logUserName;

                List<dynamic> logs = this.GetLogByCondition(this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser);
                logs = this.sort == SORT.DESC ? logs.OrderBy(l => l.id).ToList<dynamic>() : logs.OrderByDescending(l => l.id).ToList<dynamic>();

                List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn col in this.dgv.Columns.Cast<DataGridViewColumn>())
                {
                    var c = (DataGridViewColumn)col.Clone();
                    c.DisplayIndex = ((DataGridViewColumn)col).DisplayIndex;
                    cols.Add(c);
                }

                cols.Where(c => c.Name == this.col_description.Name).First().MinimumWidth = 300;

                DialogInquiry inq = new DialogInquiry(logs, cols, cols.Where(c => c.Name == this.col_cretime.Name).First(), null, false, this.main_form.c_info);
                inq.ShowDialog();
            }
        }

        private void btnPrint_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            //DialogDateRangeSelector d = new DialogDateRangeSelector(this.main_form, false, false, DateTime.Now, DateTime.Now);
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, "", "", "", "", true, false);

            if(cond.ShowDialog() == DialogResult.OK)
            {
                using (xpumpsecureEntities sec = DBX.DataSecureSet())
                {
                    var from_date = cond.logDateFrom.Value;
                    var to_date = cond.logDateTo.Value.AddDays(1); // plus 1 day to support time(suffix)
                    List<islogVM> logs = sec.islog.Where(i => i.cretime.CompareTo(from_date) >= 0 && i.cretime.CompareTo(to_date) < 0).ToViewModel();

                    /* Perform print */
                    //this.PerformPrint(logs, d.print)
                }
            }
        }

        private void btnPrintCondition_Click(object sender, EventArgs e)
        {
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser, true);
            if (cond.ShowDialog() == DialogResult.OK)
            {
                this.condLogDateFrom = cond.logDateFrom;
                this.condLogDateTo = cond.logDateTo;
                this.condLogCode = cond.logCode;
                this.condLogData = cond.logData;
                this.condLogModule = cond.logModule;
                this.condLogUser = cond.logUserName;

                List<dynamic> logs = this.GetLogByCondition(this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser);
                //logs = this.sort == SORT.DESC ? logs.OrderBy(l => l.id).ToList<dynamic>() : logs.OrderByDescending(l => l.id).ToList<dynamic>();

                /* Perform print */
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.focused_id = null;
            if(this.sort == SORT.DESC)
            {
                this.islogs = new BindingList<islogVM>(this.GetPreviousLog(null, 1).ToViewModel());
            }
            else
            {
                this.islogs = new BindingList<islogVM>(this.GetNextLog(null, 1).ToViewModel());
            }
            this.dgv.DataSource = this.islogs;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (this.islogs.Count > 0 && this.focused_id == null)
            //    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_logcode.Name].Selected = true;
            
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            var d = this.islogs;

            this.focused_id = (int?)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_id.Name].Value;

            if (((XDatagrid)sender).CurrentCell.RowIndex == 0)
            {
                int curr_id = (int)((XDatagrid)sender).Rows[0].Cells[this.col_id.Name].Value;

                if (this.sort == SORT.DESC) // DESC
                {
                    foreach (var item in this.GetPreviousLog(curr_id, 20).ToViewModel().OrderByDescending(i => i.id))
                    {
                        this.islogs.Insert(0, item);
                    }
                }
                else if(this.sort == SORT.ASC) // ASC
                {
                    foreach (var item in this.GetNextLog(curr_id, 20).ToViewModel().OrderBy(i => i.id))
                    {
                        this.islogs.Insert(0, item);
                    }
                }
                
                ((XDatagrid)sender).FirstDisplayedScrollingRowIndex = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == curr_id).First().Index;
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_cretime.Name).First().Index)
                {
                    Console.WriteLine(" ==>> cretime columns is clicked");
                    this.sort = this.sort == SORT.DESC ? SORT.ASC : SORT.DESC;
                    this.btnRefresh.PerformClick();
                }
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_cretime.Name).First().Index)
            {
                e.CellStyle.BackColor = Color.Tan;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                if(this.sort == SORT.DESC)
                {
                    using (SolidBrush brush = new SolidBrush(Color.SaddleBrown))
                    {
                        PointF p1 = new PointF(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 18);
                        PointF p2 = new PointF(p1.X + 10, p1.Y);
                        PointF p3 = new PointF(e.CellBounds.X + e.CellBounds.Width - 13, e.CellBounds.Y + 10);
                        e.Graphics.FillPolygon(brush, new PointF[] { p1, p2, p3 });
                        e.Graphics.DrawPolygon(new Pen(Color.WhiteSmoke), new PointF[] { p1, p2, p3 });
                    }
                }
                else if(this.sort == SORT.ASC)
                {
                    using (SolidBrush brush = new SolidBrush(Color.SaddleBrown))
                    {
                        PointF p1 = new PointF(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 10);
                        PointF p2 = new PointF(p1.X + 10, p1.Y);
                        PointF p3 = new PointF(e.CellBounds.X + e.CellBounds.Width - 13, e.CellBounds.Y + 18);
                        e.Graphics.FillPolygon(brush, new PointF[] { p1, p2, p3 });
                        e.Graphics.DrawPolygon(new Pen(Color.WhiteSmoke), new PointF[] { p1, p2, p3 });
                    }
                }

                e.Handled = true;
            }
        }

        private void PerformPrint()
        {

        }
    }
}
