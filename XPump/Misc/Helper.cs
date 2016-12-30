using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump.Misc
{
    // ENUM
    public enum FORM_MODE_MD
    {

    }

    public enum FORM_MODE_LIST
    {
        READ,
        ADD,
        EDIT
    }

    public enum RECORD_STATE : int
    {
        EXISTING = 0,
        NEW = 1
    }

    // Miscellenous class
    public class InlineControlGridPosition
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }

    public class XComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }

    // Extension Method
    public static class Helper
    {
        public static shiftVM ToViewModel(this shift shift)
        {
            if (shift == null)
                return null;

            shiftVM s = new shiftVM
            {
                id = shift.id,
                name = shift.name,
                description = shift.description,
                starttime = shift.starttime,
                endtime = shift.endtime,
                remark = shift.remark,

                //record_state = shift.id > -1 ? RECORD_STATE.EXISTING : RECORD_STATE.NEW,
                shift = shift
            };

            return s;
        }

        public static List<shiftVM> ToViewModel(this IEnumerable<shift> shift_lsit)
        {
            List<shiftVM> s = new List<shiftVM>();
            foreach (var shift in shift_lsit)
            {
                s.Add(shift.ToViewModel());
            }

            return s;
        }

        public static tankVM ToViewModel(this tank tank)
        {
            if (tank == null)
                return null;

            tankVM t = new tankVM
            {
                id = tank.id,
                name = tank.name,
                description = tank.description,
                remark = tank.remark,
                isactive = tank.isactive,
                tank = tank
            };

            return t;
        }

        public static List<tankVM> ToViewModel(this IEnumerable<tank> tank_list)
        {
            List<tankVM> t = new List<tankVM>();
            foreach (var tank in tank_list)
            {
                t.Add(tank.ToViewModel());
            }

            return t;
        }

        public static void SetControlState(this Component comp, FORM_MODE_LIST[] form_mode_to_enable, FORM_MODE_LIST form_mode)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true; return;
                }
            }
            else
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = false; return;
                }
            }
        }

        public static XTextBox CreateXTextBoxEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XTextBox xtext = new XTextBox();
            xtext.Text = (string)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null); //(string)dgv_cell.Value;
            xtext.TextChanged += delegate
            {
                dgv_cell.Value = xtext.Text;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, xtext.Text, null);
            };
            return xtext;
        }

        public static XTimePicker CreateXTimePickerEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XTimePicker xtime = new XTimePicker();
            xtime.Text = ((TimeSpan)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null)).ToString(@"hh\:mm\:ss");
            xtime.ValueChanged += delegate
            {
                string str_time = xtime.Value.ToString("HH") + ":" + xtime.Value.ToString("mm") + ":" + xtime.Value.ToString("ss");
                dgv_cell.Value = TimeSpan.Parse(str_time);
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, TimeSpan.Parse(str_time), null);
            };
            return xtime;
        }

        public static XComboBox CreateXComboBoxTrueFalseEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XComboBox xcb = new XComboBox();
            xcb.Items.Add(new XComboBoxItem
            {
                Text = "ใช้งาน",
                Value = true
            });
            xcb.Items.Add(new XComboBoxItem
            {
                Text = "ไม่ใช้งาน",
                Value = false
            });
            xcb.SelectedValueChanged += delegate
            {
                var selected_value = (object)((XComboBoxItem)xcb.SelectedItem).Value;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, selected_value, null);
            };
            return xcb;
        }

        public static XComboBox CreateXComboBoxEdit(this DataGridViewCell dgv_cell, List<XComboBoxItem> item_list, object affected_object, string affected_field)
        {
            XComboBox xcb = new XComboBox();
            foreach (var item in item_list)
            {
                xcb.Items.Add(item);
            }
            xcb.SelectedValueChanged += delegate
            {
                var selected_value = (object)((XComboBoxItem)xcb.SelectedItem).Value;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, selected_value, null);
            };
            return xcb;
        }
        
        public static XBrowseBox CreateXBrowseBoxEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            return null;
        }

        //public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv)
        //{
        //    if (inline_control != null && (dgv.Tag != null && (dgv.Tag.GetType() == typeof(InlineControlGridPosition))))
        //    {
        //        Rectangle rect = dgv.GetCellDisplayRectangle(((InlineControlGridPosition)dgv.Tag).ColumnIndex, ((InlineControlGridPosition)dgv.Tag).RowIndex, true);
        //        inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 5);
        //    }
        //}

        public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv, int row_index, int column_index)
        {
            if(inline_control != null)
            {
                Rectangle rect = dgv.GetCellDisplayRectangle(column_index, row_index, true);
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 1);
            }
        }
    }
}
