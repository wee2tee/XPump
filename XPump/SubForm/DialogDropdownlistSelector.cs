using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;

namespace XPump.SubForm
{
    public partial class DialogDropdownlistSelector : Form
    {
        private List<XDropdownListItem> dropdown_items = new List<XDropdownListItem>();
        private string caption = string.Empty;
        private string label_description = string.Empty;
        private object initial_selected_item_value = null;
        public XDropdownListItem selected_item = null;

        public DialogDropdownlistSelector(string caption, string label_description, List<XDropdownListItem> dropdown_items, object initial_selected_item_value)
        {
            this.caption = caption;
            this.label_description = label_description;
            this.dropdown_items = dropdown_items;
            this.initial_selected_item_value = initial_selected_item_value;
            InitializeComponent();
        }

        private void DialogDropdownlistSelector_Load(object sender, EventArgs e)
        {
            this.Text = this.caption;
            this.label1.Text = this.label_description;
            
            foreach (var item in this.dropdown_items)
            {
                this.xDropdownList1._Items.Add(item);
            }

            if(this.initial_selected_item_value != null)
            {
                var selected = this.xDropdownList1._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString() == this.initial_selected_item_value.ToString()).FirstOrDefault();
                if(selected != null)
                {
                    this.xDropdownList1._SelectedItem = selected;
                }
            }
        }

        private void xDropdownList1__SelectedItemChanged(object sender, EventArgs e)
        {
            this.selected_item = (XDropdownListItem)((XDropdownList)sender)._SelectedItem;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (!this.xDropdownList1.comboBox1.DroppedDown && this.selected_item != null)
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
