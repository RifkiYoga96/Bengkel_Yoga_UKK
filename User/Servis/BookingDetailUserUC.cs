using Syncfusion.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class BookingDetailUserUC : UserControl
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly RiwayatDal _riwayatDal = new RiwayatDal();
        private bool _isBooking = false;
        private int _id_terkait = 0;
        private bool _isSelesai = false;
        private CultureInfo _culture = new CultureInfo("id-ID");
        public BookingDetailUserUC(bool isBooking, int id_terkait)
        {
            InitializeComponent();
            _isBooking = isBooking;
            _id_terkait = id_terkait;
            InitComponent();
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            this.Load += (s, e) =>
            {
                ServisUserUC._child = true;
                LoadData();

                if (_isSelesai)
                {
                    int space = (panelDetails.Location.Y + panelDetails.Height) - (panelProgres.Location.Y + panelProgres.Height) - panelDetails.Height;
                    panelSparepart.Location = new Point(panelSparepart.Location.X, panelDetails.Location.Y + panelDetails.Height + space);

                    panelSparepart.Visible = true;

                    StyleGrid();
                }
            };
        }
        private void InitComponent()
        {
            SettingButtonStatus(Color.FromArgb(4, 120, 244), "Pending"); //biru
        }
        private void LoadData()
        {
            Color orenColor = Color.FromArgb(240, 177, 0); //oren
            Color hijauColor = Color.FromArgb(0, 192, 0); //hijau
            Color merahColor = Color.FromArgb(239, 7, 7); //merah

            if (_isBooking)
            {
                var data = _bookingDal.GetData(_id_terkait);
                if (data is null) return;
                if (data.status == "dikerjakan")
                {
                    panelBookingToServis.BackColor = hijauColor;
                    pictureServis.BackColor = hijauColor;
                    pictureServis.BorderSize = 0;

                    lblServis.Visible = true;
                    lblServis.Text = "(Proses)";
                    lblServis.ForeColor = orenColor;

                    SettingButtonStatus(orenColor, "Dikerjakan");

                    btnBatalkanPesanan.Visible = false;
                }
                else if (data.status == "belum bayar")
                {
                    panelBookingToServis.BackColor = hijauColor;
                    pictureServis.BackColor = hijauColor;
                    pictureServis.BorderSize = 0;
                    panelServisToPembayaran.BackColor = orenColor;
                    pictureSelesai.BackColor = orenColor;
                    pictureSelesai.BorderSize = 0;

                    lblServis.Visible = true;
                    lblServis.Text = "(Selesai)";
                    lblServis.ForeColor = hijauColor;

                    lblPembayaran.Visible = true;
                    lblPembayaran.Text = "(Belum Bayar)";
                    lblPembayaran.ForeColor = orenColor;

                    SettingButtonStatus(orenColor, "Belum Bayar");
                }

                lblKendaraan.Text = data.nama_kendaraan;
                lblNoPol.Text = data.no_pol;
                lblTanggalBooking.Text = data.tanggal.ToString("d MMMM yyyy", _culture);
                lblKeluhan.Text = data.keluhan;

                lbl2.Location = lbl1.Location;
                lblCatatan.Location = lblBatal.Location;
                lbl1.Visible = false;
                lblBatal.Visible = false;
            }
            else
            {
                var data = _riwayatDal.GetData(_id_terkait);
                if (data is null) return;

                if (data.status == "batal booking")
                {
                    pictureBooking.BackColor = merahColor;
                    pictureBooking.BorderSize = 0;
                    panelBookingToServis.BackColor = merahColor;
                    lblBooking.Visible = true;
                    lblBooking.Text = "(Dibatalkan)";
                    lblBooking.ForeColor = merahColor;

                    SettingButtonStatus(merahColor, "Dibatalkan");
                }
                else if (data.status == "batal servis")
                {
                    panelBookingToServis.BackColor = merahColor;
                    pictureServis.BackColor = merahColor;
                    pictureServis.BorderSize = 0;
                    lblServis.Visible = true;
                    lblServis.Text = "(Dibatalkan)";
                    lblServis.ForeColor = merahColor;

                    SettingButtonStatus(merahColor, "Dibatalkan");
                }
                else if (data.status == "batal pembayaran")
                {
                    panelBookingToServis.BackColor = hijauColor;
                    pictureServis.BackColor = hijauColor;
                    pictureServis.BorderSize = 0;
                    lblServis.Visible = true;
                    lblServis.Text = "(Selesai)";
                    lblServis.ForeColor = hijauColor;

                    panelServisToPembayaran.BackColor = merahColor;
                    pictureSelesai.BackColor = merahColor;
                    pictureSelesai.BorderSize = 0;
                    lblPembayaran.Visible = true;
                    lblPembayaran.Text = "(Dibatalkan)";
                    lblPembayaran.ForeColor = merahColor;

                    SettingButtonStatus(merahColor, "Dibatalkan");
                }
                else
                {
                    panelBookingToServis.BackColor = hijauColor;
                    pictureServis.BackColor = hijauColor;
                    pictureServis.BorderSize = 0;
                    panelServisToPembayaran.BackColor = hijauColor;
                    pictureSelesai.BackColor = hijauColor;
                    pictureSelesai.BorderSize = 0;

                    lblServis.Visible = true;
                    lblServis.Text = "(Selesai)";
                    lblServis.ForeColor = hijauColor;

                    lblPembayaran.Visible = true;
                    lblPembayaran.Text = "(Selesai)";
                    lblPembayaran.ForeColor = hijauColor;

                    SettingButtonStatus(hijauColor, "Selesai");

                    lbl2.Location = lbl1.Location;
                    lblCatatan.Location = lblBatal.Location;
                    lbl1.Visible = false;
                    lblBatal.Visible = false;

                    //sparepart
                    var listSparepart = _riwayatDal.ListDataSparepartUser(_id_terkait).ToList();

                    var toGrid = listSparepart.Select(x => new InvoiceDto
                    {
                        nama_sparepart = x.nama_sparepart,
                        harga_satuan = x.harga.ToString("C0", _culture),
                        jumlah = x.jumlah.ToString(),
                        total = (x.harga * x.jumlah).ToString("C0", _culture)
                    }).ToList();

                    var jasaServis = _riwayatDal.GetJasaServis(_id_terkait)
                        .Select(x => new InvoiceDto
                        {
                            nama_sparepart = x.nama_jasaServis,
                            harga_satuan = x.harga.ToString("C0", _culture),
                            jumlah = "-",
                            total = x.harga.ToString("C0", _culture)
                        }).ToList();

                    toGrid.AddRange(jasaServis);

                    gridSparepart.DataSource = toGrid;

                    ResizeSparepart(40,55,toGrid.Count());

                    _isSelesai = true;
                }

                btnBatalkanPesanan.Visible = false;

                lblSelesaiOrBatal.Text = data.status != "selesai" ? "Dibatalkan :" : "Selesai :";

                lblKendaraan.Text = data.nama_kendaraan;
                lblNoPol.Text = data.no_pol;
                lblTanggalBooking.Text = data.tanggal.ToString("d MMMM yyyy", _culture);
                lblMulaiServis.Text = data.tanggal_servis.ToString("d MMMM yyyy HH:mm", _culture);
                lblSelesaiOrBatalV.Text = data.tanggal_selesai.ToString("d MMMM yyyy HH:mm", _culture);
                lblKeluhan.Text = data.keluhan;
                lblPetugas.Text = data.nama_admin;
                lblMekanik.Text = data.nama_mekanik;
                lblBatal.Text = data.pembatalan_oleh;
                lblCatatan.Text = data.catatan;




            }
        }
        private void SettingButtonStatus(Color color, string txt)
        {
            btnStatus.BackColor = color;
            btnStatus.FlatAppearance.MouseOverBackColor = color;
            btnStatus.FlatAppearance.MouseDownBackColor = color;
            btnStatus.Text = txt;
        }

        private void StyleGrid()
        {
            DataGridView dgv = gridSparepart;
            CustomGrids.CustomDataGrid(dgv);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns["No"].FillWeight = 10;
            dgv.Columns["nama_sparepart"].FillWeight = 30;
            dgv.Columns["harga_satuan"].FillWeight = 20;
            dgv.Columns["jumlah"].FillWeight = 20;
            dgv.Columns["total"].FillWeight = 20;


            dgv.Columns["No"].HeaderText = "   No";
            dgv.Columns["nama_sparepart"].HeaderText = "Nama Barang/Jasa";
            dgv.Columns["harga_satuan"].HeaderText = "Harga Satuan";
            dgv.Columns["jumlah"].HeaderText = "Jumlah";
            dgv.Columns["total"].HeaderText = "Total";

            dgv.Columns["No"].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            dgv.Columns["total"].DefaultCellStyle.Padding = new Padding(0, 0, 20, 0);
            dgv.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["jumlah"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            
        }
        private void ResizeSparepart(int headerHeight, int rowHeight,int jumlahRow)
        {
            panelSparepart.Height = jumlahRow > 1 ? panelSparepart.Height + jumlahRow * rowHeight : panelSparepart.Height;
            gridSparepart.Height = headerHeight + (rowHeight * jumlahRow);
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}

public class InvoiceDto 
{
    public int No {  get; set; }
    public string nama_sparepart {  get; set; }
    public string harga_satuan { get; set; }
    public string jumlah { get; set; }
    public string total { get; set; }

}

