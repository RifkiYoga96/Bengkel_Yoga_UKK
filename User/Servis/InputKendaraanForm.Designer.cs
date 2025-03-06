namespace Bengkel_Yoga_UKK
{
    partial class InputKendaraanForm
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
            txtMerk = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new YogaButton();
            txtTipe = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label1 = new Label();
            label2 = new Label();
            txtNoPol = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label5 = new Label();
            txtTahun = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            comboTransmisi = new ComboBox();
            numericCC = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            label16 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMerk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCC).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 42);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(520, 43);
            lblHeader.TabIndex = 11;
            lblHeader.Text = "Tambah Kendaraan";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(16, 85);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 15;
            label3.Text = "Merk";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(16, 166);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 24;
            label4.Text = "Tipe";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMerk
            // 
            txtMerk.BackColor = Color.White;
            txtMerk.BeforeTouchSize = new Size(316, 29);
            txtMerk.BorderColor = Color.FromArgb(209, 211, 212);
            txtMerk.BorderStyle = BorderStyle.FixedSingle;
            txtMerk.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtMerk.Location = new Point(177, 85);
            txtMerk.Name = "txtMerk";
            txtMerk.PlaceholderText = " Masukkan Merk Motor";
            txtMerk.Size = new Size(316, 29);
            txtMerk.TabIndex = 26;
            txtMerk.ThemeName = "Default";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(385, 574);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtTipe
            // 
            txtTipe.BackColor = Color.White;
            txtTipe.BeforeTouchSize = new Size(316, 29);
            txtTipe.BorderColor = Color.FromArgb(209, 211, 212);
            txtTipe.BorderStyle = BorderStyle.FixedSingle;
            txtTipe.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTipe.Location = new Point(177, 166);
            txtTipe.Name = "txtTipe";
            txtTipe.PlaceholderText = " Masukkan Tipe Motor";
            txtTipe.Size = new Size(316, 29);
            txtTipe.TabIndex = 41;
            txtTipe.ThemeName = "Default";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(19, 334);
            label1.Name = "label1";
            label1.Size = new Size(122, 25);
            label1.TabIndex = 43;
            label1.Text = "Kapasitas (cc)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(19, 253);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 42;
            label2.Text = "Transmisi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNoPol
            // 
            txtNoPol.BackColor = Color.White;
            txtNoPol.BeforeTouchSize = new Size(316, 29);
            txtNoPol.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoPol.BorderStyle = BorderStyle.FixedSingle;
            txtNoPol.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoPol.Location = new Point(177, 411);
            txtNoPol.Name = "txtNoPol";
            txtNoPol.PlaceholderText = " Masukkan Nomor Polisi";
            txtNoPol.Size = new Size(316, 29);
            txtNoPol.TabIndex = 47;
            txtNoPol.ThemeName = "Default";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(19, 411);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 46;
            label5.Text = "Nomor polisi";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTahun
            // 
            txtTahun.BackColor = Color.White;
            txtTahun.BeforeTouchSize = new Size(316, 29);
            txtTahun.BorderColor = Color.FromArgb(209, 211, 212);
            txtTahun.BorderStyle = BorderStyle.FixedSingle;
            txtTahun.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTahun.Location = new Point(177, 488);
            txtTahun.Name = "txtTahun";
            txtTahun.PlaceholderText = " Masukkan Tahun Motor";
            txtTahun.Size = new Size(316, 29);
            txtTahun.TabIndex = 49;
            txtTahun.ThemeName = "Default";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(19, 488);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 48;
            label6.Text = "Tahun";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboTransmisi
            // 
            comboTransmisi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTransmisi.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboTransmisi.FormattingEnabled = true;
            comboTransmisi.Location = new Point(177, 253);
            comboTransmisi.Name = "comboTransmisi";
            comboTransmisi.Size = new Size(316, 29);
            comboTransmisi.TabIndex = 50;
            // 
            // numericCC
            // 
            numericCC.BackColor = Color.White;
            numericCC.BeforeTouchSize = new Size(316, 29);
            numericCC.BorderColor = Color.FromArgb(197, 197, 197);
            numericCC.BorderStyle = BorderStyle.FixedSingle;
            numericCC.Font = new Font("Segoe UI", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            numericCC.ForeColor = Color.FromArgb(68, 68, 68);
            numericCC.Location = new Point(177, 334);
            numericCC.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericCC.Name = "numericCC";
            numericCC.Size = new Size(316, 29);
            numericCC.TabIndex = 51;
            numericCC.ThemeName = "Office2016Colorful";
            numericCC.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Red;
            label16.Location = new Point(177, 117);
            label16.Name = "label16";
            label16.Size = new Size(174, 17);
            label16.TabIndex = 78;
            label16.Text = "⚠️ No KTP tidak ditemukan!";
            label16.TextAlign = ContentAlignment.MiddleRight;
            label16.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(177, 196);
            label7.Name = "label7";
            label7.Size = new Size(174, 17);
            label7.TabIndex = 79;
            label7.Text = "⚠️ No KTP tidak ditemukan!";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(177, 284);
            label8.Name = "label8";
            label8.Size = new Size(174, 17);
            label8.TabIndex = 80;
            label8.Text = "⚠️ No KTP tidak ditemukan!";
            label8.TextAlign = ContentAlignment.MiddleRight;
            label8.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(177, 364);
            label9.Name = "label9";
            label9.Size = new Size(174, 17);
            label9.TabIndex = 81;
            label9.Text = "⚠️ No KTP tidak ditemukan!";
            label9.TextAlign = ContentAlignment.MiddleRight;
            label9.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(177, 441);
            label10.Name = "label10";
            label10.Size = new Size(174, 17);
            label10.TabIndex = 82;
            label10.Text = "⚠️ No KTP tidak ditemukan!";
            label10.TextAlign = ContentAlignment.MiddleRight;
            label10.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(177, 518);
            label11.Name = "label11";
            label11.Size = new Size(174, 17);
            label11.TabIndex = 83;
            label11.Text = "⚠️ No KTP tidak ditemukan!";
            label11.TextAlign = ContentAlignment.MiddleRight;
            label11.Visible = false;
            // 
            // InputKendaraanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 247);
            ClientSize = new Size(520, 632);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label16);
            Controls.Add(numericCC);
            Controls.Add(comboTransmisi);
            Controls.Add(txtTahun);
            Controls.Add(label6);
            Controls.Add(txtNoPol);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtTipe);
            Controls.Add(btnSave);
            Controls.Add(txtMerk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "InputKendaraanForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtMerk).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label3;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMerk;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTipe;
        private Label label1;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoPol;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTahun;
        private Label label6;
        private ComboBox comboTransmisi;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt numericCC;
        private Label label16;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}