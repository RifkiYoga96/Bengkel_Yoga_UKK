using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Bengkel_Yoga_UKK
{
    public class InvoiceGenerators
    {
        public static void GenerateInvoice(InvoiceModel invoice)
        {
            string logoPath = @"D:\gws.png";

            // Nama file dan path
            string fileName = $"Invoice_{invoice.NamaPelanggan}_{invoice.Tanggal:dd-MM-yyyy}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Ukuran kertas A4 (595 x 842 pts)
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 30f, 30f, 30f, 30f);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Font Styling
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);
            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            iTextSharp.text.Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            iTextSharp.text.Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            iTextSharp.text.Font invoiceFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36, BaseColor.GRAY);

            // Header dengan logo dan tulisan "INVOICE"
            PdfPTable headerTable = new PdfPTable(2)
            {
                WidthPercentage = 100
            };
            headerTable.SetWidths(new float[] { 30f, 70f });

            // Logo di kiri
            if (File.Exists(logoPath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                logo.ScaleToFit(40f, 40f); // Sesuaikan ukuran logo
                PdfPCell logoCell = new PdfPCell(logo)
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    PaddingBottom = 10f
                };
                headerTable.AddCell(logoCell);
            }
            else
            {
                headerTable.AddCell(new PdfPCell(new Phrase(" ")) { Border = iTextSharp.text.Rectangle.NO_BORDER });
            }

            // Tulisan "INVOICE" di kanan
            PdfPCell invoiceCell = new PdfPCell(new Phrase("INVOICE", invoiceFont))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_BOTTOM,
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                PaddingBottom = 10f
            };
            headerTable.AddCell(invoiceCell);

            doc.Add(headerTable);

            // Informasi Bengkel
            Paragraph bengkelInfo = new Paragraph(invoice.NamaBengkel, titleFont)
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingAfter = 5f
            };
            doc.Add(bengkelInfo);
            doc.Add(new Paragraph(invoice.AlamatBengkel, bodyFont));
            doc.Add(new Paragraph($"Email: {invoice.EmailBengkel} | Telp: {invoice.TelpBengkel}", bodyFont));
            doc.Add(new Paragraph("------------------------------------------------------", bodyFont) { SpacingAfter = 10f });

            // Informasi Invoice
            doc.Add(new Paragraph($"Nomor Antrean: {invoice.Antrean}", bodyFont) { SpacingAfter = 5f });
            doc.Add(new Paragraph($"Tanggal: {invoice.Tanggal:dd MMM yyyy}", bodyFont));
            doc.Add(new Paragraph($"Pelanggan: {invoice.NamaPelanggan}", bodyFont));
            doc.Add(new Paragraph($"Kendaraan: {invoice.NamaKendaraan} ({invoice.NoPolisi})", bodyFont));
            doc.Add(new Paragraph("------------------------------------------------------", bodyFont) { SpacingAfter = 10f });

            // Tabel Invoice
            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100
            };
            table.SetWidths(new float[] { 50f, 10f, 20f, 20f });

            // Header tabel dengan warna abu-abu
            PdfPCell cell;
            BaseColor headerColor = new BaseColor(128, 128, 128); // Warna abu-abu

            cell = new PdfPCell(new Phrase("Barang / Jasa", headerFont))
            {
                BackgroundColor = headerColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Qty", headerFont))
            {
                BackgroundColor = headerColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Harga", headerFont))
            {
                BackgroundColor = headerColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Jumlah", headerFont))
            {
                BackgroundColor = headerColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5f
            };
            table.AddCell(cell);

            // Data dalam tabel
            for (int i = 0; i < invoice.ListBarang.Count; i++)
            {
                table.AddCell(new PdfPCell(new Phrase(invoice.ListBarang[i], bodyFont)) { Padding = 5f });
                table.AddCell(new PdfPCell(new Phrase(invoice.ListQuantity[i].ToString(), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                table.AddCell(new PdfPCell(new Phrase($"Rp {invoice.ListHarga[i]:N0}", bodyFont)) { Padding = 5f });
                table.AddCell(new PdfPCell(new Phrase($"Rp {invoice.ListQuantity[i] * invoice.ListHarga[i]:N0}", bodyFont)) { Padding = 5f });
            }

            doc.Add(table);
            doc.Add(new Paragraph(" "));

            // Total biaya
            doc.Add(new Paragraph($"**TOTAL: Rp {invoice.TotalBiaya:N0}**", footerFont) { Alignment = Element.ALIGN_RIGHT, SpacingBefore = 10f });
            doc.Add(new Paragraph($"Catatan: {invoice.Catatan}", bodyFont) { SpacingBefore = 10f });

            doc.Close();

            // Buka file PDF setelah dibuat
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}

    public class InvoiceModel
    {
        public string LogoPath { get; set; } = @"D:\gws.png";
        public string NamaBengkel { get; set; } = "BENGKEL PROFIX";
        public string AlamatBengkel { get; set; } = "Jl. Raya No. 123, Indonesia";
        public string EmailBengkel { get; set; } = "bengkelprofix@gmail.com";
        public string TelpBengkel { get; set; } = "08123456789";

        public string Antrean { get; set; } = "A123";
        public DateTime Tanggal { get; set; } = DateTime.Now;
        public string NamaPelanggan { get; set; } = "Budi Santoso";
        public string NamaKendaraan { get; set; } = "Toyota Avanza";
        public string NoPolisi { get; set; } = "B 1234 XYZ";
        public string NomorInvoice { get; set; } = "BKGA1332";

        public List<string> ListBarang { get; set; } = new List<string> { "Servis Rutin", "Oli Mesin", "Filter Udara" };
        public List<int> ListQuantity { get; set; } = new List<int> { 1, 1, 1 };
        public List<int> ListHarga { get; set; } = new List<int> { 250000, 75000, 50000 };

        public string Catatan { get; set; } = "Terima kasih telah menggunakan layanan kami.";

        public int TotalBiaya => HitungTotal();

        private int HitungTotal()
        {
            int total = 0;
            for (int i = 0; i < ListBarang.Count; i++)
            {
                total += ListQuantity[i] * ListHarga[i];
            }
            return total;
        }
    }

