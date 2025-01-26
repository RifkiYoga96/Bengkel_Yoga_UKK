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
            btnFile = new YogaButton();
            txtFile = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label4 = new Label();
            txtNamaProduk = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtStok = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            currencyHarga = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            btnMinStok = new YogaButton();
            btnPlusStok = new YogaButton();
            btnPlusStokMinimum = new YogaButton();
            btnMinStokMinimum = new YogaButton();
            label5 = new Label();
            btnSave = new YogaButton();
            textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNamaProduk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).BeginInit();
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
            label1.Location = new Point(19, 81);
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
            label3.Location = new Point(20, 158);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 15;
            label3.Text = "Nama Produk:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFile
            // 
            btnFile.BackColor = Color.FromArgb(230, 126, 34);
            btnFile.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnFile.BorderColor = Color.PaleVioletRed;
            btnFile.BorderRadius = 0;
            btnFile.BorderSize = 0;
            btnFile.FlatAppearance.BorderSize = 0;
            btnFile.FlatStyle = FlatStyle.Flat;
            btnFile.ForeColor = Color.White;
            btnFile.Location = new Point(373, 81);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(82, 27);
            btnFile.TabIndex = 22;
            btnFile.Text = "Choose File";
            btnFile.TextColor = Color.White;
            btnFile.UseVisualStyleBackColor = false;
            // 
            // txtFile
            // 
            txtFile.BackColor = SystemColors.Control;
            txtFile.BeforeTouchSize = new Size(201, 27);
            txtFile.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtFile.Location = new Point(162, 81);
            txtFile.Name = "txtFile";
            txtFile.ReadOnly = true;
            txtFile.Size = new Size(205, 27);
            txtFile.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(20, 235);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 24;
            label4.Text = "Harga:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.BackColor = Color.White;
            txtNamaProduk.BeforeTouchSize = new Size(201, 27);
            txtNamaProduk.BorderColor = Color.FromArgb(209, 211, 212);
            txtNamaProduk.BorderStyle = BorderStyle.FixedSingle;
            txtNamaProduk.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNamaProduk.Location = new Point(162, 158);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(293, 27);
            txtNamaProduk.TabIndex = 26;
            txtNamaProduk.ThemeName = "Default";
            // 
            // txtStok
            // 
            txtStok.BackColor = Color.White;
            txtStok.BeforeTouchSize = new Size(201, 27);
            txtStok.BorderColor = Color.FromArgb(209, 211, 212);
            txtStok.BorderStyle = BorderStyle.FixedSingle;
            txtStok.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtStok.Location = new Point(208, 312);
            txtStok.MinimumSize = new Size(14, 10);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(201, 27);
            txtStok.TabIndex = 29;
            txtStok.TextAlign = HorizontalAlignment.Center;
            txtStok.ThemeName = "Default";
            txtStok.ThemeStyle.BorderColor = Color.Blue;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(20, 312);
            label6.Name = "label6";
            label6.Size = new Size(53, 25);
            label6.TabIndex = 28;
            label6.Text = "Stok:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currencyHarga
            // 
            currencyHarga.AccessibilityEnabled = true;
            currencyHarga.BeforeTouchSize = new Size(201, 27);
            currencyHarga.BorderColor = Color.FromArgb(209, 211, 212);
            currencyHarga.BorderStyle = BorderStyle.FixedSingle;
            currencyHarga.DecimalValue = new decimal(new int[] { 1, 0, 0, 0 });
            currencyHarga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            currencyHarga.Location = new Point(162, 235);
            currencyHarga.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            currencyHarga.Name = "currencyHarga";
            currencyHarga.Size = new Size(293, 27);
            currencyHarga.TabIndex = 30;
            currencyHarga.Text = "Rp1";
            currencyHarga.ThemeName = "Metro";
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
            btnMinStok.Location = new Point(162, 312);
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
            btnPlusStok.Location = new Point(415, 312);
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
            btnPlusStokMinimum.Location = new Point(415, 389);
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
            btnMinStokMinimum.Location = new Point(162, 389);
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
            label5.Location = new Point(21, 389);
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
            btnSave.Location = new Point(347, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // textBoxExt1
            // 
            textBoxExt1.BackColor = Color.White;
            textBoxExt1.BeforeTouchSize = new Size(201, 27);
            textBoxExt1.BorderColor = Color.FromArgb(209, 211, 212);
            textBoxExt1.BorderStyle = BorderStyle.FixedSingle;
            textBoxExt1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxExt1.Location = new Point(208, 389);
            textBoxExt1.MinimumSize = new Size(14, 10);
            textBoxExt1.Name = "textBoxExt1";
            textBoxExt1.Size = new Size(201, 27);
            textBoxExt1.TabIndex = 38;
            textBoxExt1.TextAlign = HorizontalAlignment.Center;
            textBoxExt1.ThemeName = "Default";
            textBoxExt1.ThemeStyle.BorderColor = Color.Blue;
            // 
            // FormInputProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 514);
            Controls.Add(textBoxExt1);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(btnPlusStokMinimum);
            Controls.Add(btnMinStokMinimum);
            Controls.Add(btnPlusStok);
            Controls.Add(btnMinStok);
            Controls.Add(currencyHarga);
            Controls.Add(txtStok);
            Controls.Add(label6);
            Controls.Add(txtNamaProduk);
            Controls.Add(label4);
            Controls.Add(txtFile);
            Controls.Add(btnFile);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputProduk";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtFile).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNamaProduk).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label1;
        private Label label3;
        private YogaButton btnFile;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtFile;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaProduk;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtStok;
        private Label label6;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyHarga;
        private YogaButton btnMinStok;
        private YogaButton btnPlusStok;
        private YogaButton btnPlusStokMinimum;
        private YogaButton btnMinStokMinimum;
        private Label label5;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
    }
}