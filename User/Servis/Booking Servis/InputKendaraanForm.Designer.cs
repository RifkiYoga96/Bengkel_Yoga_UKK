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
            label1 = new Label();
            comboTransmisi = new ComboBox();
            numericKapasitas = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            lblErrorTahun = new Label();
            lblErrorNoPol = new Label();
            label8 = new Label();
            txtNoPol = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label9 = new Label();
            label10 = new Label();
            txtTahun = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorTipe = new Label();
            label5 = new Label();
            txtTipe = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label3 = new Label();
            label2 = new Label();
            txtMerk = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorMerk = new Label();
            btnSave = new YogaButton();
            btnCancel = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)numericKapasitas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMerk).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(42, 142, 209);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(864, 46);
            label1.TabIndex = 1;
            label1.Text = "Tambah Kendaraan";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboTransmisi
            // 
            comboTransmisi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTransmisi.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            comboTransmisi.FormattingEnabled = true;
            comboTransmisi.Location = new Point(33, 283);
            comboTransmisi.Name = "comboTransmisi";
            comboTransmisi.Size = new Size(370, 31);
            comboTransmisi.TabIndex = 165;
            // 
            // numericKapasitas
            // 
            numericKapasitas.BackColor = Color.White;
            numericKapasitas.BeforeTouchSize = new Size(205, 31);
            numericKapasitas.BorderColor = Color.FromArgb(197, 197, 197);
            numericKapasitas.BorderStyle = BorderStyle.FixedSingle;
            numericKapasitas.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            numericKapasitas.ForeColor = Color.FromArgb(68, 68, 68);
            numericKapasitas.Location = new Point(465, 97);
            numericKapasitas.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericKapasitas.Name = "numericKapasitas";
            numericKapasitas.Size = new Size(205, 31);
            numericKapasitas.TabIndex = 166;
            numericKapasitas.ThemeName = "Office2016Colorful";
            numericKapasitas.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            // 
            // lblErrorTahun
            // 
            lblErrorTahun.AutoSize = true;
            lblErrorTahun.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTahun.ForeColor = Color.Red;
            lblErrorTahun.Location = new Point(465, 317);
            lblErrorTahun.Name = "lblErrorTahun";
            lblErrorTahun.Size = new Size(162, 17);
            lblErrorTahun.TabIndex = 180;
            lblErrorTahun.Text = "⚠️ Harap mengisi alamat!";
            lblErrorTahun.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTahun.Visible = false;
            // 
            // lblErrorNoPol
            // 
            lblErrorNoPol.AutoSize = true;
            lblErrorNoPol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNoPol.ForeColor = Color.Red;
            lblErrorNoPol.Location = new Point(465, 224);
            lblErrorNoPol.Name = "lblErrorNoPol";
            lblErrorNoPol.Size = new Size(218, 17);
            lblErrorNoPol.TabIndex = 179;
            lblErrorNoPol.Text = "⚠️ Nomor telepon sudah terdaftar!";
            lblErrorNoPol.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNoPol.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(465, 166);
            label8.Name = "label8";
            label8.Size = new Size(103, 21);
            label8.TabIndex = 178;
            label8.Text = "Nomor Polisi";
            // 
            // txtNoPol
            // 
            txtNoPol.BeforeTouchSize = new Size(370, 31);
            txtNoPol.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoPol.Location = new Point(465, 190);
            txtNoPol.Name = "txtNoPol";
            txtNoPol.PlaceholderText = " Masukkan nomor polisi";
            txtNoPol.Size = new Size(370, 31);
            txtNoPol.TabIndex = 177;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(465, 259);
            label9.Name = "label9";
            label9.Size = new Size(52, 21);
            label9.TabIndex = 176;
            label9.Text = "Tahun";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(465, 73);
            label10.Name = "label10";
            label10.Size = new Size(156, 21);
            label10.TabIndex = 175;
            label10.Text = "Kapasitas Mesin (cc)";
            // 
            // txtTahun
            // 
            txtTahun.BeforeTouchSize = new Size(370, 31);
            txtTahun.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtTahun.Location = new Point(465, 283);
            txtTahun.Name = "txtTahun";
            txtTahun.PlaceholderText = " Masukkan tahun produksi";
            txtTahun.Size = new Size(370, 31);
            txtTahun.TabIndex = 173;
            // 
            // lblErrorTipe
            // 
            lblErrorTipe.AutoSize = true;
            lblErrorTipe.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTipe.ForeColor = Color.Red;
            lblErrorTipe.Location = new Point(33, 224);
            lblErrorTipe.Name = "lblErrorTipe";
            lblErrorTipe.Size = new Size(173, 17);
            lblErrorTipe.TabIndex = 172;
            lblErrorTipe.Text = "⚠️ Format email tidak valid!";
            lblErrorTipe.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTipe.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(33, 166);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 171;
            label5.Text = "Tipe";
            // 
            // txtTipe
            // 
            txtTipe.BeforeTouchSize = new Size(370, 31);
            txtTipe.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtTipe.Location = new Point(33, 190);
            txtTipe.Name = "txtTipe";
            txtTipe.PlaceholderText = " Masukkan Tipe Motor";
            txtTipe.Size = new Size(370, 31);
            txtTipe.TabIndex = 170;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(33, 259);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 169;
            label3.Text = "Transmisi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(33, 73);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 168;
            label2.Text = "Merk";
            // 
            // txtMerk
            // 
            txtMerk.BeforeTouchSize = new Size(370, 31);
            txtMerk.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtMerk.Location = new Point(33, 97);
            txtMerk.Name = "txtMerk";
            txtMerk.PlaceholderText = " Masukkan Merk Motor";
            txtMerk.Size = new Size(370, 31);
            txtMerk.TabIndex = 163;
            // 
            // lblErrorMerk
            // 
            lblErrorMerk.AutoSize = true;
            lblErrorMerk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorMerk.ForeColor = Color.Red;
            lblErrorMerk.Location = new Point(33, 131);
            lblErrorMerk.Name = "lblErrorMerk";
            lblErrorMerk.Size = new Size(155, 17);
            lblErrorMerk.TabIndex = 167;
            lblErrorMerk.Text = "⚠️ Harap mengisi nama!";
            lblErrorMerk.TextAlign = ContentAlignment.MiddleRight;
            lblErrorMerk.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(42, 142, 209);
            btnSave.BackgroundColor = Color.FromArgb(42, 142, 209);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 5;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(685, 366);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 181;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundColor = Color.Transparent;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 5;
            btnCancel.BorderSize = 2;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.ControlDarkDark;
            btnCancel.Location = new Point(520, 366);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 182;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // InputKendaraanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(864, 431);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(comboTransmisi);
            Controls.Add(numericKapasitas);
            Controls.Add(lblErrorTahun);
            Controls.Add(lblErrorNoPol);
            Controls.Add(label8);
            Controls.Add(txtNoPol);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtTahun);
            Controls.Add(lblErrorTipe);
            Controls.Add(label5);
            Controls.Add(txtTipe);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMerk);
            Controls.Add(lblErrorMerk);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "InputKendaraanForm";
            ((System.ComponentModel.ISupportInitialize)numericKapasitas).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoPol).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTahun).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTipe).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMerk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboTransmisi;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt numericKapasitas;
        private Label lblErrorTahun;
        private Label lblErrorNoPol;
        private Label label8;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoPol;
        private Label label9;
        private Label label10;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTahun;
        private Label lblErrorTipe;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTipe;
        private Label label3;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMerk;
        private Label lblErrorMerk;
        private YogaButton btnSave;
        private YogaButton btnCancel;
    }
}