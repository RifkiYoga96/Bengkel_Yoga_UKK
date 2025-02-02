namespace Bengkel_Yoga_UKK
{
    partial class FormInputProduk
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputProduk));
            panel1 = new Panel();
            lblHeader = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNamaProduk = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            txtHarga = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            btnMinStok = new YogaButton();
            btnPlusStok = new YogaButton();
            btnPlusStokMinimum = new YogaButton();
            btnMinStokMinimum = new YogaButton();
            label5 = new Label();
            btnSave = new YogaButton();
            txtStok = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtStokMinimum = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            btnChooseFile = new YogaButton();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            txtImage = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNamaProduk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStokMinimum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 42);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(476, 43);
            lblHeader.TabIndex = 11;
            lblHeader.Text = "Input Produk";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(21, 177);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 12;
            label1.Text = "Foto:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(20, 250);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 15;
            label3.Text = "Nama Produk:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(20, 327);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 24;
            label4.Text = "Harga:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.BackColor = Color.White;
            txtNamaProduk.BeforeTouchSize = new Size(157, 27);
            txtNamaProduk.BorderColor = Color.FromArgb(209, 211, 212);
            txtNamaProduk.BorderStyle = BorderStyle.FixedSingle;
            txtNamaProduk.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNamaProduk.Location = new Point(162, 250);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(293, 27);
            txtNamaProduk.TabIndex = 26;
            txtNamaProduk.ThemeName = "Default";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(20, 404);
            label6.Name = "label6";
            label6.Size = new Size(53, 25);
            label6.TabIndex = 28;
            label6.Text = "Stok:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtHarga
            // 
            txtHarga.AccessibilityEnabled = true;
            txtHarga.BeforeTouchSize = new Size(157, 27);
            txtHarga.BorderColor = Color.FromArgb(209, 211, 212);
            txtHarga.BorderStyle = BorderStyle.FixedSingle;
            txtHarga.DecimalValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtHarga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtHarga.Location = new Point(162, 327);
            txtHarga.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtHarga.Name = "txtHarga";
            txtHarga.Size = new Size(293, 27);
            txtHarga.TabIndex = 30;
            txtHarga.Text = "Rp1";
            txtHarga.ThemeName = "Metro";
            // 
            // btnMinStok
            // 
            btnMinStok.BackColor = Color.Red;
            btnMinStok.BackgroundColor = Color.Red;
            btnMinStok.BorderColor = Color.PaleVioletRed;
            btnMinStok.BorderRadius = 0;
            btnMinStok.BorderSize = 0;
            btnMinStok.FlatAppearance.BorderSize = 0;
            btnMinStok.FlatStyle = FlatStyle.Flat;
            btnMinStok.ForeColor = Color.White;
            btnMinStok.Image = (Image)resources.GetObject("btnMinStok.Image");
            btnMinStok.Location = new Point(162, 404);
            btnMinStok.Name = "btnMinStok";
            btnMinStok.Size = new Size(40, 27);
            btnMinStok.TabIndex = 31;
            btnMinStok.TextColor = Color.White;
            btnMinStok.UseVisualStyleBackColor = false;
            // 
            // btnPlusStok
            // 
            btnPlusStok.BackColor = Color.FromArgb(0, 192, 0);
            btnPlusStok.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnPlusStok.BorderColor = Color.PaleVioletRed;
            btnPlusStok.BorderRadius = 0;
            btnPlusStok.BorderSize = 0;
            btnPlusStok.FlatAppearance.BorderSize = 0;
            btnPlusStok.FlatStyle = FlatStyle.Flat;
            btnPlusStok.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlusStok.ForeColor = Color.White;
            btnPlusStok.Image = (Image)resources.GetObject("btnPlusStok.Image");
            btnPlusStok.Location = new Point(415, 404);
            btnPlusStok.Name = "btnPlusStok";
            btnPlusStok.Size = new Size(40, 27);
            btnPlusStok.TabIndex = 32;
            btnPlusStok.TextColor = Color.White;
            btnPlusStok.UseVisualStyleBackColor = false;
            // 
            // btnPlusStokMinimum
            // 
            btnPlusStokMinimum.BackColor = Color.FromArgb(0, 192, 0);
            btnPlusStokMinimum.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnPlusStokMinimum.BorderColor = Color.PaleVioletRed;
            btnPlusStokMinimum.BorderRadius = 0;
            btnPlusStokMinimum.BorderSize = 0;
            btnPlusStokMinimum.FlatAppearance.BorderSize = 0;
            btnPlusStokMinimum.FlatStyle = FlatStyle.Flat;
            btnPlusStokMinimum.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlusStokMinimum.ForeColor = Color.White;
            btnPlusStokMinimum.Image = (Image)resources.GetObject("btnPlusStokMinimum.Image");
            btnPlusStokMinimum.Location = new Point(415, 481);
            btnPlusStokMinimum.Name = "btnPlusStokMinimum";
            btnPlusStokMinimum.Size = new Size(40, 27);
            btnPlusStokMinimum.TabIndex = 35;
            btnPlusStokMinimum.TextColor = Color.White;
            btnPlusStokMinimum.UseVisualStyleBackColor = false;
            // 
            // btnMinStokMinimum
            // 
            btnMinStokMinimum.BackColor = Color.Red;
            btnMinStokMinimum.BackgroundColor = Color.Red;
            btnMinStokMinimum.BorderColor = Color.PaleVioletRed;
            btnMinStokMinimum.BorderRadius = 0;
            btnMinStokMinimum.BorderSize = 0;
            btnMinStokMinimum.FlatAppearance.BorderSize = 0;
            btnMinStokMinimum.FlatStyle = FlatStyle.Flat;
            btnMinStokMinimum.ForeColor = Color.White;
            btnMinStokMinimum.Image = (Image)resources.GetObject("btnMinStokMinimum.Image");
            btnMinStokMinimum.Location = new Point(162, 481);
            btnMinStokMinimum.Name = "btnMinStokMinimum";
            btnMinStokMinimum.Size = new Size(40, 27);
            btnMinStokMinimum.TabIndex = 34;
            btnMinStokMinimum.TextColor = Color.White;
            btnMinStokMinimum.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(21, 481);
            label5.Name = "label5";
            label5.Size = new Size(138, 25);
            label5.TabIndex = 36;
            label5.Text = "Stok Minimum:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
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
            btnSave.Location = new Point(347, 542);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtStok
            // 
            txtStok.AccessibilityEnabled = true;
            txtStok.BeforeTouchSize = new Size(157, 27);
            txtStok.BorderColor = Color.FromArgb(209, 211, 212);
            txtStok.BorderStyle = BorderStyle.FixedSingle;
            txtStok.DoubleValue = 1D;
            txtStok.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtStok.Location = new Point(208, 404);
            txtStok.MaxValue = 10000D;
            txtStok.MinValue = 0D;
            txtStok.Name = "txtStok";
            txtStok.NumberDecimalDigits = 2;
            txtStok.Size = new Size(201, 27);
            txtStok.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            txtStok.TabIndex = 39;
            txtStok.Text = "1,00";
            txtStok.TextAlign = HorizontalAlignment.Center;
            txtStok.ThemeName = "Metro";
            // 
            // txtStokMinimum
            // 
            txtStokMinimum.AccessibilityEnabled = true;
            txtStokMinimum.BeforeTouchSize = new Size(157, 27);
            txtStokMinimum.BorderColor = Color.FromArgb(209, 211, 212);
            txtStokMinimum.BorderStyle = BorderStyle.FixedSingle;
            txtStokMinimum.DoubleValue = 1D;
            txtStokMinimum.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtStokMinimum.Location = new Point(208, 481);
            txtStokMinimum.MaxValue = 10000D;
            txtStokMinimum.MinValue = 0D;
            txtStokMinimum.Name = "txtStokMinimum";
            txtStokMinimum.NumberDecimalDigits = 2;
            txtStokMinimum.Size = new Size(201, 27);
            txtStokMinimum.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            txtStokMinimum.TabIndex = 40;
            txtStokMinimum.Text = "1,00";
            txtStokMinimum.TextAlign = HorizontalAlignment.Center;
            txtStokMinimum.ThemeName = "Metro";
            // 
            // btnChooseFile
            // 
            btnChooseFile.BackColor = Color.FromArgb(230, 126, 34);
            btnChooseFile.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnChooseFile.BorderColor = Color.PaleVioletRed;
            btnChooseFile.BorderRadius = 0;
            btnChooseFile.BorderSize = 0;
            btnChooseFile.FlatAppearance.BorderSize = 0;
            btnChooseFile.FlatStyle = FlatStyle.Flat;
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(199, 80);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(82, 27);
            btnChooseFile.TabIndex = 64;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.TextColor = Color.White;
            btnChooseFile.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.defaultImage;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 115);
            pictureBox1.TabIndex = 67;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtImage);
            panel2.Controls.Add(btnChooseFile);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(162, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(293, 121);
            panel2.TabIndex = 68;
            // 
            // txtImage
            // 
            txtImage.BackColor = Color.Gainsboro;
            txtImage.BeforeTouchSize = new Size(157, 27);
            txtImage.BorderColor = Color.Gray;
            txtImage.BorderStyle = BorderStyle.FixedSingle;
            txtImage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtImage.Location = new Point(124, 3);
            txtImage.Name = "txtImage";
            txtImage.ReadOnly = true;
            txtImage.Size = new Size(157, 27);
            txtImage.TabIndex = 69;
            txtImage.ThemeName = "Default";
            // 
            // FormInputProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 600);
            Controls.Add(panel2);
            Controls.Add(txtStokMinimum);
            Controls.Add(txtStok);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(btnPlusStokMinimum);
            Controls.Add(btnMinStokMinimum);
            Controls.Add(btnPlusStok);
            Controls.Add(btnMinStok);
            Controls.Add(txtHarga);
            Controls.Add(label6);
            Controls.Add(txtNamaProduk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputProduk";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNamaProduk).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStokMinimum).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label1;
        private Label label3;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaProduk;
        private Label label6;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtHarga;
        private YogaButton btnMinStok;
        private YogaButton btnPlusStok;
        private YogaButton btnPlusStokMinimum;
        private YogaButton btnMinStokMinimum;
        private Label label5;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtStok;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtStokMinimum;
        private YogaButton btnChooseFile;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtImage;
    }
}