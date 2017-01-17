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
    public partial class DialogNozzle : Form
    {
        private MainForm main_form;
        private tank tank;
        private section section;
        private nozzle temp_nozzle;

        private XTextEdit inline_name;
        private XTextEdit inline_desc;
        private XComboBox inline_isactive;

        private List<nozzle> nozzle_list;
        private BindingSource bs;


        public DialogNozzle()
        {
            InitializeComponent();
        }

        public DialogNozzle(MainForm main_form, section section_object)
            : this()
        {
            this.main_form = main_form;
            this.section = section_object;
        }

        private void DialogNozzle_Load(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                this.tank = db.tank.Find(this.section.tank_id);

                if(this.tank != null)
                {
                    this.lblTank.Text = this.tank.name + " / " + this.tank.description;
                    this.lblSection.Text = this.section.name;
                }
            }
        }

    }
}
