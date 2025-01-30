using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputProduk : Form
    {
        public FormInputProduk()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            txtStok.NumberDecimalDigits = 0;
            txtStokMinimum.NumberDecimalDigits = 0;
            btnPlusStok.Click += (s, e) => txtStok.DoubleValue += 1;
            btnMinStok.Click += (s, e) => txtStok.DoubleValue -= 1;
            btnPlusStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue += 1;
            btnMinStokMinimum.Click += (s, e) => txtStokMinimum.DoubleValue -= 1;

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            int harga = Convert.ToInt32(txtHarga.DecimalValue);
           
        }
    }
}
