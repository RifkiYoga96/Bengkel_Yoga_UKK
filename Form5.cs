using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.Core;
using Syncfusion.WinForms.Core.Enums;

namespace Bengkel_Yoga_UKK
{
    public partial class Form5 : SfForm
    {
        public Form5()
        {
            InitializeComponent();
            this.Style.TitleBar.BackColor = Color.FromArgb(46, 134, 171);
            this.Style.TitleBar.ForeColor = Color.White;

            this.Style.TitleBar.CloseButtonForeColor = Color.White;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.White;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.White;

            //this.Style.InactiveBorder = new Pen(Color.FromArgb(46, 134, 171));
        }
    }
}
