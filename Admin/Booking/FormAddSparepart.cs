using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormAddSparepart : Form
    {
        private readonly ProdukDal _produkDal = new ProdukDal();
        public FormAddSparepart()
        {
            InitializeComponent();
            InitComponent();
            LoadData();
        }

        private void InitComponent()
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void LoadData()
        {

        }
    }
}
