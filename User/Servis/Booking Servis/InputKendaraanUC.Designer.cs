namespace Bengkel_Yoga_UKK
{
    partial class InputKendaraanUC
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
            label1 = new Label();
            yogaPanel1 = new YogaPanel();
            comboBox1 = new ComboBox();
            numericUpDownExt1 = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            lblErrorAlamat = new Label();
            lblErrorTelepon = new Label();
            label8 = new Label();
            txtNoTelp = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label9 = new Label();
            label10 = new Label();
            lblErrorKTP = new Label();
            txtAlamat = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorEmail = new Label();
            label5 = new Label();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label3 = new Label();
            label2 = new Label();
            btnRegister = new Button();
            txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorNama = new Label();
            yogaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAlamat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(42, 142, 209);
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(873, 46);
            label1.TabIndex = 0;
            label1.Text = "Tambah Kendaraan";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yogaPanel1
            // 
            yogaPanel1.Anchor = AnchorStyles.None;
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 15;
            yogaPanel1.BorderSize = 2;
            yogaPanel1.Controls.Add(comboBox1);
            yogaPanel1.Controls.Add(numericUpDownExt1);
            yogaPanel1.Controls.Add(lblErrorAlamat);
            yogaPanel1.Controls.Add(lblErrorTelepon);
            yogaPanel1.Controls.Add(label8);
            yogaPanel1.Controls.Add(txtNoTelp);
            yogaPanel1.Controls.Add(label9);
            yogaPanel1.Controls.Add(label10);
            yogaPanel1.Controls.Add(lblErrorKTP);
            yogaPanel1.Controls.Add(txtAlamat);
            yogaPanel1.Controls.Add(lblErrorEmail);
            yogaPanel1.Controls.Add(label5);
            yogaPanel1.Controls.Add(txtEmail);
            yogaPanel1.Controls.Add(label3);
            yogaPanel1.Controls.Add(label2);
            yogaPanel1.Controls.Add(btnRegister);
            yogaPanel1.Controls.Add(txtNama);
            yogaPanel1.Controls.Add(lblErrorNama);
            yogaPanel1.Controls.Add(label1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(45, 45);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(873, 444);
            yogaPanel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 283);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(370, 31);
            comboBox1.TabIndex = 129;
            // 
            // numericUpDownExt1
            // 
            numericUpDownExt1.BackColor = Color.White;
            numericUpDownExt1.BeforeTouchSize = new Size(205, 31);
            numericUpDownExt1.BorderColor = Color.FromArgb(197, 197, 197);
            numericUpDownExt1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDownExt1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownExt1.ForeColor = Color.FromArgb(68, 68, 68);
            numericUpDownExt1.Location = new Point(467, 103);
            numericUpDownExt1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownExt1.Name = "numericUpDownExt1";
            numericUpDownExt1.Size = new Size(205, 31);
            numericUpDownExt1.TabIndex = 130;
            numericUpDownExt1.ThemeName = "Office2016Colorful";
            numericUpDownExt1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            // 
            // lblErrorAlamat
            // 
            lblErrorAlamat.AutoSize = true;
            lblErrorAlamat.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorAlamat.ForeColor = Color.Red;
            lblErrorAlamat.Location = new Point(467, 317);
            lblErrorAlamat.Name = "lblErrorAlamat";
            lblErrorAlamat.Size = new Size(162, 17);
            lblErrorAlamat.TabIndex = 144;
            lblErrorAlamat.Text = "⚠️ Harap mengisi alamat!";
            lblErrorAlamat.TextAlign = ContentAlignment.MiddleRight;
            lblErrorAlamat.Visible = false;
            // 
            // lblErrorTelepon
            // 
            lblErrorTelepon.AutoSize = true;
            lblErrorTelepon.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTelepon.ForeColor = Color.Red;
            lblErrorTelepon.Location = new Point(467, 227);
            lblErrorTelepon.Name = "lblErrorTelepon";
            lblErrorTelepon.Size = new Size(218, 17);
            lblErrorTelepon.TabIndex = 143;
            lblErrorTelepon.Text = "⚠️ Nomor telepon sudah terdaftar!";
            lblErrorTelepon.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTelepon.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(467, 169);
            label8.Name = "label8";
            label8.Size = new Size(103, 21);
            label8.TabIndex = 142;
            label8.Text = "Nomor Polisi";
            // 
            // txtNoTelp
            // 
            txtNoTelp.BeforeTouchSize = new Size(325, 31);
            txtNoTelp.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoTelp.Location = new Point(467, 193);
            txtNoTelp.Name = "txtNoTelp";
            txtNoTelp.PlaceholderText = " Masukkan nomor polisi";
            txtNoTelp.Size = new Size(370, 31);
            txtNoTelp.TabIndex = 141;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(467, 259);
            label9.Name = "label9";
            label9.Size = new Size(52, 21);
            label9.TabIndex = 140;
            label9.Text = "Tahun";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(467, 79);
            label10.Name = "label10";
            label10.Size = new Size(156, 21);
            label10.TabIndex = 139;
            label10.Text = "Kapasitas Mesin (cc)";
            // 
            // lblErrorKTP
            // 
            lblErrorKTP.AutoSize = true;
            lblErrorKTP.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorKTP.ForeColor = Color.Red;
            lblErrorKTP.Location = new Point(467, 137);
            lblErrorKTP.Name = "lblErrorKTP";
            lblErrorKTP.Size = new Size(208, 17);
            lblErrorKTP.TabIndex = 138;
            lblErrorKTP.Text = "⚠️ Kapasitas mesin tidak boleh 0!";
            lblErrorKTP.TextAlign = ContentAlignment.MiddleRight;
            lblErrorKTP.Visible = false;
            // 
            // txtAlamat
            // 
            txtAlamat.BeforeTouchSize = new Size(325, 31);
            txtAlamat.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtAlamat.Location = new Point(467, 283);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.PlaceholderText = " Masukkan tahun produksi";
            txtAlamat.Size = new Size(370, 31);
            txtAlamat.TabIndex = 137;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(37, 227);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(173, 17);
            lblErrorEmail.TabIndex = 136;
            lblErrorEmail.Text = "⚠️ Format email tidak valid!";
            lblErrorEmail.TextAlign = ContentAlignment.MiddleRight;
            lblErrorEmail.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(37, 169);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 135;
            label5.Text = "Tipe";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(325, 31);
            txtEmail.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(37, 193);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = " Masukkan Tipe Motor";
            txtEmail.Size = new Size(370, 31);
            txtEmail.TabIndex = 134;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(37, 259);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 133;
            label3.Text = "Transmisi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(37, 79);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 132;
            label2.Text = "Merk";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(42, 142, 209);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(699, 370);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(138, 36);
            btnRegister.TabIndex = 128;
            btnRegister.Text = "Save";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // txtNama
            // 
            txtNama.BeforeTouchSize = new Size(325, 31);
            txtNama.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtNama.Location = new Point(37, 103);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = " Masukkan Merk Motor";
            txtNama.Size = new Size(370, 31);
            txtNama.TabIndex = 127;
            // 
            // lblErrorNama
            // 
            lblErrorNama.AutoSize = true;
            lblErrorNama.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNama.ForeColor = Color.Red;
            lblErrorNama.Location = new Point(37, 137);
            lblErrorNama.Name = "lblErrorNama";
            lblErrorNama.Size = new Size(155, 17);
            lblErrorNama.TabIndex = 131;
            lblErrorNama.Text = "⚠️ Harap mengisi nama!";
            lblErrorNama.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNama.Visible = false;
            // 
            // InputKendaraanUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 235, 240);
            Controls.Add(yogaPanel1);
            Name = "InputKendaraanUC";
            Size = new Size(970, 539);
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelp).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAlamat).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private YogaPanel yogaPanel1;
        private ComboBox comboBox1;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt numericUpDownExt1;
        private Label lblErrorAlamat;
        private Label lblErrorTelepon;
        private Label label8;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoTelp;
        private Label label9;
        private Label label10;
        private Label lblErrorKTP;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAlamat;
        private Label lblErrorEmail;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Label label3;
        private Label label2;
        private Button btnRegister;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Label lblErrorNama;
    }
}
