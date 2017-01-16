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

namespace XPump.SubForm
{
    public partial class FormTankSetup : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private tank curr_tank;
        private tank temp_tank;
        private section temp_section;
        //private nozzle temp_nozzle;
        private BindingSource bs_section;

        private XTextBox inline_name;
        private XBrowseBox inline_stkcod;
        private XNumEdit inline_capacity;
        private XBrowseBox inline_nozzle;


        public FormTankSetup()
        {
            InitializeComponent();
        }

        public FormTankSetup(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void FormTank_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.col_section_capacity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ใช้งาน", Value = true });
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ไม่ใช้งาน", Value = false });

            this.bs_section = new BindingSource();
            this.dgvSection.DataSource = this.bs_section;

            this.BindingCustomControlEventHandler();

            this.btnLast.PerformClick();
        }

        private void BindingCustomControlEventHandler()
        {
            this.txtName.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.name = ((TextBox)sender).Text;
            };

            this.dtStartDate._SelectedDateChanged += delegate(object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.startdate = ((XDatePicker)sender)._SelectedDate.Value;
            };

            this.dtEndDate._SelectedDateChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.enddate = ((XDatePicker)sender)._SelectedDate;
            };

            this.txtDesc.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.description = ((TextBox)sender).Text;
            };

            this.txtRemark.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.remark = ((TextBox)sender).Text;
            };

            this.ddIsactive.comboBox1.SelectedIndexChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.isactive = (bool)((XComboBoxItem)((XComboBox)sender).SelectedItem).Value;
            };
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.txtName.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.dtStartDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtEndDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtDesc.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.ddIsactive.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ)
            {
                if(MessageBox.Show(StringResource.Msg("0001"), "Message # 0001", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        public tank GetTank(int tank_id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    return db.tank.Include("section").Where(t => t.id == tank_id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private void FillForm(tank tank_to_fill = null)
        {
            tank tank = tank_to_fill != null ? tank_to_fill : this.curr_tank;

            if (tank == null)
                return;

            this.txtName._Text = tank.name;
            this.dtStartDate._SelectedDate = tank.startdate;
            this.dtEndDate._SelectedDate = tank.enddate;
            this.txtDesc._Text = tank.description;
            this.txtRemark._Text = tank.remark;
            this.ddIsactive._SelectedItem = this.ddIsactive._Items.Cast<XDropdownListItem>().Where(i => (bool)i.Value == tank.isactive).First();

            this.bs_section.ResetBindings(true);
            var sections = tank.section.ToList().ToViewModel();
            //for (int i = 0; i < 50; i++)
            //{
            //    sections.Add(new section
            //    {
            //        id = -1,
            //        name = string.Empty,
            //        capacity = 0m,
            //        stmas_id = 0,
            //        tank_id = 0
            //    }.ToViewModel());
            //}

            this.bs_section.DataSource = sections;
        }

        private void ShowInlineForm(int row_index)
        {
            Rectangle row_rect = this.dgvSection.GetRowDisplayRectangle(row_index, true);
            using (Graphics g = this.dgvSection.CreateGraphics())
            {
                using (Pen p = new Pen(Color.Red))
                {
                    g.DrawLine(p, row_rect.X, row_rect.Y, row_rect.X + row_rect.Width, row_rect.Y);
                }
            }

            int col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index;

            this.inline_name = this.dgvSection.Rows[row_index].Cells[col_index].CreateXTextBoxEdit(this.temp_section, "name");
            this.inline_name.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.dgvSection.Parent.Controls.Add(this.inline_name);

            this.dgvSection.SendToBack();
            this.inline_name.BringToFront();

            this.inline_stkcod = new XBrowseBox();

            this.inline_capacity = new XNumEdit();

            this.inline_nozzle = new XBrowseBox();

        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.toolStrip1.Focus();
            this.btnEdit.PerformClick();
            if(sender == this.txtName)
            {
                this.txtDesc.Focus();
                return;
            }

            ((Control)sender).Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_tank = new tank
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                remark = string.Empty,
                isactive = true
            };

            this.toolStrip1.Focus();
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.txtName.Focus();

            this.FillForm(this.temp_tank);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_tank == null)
                return;

            using (xpumpEntities db = DBX.DataSet())
            {
                tank tmp = this.GetTank(this.curr_tank.id);
                
                if(tmp == null)
                {
                    MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.temp_tank = tmp;
                this.form_mode = FORM_MODE.EDIT;
                this.ResetControlState();
                this.FillForm(this.temp_tank);
                this.txtDesc.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {

                return;
            }

            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.toolStrip1.Focus();
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                return;
            }

            if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
            {
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.temp_tank = null;
                this.FillForm();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                tank tmp = db.tank.Include("section").OrderBy(t => t.name).FirstOrDefault();

                if(tmp != null)
                {
                    this.curr_tank = tmp;
                }
                else
                {
                    this.curr_tank = new tank
                    {
                        id = -1,
                        name = string.Empty,
                        description = string.Empty,
                        remark = string.Empty,
                        isactive = false
                    };
                }

                this.FillForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                tank tmp = db.tank.Include("section").Where(t => t.name.CompareTo(this.curr_tank.name) < 0).OrderByDescending(t => t.name).FirstOrDefault();

                if (tmp == null)
                    return;

                this.curr_tank = tmp;
                this.FillForm();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                tank tmp = db.tank.Include("section").Where(t => t.name.CompareTo(this.curr_tank.name) > 0).OrderBy(t => t.name).FirstOrDefault();

                if (tmp == null)
                    return;

                this.curr_tank = tmp;
                this.FillForm();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                tank tmp = db.tank.Include("section").OrderByDescending(t => t.name).FirstOrDefault();

                if(tmp != null)
                {
                    this.curr_tank = tmp;
                }
                else
                {
                    this.curr_tank = new tank
                    {
                        id = -1,
                        name = string.Empty,
                        startdate = DateTime.Now,
                        enddate = null,
                        description = string.Empty,
                        remark = string.Empty,
                        isactive = false
                    };
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

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.dgvSection.Focus();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F8)
            {
                this.btnItem.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvSection_Paint(object sender, PaintEventArgs e)
        {
            //Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(1, this.curr_tank.section.Count, true);
            //this.inline_btn_add_section = new Button();
            //this.inline_btn_add_section.Text = "<< Add new >>";
            //this.inline_btn_add_section.SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
            //((XDatagrid)sender).Parent.Controls.Add(this.inline_btn_add_section);
            //this.inline_btn_add_section.BringToFront();
        }

        private void dgvSection_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
                int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

                if(row_index > -1)
                {
                    Console.WriteLine(" ... >>> data row");
                }
                else
                {
                    Console.WriteLine(" ... >>> not a data row");
                }

            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            this.temp_section = new section
            {
                id = -1,
                name = string.Empty,
                capacity = 0m,
                stmas_id = 0,
                tank_id = 0
            };
            this.curr_tank.section.Add(this.temp_section);
            this.FillForm();
            this.ShowInlineForm(0);
        }
    }
}
