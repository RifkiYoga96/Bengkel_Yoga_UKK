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
    public partial class FormInputJasaServis : Form
    {
        private readonly JasaServisDal _jasaServisDal = new JasaServisDal();
        private int _id_JasaServis = 0;
        private bool _isInsert = true;
        public FormInputJasaServis(int id_jasaServis, bool isInsert = true)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            
            if (!isInsert)
            {
                GetData(id_jasaServis);
                lblHeader.Text = "Edit Jasa Servis";
                _isInsert = false;
                _id_JasaServis = id_jasaServis;
            }
        }

        #region EVENT

        private void RegisterEvent()
        {
            StyleComponent.TextChangeNull(txtNamaJasa, lblErrorJasa, "⚠️ Harap isi nama jasa servis!");

            txtHarga.DecimalValueChanged += (s, e) =>
            {
                if (txtHarga.DecimalValue == 0)
                    lblErrorHarga.Visible = true;
                else
                    lblErrorHarga.Visible = false;
            };
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            
        }

        #endregion

        #region INIT COMPONENT

        private void InitComponent()
        {

        }

        #endregion

        #region LOADDATA
        private void GetData(int id)
        {

        }
        #endregion
    }
}
