namespace Bengkel_Yoga_UKK
{
    partial class BookingDetailUserUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingDetailUserUC));
            panel1 = new Panel();
            btnBatalkanPesanan = new YogaButton();
            panelSparepart = new YogaPanel();
            label25 = new Label();
            label29 = new Label();
            gridSparepart = new DataGridView();
            panelDetails = new YogaPanel();
            lblSelesaiOrBatalV = new Label();
            lblSelesaiOrBatal = new Label();
            lblBatal = new Label();
            lbl1 = new Label();
            lblCatatan = new Label();
            lblMekanik = new Label();
            lblPetugas = new Label();
            lblKeluhan = new Label();
            lblMulaiServis = new Label();
            lblTanggalBooking = new Label();
            lblNoPol = new Label();
            lblKendaraan = new Label();
            lbl2 = new Label();
            label12 = new Label();
            label13 = new Label();
            label9 = new Label();
            lblTanggalSelesaiKet = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panelProgres = new YogaPanel();
            btnStatus = new YogaButton();
            lblBooking = new Label();
            label3 = new Label();
            lblPembayaran = new Label();
            lblServis = new Label();
            pictureSelesai = new RJCircularPictureBox();
            label16 = new Label();
            pictureServis = new RJCircularPictureBox();
            panelServisToPembayaran = new Panel();
            label17 = new Label();
            pictureBooking = new RJCircularPictureBox();
            pictureBox2 = new PictureBox();
            panelBookingToServis = new Panel();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            panelSparepart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSparepart).BeginInit();
            panelDetails.SuspendLayout();
            panelProgres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSelesai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureServis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBooking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(btnBatalkanPesanan);
            panel1.Controls.Add(panelSparepart);
            panel1.Controls.Add(panelDetails);
            panel1.Controls.Add(panelProgres);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1314, 1045);
            panel1.TabIndex = 0;
            // 
            // btnBatalkanPesanan
            // 
            btnBatalkanPesanan.Anchor = AnchorStyles.Top;
            btnBatalkanPesanan.BackColor = Color.FromArgb(239, 7, 7);
            btnBatalkanPesanan.BackgroundColor = Color.FromArgb(239, 7, 7);
            btnBatalkanPesanan.BorderColor = Color.PaleVioletRed;
            btnBatalkanPesanan.BorderRadius = 12;
            btnBatalkanPesanan.BorderSize = 0;
            btnBatalkanPesanan.FlatAppearance.BorderSize = 0;
            btnBatalkanPesanan.FlatStyle = FlatStyle.Flat;
            btnBatalkanPesanan.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBatalkanPesanan.ForeColor = Color.White;
            btnBatalkanPesanan.Location = new Point(889, 597);
            btnBatalkanPesanan.Name = "btnBatalkanPesanan";
            btnBatalkanPesanan.Size = new Size(253, 75);
            btnBatalkanPesanan.TabIndex = 121;
            btnBatalkanPesanan.Text = "Batalkan Pesanan";
            btnBatalkanPesanan.TextColor = Color.White;
            btnBatalkanPesanan.UseVisualStyleBackColor = false;
            // 
            // panelSparepart
            // 
            panelSparepart.Anchor = AnchorStyles.Top;
            panelSparepart.BackColor = Color.White;
            panelSparepart.BorderColor = Color.PaleVioletRed;
            panelSparepart.BorderRadius = 15;
            panelSparepart.BorderSize = 2;
            panelSparepart.Controls.Add(label25);
            panelSparepart.Controls.Add(label29);
            panelSparepart.Controls.Add(gridSparepart);
            panelSparepart.ForeColor = Color.White;
            panelSparepart.Location = new Point(190, 685);
            panelSparepart.Name = "panelSparepart";
            panelSparepart.Size = new Size(952, 203);
            panelSparepart.TabIndex = 121;
            panelSparepart.Visible = false;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Bottom;
            label25.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold, GraphicsUnit.Point);
            label25.ForeColor = SystemColors.ControlText;
            label25.Location = new Point(685, 138);
            label25.Name = "label25";
            label25.Size = new Size(160, 30);
            label25.TabIndex = 70;
            label25.Text = "Rp215.000";
            label25.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Bottom;
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold, GraphicsUnit.Point);
            label29.ForeColor = SystemColors.ControlText;
            label29.Location = new Point(607, 138);
            label29.Name = "label29";
            label29.Size = new Size(72, 30);
            label29.TabIndex = 66;
            label29.Text = "Total :";
            label29.Click += label29_Click;
            // 
            // gridSparepart
            // 
            gridSparepart.Anchor = AnchorStyles.Top;
            gridSparepart.BackgroundColor = Color.White;
            gridSparepart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSparepart.Location = new Point(88, 38);
            gridSparepart.Name = "gridSparepart";
            gridSparepart.RowTemplate.Height = 25;
            gridSparepart.Size = new Size(777, 95);
            gridSparepart.TabIndex = 0;
            // 
            // panelDetails
            // 
            panelDetails.Anchor = AnchorStyles.Top;
            panelDetails.BackColor = Color.White;
            panelDetails.BorderColor = Color.PaleVioletRed;
            panelDetails.BorderRadius = 15;
            panelDetails.BorderSize = 2;
            panelDetails.Controls.Add(lblSelesaiOrBatalV);
            panelDetails.Controls.Add(lblSelesaiOrBatal);
            panelDetails.Controls.Add(lblBatal);
            panelDetails.Controls.Add(lbl1);
            panelDetails.Controls.Add(lblCatatan);
            panelDetails.Controls.Add(lblMekanik);
            panelDetails.Controls.Add(lblPetugas);
            panelDetails.Controls.Add(lblKeluhan);
            panelDetails.Controls.Add(lblMulaiServis);
            panelDetails.Controls.Add(lblTanggalBooking);
            panelDetails.Controls.Add(lblNoPol);
            panelDetails.Controls.Add(lblKendaraan);
            panelDetails.Controls.Add(lbl2);
            panelDetails.Controls.Add(label12);
            panelDetails.Controls.Add(label13);
            panelDetails.Controls.Add(label9);
            panelDetails.Controls.Add(lblTanggalSelesaiKet);
            panelDetails.Controls.Add(label7);
            panelDetails.Controls.Add(label6);
            panelDetails.Controls.Add(label5);
            panelDetails.ForeColor = Color.White;
            panelDetails.Location = new Point(190, 270);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(952, 305);
            panelDetails.TabIndex = 120;
            // 
            // lblSelesaiOrBatalV
            // 
            lblSelesaiOrBatalV.AutoSize = true;
            lblSelesaiOrBatalV.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelesaiOrBatalV.ForeColor = Color.Black;
            lblSelesaiOrBatalV.Location = new Point(212, 167);
            lblSelesaiOrBatalV.Name = "lblSelesaiOrBatalV";
            lblSelesaiOrBatalV.Size = new Size(154, 23);
            lblSelesaiOrBatalV.TabIndex = 121;
            lblSelesaiOrBatalV.Text = "3 Maret 2025 12:30";
            // 
            // lblSelesaiOrBatal
            // 
            lblSelesaiOrBatal.AutoSize = true;
            lblSelesaiOrBatal.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelesaiOrBatal.ForeColor = SystemColors.ControlDarkDark;
            lblSelesaiOrBatal.Location = new Point(30, 167);
            lblSelesaiOrBatal.Name = "lblSelesaiOrBatal";
            lblSelesaiOrBatal.Size = new Size(70, 23);
            lblSelesaiOrBatal.TabIndex = 120;
            lblSelesaiOrBatal.Text = "Selesai :";
            // 
            // lblBatal
            // 
            lblBatal.AutoSize = true;
            lblBatal.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBatal.ForeColor = Color.Black;
            lblBatal.Location = new Point(672, 95);
            lblBatal.Name = "lblBatal";
            lblBatal.Size = new Size(17, 23);
            lblBatal.TabIndex = 119;
            lblBatal.Text = "-";
            // 
            // lbl1
            // 
            lbl1.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.ForeColor = SystemColors.ControlDarkDark;
            lbl1.Location = new Point(535, 95);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(149, 36);
            lbl1.TabIndex = 118;
            lbl1.Text = "Dibatalkan oleh : ";
            // 
            // lblCatatan
            // 
            lblCatatan.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCatatan.ForeColor = Color.Black;
            lblCatatan.Location = new Point(672, 131);
            lblCatatan.Name = "lblCatatan";
            lblCatatan.Size = new Size(251, 69);
            lblCatatan.TabIndex = 117;
            lblCatatan.Text = "-";
            // 
            // lblMekanik
            // 
            lblMekanik.AutoSize = true;
            lblMekanik.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMekanik.ForeColor = Color.Black;
            lblMekanik.Location = new Point(672, 60);
            lblMekanik.Name = "lblMekanik";
            lblMekanik.Size = new Size(17, 23);
            lblMekanik.TabIndex = 116;
            lblMekanik.Text = "-";
            // 
            // lblPetugas
            // 
            lblPetugas.AutoSize = true;
            lblPetugas.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPetugas.ForeColor = Color.Black;
            lblPetugas.Location = new Point(672, 23);
            lblPetugas.Name = "lblPetugas";
            lblPetugas.Size = new Size(17, 23);
            lblPetugas.TabIndex = 115;
            lblPetugas.Text = "-";
            // 
            // lblKeluhan
            // 
            lblKeluhan.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblKeluhan.ForeColor = Color.Black;
            lblKeluhan.Location = new Point(212, 203);
            lblKeluhan.Name = "lblKeluhan";
            lblKeluhan.Size = new Size(300, 69);
            lblKeluhan.TabIndex = 114;
            lblKeluhan.Text = "CVT bunyi grek grek dan tarikan loyo";
            // 
            // lblMulaiServis
            // 
            lblMulaiServis.AutoSize = true;
            lblMulaiServis.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMulaiServis.ForeColor = Color.Black;
            lblMulaiServis.Location = new Point(212, 131);
            lblMulaiServis.Name = "lblMulaiServis";
            lblMulaiServis.Size = new Size(156, 23);
            lblMulaiServis.TabIndex = 113;
            lblMulaiServis.Text = "2 Maret 2025 09:22";
            // 
            // lblTanggalBooking
            // 
            lblTanggalBooking.AutoSize = true;
            lblTanggalBooking.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTanggalBooking.ForeColor = Color.Black;
            lblTanggalBooking.Location = new Point(212, 95);
            lblTanggalBooking.Name = "lblTanggalBooking";
            lblTanggalBooking.Size = new Size(111, 23);
            lblTanggalBooking.TabIndex = 112;
            lblTanggalBooking.Text = "2 Maret 2025";
            // 
            // lblNoPol
            // 
            lblNoPol.AutoSize = true;
            lblNoPol.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNoPol.ForeColor = Color.Black;
            lblNoPol.Location = new Point(212, 60);
            lblNoPol.Name = "lblNoPol";
            lblNoPol.Size = new Size(86, 23);
            lblNoPol.TabIndex = 111;
            lblNoPol.Text = "AB 123 FC";
            // 
            // lblKendaraan
            // 
            lblKendaraan.AutoSize = true;
            lblKendaraan.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblKendaraan.ForeColor = Color.Black;
            lblKendaraan.Location = new Point(212, 23);
            lblKendaraan.Name = "lblKendaraan";
            lblKendaraan.Size = new Size(203, 23);
            lblKendaraan.TabIndex = 110;
            lblKendaraan.Text = "Honda Vario 125cc (2018)";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.ForeColor = SystemColors.ControlDarkDark;
            lbl2.Location = new Point(535, 131);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(79, 23);
            lbl2.TabIndex = 108;
            lbl2.Text = "Catatan :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(535, 60);
            label12.Name = "label12";
            label12.Size = new Size(90, 23);
            label12.TabIndex = 107;
            label12.Text = "Mekanik : ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(535, 23);
            label13.Name = "label13";
            label13.Size = new Size(84, 23);
            label13.TabIndex = 106;
            label13.Text = "Petugas : ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(30, 203);
            label9.Name = "label9";
            label9.Size = new Size(81, 23);
            label9.TabIndex = 105;
            label9.Text = "Keluhan :";
            // 
            // lblTanggalSelesaiKet
            // 
            lblTanggalSelesaiKet.AutoSize = true;
            lblTanggalSelesaiKet.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTanggalSelesaiKet.ForeColor = SystemColors.ControlDarkDark;
            lblTanggalSelesaiKet.Location = new Point(30, 131);
            lblTanggalSelesaiKet.Name = "lblTanggalSelesaiKet";
            lblTanggalSelesaiKet.Size = new Size(112, 23);
            lblTanggalSelesaiKet.TabIndex = 104;
            lblTanggalSelesaiKet.Text = "Mulai Servis :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(30, 95);
            label7.Name = "label7";
            label7.Size = new Size(146, 23);
            label7.TabIndex = 103;
            label7.Text = "Tanggal Booking :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(30, 60);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 102;
            label6.Text = "No Pol : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(30, 23);
            label5.Name = "label5";
            label5.Size = new Size(106, 23);
            label5.TabIndex = 100;
            label5.Text = "Kendaraan : ";
            // 
            // panelProgres
            // 
            panelProgres.Anchor = AnchorStyles.Top;
            panelProgres.BackColor = Color.White;
            panelProgres.BorderColor = Color.PaleVioletRed;
            panelProgres.BorderRadius = 15;
            panelProgres.BorderSize = 2;
            panelProgres.Controls.Add(btnStatus);
            panelProgres.Controls.Add(lblBooking);
            panelProgres.Controls.Add(label3);
            panelProgres.Controls.Add(lblPembayaran);
            panelProgres.Controls.Add(lblServis);
            panelProgres.Controls.Add(pictureSelesai);
            panelProgres.Controls.Add(label16);
            panelProgres.Controls.Add(pictureServis);
            panelProgres.Controls.Add(panelServisToPembayaran);
            panelProgres.Controls.Add(label17);
            panelProgres.Controls.Add(pictureBooking);
            panelProgres.Controls.Add(pictureBox2);
            panelProgres.Controls.Add(panelBookingToServis);
            panelProgres.Controls.Add(pictureBox4);
            panelProgres.ForeColor = Color.White;
            panelProgres.Location = new Point(190, 37);
            panelProgres.Name = "panelProgres";
            panelProgres.Size = new Size(952, 205);
            panelProgres.TabIndex = 119;
            // 
            // btnStatus
            // 
            btnStatus.BackColor = Color.FromArgb(4, 120, 244);
            btnStatus.BackgroundColor = Color.FromArgb(4, 120, 244);
            btnStatus.BorderColor = Color.PaleVioletRed;
            btnStatus.BorderRadius = 27;
            btnStatus.BorderSize = 0;
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 14.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStatus.ForeColor = Color.White;
            btnStatus.Location = new Point(18, 17);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(161, 53);
            btnStatus.TabIndex = 120;
            btnStatus.Text = "Pending";
            btnStatus.TextColor = Color.White;
            btnStatus.UseVisualStyleBackColor = false;
            // 
            // lblBooking
            // 
            lblBooking.BackColor = Color.White;
            lblBooking.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBooking.ForeColor = Color.FromArgb(0, 192, 0);
            lblBooking.Location = new Point(230, 144);
            lblBooking.Name = "lblBooking";
            lblBooking.Size = new Size(95, 25);
            lblBooking.TabIndex = 99;
            lblBooking.Text = "(Selesai)";
            lblBooking.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(237, 117);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 98;
            label3.Text = "Booking";
            // 
            // lblPembayaran
            // 
            lblPembayaran.BackColor = Color.White;
            lblPembayaran.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPembayaran.ForeColor = Color.FromArgb(240, 177, 0);
            lblPembayaran.Location = new Point(680, 144);
            lblPembayaran.Name = "lblPembayaran";
            lblPembayaran.Size = new Size(133, 25);
            lblPembayaran.TabIndex = 97;
            lblPembayaran.Text = "(Belum Bayar)";
            lblPembayaran.TextAlign = ContentAlignment.MiddleCenter;
            lblPembayaran.Visible = false;
            // 
            // lblServis
            // 
            lblServis.BackColor = Color.White;
            lblServis.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblServis.ForeColor = Color.FromArgb(240, 177, 0);
            lblServis.Location = new Point(441, 144);
            lblServis.Name = "lblServis";
            lblServis.Size = new Size(138, 25);
            lblServis.TabIndex = 96;
            lblServis.Text = "(Proses)";
            lblServis.TextAlign = ContentAlignment.MiddleCenter;
            lblServis.Visible = false;
            // 
            // pictureSelesai
            // 
            pictureSelesai.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            pictureSelesai.BorderColor = SystemColors.ControlDarkDark;
            pictureSelesai.BorderColor2 = SystemColors.ControlDarkDark;
            pictureSelesai.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pictureSelesai.BorderSize = 2;
            pictureSelesai.GradientAngle = 50F;
            pictureSelesai.Location = new Point(728, 80);
            pictureSelesai.Name = "pictureSelesai";
            pictureSelesai.Size = new Size(34, 34);
            pictureSelesai.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureSelesai.TabIndex = 86;
            pictureSelesai.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = SystemColors.ControlDarkDark;
            label16.Location = new Point(479, 117);
            label16.Name = "label16";
            label16.Size = new Size(63, 25);
            label16.TabIndex = 88;
            label16.Text = "Servis";
            // 
            // pictureServis
            // 
            pictureServis.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            pictureServis.BorderColor = SystemColors.ControlDarkDark;
            pictureServis.BorderColor2 = SystemColors.ControlDarkDark;
            pictureServis.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pictureServis.BorderSize = 2;
            pictureServis.GradientAngle = 50F;
            pictureServis.Location = new Point(494, 80);
            pictureServis.Name = "pictureServis";
            pictureServis.Size = new Size(34, 34);
            pictureServis.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureServis.TabIndex = 85;
            pictureServis.TabStop = false;
            // 
            // panelServisToPembayaran
            // 
            panelServisToPembayaran.BackColor = SystemColors.ControlDarkDark;
            panelServisToPembayaran.Location = new Point(523, 96);
            panelServisToPembayaran.Name = "panelServisToPembayaran";
            panelServisToPembayaran.Size = new Size(213, 4);
            panelServisToPembayaran.TabIndex = 95;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = SystemColors.ControlDarkDark;
            label17.Location = new Point(688, 117);
            label17.Name = "label17";
            label17.Size = new Size(118, 25);
            label17.TabIndex = 89;
            label17.Text = "Pembayaran";
            // 
            // pictureBooking
            // 
            pictureBooking.BackgroundImage = Properties.Resources.hijau;
            pictureBooking.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            pictureBooking.BorderColor = SystemColors.ControlDarkDark;
            pictureBooking.BorderColor2 = SystemColors.ControlDarkDark;
            pictureBooking.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pictureBooking.BorderSize = 0;
            pictureBooking.GradientAngle = 50F;
            pictureBooking.Location = new Point(260, 80);
            pictureBooking.Name = "pictureBooking";
            pictureBooking.Size = new Size(34, 34);
            pictureBooking.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBooking.TabIndex = 83;
            pictureBooking.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(486, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 90;
            pictureBox2.TabStop = false;
            // 
            // panelBookingToServis
            // 
            panelBookingToServis.BackColor = SystemColors.ControlDarkDark;
            panelBookingToServis.Location = new Point(289, 96);
            panelBookingToServis.Name = "panelBookingToServis";
            panelBookingToServis.Size = new Size(213, 4);
            panelBookingToServis.TabIndex = 94;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(719, 26);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.TabIndex = 91;
            pictureBox4.TabStop = false;
            // 
            // BookingDetailUserUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "BookingDetailUserUC";
            Size = new Size(1320, 1051);
            panel1.ResumeLayout(false);
            panelSparepart.ResumeLayout(false);
            panelSparepart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSparepart).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            panelProgres.ResumeLayout(false);
            panelProgres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSelesai).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureServis).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBooking).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private YogaPanel panelSparepart;
        private DataGridView gridSparepart;
        private YogaPanel panelDetails;
        private Label lblCatatan;
        private Label lblMekanik;
        private Label lblPetugas;
        private Label lblKeluhan;
        private Label lblMulaiServis;
        private Label lblTanggalBooking;
        private Label lblNoPol;
        private Label lblKendaraan;
        private Label lbl2;
        private Label label12;
        private Label label13;
        private Label label9;
        private Label lblTanggalSelesaiKet;
        private Label label7;
        private Label label6;
        private Label label5;
        private YogaPanel panelProgres;
        private Label lblBooking;
        private Label label3;
        private Label lblPembayaran;
        private Label lblServis;
        private RJCircularPictureBox pictureSelesai;
        private Label label16;
        private RJCircularPictureBox pictureServis;
        private Panel panelServisToPembayaran;
        private Label label17;
        private RJCircularPictureBox pictureBooking;
        private PictureBox pictureBox2;
        private Panel panelBookingToServis;
        private PictureBox pictureBox4;
        private YogaButton btnStatus;
        private Label lblBatal;
        private Label lbl1;
        private Label lblSelesaiOrBatalV;
        private Label lblSelesaiOrBatal;
        private YogaButton btnBatalkanPesanan;
        private Label label25;
        private Label label29;
    }
}
