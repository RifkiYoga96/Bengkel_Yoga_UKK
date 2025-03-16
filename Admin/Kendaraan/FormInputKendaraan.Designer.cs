namespace Bengkel_Yoga_UKK
{
    partial class FormInputKendaraan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblHeader = new Label();
            label3 = new Label();
            label4 = new Label();
            txtKTP = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new YogaButton();
            txtPemilik = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtKapasitas = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtTipe = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label9 = new Label();
            label10 = new Label();
            txtMerk = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label12 = new Label();
            txtTahun = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label13 = new Label();
            label5 = new Label();
            btnCancel = new YogaButton();
            lblErrorKTP = new Label();
            lblErrorMerk = new Label();
            lblErrorTipe = new Label();
            lblErrorTahun = new Label();
            lblErrorNoPol = new Label();
            btnCariKTP = new YogaButton();
            label6 = new Label();
            txtNoPol = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorKapasitas = new Label();
            comboTransmisi = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKTP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPemilik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKapasitas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMerk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(937, 42);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(937, 43);
            lblHeader.TabIndex = 11;
            lblHeader.Text = "Input Kendaraan";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(21, 74);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 15;
            label3.Text = "KTP Pemilik";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(21, 151);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 24;
            label4.Text = "Nama Pemilik";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtKTP
            // 
            txtKTP.BackColor = Color.White;
            txtKTP.BeforeTouchSize = new Size(293, 27);
            txtKTP.BorderColor = Color.FromArgb(209, 211, 212);
            txtKTP.BorderStyle = BorderStyle.FixedSingle;
            txtKTP.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtKTP.Location = new Point(150, 74);
            txtKTP.Name = "txtKTP";
            txtKTP.PlaceholderText = " Masukkan atau cari KTP";
            txtKTP.Size = new Size(240, 27);
            txtKTP.TabIndex = 26;
            txtKTP.ThemeName = "Default";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(804, 396);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtPemilik
            // 
            txtPemilik.BackColor = SystemColors.ButtonFace;
            txtPemilik.BeforeTouchSize = new Size(293, 27);
            txtPemilik.BorderColor = Color.Silver;
            txtPemilik.BorderStyle = BorderStyle.FixedSingle;
            txtPemilik.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPemilik.Location = new Point(150, 151);
            txtPemilik.Name = "txtPemilik";
            txtPemilik.ReadOnly = true;
            txtPemilik.Size = new Size(293, 27);
            txtPemilik.TabIndex = 39;
            txtPemilik.ThemeName = "Default";
            // 
            // txtKapasitas
            // 
            txtKapasitas.BackColor = Color.White;
            txtKapasitas.BeforeTouchSize = new Size(293, 27);
            txtKapasitas.BorderColor = Color.FromArgb(209, 211, 212);
            txtKapasitas.BorderStyle = BorderStyle.FixedSingle;
            txtKapasitas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtKapasitas.Location = new Point(619, 151);
            txtKapasitas.Name = "txtKapasitas";
            txtKapasitas.PlaceholderText = " Masukkan kapasitas mesin";
            txtKapasitas.Size = new Size(293, 27);
            txtKapasitas.TabIndex = 52;
            txtKapasitas.ThemeName = "Default";
            // 
            // txtTipe
            // 
            txtTipe.BackColor = Color.White;
            txtTipe.BeforeTouchSize = new Size(293, 27);
            txtTipe.BorderColor = Color.FromArgb(209, 211, 212);
            txtTipe.BorderStyle = BorderStyle.FixedSingle;
            txtTipe.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTipe.Location = new Point(150, 305);
            txtTipe.Name = "txtTipe";
            txtTipe.PlaceholderText = " Masukkan tipe kendaraan";
            txtTipe.Size = new Size(293, 27);
            txtTipe.TabIndex = 51;
            txtTipe.ThemeName = "Default";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(493, 151);
            label9.Name = "label9";
            label9.Size = new Size(122, 25);
            label9.TabIndex = 50;
            label9.Text = "Kapasitas (cc)";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(21, 305);
            label10.Name = "label10";
            label10.Size = new Size(48, 25);
            label10.TabIndex = 49;
            label10.Text = "Tipe";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMerk
            // 
            txtMerk.BackColor = Color.White;
            txtMerk.BeforeTouchSize = new Size(293, 27);
            txtMerk.BorderColor = Color.FromArgb(209, 211, 212);
            txtMerk.BorderStyle = BorderStyle.FixedSingle;
            txtMerk.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtMerk.Location = new Point(150, 228);
            txtMerk.Name = "txtMerk";
            txtMerk.PlaceholderText = " Masukan merk kendaraan";
            txtMerk.Size = new Size(293, 27);
            txtMerk.TabIndex = 55;
            txtMerk.ThemeName = "Default";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(21, 228);
            label12.Name = "label12";
            label12.Size = new Size(55, 25);
            label12.TabIndex = 53;
            label12.Text = "Merk";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTahun
            // 
            txtTahun.BackColor = Color.White;
            txtTahun.BeforeTouchSize = new Size(293, 27);
            txtTahun.BorderColor = Color.FromArgb(209, 211, 212);
            txtTahun.BorderStyle = BorderStyle.FixedSingle;
            txtTahun.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTahun.Location = new Point(619, 228);
            txtTahun.Name = "txtTahun";
            txtTahun.PlaceholderText = " Masukkan tahun produksi";
            txtTahun.Size = new Size(293, 27);
            txtTahun.TabIndex = 58;
            txtTahun.ThemeName = "Default";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(493, 228);
            label13.Name = "label13";
            label13.Size = new Size(61, 25);
            label13.TabIndex = 57;
            label13.Text = "Tahun";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(493, 305);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 60;
            label5.Text = "No Polisi";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundColor = Color.Transparent;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 2;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.ControlDarkDark;
            btnCancel.Location = new Point(687, 396);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 36);
            btnCancel.TabIndex = 62;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblErrorKTP
            // 
            lblErrorKTP.AutoSize = true;
            lblErrorKTP.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorKTP.ForeColor = Color.Red;
            lblErrorKTP.Location = new Point(150, 104);
            lblErrorKTP.Name = "lblErrorKTP";
            lblErrorKTP.Size = new Size(159, 17);
            lblErrorKTP.TabIndex = 78;
            lblErrorKTP.Text = "⚠️ Harap mengisi nama !";
            lblErrorKTP.TextAlign = ContentAlignment.MiddleRight;
            lblErrorKTP.Visible = false;
            // 
            // lblErrorMerk
            // 
            lblErrorMerk.AutoSize = true;
            lblErrorMerk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorMerk.ForeColor = Color.Red;
            lblErrorMerk.Location = new Point(150, 258);
            lblErrorMerk.Name = "lblErrorMerk";
            lblErrorMerk.Size = new Size(214, 17);
            lblErrorMerk.TabIndex = 87;
            lblErrorMerk.Text = "⚠️ Harap mengisi nomor telepon !";
            lblErrorMerk.TextAlign = ContentAlignment.MiddleRight;
            lblErrorMerk.Visible = false;
            // 
            // lblErrorTipe
            // 
            lblErrorTipe.AutoSize = true;
            lblErrorTipe.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTipe.ForeColor = Color.Red;
            lblErrorTipe.Location = new Point(150, 335);
            lblErrorTipe.Name = "lblErrorTipe";
            lblErrorTipe.Size = new Size(194, 17);
            lblErrorTipe.TabIndex = 87;
            lblErrorTipe.Text = "⚠️ Masukkan email yang valid !";
            lblErrorTipe.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTipe.Visible = false;
            // 
            // lblErrorTahun
            // 
            lblErrorTahun.AutoSize = true;
            lblErrorTahun.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTahun.ForeColor = Color.Red;
            lblErrorTahun.Location = new Point(619, 258);
            lblErrorTahun.Name = "lblErrorTahun";
            lblErrorTahun.Size = new Size(248, 17);
            lblErrorTahun.TabIndex = 87;
            lblErrorTahun.Text = "⚠️ Harap mengisi konfirmasi password !";
            lblErrorTahun.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTahun.Visible = false;
            // 
            // lblErrorNoPol
            // 
            lblErrorNoPol.AutoSize = true;
            lblErrorNoPol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNoPol.ForeColor = Color.Red;
            lblErrorNoPol.Location = new Point(619, 335);
            lblErrorNoPol.Name = "lblErrorNoPol";
            lblErrorNoPol.Size = new Size(166, 17);
            lblErrorNoPol.TabIndex = 91;
            lblErrorNoPol.Text = "⚠️ Harap mengisi alamat !";
            lblErrorNoPol.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNoPol.Visible = false;
            // 
            // btnCariKTP
            // 
            btnCariKTP.BackColor = Color.FromArgb(230, 126, 34);
            btnCariKTP.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnCariKTP.BorderColor = Color.PaleVioletRed;
            btnCariKTP.BorderRadius = 2;
            btnCariKTP.BorderSize = 0;
            btnCariKTP.FlatAppearance.BorderSize = 0;
            btnCariKTP.FlatStyle = FlatStyle.Flat;
            btnCariKTP.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCariKTP.ForeColor = Color.White;
            btnCariKTP.Location = new Point(396, 74);
            btnCariKTP.Name = "btnCariKTP";
            btnCariKTP.Size = new Size(47, 27);
            btnCariKTP.TabIndex = 94;
            btnCariKTP.Text = "Cari";
            btnCariKTP.TextColor = Color.White;
            btnCariKTP.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(490, 74);
            label6.Name = "label6";
            label6.Size = new Size(90, 25);
            label6.TabIndex = 95;
            label6.Text = "Transmisi";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNoPol
            // 
            txtNoPol.BackColor = Color.White;
            txtNoPol.BeforeTouchSize = new Size(293, 27);
            txtNoPol.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoPol.BorderStyle = BorderStyle.FixedSingle;
            txtNoPol.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoPol.Location = new Point(619, 305);
            txtNoPol.Name = "txtNoPol";
            txtNoPol.PlaceholderText = " Masukkan nomor polisi";
            txtNoPol.Size = new Size(293, 27);
            txtNoPol.TabIndex = 98;
            txtNoPol.ThemeName = "Default";
            // 
            // lblErrorKapasitas
            // 
            lblErrorKapasitas.AutoSize = true;
            lblErrorKapasitas.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorKapasitas.ForeColor = Color.Red;
            lblErrorKapasitas.Location = new Point(619, 181);
            lblErrorKapasitas.Name = "lblErrorKapasitas";
            lblErrorKapasitas.Size = new Size(248, 17);
            lblErrorKapasitas.TabIndex = 99;
            lblErrorKapasitas.Text = "⚠️ Harap mengisi konfirmasi password !";
            lblErrorKapasitas.TextAlign = ContentAlignment.MiddleRight;
            lblErrorKapasitas.Visible = false;
            // 
            // comboTransmisi
            // 
            comboTransmisi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTransmisi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboTransmisi.FormattingEnabled = true;
            comboTransmisi.Location = new Point(619, 74);
            comboTransmisi.Name = "comboTransmisi";
            comboTransmisi.Size = new Size(293, 28);
            comboTransmisi.TabIndex = 100;
            // 
            // FormInputKendaraan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 453);
            Controls.Add(comboTransmisi);
            Controls.Add(lblErrorKapasitas);
            Controls.Add(txtNoPol);
            Controls.Add(label6);
            Controls.Add(btnCariKTP);
            Controls.Add(lblErrorNoPol);
            Controls.Add(lblErrorTahun);
            Controls.Add(lblErrorTipe);
            Controls.Add(lblErrorMerk);
            Controls.Add(lblErrorKTP);
            Controls.Add(btnCancel);
            Controls.Add(label5);
            Controls.Add(txtTahun);
            Controls.Add(label13);
            Controls.Add(txtMerk);
            Controls.Add(label12);
            Controls.Add(txtKapasitas);
            Controls.Add(txtTipe);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtPemilik);
            Controls.Add(btnSave);
            Controls.Add(txtKTP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputKendaraan";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKTP).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPemilik).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKapasitas).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMerk).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label3;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKTP;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPemilik;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKapasitas;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTipe;
        private Label label9;
        private Label label10;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMerk;
        private Label label12;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTahun;
        private Label label13;
        private Label label5;
        private YogaButton btnCancel;
        private Label lblErrorKTP;
        private Label lblErrorMerk;
        private Label lblErrorTipe;
        private Label lblErrorTahun;
        private Label lblErrorNoPol;
        private YogaButton btnCariKTP;
        private Label label6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoPol;
        private Label lblErrorKapasitas;
        private ComboBox comboTransmisi;
    }
}