using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
