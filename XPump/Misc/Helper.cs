using CC;
using System;
using System.Collections.Generic;
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

                record_state = shift.id > -1 ? RECORD_STATE.EXISTING : RECORD_STATE.NEW,
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

        public static XBrowseBox CreateXBrowseBoxEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            return null;
        }

        public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv)
        {
            if (inline_control != null || (dgv.Tag != null && (dgv.Tag.GetType() == typeof(InlineControlGridPosition))))
            {
                Rectangle rect = dgv.GetCellDisplayRectangle(((InlineControlGridPosition)dgv.Tag).ColumnIndex, ((InlineControlGridPosition)dgv.Tag).RowIndex, true);
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 5);
            }
        }
    }
}
