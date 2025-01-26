using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.WinForms.Controls;

namespace Bengkel_Yoga_UKK
{
    public static class FormExtensions
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        public static void EnableFlashing(this Form form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            form.Deactivate += (sender, e) => FlashWindow(form.Handle, true);
        }
    }
}
