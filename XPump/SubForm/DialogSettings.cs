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
using System.Data.OleDb;
using System.IO;

namespace XPump.SubForm
{
    public partial class DialogSettings : Form
    {
        private MainForm main_form;
        private settings settings;
        private settings tmp_settings;
        private FORM_MODE form_mode;

        public DialogSettings(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogSettings_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            using (xpumpEntities db = DBX.DataSet())
            {
                if (db.settings.Count() == 0)
                {
                    db.settings.Add(new settings
                    {
                        express_data_path = string.Empty
                    });
                    db.SaveChanges();
                }
            }

            this.settings = GetSettings();
            this.FillForm();
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);

            /* Form control */
            this.btnBrowseExpressData.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
        }

        private void FillForm(settings settings_value_to_fill = null)
        {
            settings settings = settings_value_to_fill != null ? settings_value_to_fill : this.settings;

            this.txtExpressData._Text = settings.express_data_path;
        }

        public static settings GetSettings()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.settings.First();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.tmp_settings = GetSettings();
            this.FillForm(this.tmp_settings);

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    settings setting_to_update = db.settings.First();
                    setting_to_update.express_data_path = this.tmp_settings.express_data_path;

                    db.SaveChanges();
                    this.settings = GetSettings();
                    this.FillForm();

                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                    this.tmp_settings = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            this.settings = GetSettings();
            this.FillForm();

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.tmp_settings = null;
        }

        private void btnBrowseExpressData_Click(object sender, EventArgs e)
        {
            DataTable dt = DbfTable.Sccomp();
            if (dt == null)
                return;

            List<SccompDbf> sccomp = dt.ToList<SccompDbf>();

            DialogSccompSelection sel = new DialogSccompSelection(this.main_form, sccomp);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                this.txtExpressData._Text = sel.selected_sccomp.path;
            }
        }

        private void txtExpressData__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.express_data_path = ((XTextEdit)sender)._Text;
        }
    }
}
