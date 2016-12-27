using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC.Dialog
{
    public partial class ListDialog : Form
    {
        private Object list_object;
        private BindingSource bs;

        public ListDialog()
        {
            InitializeComponent();
        }

        public ListDialog(Form parent_form, Object list_object)
            : this()
        {
            this.Owner = parent_form;
            this.list_object = list_object;
        }

        private void ListDialog_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.bs.DataSource = this.list_object;
            this.dgv.DataSource = this.bs;
        }

    }
}
