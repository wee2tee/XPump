using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class _TestForm1 : Form
    {
        private BindingList<Person> persons = new BindingList<Person>();

        public _TestForm1()
        {
            InitializeComponent();
        }

        private void _TestForm1_Load(object sender, EventArgs e)
        {
            this.dgv.DataSource = this.persons;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.persons.Add(new Person
            {
                fname = string.Empty,
                lname = string.Empty,
                age = 1
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.persons[this.dgv.CurrentCell.RowIndex].fname = this.txtFname.Text;
            this.persons[this.dgv.CurrentCell.RowIndex].lname = this.txtLname.Text;
            this.persons[this.dgv.CurrentCell.RowIndex].age = Convert.ToInt32(this.numAge.Value);

            this.persons.ResetItem(this.dgv.CurrentCell.RowIndex);
        }
    }

    public class Person
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }

    }
}
