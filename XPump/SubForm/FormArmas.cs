using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;

namespace XPump.SubForm
{
    public partial class FormArmas : Form
    {
        private MainForm main_form;
        private List<ArmasDbfList> armas;
        private ArmasDbf curr_armas;
        private ArmasDbf tmp_armas;
        private FORM_MODE form_mode;

        public FormArmas(MainForm main_form)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.main_form = main_form;
            InitializeComponent();
        }

        private void FormArmas_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("Start at " + DateTime.Now.ToString());
            //this.armas = DbfTable.ArmasList(this.main_form.working_express_db);
            //Console.WriteLine("Finish at ==> " + DateTime.Now.ToString());
            this.ApplyDropdownSelection();
        }

        private void FormArmas_Shown(object sender, EventArgs e)
        {
            this.btnFirst.PerformClick();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            this.form_mode = FORM_MODE.READ;
            base.OnFormClosed(e);
        }

        private void ApplyDropdownSelection()
        {
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Active", Value = "A" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Inactive", Value = "I" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "ไม่ได้ระบุ(Active)", Value = "" });

            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายล่าสุด", Value = "0" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 1", Value = "1" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 2", Value = "2" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 3", Value = "3" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 4", Value = "4" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 5", Value = "5" });
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.cCuscod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.cPrenam.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCusnam.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr01.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr02.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr03.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cZipcod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTelnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cContact.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTaxid.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cStatus.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cOrgnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCustyp.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAccnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cSlmcod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAreacod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDlvby.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cPaytrm.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cPaycond.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTabpr.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDisc.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCrline.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        private void FillForm(ArmasDbf data_to_fill)
        {
            ArmasDbf armas;
            if(data_to_fill == null)
            {
                armas = new ArmasDbf
                {
                    cuscod = string.Empty
                };
            }
            else
            {
                armas = data_to_fill;
            }

            var status = this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.status).FirstOrDefault();
            var tabpr = this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.tabpr).FirstOrDefault();

            this.cCuscod._Text = armas.cuscod;
            this.cCusnam._Text = armas.cusnam;
            this.cAddr01._Text = armas.addr01;
            this.cAddr02._Text = armas.addr02;
            this.cAddr03._Text = armas.addr03;
            this.cZipcod._Text = armas.zipcod;
            this.cTelnum._Text = armas.telnum;
            this.cContact._Text = armas.contact;
            this.cRemark._Text = armas.remark;
            this.cStatus._SelectedItem = status != null ? status : this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "").First();
            this.cTaxid._Text = armas.taxid;
            this.cOrgnum._Value = Convert.ToDecimal(armas.orgnum);
            this.cCustyp._Text = armas.custyp;
            this.cCustypDesc.Text = armas._custypdesc;
            this.cAccnum._Text = armas.accnum;
            this.cAccnam.Text = armas._accnam;
            this.cSlmcod._Text = armas.slmcod;
            this.cSlmnam.Text = armas._slmnam;
            this.cAreacod._Text = armas.areacod;
            this.cAreaDesc.Text = armas._areadesc;
            this.cDlvby._Text = armas.dlvby;
            this.cDlvbyDesc.Text = armas._dlvbydesc;
            this.cPaytrm._Value = Convert.ToDecimal(armas.paytrm);
            this.cPaycond._Text = armas.paycond;
            this.cTabpr._SelectedItem = tabpr != null ? tabpr : this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "0").First();
            this.cDisc._Text = armas.disc;
            this.cCrline._Value = Convert.ToDecimal(armas.crline);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.FIRST);
            this.FillForm(this.curr_armas);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false);
            int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            if(curr_index > 0)
            {
                this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index - 1]);
                this.FillForm(this.curr_armas);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false);
            int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            if (curr_index < cuscod_list.Count - 1)
            {
                this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index + 1]);
                this.FillForm(this.curr_armas);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.LAST);
            this.FillForm(this.curr_armas);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_armas = (ArmasDbf)this.curr_armas.Clone(); //new ArmasDbf { cuscod = string.Empty };

            this.FillForm(this.tmp_armas);
            this.ResetFormState(FORM_MODE.ADD);
            this.cCuscod.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cCuscod_Leave(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db);
                if(cuscod_list.Where(c => c.TrimEnd() == ((XTextEdit)sender)._Text.TrimEnd()).Count() > 0)
                {
                    ((XTextEdit)sender).Focus();
                    XMessageBox.Show("รหัสลูกค้า '" + ((XTextEdit)sender)._Text.TrimEnd() + "' นี้มีอยู่แล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void cPrenam__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.PRENAM).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }

        private void cRemark__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.REMARK_AR).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }

        private void cCustyp__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typcod = new DataGridViewTextBoxColumn
            {
                Name = "col_typcod",
                HeaderText = "รหัส",
                DataPropertyName = "typcod",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "คำย่อ",
                DataPropertyName = "shortnam",
                Width = 160,
                MinimumWidth = 160,
            };
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "รายละเอียด",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typcod,
                col_shortnam,
                col_typdes
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.CUSTYP).Select(i => new { typcod = i.typcod, shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typcod.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typcod = br.selected_row.Cells[col_typcod.Name].Value.ToString();
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typcod;
                this.cCustypDesc.Text = typdes;
            }
        }

        private void cAccnum__ButtonClick(object sender, EventArgs e)
        {

        }

        private void cSlmcod__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_slmcod = new DataGridViewTextBoxColumn
            {
                Name = "col_slmcod",
                HeaderText = "รหัส",
                DataPropertyName = "slmcod",
                Width = 120,
                MinimumWidth = 120,
            };
            DataGridViewTextBoxColumn col_slmnam = new DataGridViewTextBoxColumn
            {
                Name = "col_slmnam",
                HeaderText = "ชื่อพนักงานขาย",
                DataPropertyName = "slmnam",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_slmcod,
                col_slmnam
            };

            var datasource = DbfTable.OeslmList(this.main_form.working_express_db).Select(i => new { slmcod = i.slmcod, slmnam = i.slmnam }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_slmcod.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string slmcod = br.selected_row.Cells[col_slmcod.Name].Value.ToString();
                string slmnam = br.selected_row.Cells[col_slmnam.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = slmcod;
                this.cSlmnam.Text = slmnam;
            }
        }

        private void cAreacod__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typcod = new DataGridViewTextBoxColumn
            {
                Name = "col_typcod",
                HeaderText = "รหัส",
                DataPropertyName = "typcod",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "คำย่อ",
                DataPropertyName = "shortnam",
                Width = 160,
                MinimumWidth = 160,
            };
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "รายละเอียด",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typcod,
                col_shortnam,
                col_typdes
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.AREA).Select(i => new { typcod = i.typcod, shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typcod.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typcod = br.selected_row.Cells[col_typcod.Name].Value.ToString();
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typcod;
                this.cAreaDesc.Text = typdes;
            }
        }

        private void cDlvby__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typcod = new DataGridViewTextBoxColumn
            {
                Name = "col_typcod",
                HeaderText = "รหัส",
                DataPropertyName = "typcod",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "คำย่อ",
                DataPropertyName = "shortnam",
                Width = 160,
                MinimumWidth = 160,
            };
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "รายละเอียด",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typcod,
                col_shortnam,
                col_typdes
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.DLVBY).Select(i => new { typcod = i.typcod, shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typcod.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typcod = br.selected_row.Cells[col_typcod.Name].Value.ToString();
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typcod;
                this.cDlvbyDesc.Text = typdes;
            }
        }

        private void cPaycond__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.PAYCOND).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.main_form, cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }
    }
}