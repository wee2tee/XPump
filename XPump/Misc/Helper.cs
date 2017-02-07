using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump.Misc
{
    // ENUM
    //public enum FORM_MODE_MD
    //{
    //    READ,
    //    ADD,
    //    EDIT,
    //    READ_ITEM,
    //    ADD_ITEM,
    //    EDIT_ITEM
    //}

    public enum FORM_MODE
    {
        READ,
        ADD,
        EDIT,
        READ_ITEM,
        ADD_ITEM,
        EDIT_ITEM
    }

    public enum RECORD_STATE : int
    {
        EXISTING = 0,
        NEW = 1
    }

    public enum INQUIRY
    {
        ALL,
        REST
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

        public static sectionVM ToViewModel(this section section)
        {
            if (section == null)
                return null;

            sectionVM s = new sectionVM
            {
                id = section.id,
                name = section.name,
                begbal = section.begbal,
                tank_id = section.tank_id,
                stmas_id = section.stmas_id,
                section = section,
            };

            return s;
        }

        public static List<sectionVM> ToViewModel(this IEnumerable<section> section_list)
        {
            List<sectionVM> s = new List<sectionVM>();
            foreach (var item in section_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static nozzleVM ToViewModel(this nozzle nozzle)
        {
            if (nozzle == null)
                return null;

            nozzleVM n = new nozzleVM
            {
                id = nozzle.id,
                name = nozzle.name,
                description = nozzle.description,
                remark = nozzle.remark,
                isactive = nozzle.isactive,
                nozzle = nozzle
            };

            return n;
        }

        public static List<nozzleVM> ToViewModel(this IEnumerable<nozzle> nozzle_list)
        {
            List<nozzleVM> n = new List<nozzleVM>();
            foreach (var nozzle in nozzle_list)
            {
                n.Add(nozzle.ToViewModel());
            }

            return n;
        }

        public static stmasVM ToViewModel(this stmas stmas)
        {
            if (stmas == null)
                return null;

            stmasVM s = new stmasVM
            {
                id = stmas.id,
                name = stmas.name,
                description = stmas.description,
                remark = stmas.remark,
                stmas = stmas
            };

            return s;
        }

        public static List<stmasVM> ToViewModel(this IEnumerable<stmas> stmas_list)
        {
            List<stmasVM> s = new List<stmasVM>();
            foreach (var stmas in stmas_list)
            {
                s.Add(stmas.ToViewModel());
            }

            return s;
        }

        public static stmasPriceVM ToPriceViewModel(this stmasVM stmas_vm)
        {
            if (stmas_vm == null)
                return null;

            stmasPriceVM s = new stmasPriceVM
            {
                price_id = stmas_vm.price_id,
                stmas_id = stmas_vm.id,
                price_date = stmas_vm.price_date,
                unitpr = stmas_vm.unitpr
            };

            return s;
        }

        public static List<stmasPriceVM> ToPriceViewModel(this IEnumerable<stmasVM> stmas_vm_list)
        {
            List<stmasPriceVM> s = new List<stmasPriceVM>();
            foreach (var stmas_vm in stmas_vm_list)
            {
                s.Add(stmas_vm.ToPriceViewModel());
            }

            return s;
        }
        
        //public static stmasSummaryTransactionVM ToSummaryVM(this stmasVM stmas_vm)
        //{
        //    if (stmas_vm == null)
        //        return null;

        //    stmasSummaryTransactionVM s = new stmasSummaryTransactionVM
        //    {
        //        price_id = stmas_vm.price_id,
        //        stmas_id = stmas_vm.id,
        //        price_date = stmas_vm.price_date,
        //        unitpr = stmas_vm.unitpr
        //    };

        //    return s;
        //}

        //public static List<stmasSummaryTransactionVM> ToSummaryVM(this IEnumerable<stmasVM> stmas_vm_list)
        //{
        //    List<stmasSummaryTransactionVM> s = new List<stmasSummaryTransactionVM>();
        //    foreach (var stmas_vm in stmas_vm_list)
        //    {
        //        s.Add(stmas_vm.ToSummaryVM());
        //    }

        //    return s;
        //}

        public static pricelistVM ToViewModel(this pricelist price)
        {
            if (price == null)
                return null;

            pricelistVM p = new pricelistVM
            {
                id = price.id,
                unitpr = price.unitpr,
                stmas_id = price.stmas_id,
            };
            return p;
        }

        public static List<pricelistVM> ToViewModel(this IEnumerable<pricelist> pricelist)
        {
            List<pricelistVM> p = new List<pricelistVM>();

            foreach (var item in pricelist)
            {
                p.Add(item.ToViewModel());
            }

            return p;
        }

        //public static dailyPriceVM ToDailyPriceViewModel(this pricelistVM price)
        //{
        //    if (price == null)
        //        return null;

        //    dailyPriceVM p = new dailyPriceVM
        //    {
        //        id = price.id,
        //        unitpr = price.unitpr,
        //        stmas_id = price.stmas_id
        //    };

        //    return p;
        //}

        //public static List<dailyPriceVM> ToDailyPriceViewModel(this IEnumerable<pricelistVM> pricelist)
        //{
        //    List<dailyPriceVM> p = new List<dailyPriceVM>();
        //    foreach (var item in pricelist)
        //    {
        //        p.Add(item.ToDailyPriceViewModel());
        //    }

        //    return p;
        //    //return ((IEnumerable<dailyPriceVM>)pricelist).ToList();
        //}

        //public static shiftsalesVM ToViewModel(this shiftsales shiftsales)
        //{
        //    if (shiftsales == null)
        //        return null;

        //    shiftsalesVM s = new shiftsalesVM
        //    {
        //        id = shiftsales.id,
        //        saldat = shiftsales.saldat,
        //        shift_id = shiftsales.shift_id,
        //        shiftsales = shiftsales
        //    };

        //    return s;
        //}

        //public static List<shiftsalesVM> ToViewModel(this IEnumerable<shiftsales> shiftsales_list)
        //{
        //    List<shiftsalesVM> s = new List<shiftsalesVM>();

        //    foreach (var item in shiftsales_list)
        //    {
        //        s.Add(item.ToViewModel());
        //    }

        //    return s;
        //}

        public static salessummaryVM ToViewModel(this salessummary sales)
        {
            if (sales == null)
                return null;

            salessummaryVM s = new salessummaryVM
            {
                id = sales.id,
                saldat = sales.saldat,
                dtest = sales.dtest,
                dother = sales.dother,
                dothertxt = sales.dothertxt,
                ddisc = sales.ddisc,
                purvat = sales.purvat,
                shift_id = sales.shift_id,
                stmas_id = sales.stmas_id,
                pricelist_id = sales.pricelist_id,
                shiftsales_id = sales.shiftsales_id,
                salessummary = sales
            };

            return s;
        }

        public static List<salessummaryVM> ToViewModel(this IEnumerable<salessummary> sales_list)
        {
            List<salessummaryVM> s = new List<salessummaryVM>();
            foreach (var item in sales_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static saleshistoryVM ToViewModel(this saleshistory saleshistory)
        {
            if (saleshistory == null)
                return null;

            saleshistoryVM s = new saleshistoryVM
            {
                id = saleshistory.id,
                saldat = saleshistory.saldat,
                mitbeg = saleshistory.mitbeg,
                mitend = saleshistory.mitend,
                salqty = saleshistory.salqty,
                salval = saleshistory.salval,
                shift_id = saleshistory.shift_id,
                nozzle_id = saleshistory.nozzle_id,
                stmas_id = saleshistory.stmas_id,
                pricelist_id = saleshistory.pricelist_id,
                salessummary_id = saleshistory.salessummary_id,
                saleshistory = saleshistory
            };

            return s;
        }

        public static List<saleshistoryVM> ToViewModel(this IEnumerable<saleshistory> saleshistory_list)
        {
            List<saleshistoryVM> s = new List<saleshistoryVM>();
            foreach (var item in saleshistory_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static aptrnVM ToViewModel(this aptrn aptrn)
        {
            if (aptrn == null)
                return null;

            aptrnVM a = new aptrnVM
            {
                id = aptrn.id,
                apmas_id = aptrn.apmas_id,
                rcvdat = aptrn.rcvdat,
                vatnum = aptrn.vatnum,
                vatdat = aptrn.vatdat,
                aptrn = aptrn
            };

            return a;
        }

        public static List<aptrnVM> ToViewModel(this IEnumerable<aptrn> aptrn_list)
        {
            List<aptrnVM> a = new List<aptrnVM>();

            foreach (var item in aptrn_list)
            {
                a.Add(item.ToViewModel());
            }

            return a;
        }

        public static void SetControlState(this Component comp, FORM_MODE[] form_mode_to_enable, FORM_MODE form_mode)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = true; return;
                }
                if(comp is TabControl)
                {
                    ((TabControl)comp).Enabled = true; return;
                }
                if(comp is Button)
                {
                    ((Button)comp).Enabled = true; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = false; return;
                }
                if(comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = false; return;
                }
                if(comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = false; return;
                }
                if(comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = false; return;
                }
            }
            else
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = false; return;
                }
                if(comp is TabControl)
                {
                    ((TabControl)comp).Enabled = false; return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = false; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = false; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = true; return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = true; return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = true; return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = true; return;
                }
            }
        }

        public static void SetControlVisibility(this Component comp, FORM_MODE[] form_mode_to_visible, FORM_MODE form_mode)
        {
            if(form_mode_to_visible.Where(fm => fm == form_mode).Count() > 0)
            {
                if(comp is Control)
                {
                    ((Control)comp).Visible = true; return;
                }
            }
            else
            {
                if(comp is Control)
                {
                    ((Control)comp).Visible = false; return;
                }
            }
        }

        //public static void SetControlState(this Component comp, FORM_MODE_MD[] form_mode_to_enable, FORM_MODE_MD form_mode)
        //{
        //    if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
        //    {
        //        if (comp is ToolStripButton)
        //        {
        //            ((ToolStripButton)comp).Enabled = true; return;
        //        }
        //        if (comp is DataGridView)
        //        {
        //            ((DataGridView)comp).Enabled = true; return;
        //        }
        //        if(comp is XTextEdit)
        //        {
        //            ((XTextEdit)comp)._ReadOnly = false; return;
        //        }
        //    }
        //    else
        //    {
        //        if (comp is ToolStripButton)
        //        {
        //            ((ToolStripButton)comp).Enabled = false; return;
        //        }
        //        if (comp is DataGridView)
        //        {
        //            ((DataGridView)comp).Enabled = false; return;
        //        }
        //        if(comp is XTextEdit)
        //        {
        //            ((XTextEdit)comp)._ReadOnly = true; return;
        //        }
        //    }
        //}

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
            xcb.SelectedItem = xcb.Items.Cast<XComboBoxItem>().Where(i => (bool)i.Value == (bool)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null)).First();
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
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            }
        }

        /// <summary>
        ///     Displays a message box with a message of Exception(especialy for DbUpdateException).
        /// </summary>
        /// <param name="exception_key">
        ///     The text to display as a DB error key, such as a duplicate field name in case duplicate entry.
        /// </param>
        /// <param name="exception_value">
        ///     The text to display as a DB error value.
        /// </param>
        /// <param name="exception_parent_key">
        ///     The text to display as a DB error key of parent table(foreign key contraint), in case add/update a child row while parent row is deleted.
        /// </param>
        /// <param name="exception_parent_value">
        ///     The text to display as a DB error value of parent table.
        /// </param>
        public static void ShowMessage(this Exception ex, string exception_key, string exception_value, string exception_parent_key = "", string exception_parent_value = "")
        {
            if(ex is DbUpdateException)
            {
                string message = string.Empty; ;

                // adding a duplicate unique value
                if (ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                {
                    message = string.Format("{0} \"{1}\" มีอยู่แล้วในระบบ", exception_key, exception_value);
                }

                // adding/updating a child row while parent row(foreign key constraint) is deleted
                if (ex.InnerException.InnerException.Message.ToLower().Contains("cannot add or update a child row"))
                {
                    message = string.Format("{0} \"{1}\" ไม่มีอยู่ในระบบ, ไม่สามารถแก้ไขได้", exception_parent_key, exception_parent_value);
                }

                // delete a parent row while a child row(foreign key constraint) is exist
                if (ex.InnerException.InnerException.Message.ToLower().Contains("cannot delete or update a parent row"))
                {
                    message = string.Format("{0} \"{1}\" ยังไม่สามารถลบได้ เนื่องจากมีการนำไปใช้งานแล้ว", exception_key, exception_value);
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else if(ex is ArgumentNullException)
            {
                if(ex.Message.ToLower().Contains("value cannot be null") && ex.StackTrace.ToLower().Contains(".remove("))
                {
                    MessageBox.Show(string.Format("{0} \"{1}\" ไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", exception_key, exception_value));
                    return;
                }
            }

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
