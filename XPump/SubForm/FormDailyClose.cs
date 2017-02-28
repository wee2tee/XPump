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
using CC;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormDailyClose : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingSource bs;
        private List<dayend> dayend_list;
        private DateTime? curr_date;
        private dayend curr_dayend;

        public FormDailyClose(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        private void DialogDailySummary_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.form_mode = FORM_MODE.READ;
            this.btnLast.PerformClick();
        }

        private List<dayend> GetDayEnd(DateTime date)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.dayend.Include("daysttak").Where(d => d.saldat == date).ToList();
            }
        }

        private void FillForm()
        {
            this.lblDate.Text = this.curr_date.HasValue ? this.curr_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : string.Empty;

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.dayend_list.ToViewModel();
        }

        private void ShowDayendEditDialog(dayend dayend)
        {
            DialogDayendEdit dlg = new DialogDayendEdit(this.main_form, this.curr_dayend);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("edited");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDateSelector dlg = new DialogDateSelector("วันที่ปิดยอดขาย", DateTime.Now);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    if(db.dayend.Where(d => d.saldat == dlg.selected_date).Count() > 0)
                    {
                        MessageBox.Show("วันที่ \"" + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" ปิดยอดขายไปแล้ว, ไม่สามารถปิดซ้ำได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    try
                    {
                        var stmas_ids = db.salessummary.Where(s => s.saldat == dlg.selected_date)
                                        .GroupBy(s => s.stmas_id)
                                        .Select(s => s.Key).ToArray();

                        foreach (int stmas_id in stmas_ids)
                        {
                            dayendVM d = new dayend()
                            {
                                id = -1,
                                stmas_id = stmas_id,
                                dothertxt = string.Empty,
                                saldat = dlg.selected_date,

                            }.ToViewModel();
                            db.dayend.Add(d.dayend);
                            db.SaveChanges();

                            var sections = db.section.Where(s => s.stmas_id == stmas_id).ToList();

                            foreach (var sect in sections)
                            {
                                //var shiftsales = db.shiftsales.Include("shiftsttak").Where(s => s.saldat == dlg.selected_date)
                                //                .OrderByDescending(s => s.cretime).FirstOrDefault();

                                //decimal qty;
                                //if(shiftsales != null)
                                //{
                                //    qty = shiftsales.shiftsttak.Where(s => s.section_id == sect.id).FirstOrDefault() != null ? shiftsales.shiftsttak.Where(s => s.section_id == sect.id).First().qty : -1;
                                //}
                                //else
                                //{
                                //    qty = -1;
                                //}
                                
                                shiftsttak sttak = db.shiftsttak.Where(s => s.takdat == dlg.selected_date)
                                            .Where(s => s.section_id == sect.id)
                                            .Where(s => s.qty > -1).FirstOrDefault();


                                db.daysttak.Add(new daysttak
                                {
                                    dayend_id = d.dayend.id,
                                    qty = sttak != null ? sttak.qty : -1,
                                    section_id = sect.id
                                });
                                db.SaveChanges();

                                foreach (shiftsales sales in db.shiftsales.Where(s => s.saldat == dlg.selected_date).ToList())
                                {
                                    sales.closed = true;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.curr_date = dlg.selected_date;
                this.btnRefresh.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var tmp = db.dayend.OrderBy(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderByDescending(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) < 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        this.curr_date = null;
                        this.dayend_list = new List<dayend>();
                    }

                    this.FillForm();
                }
                else
                {
                    this.btnFirst.PerformClick();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderBy(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) > 0).FirstOrDefault();

                    if (tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        this.curr_date = null;
                        this.dayend_list = new List<dayend>();
                    }

                    this.FillForm();
                }
                else
                {
                    this.btnFirst.PerformClick();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var tmp = db.dayend.OrderByDescending(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintB_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintC_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_date.HasValue)
            {
                this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            dayend tmp = (dayend)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_dayend.Name].Value;

            if (this.curr_dayend == null)
            {
                this.curr_dayend = tmp;
            }
            else
            {
                if(this.curr_dayend.id != tmp.id)
                {
                    this.curr_dayend = tmp;
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.ShowDayendEditDialog(this.curr_dayend);
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.ShowDayendEditDialog(this.curr_dayend);
                };
                cm.MenuItems.Add(mnu_edit);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }
    }
}
