using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public static class StyleComponent
    {
        public static void StyleDateTimeEdit(this SfDateTimeEdit edit)
        {
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
                lbl.Text = pesan;
                lbl.Visible = txt.TextLength == 0;
            };
        }
    }
}
