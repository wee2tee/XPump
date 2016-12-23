﻿using System;
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
    public partial class ShiftForm : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private FORM_MODE_LIST form_mode;
        private shiftVM temp_shift; // model for create new shift
        private Control inline_control; // control for add/edit inline form

        public ShiftForm()
        {
            InitializeComponent();
        }

        public ShiftForm(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE_LIST.READ;

            this.bs = new BindingSource();
            this.bs.DataSource = this.shift_list;
            this.dgv.DataSource = this.bs;

            this.shift_list = this.GetShiftList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;

        }

        public List<shift> GetShiftList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shift.Include("saleshistory").Include("salessummary").ToList();
            }
        }

        private void ShowInlineControl(XDatagrid dgv, int row_index, int column_index)
        {
            if (dgv.CurrentCell == null)
                return;

            this.inline_control = new XTextBox();
            this.dgv.Tag = new InlineControlGridPosition() { RowIndex = row_index, ColumnIndex = column_index };
            this.SetInlineControlPosition();
            this.dgv.Parent.Controls.Add(this.inline_control);
            this.inline_control.BringToFront();
            this.inline_control.Focus();
        }

        private void RemoveInlineControl()
        {
            this.inline_control.Dispose();
            this.inline_control = null;
            this.dgv.Tag = null;
        }

        private void SetInlineControlPosition()
        {
            if(this.inline_control != null || (this.dgv.Tag != null && (this.dgv.Tag.GetType() == typeof(InlineControlGridPosition))))
            {
                Rectangle rect = this.dgv.GetCellDisplayRectangle(((InlineControlGridPosition)this.dgv.Tag).ColumnIndex, ((InlineControlGridPosition)this.dgv.Tag).RowIndex, true);
                this.inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 5);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE_LIST.READ)
            {
                if (MessageBox.Show("close", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_shift = new shiftVM
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                starttime = new TimeSpan(0, 0, 0),
                endtime = new TimeSpan(0, 0, 0),
                remark = string.Empty,
                shift = null,
                record_state = RECORD_STATE.NEW,
            };

            this.shift_list.Add(this.temp_shift);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.shift_list.Count - 1].Cells["col_name"];
            this.ShowInlineControl(this.dgv, this.dgv.CurrentCell.RowIndex, this.dgv.CurrentCell.ColumnIndex);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.shift_list = this.GetShiftList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.Button == MouseButtons.Left && this.form_mode == FORM_MODE_LIST.READ)
            {
                ((XDatagrid)sender).SortByColumn<shiftVM>(e.ColumnIndex);
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if(((XDatagrid)sender).Tag != null && (((XDatagrid)sender).Tag.GetType() == typeof(InlineControlGridPosition)))
            {
                if(((InlineControlGridPosition)((XDatagrid)sender).Tag).RowIndex == ((XDatagrid)sender).CurrentCell.RowIndex)
                {
                    this.RemoveInlineControl();
                    this.ShowInlineControl((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).CurrentCell.ColumnIndex);
                }
            }
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            this.SetInlineControlPosition();
        }
    }
}
