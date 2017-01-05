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
    public partial class StmasForm : Form
    {
        private MainForm main_form;

        public StmasForm()
        {
            InitializeComponent();
        }

        public StmasForm(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).FirstOrDefault() != null)
            {
                if (MessageBox.Show(StringResource.Msg("0001"), "Message # 0001", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

    }
}
