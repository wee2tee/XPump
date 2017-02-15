using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump.Misc
{
    public enum FORM_MODE
    {
        READ,
        ADD,
        EDIT,
        READ_ITEM,
        ADD_ITEM,
        EDIT_ITEM
    }

    public enum PRINT_OUTPUT
    {
        SCREEN,
        PRINTER,
        FILE
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
                paeprefix = shift.paeprefix,
                phpprefix = shift.phpprefix,
                prrprefix = shift.prrprefix,
                saiprefix = shift.saiprefix,
                shsprefix = shift.shsprefix,
                sivprefix = shift.sivprefix,

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

        public static List<StmasDbf> ToStmasList(this DataTable stmas_dbf)
        {
            List<StmasDbf> stmas = new List<StmasDbf>();

            foreach (DataRow row in stmas_dbf.Rows)
            {
                try
                {
                    StmasDbf s = new StmasDbf
                    {
                        stkcod = row.Field<string>("stkcod"),
                        stkdes = row.Field<string>("stkdes"),
                        stkdes2 = row.Field<string>("stkdes2"),
                        stktyp = row.Field<string>("stktyp"),
                        stklev = row.Field<string>("stklev"),
                        stkgrp = row.Field<string>("stkgrp"),
                        barcod = row.Field<string>("barcod"),
                        stkcods = row.Field<string>("stkcods"),
                        acccod = row.Field<string>("acccod"),
                        isinv = row.Field<string>("isinv"),
                        stkclass = row.Field<string>("stkclass"),
                        negallow = row.Field<string>("negallow"),
                        qucod = row.Field<string>("qucod"),
                        cqucod = row.Field<string>("cqucod"),
                        cfactor = row.Field<double>("cfactor"),
                        stnpr = row.Field<double>("stnpr"),
                        ispur = row.Field<string>("ispur"),
                        pqucod = row.Field<string>("pqucod"),
                        pfactor = row.Field<double>("pfactor"),
                        lpurqu = row.Field<string>("lpurqu"),
                        lpurfac = row.Field<double>("lpurfac"),
                        lpurpr = row.Field<double>("lpurpr"),
                        lpdisc = row.Field<string>("lpdisc"),
                        lpurdat = row.Field<DateTime?>("lpurdat"),
                        supcod = row.Field<string>("supcod"),
                        issal = row.Field<string>("issal"),
                        squcod = row.Field<string>("squcod"),
                        sfactor = row.Field<double>("sfactor"),
                        sellpr1 = row.Field<double>("sellpr1"),
                        sellpr2 = row.Field<double>("sellpr2"),
                        sellpr3 = row.Field<double>("sellpr3"),
                        sellpr4 = row.Field<double>("sellpr4"),
                        sellpr5 = row.Field<double>("sellpr5"),
                        tracksal = row.Field<string>("tracksal"),
                        vatcod = row.Field<string>("vatcod"),
                        iscom = row.Field<string>("iscom"),
                        comrat = row.Field<string>("comrat"),
                        lsellqu = row.Field<string>("lsellqu"),
                        lsellfac = row.Field<double>("lsellfac"),
                        lsellpr = row.Field<double>("lsellpr"),
                        lsdisc = row.Field<string>("lsdisc"),
                        lseldat = row.Field<DateTime?>("lseldat"),
                        numelem = row.Field<decimal?>("numelem"),
                        totbal = row.Field<double>("totbal"),
                        totval = row.Field<double>("totval"),
                        totreo = row.Field<double>("totreo"),
                        totres = row.Field<double>("totres"),
                        opnbal = row.Field<double>("opnbal"),
                        unitpr = row.Field<double>("unitpr"),
                        opnval = row.Field<double>("opnval"),
                        lasupd = row.Field<DateTime?>("lasupd"),
                        packing = row.Field<string>("packing"),
                        mlotnum = row.Field<string>("mlotnum"),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        remark = row.Field<string>("remark"),
                        dat1 = row.Field<DateTime?>("dat1"),
                        dat2 = row.Field<DateTime?>("dat2"),
                        num1 = row.Field<double>("num1"),
                        str1 = row.Field<string>("str1"),
                        str2 = row.Field<string>("str2"),
                        str3 = row.Field<string>("str3"),
                        str4 = row.Field<string>("str4"),
                        creby = row.Field<string>("creby"),
                        credat = row.Field<DateTime?>("credat"),
                        userid = row.Field<string>("userid"),
                        chgdat = row.Field<DateTime?>("chgdat"),
                        status = row.Field<string>("status"),
                        inactdat = row.Field<DateTime?>("inactdat")
                    };
                    stmas.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stmas;
        }

        public static List<SccompDbf> ToSccompList(this DataTable sccomp_dbf)
        {
            List<SccompDbf> sccomp = new List<SccompDbf>();

            foreach (DataRow row in sccomp_dbf.Rows)
            {
                try
                {
                    SccompDbf s = new SccompDbf
                    {
                        compnam = row.Field<string>("compnam").Trim(),
                        compcod = row.Field<string>("compcod").Trim(),
                        path = row.Field<string>("path").Trim(),
                        gendat = row.Field<DateTime?>("gendat"),
                        candel = row.Field<string>("candel").Trim()
                    };

                    sccomp.Add(s);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return sccomp;
        }

        public static List<IsrunDbf> ToIsrunList(this DataTable isrun_dbf)
        {
            List<IsrunDbf> isrun = new List<IsrunDbf>();

            foreach (DataRow row in isrun_dbf.Rows)
            {
                try
                {
                    IsrunDbf i = new IsrunDbf
                    {
                        doctyp = !(row.IsNull("doctyp")) ? row.Field<string>("doctyp") : string.Empty,
                        doccod = !(row.IsNull("doccod")) ? row.Field<string>("doccod") : string.Empty,
                        shortnam = !(row.IsNull("shortnam")) ? row.Field<string>("shortnam") : string.Empty,
                        posdes = !(row.IsNull("posdes")) ? row.Field<string>("posdes") : string.Empty,
                        posdes2 = !(row.IsNull("posdes2")) ?  row.Field<string>("posdes2") : string.Empty,
                        prefix = !(row.IsNull("prefix")) ? row.Field<string>("prefix") : string.Empty,
                        docnum = !(row.IsNull("docnum")) ? row.Field<string>("docnum") : string.Empty,
                        ismodify = !(row.IsNull("ismodify")) ? row.Field<bool>("ismodify") : false,
                        depcod = !(row.IsNull("depcod")) ? row.Field<string>("depcod") : string.Empty,
                        jnltyp = !(row.IsNull("jnltyp")) ? row.Field<string>("jnltyp") : string.Empty,
                        jnlexp = !(row.IsNull("jnlexp")) ? row.Field<string>("jnlexp") : string.Empty,
                        accnum01 = !(row.IsNull("accnum01")) ? row.Field<string>("accnum01") : string.Empty,
                        accnum02 = !(row.IsNull("accnum02")) ? row.Field<string>("accnum02") : string.Empty,
                        accnum03 = !(row.IsNull("accnum03")) ? row.Field<string>("accnum03") : string.Empty,
                        accnum04 = !(row.IsNull("accnum04")) ? row.Field<string>("accnum04") : string.Empty,
                        accnum05 = !(row.IsNull("accnum05")) ? row.Field<string>("accnum05") : string.Empty,
                        accnum06 = !(row.IsNull("accnum06")) ? row.Field<string>("accnum06") : string.Empty,
                        accnum07 = !(row.IsNull("accnum07")) ? row.Field<string>("accnum07") : string.Empty,
                        accnum08 = !(row.IsNull("accnum08")) ? row.Field<string>("accnum08") : string.Empty,
                        accnum09 = !(row.IsNull("accnum09")) ? row.Field<string>("accnum09") : string.Empty,
                        accnum10 = !(row.IsNull("accnum10")) ? row.Field<string>("accnum10") : string.Empty,
                        accnum11 = !(row.IsNull("accnum11")) ? row.Field<string>("accnum11") : string.Empty,
                        accnum12 = !(row.IsNull("accnum12")) ? row.Field<string>("accnum12") : string.Empty,
                        flgvat = !(row.IsNull("flgvat")) ? row.Field<string>("flgvat") : string.Empty,
                        vatrat = !(row.IsNull("vatrat")) ? row.Field<decimal>("vatrat") : 0m,
                        srv_vattyp = !(row.IsNull("srv_vattyp")) ? row.Field<string>("srv_vattyp") : string.Empty,
                        autoprn = !(row.IsNull("autoprn")) ? row.Field<string>("autoprn") : string.Empty,
                        whichform = !(row.IsNull("whichform")) ? row.Field<string>("whichform") : string.Empty,
                        reprn_lev = !(row.IsNull("reprn_lev")) ? row.Field<string>("reprn_lev") : string.Empty,
                        cancel_lev = !(row.IsNull("cancel_lev")) ? row.Field<string>("cancel_lev") : string.Empty,
                        delete_lev = !(row.IsNull("delete_lev")) ? row.Field<string>("delete_lev") : string.Empty,
                        approv_met = !(row.IsNull("approv_met")) ? row.Field<string>("approv_met") : string.Empty,
                        approv_lev = !(row.IsNull("approv_lev")) ? row.Field<string>("approv_lev") : string.Empty,
                        ovrlin_lev = !(row.IsNull("ovrlin_lev")) ? row.Field<string>("ovrlin_lev") : string.Empty,
                        vat_initem = !(row.IsNull("vat_initem")) ? row.Field<string>("vat_initem") : string.Empty,
                        loccod = !(row.IsNull("loccod")) ? row.Field<string>("loccod") : string.Empty,
                        usebarcod = !(row.IsNull("usebarcod")) ? row.Field<string>("usebarcod") : string.Empty,
                        pvatprorat = !(row.IsNull("pvatprorat")) ? row.Field<string>("pvatprorat") : string.Empty,
                        reserve1 = !(row.IsNull("reserve1")) ? row.Field<string>("reserve1") : string.Empty,
                        reserve2 = !(row.IsNull("reserve2")) ? row.Field<string>("reserve2") : string.Empty,
                        reserve3 = !(row.IsNull("reserve3")) ? row.Field<double>("reserve3") : 0d
                    };

                    isrun.Add(i);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return isrun;
        }

        //public static IsinfoDbf ToIsrunDbf(this DataTable isinfo_dbf)
        //{
        //    try
        //    {
        //        IsinfoDbf isinfo = new IsinfoDbf
        //        {

        //        };

        //        return isinfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            if (propertyInfo.PropertyType == typeof(string))
                            {
                                propertyInfo.SetValue(obj, ((string)Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType)).Trim(), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static StmasDbfVM ToViewModel(this StmasDbf stmasdbf)
        {
            if (stmasdbf == null)
                return null;

            StmasDbfVM s = new StmasDbfVM
            {
                selected = false,
                stkcod = stmasdbf.stkcod.Trim(),
                stkdes = stmasdbf.stkdes.Trim(),
                stkdes2 = stmasdbf.stkdes2.Trim(),
                stktyp = stmasdbf.stktyp.Trim(),
                remark = stmasdbf.remark.Trim(),
                StmasDbf = stmasdbf
            };

            return s;
        }

        public static List<StmasDbfVM> ToViewModel(this IEnumerable<StmasDbf> stmasdbf_list)
        {
            List<StmasDbfVM> s = new List<StmasDbfVM>();
            foreach (var item in stmasdbf_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static IsrunDbfVM ToViewModel(this IsrunDbf isrundbf)
        {
            if (isrundbf == null)
                return null;

            IsrunDbfVM i = new IsrunDbfVM
            {
                doctyp = isrundbf.doctyp,
                doccod = isrundbf.doccod,
                shortnam = isrundbf.shortnam,
                posdes = isrundbf.posdes,
                prefix = isrundbf.prefix,
                docnum = isrundbf.docnum,
                depcod = isrundbf.depcod,
                IsrunDbf = isrundbf
            };

            return i;
        }

        public static List<IsrunDbfVM> ToViewModel(this IEnumerable<IsrunDbf> isrundbf_list)
        {
            List<IsrunDbfVM> i = new List<IsrunDbfVM>();

            foreach (var item in isrundbf_list)
            {
                i.Add(item.ToViewModel());
            }

            return i;
        }

        public static IsinfoDbfVM ToViewModel(this IsinfoDbf isinfodbf)
        {
            if (isinfodbf == null)
                return null;

            IsinfoDbfVM i = new IsinfoDbfVM
            {
                compnam = isinfodbf.thinam.Trim(),
                addr = isinfodbf.addr01.Trim() + " " + isinfodbf.addr02.Trim(),
                telnum = isinfodbf.telnum.Trim(),
                taxid = isinfodbf.taxid.Trim()
            };

            return i;
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

        public static int Width(this string str, Font fnt)
        {
            return TextRenderer.MeasureText(str, fnt).Width + 5;
        }

        public static int Height(this string str, Font fnt)
        {
            return TextRenderer.MeasureText(str, fnt).Height;
        }

        public static Rectangle GetDisplayRect(this string str, Font fnt, int x, int y)
        {
            return new Rectangle(x, y, str.Width(fnt), str.Height(fnt));
        }

    }
}
