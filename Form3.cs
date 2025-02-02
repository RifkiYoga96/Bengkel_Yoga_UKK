using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class Form3 : Form
    {
        private Panel invoicePanel;
        private Button printButton;
        public Form3()
        {
            InitializeComponent();

            flowLayoutPanel1.Controls.Clear();

            TambahBreadcrumb("Home", () => MessageBox.Show("Ke Home"));
            TambahBreadcrumb("Info", () => MessageBox.Show("Ke Info"));
            TambahBreadcrumb("Setting", () => MessageBox.Show("Ke Setting"), false);

        }

        private void TambahBreadcrumb(string text, Action onClick, bool addSeparator = true)
        {
            LinkLabel btn = new LinkLabel
            {
                Text = text,
                AutoSize = true,
                
            };
            btn.Click += (s, e) => onClick();

            flowLayoutPanel1.Controls.Add(btn);

            if (addSeparator)
            {
                Label separator = new Label { Text = " > ", AutoSize = true };
                flowLayoutPanel1.Controls.Add(separator);
            }
        }
    }
}
