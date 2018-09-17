using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Misc;
using XPump.Model;

namespace XPump.SubForm
{
    public partial class DialogStkgrp : Form
    {
        private MainForm main_form;
        private BindingList<StkgrpBillMethodList> stkgrp_list;

        public DialogStkgrp(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void DialogStkgrp_Load(object sender, EventArgs e)
        {
            this.stkgrp_list = new BindingList<StkgrpBillMethodList>(DbfTable.StkgrpBillMethodList(this.main_form.working_express_db));
            this.dgv.DataSource = this.stkgrp_list;
        }
    }
}
