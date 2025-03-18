using ClosedXML.Excel;
using Dapper;
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
        public void GenerateLaporan(DateTime tanggal_1, DateTime tanggal_2)
        {
            var laporan = ListLaporan(tanggal_1, tanggal_2).ToList();
            if (laporan.Count == 0 || laporan == null)
            {
                MB.Error($"Mohon maaf \nTidak ada data pada rentang tanggal \"{tanggal_1:dd-MM-yyyy}\" - \"{tanggal_2:dd-MM-yyyy}\". \nSilakan pilih tanggal yang lain.");
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Laporan Riwayat Servis");
                worksheet.Cell(1, 1).Value = $"Rentang Tanggal : {tanggal_1:dd-MMMM-yyyy} - {tanggal_2:dd-MMMM-yyyy}";

                // Header
                string[] headers = { "Tanggal", "No KTP Pelanggan", "Nama Pelanggan", "No Polisi", "Nama Kendaraan", "Nama Petugas", "Nama Mekanik", "Keluhan", "Catatan", "Total Biaya", "Status" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(2, i + 1).Value = headers[i];
                }

                int row = 3;
                foreach (var item in laporan)
                {
                    worksheet.Cell(row, 1).Value = item.tanggal.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 2).Value = item.ktp_pelanggan ?? "[Tamu]";
                    worksheet.Cell(row, 3).Value = item.nama_pelanggan;
                    worksheet.Cell(row, 4).Value = item.no_pol;
                    worksheet.Cell(row, 5).Value = item.nama_kendaraan;
                    worksheet.Cell(row, 6).Value = item.nama_admin;
                    worksheet.Cell(row, 7).Value = item.nama_mekanik;
                    worksheet.Cell(row, 8).Value = item.keluhan;
                    worksheet.Cell(row, 9).Value = item.catatan;
                    worksheet.Cell(row, 10).Value = $"Rp{item.total_harga:N0}";
                    worksheet.Cell(row, 11).Value = item.status == "selesai" ? "Selesai" : "Dibatalkan";
                    row++;
                }

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

        public IEnumerable<RiwayatModel> ListLaporan(DateTime tanggal_1, DateTime tanggal_2)
        {
            const string sql = @"SELECT
                    CAST(r.tanggal AS DATE) AS tanggal,
                    p.ktp_pelanggan,
                    COALESCE(p.nama_pelanggan, r.nama_pelanggan) AS nama_pelanggan,
                    CASE 
                        WHEN (r.no_pol IS NULL OR r.no_pol = '') AND (r.nama_kendaraan IS NULL OR r.nama_kendaraan = '')
                            THEN CONCAT(k.no_pol, ', ', k.merk)
                        ELSE CONCAT(r.no_pol, ', ', r.nama_kendaraan)
                    END AS nama_kendaraan,
                    a.nama_admin AS nama_petugas,
                    r.ktp_mekanik,
                    js.nama_jasaServis AS jasa_servis,
                    COALESCE(STRING_AGG(s.nama_sparepart, ', '), ' ') AS nama_sparepart,
                    r.keluhan,
                    r.catatan,
                    r.total_harga,
                    r.status
                FROM Riwayat r
                LEFT JOIN Pelanggan p ON r.ktp_pelanggan = p.ktp_pelanggan
                LEFT JOIN Kendaraan k ON r.id_kendaraan = k.id_kendaraan
                LEFT JOIN Admins a ON r.ktp_admin = a.ktp_admin
                LEFT JOIN JasaServis js ON r.id_jasaServis = js.id_jasaServis
                LEFT JOIN RiwayatSparepart rs ON r.id_riwayat = rs.id_riwayat
                LEFT JOIN Sparepart s ON rs.kode_sparepart = s.kode_sparepart
                WHERE r.tanggal BETWEEN CAST(@tanggal_1 AS DATE) AND CAST(@tanggal_2 AS DATE)
                GROUP BY
                    r.tanggal,
                    p.ktp_pelanggan,
                    COALESCE(p.nama_pelanggan, r.nama_pelanggan),
                    CASE  
                        WHEN (r.no_pol IS NULL OR r.no_pol = '') AND (r.nama_kendaraan IS NULL OR r.nama_kendaraan = '')
                            THEN CONCAT(k.no_pol, ', ', k.merk)
                        ELSE CONCAT(r.no_pol, ', ', r.nama_kendaraan)
                    END,
                    a.nama_admin,
                    r.ktp_mekanik,
                    js.nama_jasaServis,
                    r.keluhan,
                    r.catatan,
                    r.total_harga,
                    r.status";

            using var koneksi = new SqlConnection(conn.connStr);
            return koneksi.Query<RiwayatModel>(sql, new { tanggal_1, tanggal_2 });
        }

    }
}



