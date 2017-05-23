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
    public partial class DialogDayendEdit : Form
    {
        private MainForm main_form;
        private dayend curr_dayend;
        private daysttak tmp_sttak;
        private BindingSource bs;
        private FORM_MODE form_mode;

        public DialogDayendEdit(MainForm main_form, dayend curr_dayend)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.curr_dayend = curr_dayend;

            DbfTable.Isinfo(this.main_form.working_express_db);
            DbfTable.Apmas(this.main_form.working_express_db);
            DbfTable.Aptrn(this.main_form.working_express_db);
        }

        private void DialogDayendEdit_Load(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.FillForm();
            this.ActiveControl = this.dgv;
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

            this.DialogResult = DialogResult.OK;
            base.OnFormClosing(e);
        }

        private dayend GetDayEndData(dayend dayend)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                dayend de = db.dayend.Include("daysttak").Where(d => d.id == dayend.id).FirstOrDefault();

                if (de == null)
                {
                    MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return null;
                }
                else
                {
                    return de;
                }
            }
        }

        private void FillForm()
        {
            this.curr_dayend = this.GetDayEndData(this.curr_dayend);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.curr_dayend.daysttak.ToViewModel(this.main_form.working_express_db);

            this.RefreshSummary();
        }

        private void RefreshSummary()
        {
            dayendVM vm = this.curr_dayend.ToViewModel(this.main_form.working_express_db);
            this.curr_dayend.difqty = vm.GetDifQty();

            this.lblSaldat.Text = this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblStkcod.Text = this.curr_dayend.stkcod;
            this.lblStkdes.Text = vm.stkdes;
            this.lblEndbal.Text = string.Format("{0:#,#0.00}", vm.endbal);
            this.numBegbal._Value = this.curr_dayend.begbal;
            this.numRcvqty._Value = this.curr_dayend.rcvqty;
            this.numSalqty._Value = this.curr_dayend.salqty;
            this.lblDother.Text = string.Format("{0:#,#0.00}", vm.dother);
            this.lblAccbal.Text = string.Format("{0:#,#0.00}", vm.accbal);
            this.lblDifqty.Text = string.Format("{0:#,#0.00}", this.curr_dayend.difqty);
            this.numBegdif._Value = this.curr_dayend.begdif;
            this.lblTotalDif.Text = string.Format("{0:#,#0.00}", this.curr_dayend.begdif + this.curr_dayend.difqty);
        }

        private void ResetControlState()
        {
            this.inline_qty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.numBegbal.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numBegdif.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numSalqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnDother.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSyncRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnOK.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
        }

        private void ShowInlineForm(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_sttak = (daysttak)this.dgv.Rows[row_index].Cells[this.col_daysttak.Name].Value;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            this.inline_qty.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.inline_qty._Value = this.tmp_sttak.qty;
            //this.inline_qty.Visible = true;
            this.inline_qty.Focus();
        }

        private void RemoveInlineForm()
        {
            //this.inline_qty.Visible = false;
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
            this.tmp_sttak = null;
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();

            ((XNumEdit)sender).Focus();
        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_sttak != null)
            {
                this.tmp_sttak.qty = ((XNumEdit)sender)._Value;
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if(this.tmp_sttak != null)
            {
                if (this.SaveSttak(this.tmp_sttak))
                {
                    this.RemoveInlineForm();
                    this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);
                }
                else
                {
                    ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_sttak.id).First().Cells[this.col_section_name.Name].Selected = true;
                }
            }
        }

        private bool SaveSttak(daysttak sttak)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    var sttak_to_update = db.daysttak.Find(sttak.id);

                    if (sttak_to_update == null)
                    {
                        MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }

                    sttak_to_update.qty = sttak.qty;
                    sttak_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    sttak_to_update.chgtime = DateTime.Now;
                    db.SaveChanges();

                    this.curr_dayend.daysttak.Where(d => d.id == this.tmp_sttak.id).First().qty = this.tmp_sttak.qty;
                    this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_sttak.id).First().Cells[this.col_qty.Name].Value = this.tmp_sttak.qty;
                    this.RefreshSummary();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.form_mode = FORM_MODE.EDIT_ITEM;
                this.ResetControlState();
                this.ShowInlineForm(e.RowIndex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        dayend dayend_to_update = db.dayend.Find(this.curr_dayend.id);
                        if (dayend_to_update == null)
                        {
                            MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        dayend_to_update.rcvqty = this.curr_dayend.rcvqty;
                        dayend_to_update.salqty = this.curr_dayend.salqty;
                        dayend_to_update.begbal = this.curr_dayend.begbal;
                        dayend_to_update.begdif = this.curr_dayend.begdif;
                        dayend_to_update.difqty = this.curr_dayend.difqty;
                        dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        dayend_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.RefreshSummary();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return;
            }
            
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_sttak != null)
            {
                if (this.SaveSttak(this.tmp_sttak))
                {
                    this.RemoveInlineForm();
                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                }
                else
                {
                    this.inline_qty.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.FillForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                if (this.form_mode != FORM_MODE.READ)
                    return true;

                if (this.dgv.CurrentCell == null)
                {
                    this.form_mode = FORM_MODE.EDIT;
                    this.ResetControlState();
                    return true;
                }

                if(this.dgv.CurrentCell != null)
                {
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
                    return true;
                }
            }

            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_qty._Focused)
                {
                    if (this.dgv.CurrentCell.RowIndex < this.dgv.Rows.Count - 1)
                    {
                        this.dgv.Rows[this.dgv.CurrentCell.RowIndex + 1].Cells[this.col_section_name.Name].Selected = true;
                    }
                    else if (this.dgv.CurrentCell.RowIndex == this.dgv.Rows.Count - 1)
                    {
                        this.SaveSttak(this.tmp_sttak);
                        this.RemoveInlineForm();
                        this.form_mode = FORM_MODE.EDIT;
                        this.ResetControlState();
                    }
                    return true;
                }

                if (this.form_mode == FORM_MODE.EDIT)
                {
                    if (this.numBegdif._Focused)
                    {
                        this.btnOK.PerformClick();
                        return true;
                    }

                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                if(this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDother_Click(object sender, EventArgs e)
        {
            DialogDother d = new DialogDother(this.main_form, this.curr_dayend);
            d.SetBounds(((Button)sender).PointToScreen(Point.Empty).X + ((Button)sender).Width, ((Button)sender).PointToScreen(Point.Empty).Y, d.Width, d.Height);
            d.ShowDialog();
            this.RefreshSummary();
        }

        private void btnSyncRcvqty_Click(object sender, EventArgs e)
        {
            var rcv = this.curr_dayend.ToViewModel(this.main_form.working_express_db).GetRcvQty();
            if(this.curr_dayend.rcvqty != rcv)
            {
                if(MessageBox.Show("เปลี่ยนยอดรับน้ำมันจาก " + string.Format("{0:#,#0.00}", this.curr_dayend.rcvqty) + " ลิตร  ไปเป็น  " + string.Format("{0:#,#0.00}", rcv) + " ลิตร, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.curr_dayend.rcvqty = rcv;
                    this.numRcvqty._Value = this.curr_dayend.rcvqty;
                    //this.RefreshSummary();
                }
            }
            this.numRcvqty.Focus();
        }

        private void numRcvqty__ValueChanged(object sender, EventArgs e)
        {
            this.curr_dayend.rcvqty = ((XNumEdit)sender)._Value;
            //this.RefreshSummary();
        }

        private void numBegbal__ValueChanged(object sender, EventArgs e)
        {
            this.curr_dayend.begbal = ((XNumEdit)sender)._Value;
        }

        private void numSalqty__ValueChanged(object sender, EventArgs e)
        {
            this.curr_dayend.salqty = ((XNumEdit)sender)._Value;
        }

        private void numBegdif__ValueChanged(object sender, EventArgs e)
        {
            this.curr_dayend.begdif = ((XNumEdit)sender)._Value;
        }
    }
}
