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
            InitComponent();
            RegisterEvent();
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
            SaveData();
        }

        #endregion

        #region INIT COMPONENT

        private void InitComponent()
        {
            txtNamaJasa.MaxLength = 90;
            txtHarga.MaxValue = 90000000;
        }

        #endregion

        #region LOADDATA & SAVE
        private void GetData(int id)
        {
            var data = _jasaServisDal.GetData(id);
            if (data is null) return;

            txtNamaJasa.Text = data.nama_jasaServis;
            txtHarga.DecimalValue = data.harga;
        }

        private void SaveData()
        {
            string nama_jasa = txtNamaJasa.Text;
            int harga = Convert.ToInt32(txtHarga.DecimalValue);

            bool valid = !lblErrorHarga.Visible &&
                !lblErrorJasa.Visible;
            if (!valid)
            {
                MB.Warning("Data tidak valid, harap cek kembali!");
                return;
            }
            if (!MB.Konfirmasi("Apakah anda yakin ingin menyimpan data?")) return;

            var jasa = new JasaServisModel
            {
                id_jasaServis = _id_JasaServis,
                nama_jasaServis = nama_jasa,
                harga = harga
            };
            if(_isInsert)
                _jasaServisDal.InsertData(jasa);
            else
                _jasaServisDal.UpdateData(jasa);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
