using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormDetailBooking : Form
    {
        private readonly BookingDal _bookingDal = new BookingDal();
        private readonly JasaServisDal _jasaServisDal = new JasaServisDal();
        private readonly KaryawanDal _karyawanDal = new KaryawanDal();
        private readonly ProdukDal _produkDal = new ProdukDal();
        public static int _id_booking;
        private string _servisKeterangan = "pending";
        private bool _invoiceShow = false;
        Color _hijau = Color.FromArgb(0, 192, 0);
        Color _oren = Color.FromArgb(240, 177, 0);
        Color _biru = Color.FromArgb(52, 152, 219);
        Color _merah = Color.FromArgb(239, 7, 7); //merah
        public FormDetailBooking(int id)
        {
            InitializeComponent();
            InitComponent();

            _id_booking = id;
            RegisterEvent();

            GetData();
            ProgresServisGaris();
        }
        private void RegisterEvent()
        {
            btnSparepart.Click += (s, e) =>
            {
                if (new FormAddSparepart().ShowDialog() != DialogResult.OK) return;
                GetData();
            };

            btnProgressServis.Click += (s, e) => 
            {
                ProgresServisButton();
            };

            btnBatalkanPesanan.Click += BtnBatalkanPesanan_Click;
            btnSelesai.Click += (s, e) => ProgresServisButton(true);
            comboMekanik.SelectedIndexChanged += async (s, e) => await SaveDataTunggal("mekanik");
            comboServis.SelectedIndexChanged += async (s, e) => await SaveDataTunggal("jasaServis");
            txtCatatan.Leave += async (s,e) => await SaveDataTunggal("catatan");
        }


        private void BtnBatalkanPesanan_Click(object? sender, EventArgs e)
        {
            if (txtCatatan.TextLength == 0)
            {
                MB.Warning("Mohon mengisi alasan pembatalan pada catatan!");
                return;
            }
            if (!MB.Konfirmasi("Apakah anda yakin ingin membatalkan pesanan ini?\nIsi alasan pembatalan pada catatan")) return;
            CancelServis();
        }

        private async void ProgresServisButton(bool clickFromBtnSelesai = false)
        {
            if (_servisKeterangan == "pending")
            {
                if (!MB.Konfirmasi("Apakah anda yakin ingin mengubah status menjadi Dikerjakan?\nTindakan ini tidak dapat diurungkan")) return;
                _servisKeterangan = "dikerjakan";
            }
            else if (_servisKeterangan == "dikerjakan")
            {
                if (!MB.Konfirmasi("Apakah anda yakin bahwa servis Sudah Selesai?\nTindakan ini tidak dapat diurungkan")) return;
                _servisKeterangan = "belum bayar";
            }
            else if (_servisKeterangan == "belum bayar")
            {
                bool valid = comboServis.SelectedIndex != 0
                    && comboMekanik.SelectedIndex != 0
                    && txtCatatan.TextLength != 0
                    && txtCatatan.Text.Trim() != string.Empty;
                if (!valid)
                {
                    MB.Warning("Mohon melengkapi jenis servis, mekanik dan catatan terlebih dahulu!");
                    return;
                }

                _invoiceShow = true;
                btnSelesai.Visible = _invoiceShow;

                if (clickFromBtnSelesai)
                {
                    if (!MB.Konfirmasi("Apakah anda yakin bahwa pesanan ini Sudah Dibayar?\nTindakan ini tidak dapat diurungkan")) return;
                    _servisKeterangan = "selesai";
                    await KonfirmasiSelesaiServis(true); //insert
                    btnBatalkanPesanan.Visible = false;
                }
                else
                {
                    CetakInvoice(_id_booking);
                }
                
            }
            ProgresServisGaris();
            await Task.Delay(1000);
            await SaveDataTunggal("progress");
        }
        private async void CancelServis()
        {
            if (_servisKeterangan == "pending")
                _servisKeterangan = "batal booking";
            else if (_servisKeterangan == "dikerjakan")
                _servisKeterangan = "batal servis";
            else if (_servisKeterangan == "belum bayar")
                _servisKeterangan = "batal pembayaran";

            ProgresServisGaris();
            await SaveDataTunggal("progress");
            await KonfirmasiSelesaiServis(true);
            btnBatalkanPesanan.Visible = false;
        }

        private void ProgresServisGaris()
        {
            if (_servisKeterangan == "pending")
            {
                panelBookingToServis.BackColor = SystemColors.ControlDarkDark;
                pictureServis.BackgroundImage = null;
                pictureServis.BorderSize = 2;
                panelServisToPembayaran.BackColor = SystemColors.ControlDarkDark;
                pictureSelesai.BackgroundImage = null;
                pictureSelesai.BorderSize = 2;

                ButtonStatus(_biru, "Pending");
            }
            else if (_servisKeterangan == "dikerjakan")
            {
                panelBookingToServis.BackColor = _oren;
                pictureServis.BackColor = _oren;
                pictureServis.BorderSize = 0;
                panelServisToPembayaran.BackColor = SystemColors.ControlDarkDark;
                pictureSelesai.BackColor = Color.Transparent;
                pictureSelesai.BorderSize = 2;

                lblServis.Visible = true;
                lblServis.Text = "(Dikerjakan)";
                lblServis.ForeColor = _oren;

                btnProgressServis.BackColor = _hijau;
                btnProgressServis.Text = "Selesai Servis";

                ButtonStatus(_oren, "Dikerjakan");
            }
            else if (_servisKeterangan == "belum bayar")
            {
                panelBookingToServis.BackColor = _hijau;
                pictureServis.BackColor = _hijau;
                pictureServis.BorderSize = 0;
                panelServisToPembayaran.BackColor = _oren;
                pictureSelesai.BackColor = _oren;
                pictureSelesai.BorderSize = 0;

                lblServis.Visible = true;
                lblServis.Text = "(Selesai)";
                lblServis.ForeColor = _hijau;

                lblPembayaran.Visible = true;
                lblPembayaran.Text = "(Belum Bayar)";
                lblPembayaran.ForeColor = _oren;

                btnProgressServis.BackColor = _biru;
                btnProgressServis.Text = "Invoice";

                ButtonStatus(_oren, "Belum Bayar");
            }
            else if (_servisKeterangan == "batal booking")
            {
                lblBooking.Text = "(Dibatalkan)";
                lblBooking.ForeColor = _merah;
                pictureBooking.BackColor = _merah;

                ButtonStatus(_merah, "Dibatalkan");
            }
            else if (_servisKeterangan == "batal servis")
            {
                panelBookingToServis.BackColor = _merah;
                pictureServis.BackColor = _merah;
                pictureServis.BorderSize = 0;

                lblServis.Visible = true;
                lblServis.Text = "(Dibatalkan)";
                lblServis.ForeColor = _merah;

                ButtonStatus(_merah, "Dibatalkan");
            }
            else if (_servisKeterangan == "batal pembayaran")
            {
                panelBookingToServis.BackColor = _hijau;
                pictureServis.BackColor = _hijau;
                pictureServis.BorderSize = 0;

                panelServisToPembayaran.BackColor = _merah;
                pictureSelesai.BackColor = _merah;
                pictureSelesai.BorderSize = 0;

                lblPembayaran.Visible = true;
                lblPembayaran.Text = "(Dibatalkan)";
                lblPembayaran.ForeColor = _merah;

                ButtonStatus(_merah, "Dibatalkan");
            }
            else
            {
                panelBookingToServis.BackColor = _hijau;
                pictureServis.BackColor = _hijau;
                pictureServis.BorderSize = 0;

                panelServisToPembayaran.BackColor = _hijau;
                pictureSelesai.BackColor = _hijau;
                pictureSelesai.BorderSize = 0;

                lblServis.Visible = true;
                lblServis.Text = "(Selesai)";
                lblServis.ForeColor = _hijau;

                lblPembayaran.Visible = true;
                lblPembayaran.Text = "(Selesai)";
                lblPembayaran.ForeColor = _hijau;

                ButtonStatus(_hijau, "Selesai");

            }
        }

        private void ButtonStatus(Color warna, string text)
        {
            btnStatus.BackColor = warna;
            btnStatus.Text = text;
        }

        private void InitComponent()
        {
            label1.ForeColor = SystemColors.ControlText;
            label10.ForeColor = SystemColors.ControlText;
            btnSelesai.Visible = false;

            var listServis = new List<JasaServisModel>()
            {
                new JasaServisModel{ id_jasaServis = 0, nama_jasaServis ="--Pilih jasa servis--", harga = 0 }
            };
            listServis.AddRange(_jasaServisDal.ListData(new FilterDto()));
            comboServis.DataSource = listServis;
            comboServis.DisplayMember = "nama_jasaServis";
            comboServis.ValueMember = "id_jasaServis";

            var listMekanik = new List<MekanikModelCombo>()
            {
                new MekanikModelCombo{ ktp_mekanik = string.Empty,nama_mekanik = "--Pilih Mekanik--" }
            };
            listMekanik.AddRange(_karyawanDal.ListData(new FilterDto())
               .Where(x => x.role == 0)
               .Select(x => new MekanikModelCombo
               {
                   ktp_mekanik = x.ktp_admin,
                   nama_mekanik = x.nama_admin
               }).ToList());
            comboMekanik.DataSource = listMekanik;
            comboMekanik.DisplayMember = "nama_mekanik";
            comboMekanik.ValueMember = "ktp_mekanik";
        }

        private void GetData()
        {
            var data = _bookingDal.GetData(_id_booking);
            if (data is null) return;

            lblIdBooking.Text = data.id_booking.ToString();
            lblNama.Text = data.nama_pelanggan;
            lblNoKTP.Text = data.ktp_pelanggan;
            lblKendaraan.Text = data.nama_kendaraan;
            lblNoPol.Text = data.no_pol;
            lblTanggal.Text = data.tanggal.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
            lblKeluhan.Text = data.keluhan;

            foreach (var item in comboServis.Items)
                if (item is JasaServisModel js)
                    if (js.id_jasaServis == data.id_jasaServis)
                        comboServis.SelectedItem = item;

            foreach (var item in comboMekanik.Items)
                if (item is MekanikModelCombo m)
                    if (m.ktp_mekanik == data.ktp_mekanik)
                        comboMekanik.SelectedItem = item;
            txtCatatan.Text = data.catatan;


            var listSparepart = _bookingDal.ListDataProduk(_id_booking);
            txtSparepart.Text = string.Join(", ", listSparepart.Select(x => x.nama_sparepart));


            lblAntrean.Text = (data.tipe_antrean == 1 ? "A" : "B") + data.antrean.ToString("D3");
            _servisKeterangan = data.status;
            ProgresServisGaris();
        }

        private async Task SaveDataAsync()
        {
            /*int id_booking = Convert.ToInt32(lblIdBooking.Text.Trim());
            int? jasaServis = comboServis.SelectedIndex == 0 ? null : Convert.ToInt32(comboServis.SelectedValue);
            string? ktp_mekanik = comboMekanik.SelectedIndex == 0 ? null : comboMekanik.SelectedValue.ToString() ?? string.Empty;
            string catatan = txtCatatan.Text;

            string status = _servisKeterangan;

            if (comboMekanik.SelectedIndex == 0)
                ktp_mekanik = string.Empty;

            var data = new BookingModel
            {
                id_booking = id_booking,
                id_jasaServis = jasaServis,
                ktp_mekanik = ktp_mekanik,
                catatan = catatan,
                status = status
            };

            await _bookingDal.UpdateKonfirmasiBookingAsync(data);*/
        }

        private async Task SaveDataTunggal(string component)
        {
            var models = new FilterDto();
            models.param = new Dapper.DynamicParameters();
            if (component == "mekanik")
            {
                string? ktp_mekanik = comboMekanik.SelectedIndex == 0 ? null : comboMekanik.SelectedValue.ToString() ?? string.Empty;
                models.sql = @"UPDATE Bookings SET ktp_mekanik = @ktp WHERE id_booking = @id";
                models.param.Add("@ktp",ktp_mekanik);
                models.param.Add("@id",_id_booking);
            }
            else if(component == "jasaServis")
            {
                int? jasaServis = comboServis.SelectedIndex == 0 ? null : Convert.ToInt32(comboServis.SelectedValue);
                models.sql = @"UPDATE Bookings SET id_jasaServis = @id_jasaServis WHERE id_booking = @id";
                models.param.Add("@id_jasaServis", jasaServis);
                models.param.Add("@id", _id_booking);
            }
            else if( component == "catatan")
            {
                string catatan = txtCatatan.Text;
                models.sql = @"UPDATE Bookings SET catatan = @catatan WHERE id_booking = @id";
                models.param.Add("@catatan", catatan);
                models.param.Add("@id", _id_booking);
            }
            else if(component == "progress")
            {
                if (_servisKeterangan == "dikerjakan") 
                    models.sql = @"UPDATE Bookings SET status = @status, tanggal_servis = @tanggal_servis WHERE id_booking = @id";
                else
                    models.sql = @"UPDATE Bookings SET status = @status WHERE id_booking = @id";

                models.param.Add("@status", _servisKeterangan);
                models.param.Add("@id", _id_booking);
                models.param.Add("@tanggal_servis", DateTime.Now);
            }
            await _bookingDal.UpdateKonfirmasiBookingAsync(models);
        }

        private void CetakInvoice(int id_boking)
        {
            var booking = _bookingDal.GetData(id_boking);
            var listSparepart = _bookingDal.ListDataProduk(_id_booking);
            string namaJasaServis = ((JasaServisModel)comboServis.SelectedItem).nama_jasaServis;
            int hargaJasaServis = ((JasaServisModel)comboServis.SelectedItem).harga;

            List<string> listBarangJasa = new List<string>() { namaJasaServis };
            listBarangJasa.AddRange(listSparepart.Select(x => x.nama_sparepart).ToList());

            List<int> listQtc = new List<int>() { 1 };
            listQtc.AddRange(listSparepart.Select(x => x.jumlah).ToList());

            List<int> listHarga = new List<int>() { hargaJasaServis };
            listHarga.AddRange(listSparepart.Select(x => x.harga).ToList());

            if (booking == null) return;

            var invoice = new InvoiceModel()
            {
                LogoPath = @"D:\gws.png",
                NamaBengkel = "BENGKEL PROFIX",
                AlamatBengkel = "Jl. Yos Sudarso No.16, Paten Srihardono",
                EmailBengkel = "bengkelprofix@gmail.com",
                TelpBengkel = "08422426242",

                Antrean = lblAntrean.Text,
                Tanggal = DateTime.Today,
                NamaPelanggan = booking.nama_pelanggan,
                NamaKendaraan = booking.nama_kendaraan,
                NoPolisi = booking.no_pol,
                NomorInvoice = $"INV-{_id_booking}-{lblAntrean.Text.Trim()}-{DateTime.Today.ToString("yyyyMMdd")}",

                ListBarang = listBarangJasa,
                ListQuantity = listQtc,
                ListHarga = listHarga,

                Catatan = txtCatatan.Text
            };

            InvoiceGenerators.GenerateInvoice(invoice);
        }

        private async Task KonfirmasiSelesaiServis(bool cancel = false)
        {
            var listSparepart = _bookingDal.ListDataProduk(_id_booking);
            int hargaJasaServis = ((JasaServisModel)comboServis.SelectedItem).harga;

            List<int> listQtc = new List<int>() { 1 };
            listQtc.AddRange(listSparepart.Select(x => x.jumlah).ToList());

            List<int> listHarga = new List<int>() { hargaJasaServis };
            listHarga.AddRange(listSparepart.Select(x => x.harga).ToList());

            int total = 0;
            for (int i = 0; i < listHarga.Count; i++)
            {
                total += listQtc[i] * listHarga[i];
            }

            MB.Warning(_servisKeterangan);
            
            var dp = new DynamicParameters();
            dp.Add("@id_booking",_id_booking);
            dp.Add("@ktp_admin",GlobalVariabel._ktp);
            dp.Add("@total_harga",total);
            dp.Add("@status",_servisKeterangan);
            dp.Add("@pembatalan_oleh",cancel ? "Admin/Petugas" : null);

            await _bookingDal.SelesaiServisUpdate(dp);
            
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {

        }
    }
}

public class MekanikModelCombo
{
    public string ktp_mekanik { get; set; }
    public string nama_mekanik { get; set; }
}