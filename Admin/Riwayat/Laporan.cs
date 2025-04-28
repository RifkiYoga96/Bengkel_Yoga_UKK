using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Drawing;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class Laporan
    {
        public void GenerateLaporan(DateTime tgl1, DateTime tgl2)
        {
            var laporan = ListLaporan(tgl1, tgl2).ToList();
            if (laporan.Count == 0 || laporan == null)
            {
                MB.Error($"Mohon maaf \nTidak ada data pada rentang tanggal \"{tgl1:dd-MM-yyyy}\" - \"{tgl2:dd-MM-yyyy}\". \nSilakan pilih tanggal yang lain.");
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Laporan Riwayat Servis");
                worksheet.Cell(1, 1).Value = $"Rentang Tanggal : {tgl1:dd-MMMM-yyyy} - {tgl2:dd-MMMM-yyyy}";
                worksheet.Style.Font.FontSize = 12;
                worksheet.Rows().Height = 25;

                // Header
                string[] headers = { "No", "KTP Pelanggan", "Nama Pelanggan", "No Polisi", "Nama Kendaraan", "Keluhan", "Tanggal Booking", "Mulai Servis", "Selesai/Pembatalan Servis", "Petugas/Admin", "Mekanik", "Catatan", "Daftar Sparepart", "Status", "Pembatalan Oleh", "Total Biaya" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(2, i + 1).Value = headers[i];
                }

                int row = 3;
                foreach (var item in laporan)
                {
                    worksheet.Cell(row, 1).Value = row - 2;
                    worksheet.Cell(row, 2).Value = item.ktp_pelanggan ?? "[Tamu]";
                    worksheet.Cell(row, 3).Value = item.nama_pelanggan;
                    worksheet.Cell(row, 4).Value = item.no_polisi;
                    worksheet.Cell(row, 5).Value = item.nama_kendaraan;
                    worksheet.Cell(row, 6).Value = item.keluhan;
                    worksheet.Cell(row, 7).Value = item.tanggal.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 8).Value = item.tanggal_servis?.ToString("dd-MM-yyyy HH:mm") ?? "-";
                    worksheet.Cell(row, 9).Value = item.tanggal_selesai?.ToString("dd-MM-yyyy HH:mm") ?? "-";
                    worksheet.Cell(row, 10).Value = item.nama_admin;
                    worksheet.Cell(row, 11).Value = item.nama_mekanik;
                    worksheet.Cell(row, 12).Value = item.catatan;
                    worksheet.Cell(row, 13).Value = item.daftar_sparepart;
                    worksheet.Cell(row, 14).Value = item.status == "selesai" ? "Selesai" : "Dibatalkan";
                    worksheet.Cell(row, 15).Value = item.pembatalan_oleh;
                    worksheet.Cell(row, 16).Value = $"Rp{item.total_harga:N0}";

                    row++;
                }

                worksheet.Cell(row, 15).Value = "Total";
                worksheet.Cell(row, 1).Style.Font.Bold = true;
                //worksheet.Range(row, 1, row, 15).Merge();
                worksheet.Cell(row, 16).Value = $"Rp{laporan.Sum(x => x.total_harga):N0}";
                worksheet.Cell(row, 16).Style.Font.Bold = true;
                worksheet.Cell(row, 16).Style.Fill.BackgroundColor = XLColor.LightGray;

                row++;

                // Format tabel
                var range = worksheet.Range(2, 1, row - 1, headers.Length);
                var table = range.CreateTable();
                table.Theme = XLTableTheme.TableStyleLight15;
                worksheet.Columns().AdjustToContents();


                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Simpan Laporan",
                    FileName = "Laporan_Riwayat_Servis.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                        workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        public IEnumerable<LaporanModel> ListLaporan(DateTime tgl1, DateTime tgl2)
        {
            const string sql = @"SELECT 
                    r.ktp_pelanggan, 
                    COALESCE(r.nama_pelanggan, p.nama_pelanggan) AS nama_pelanggan, 
                    COALESCE(r.no_pol, k.no_pol) AS no_pol,
                    COALESCE(
                        r.nama_kendaraan, 
                        CONCAT(k.merk, ' ', k.tipe, ' ', k.kapasitas, 'cc (', k.tahun, ')')
                    ) AS nama_kendaraan,
                    r.tanggal,
                    r.tanggal_servis,
                    r.tanggal_selesai,
                    r.keluhan,
                    r.catatan,
                    a.nama_admin AS nama_admin,
                    m.nama_admin AS nama_mekanik,
                    r.status,
                    r.total_harga,
                    COALESCE(r.pembatalan_oleh, '-') as pembatalan_oleh,
                    COALESCE(rs.sparepart_list, '(Tidak Ada Sparepart)') AS daftar_sparepart
                FROM Riwayat r
                LEFT JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                LEFT JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                LEFT JOIN JasaServis js ON r.id_jasaServis = js.id_jasaServis
                LEFT JOIN Admins a ON r.ktp_admin = a.ktp_admin
                LEFT JOIN Admins m ON r.ktp_mekanik = m.ktp_admin
                LEFT JOIN (
                    SELECT 
                        rs.id_riwayat, 
                        STRING_AGG(CONCAT(rs.nama_sparepart, '(', rs.jumlah, ')'), ', ') AS sparepart_list
                    FROM RiwayatSparepart rs
                    GROUP BY rs.id_riwayat
                ) rs ON r.id_riwayat = rs.id_riwayat
                ORDER BY r.id_riwayat ASC";

            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<LaporanModel>(sql, new { tgl1, tgl2  });
        }
    }
}





public class LaporanModel
{
    public string ktp_pelanggan { get; set; }
    public string nama_pelanggan { get; set; }
    public string no_polisi { get; set; }
    public string nama_kendaraan { get; set; }
    public string keluhan { get; set; }

    public DateTime tanggal { get; set; }
    public DateTime? tanggal_servis { get; set; }
    public DateTime? tanggal_selesai { get; set; }
    public string nama_admin { get; set; }
    public string nama_mekanik { get; set; }
    public string catatan { get; set; }
    public string daftar_sparepart { get; set; }
    public string status { get; set; }
    public string pembatalan_oleh { get; set; } = string.Empty;
    public int total_harga { get; set; }
}



