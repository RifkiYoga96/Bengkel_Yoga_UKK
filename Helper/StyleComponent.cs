﻿using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class StyleComponent
    {
        public static void StyleDateTimeEdit(this SfDateTimeEdit edit)
        {
            edit.Culture = new CultureInfo("id-ID");
            edit.Format = "d MMMM yyyy";
            edit.Style.BorderColor = Color.FromArgb(156, 156, 156);
            edit.Style.HoverBorderColor = Color.FromArgb(52, 152, 219);
            edit.DropDownSize = new Size(298, 240);
            edit.Style.DropDown.BackColor = Color.FromArgb(52, 152, 219);
            edit.Style.DropDown.HoverBackColor = Color.FromArgb(32, 132, 199);
            edit.Style.DropDown.ForeColor = Color.White;
            edit.Style.DropDown.HoverForeColor = Color.White;
        }

        public static void TextChangeNull(TextBox txt, Label lbl, string pesan)
        {
            txt.TextChanged += (s, e) =>
            {
                bool isEmpty = txt.TextLength == 0;
                bool hasLeadingOrTrailingSpace = txt.Text.StartsWith(" ") || txt.Text.EndsWith(" ");

                if (isEmpty)
                {
                    lbl.Text = pesan;
                    lbl.Visible = true;
                }
                else if (hasLeadingOrTrailingSpace)
                {
                    lbl.Text = "Tidak boleh ada spasi di awal dan akhir!";
                    lbl.Visible = true;
                }
                else
                {
                    lbl.Visible = false;
                }
            };
        }

        public static void InputNumber(this TextBoxExt txt)
        {
            txt.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        public static void IsDialogForm(this Form form)
        {
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
