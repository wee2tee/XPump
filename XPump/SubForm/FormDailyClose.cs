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
        private List<dayend> dayend;
        private DateTime? curr_date;

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
            this.bs.DataSource = this.dayend.ToViewModel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDateSelector dlg = new DialogDateSelector("วันที่ปิดยอดขาย", DateTime.Now);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        foreach (stmas st in db.stmas.ToList())
                        {
                            dayendVM d = new dayend()
                            {
                                id = -1,
                                stmas_id = st.id,
                                dothertxt = string.Empty,
                                saldat = dlg.selected_date,

                            }.ToViewModel();
                            db.dayend.Add(d.dayend);
                            db.SaveChanges();

                            var sections = db.section.Include("tank").Where(s => s.stmas_id == st.id)
                                            .Where(s => s.tank.isactive)
                                            .Where(s => s.tank.startdate.CompareTo(dlg.selected_date) <= 0)
                                            .Where(s => !s.tank.enddate.HasValue || s.tank.enddate.Value.CompareTo(dlg.selected_date) >= 0).ToList();

                            foreach (var sect in sections)
                            {
                                var shiftsales = db.shiftsales.Include("shiftsttak").Where(s => s.saldat == dlg.selected_date)
                                                .OrderByDescending(s => s.cretime).FirstOrDefault();

                                decimal qty;
                                if(shiftsales != null)
                                {
                                    qty = shiftsales.shiftsttak.Where(s => s.section_id == sect.id).FirstOrDefault() != null ? shiftsales.shiftsttak.Where(s => s.section_id == sect.id).First().qty : -1;
                                }
                                else
                                {
                                    qty = -1;
                                }

                                db.daysttak.Add(new daysttak
                                {
                                    dayend_id = d.dayend.id,
                                    qty = qty,
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
                    this.dayend = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend = new List<dayend>();
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
                        this.dayend = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        this.curr_date = null;
                        this.dayend = new List<dayend>();
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
                        this.dayend = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        this.curr_date = null;
                        this.dayend = new List<dayend>();
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
                    this.dayend = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend = new List<dayend>();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_date.HasValue)
            {
                this.dayend = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
            }
        }
    }
}
