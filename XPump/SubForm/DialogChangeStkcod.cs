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
    public partial class DialogChangeStkcod : Form
    {
        private MainForm main_form;
        private section section = null;
        public string new_stkcod = string.Empty;

        public DialogChangeStkcod(MainForm main_form, section section)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.section = section;
        }

        private void DialogChangeStkcod_Load(object sender, EventArgs e)
        {
            this.lblOldStkcod.Text = this.section.stkcod;
        }

        private void txtNewStkcod__TextChanged(object sender, EventArgs e)
        {
            this.new_stkcod = ((XTextEdit)sender)._Text;
            this.btnOK.Enabled = this.new_stkcod.Trim().Length > 0 ? true : false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var stmas = DbfTable.Stmas(this.main_form.working_express_db).ToStmasList().Where(st => st.stktyp == "0").Select(st => new { stkcod = st.stkcod.Trim(), stkdes = st.stkdes.Trim(), stkdes2 = st.stkdes2.Trim() }).ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            cols.Add(new DataGridViewTextBoxColumn { Name = "col_stkcod", HeaderText = "รหัสสินค้า", DataPropertyName = "stkcod", Width = 180, MinimumWidth = 180 });
            cols.Add(new DataGridViewTextBoxColumn { Name = "col_stkdes", HeaderText = "รายละเอียด (ไทย)", DataPropertyName = "stkdes", MinimumWidth = 250, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            cols.Add(new DataGridViewTextBoxColumn { Name = "col_stkdes2", HeaderText = "รายละเอียด (Eng.)", DataPropertyName = "stkdes2", MinimumWidth = 250, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            DialogInquiry inq = new DialogInquiry(stmas, cols, cols[0], this.txtNewStkcod._Text, true, null, true);
            if (inq.ShowDialog() == DialogResult.OK)
            {
                this.txtNewStkcod._Text = inq.selected_row.Cells[cols[0].Name].Value.ToString();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
