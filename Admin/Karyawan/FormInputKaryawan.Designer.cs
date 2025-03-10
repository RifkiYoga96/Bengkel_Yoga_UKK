namespace Bengkel_Yoga_UKK
{
    partial class FormInputKaryawan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputKaryawan));
            panel1 = new Panel();
            lblHeader = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new YogaButton();
            txtNoKTP = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label9 = new Label();
            label10 = new Label();
            label12 = new Label();
            txtKonfirPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label13 = new Label();
            label2 = new Label();
            txtAlamat = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label5 = new Label();
            btnCancel = new YogaButton();
            pictureBoxProfile = new RJCircularPictureBox();
            btnChooseFile = new YogaButton();
            lblErrorNama = new Label();
            lblErrorKTP = new Label();
            lblErrorTelepon = new Label();
            lblErrorEmail = new Label();
            lblErrorPassword = new Label();
            lblErrorCPassword = new Label();
            comboPegawai = new ComboBox();
            lblErrorAlamat = new Label();
            btnDelete = new YogaButton();
            txtNoTelepon = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label1 = new Label();
            linkReset = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNama).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoKTP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKonfirPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAlamat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelepon).BeginInit();
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
            lblHeader.Text = "Input Pegawai";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(25, 271);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 15;
            label3.Text = "Nama";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(25, 348);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 24;
            label4.Text = "No KTP";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.White;
            txtNama.BeforeTouchSize = new Size(238, 31);
            txtNama.BorderColor = Color.FromArgb(209, 211, 212);
            txtNama.BorderStyle = BorderStyle.FixedSingle;
            txtNama.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNama.Location = new Point(139, 271);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = " Masukkan nama";
            txtNama.Size = new Size(293, 27);
            txtNama.TabIndex = 26;
            txtNama.ThemeName = "Default";
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
            btnSave.Location = new Point(804, 504);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtNoKTP
            // 
            txtNoKTP.BackColor = Color.White;
            txtNoKTP.BeforeTouchSize = new Size(238, 31);
            txtNoKTP.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoKTP.BorderStyle = BorderStyle.FixedSingle;
            txtNoKTP.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoKTP.Location = new Point(139, 348);
            txtNoKTP.Name = "txtNoKTP";
            txtNoKTP.PlaceholderText = " Masukkan nomor KTP";
            txtNoKTP.Size = new Size(293, 27);
            txtNoKTP.TabIndex = 39;
            txtNoKTP.ThemeName = "Default";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BeforeTouchSize = new Size(238, 31);
            txtPassword.BorderColor = Color.FromArgb(209, 211, 212);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(619, 151);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = " Masukkan password";
            txtPassword.Size = new Size(293, 27);
            txtPassword.TabIndex = 52;
            txtPassword.ThemeName = "Default";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BeforeTouchSize = new Size(238, 31);
            txtEmail.BorderColor = Color.FromArgb(209, 211, 212);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(619, 74);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = " ex: nama@gmail.com";
            txtEmail.Size = new Size(293, 27);
            txtEmail.TabIndex = 51;
            txtEmail.ThemeName = "Default";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(505, 151);
            label9.Name = "label9";
            label9.Size = new Size(90, 25);
            label9.TabIndex = 50;
            label9.Text = "Password";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(505, 74);
            label10.Name = "label10";
            label10.Size = new Size(56, 25);
            label10.TabIndex = 49;
            label10.Text = "Email";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(25, 425);
            label12.Name = "label12";
            label12.Size = new Size(108, 25);
            label12.TabIndex = 53;
            label12.Text = "No Telepon";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtKonfirPassword
            // 
            txtKonfirPassword.BackColor = Color.White;
            txtKonfirPassword.BeforeTouchSize = new Size(238, 31);
            txtKonfirPassword.BorderColor = Color.FromArgb(209, 211, 212);
            txtKonfirPassword.BorderStyle = BorderStyle.FixedSingle;
            txtKonfirPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtKonfirPassword.Location = new Point(619, 228);
            txtKonfirPassword.Name = "txtKonfirPassword";
            txtKonfirPassword.PasswordChar = '*';
            txtKonfirPassword.PlaceholderText = " Masukkan konfirmasi password";
            txtKonfirPassword.Size = new Size(293, 27);
            txtKonfirPassword.TabIndex = 58;
            txtKonfirPassword.ThemeName = "Default";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(505, 215);
            label13.Name = "label13";
            label13.Size = new Size(106, 50);
            label13.TabIndex = 57;
            label13.Text = "Konfirmasi \r\nPassword";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(505, 425);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 59;
            label2.Text = "Jabatan";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAlamat
            // 
            txtAlamat.BackColor = Color.White;
            txtAlamat.BeforeTouchSize = new Size(238, 31);
            txtAlamat.BorderColor = Color.FromArgb(209, 211, 212);
            txtAlamat.BorderStyle = BorderStyle.FixedSingle;
            txtAlamat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtAlamat.Location = new Point(619, 305);
            txtAlamat.Multiline = true;
            txtAlamat.Name = "txtAlamat";
            txtAlamat.PlaceholderText = " Masukkan alamat";
            txtAlamat.Size = new Size(293, 70);
            txtAlamat.TabIndex = 61;
            txtAlamat.ThemeName = "Default";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(505, 305);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 60;
            label5.Text = "Alamat";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundColor = Color.Transparent;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 2;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.ControlDarkDark;
            btnCancel.Location = new Point(687, 504);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 36);
            btnCancel.TabIndex = 62;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackgroundImage = (Image)resources.GetObject("pictureBoxProfile.BackgroundImage");
            pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxProfile.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            pictureBoxProfile.BorderColor = Color.RoyalBlue;
            pictureBoxProfile.BorderColor2 = Color.HotPink;
            pictureBoxProfile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pictureBoxProfile.BorderSize = 2;
            pictureBoxProfile.GradientAngle = 50F;
            pictureBoxProfile.Location = new Point(173, 61);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(117, 117);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProfile.TabIndex = 63;
            pictureBoxProfile.TabStop = false;
            // 
            // btnChooseFile
            // 
            btnChooseFile.BackColor = Color.FromArgb(52, 152, 219);
            btnChooseFile.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnChooseFile.BorderColor = Color.PaleVioletRed;
            btnChooseFile.BorderRadius = 0;
            btnChooseFile.BorderSize = 0;
            btnChooseFile.FlatAppearance.BorderSize = 0;
            btnChooseFile.FlatStyle = FlatStyle.Flat;
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(239, 203);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(82, 27);
            btnChooseFile.TabIndex = 64;
            btnChooseFile.Text = "Upload";
            btnChooseFile.TextColor = Color.White;
            btnChooseFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChooseFile.UseVisualStyleBackColor = false;
            // 
            // lblErrorNama
            // 
            lblErrorNama.AutoSize = true;
            lblErrorNama.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNama.ForeColor = Color.Red;
            lblErrorNama.Location = new Point(139, 301);
            lblErrorNama.Name = "lblErrorNama";
            lblErrorNama.Size = new Size(159, 17);
            lblErrorNama.TabIndex = 77;
            lblErrorNama.Text = "⚠️ Harap mengisi nama !";
            lblErrorNama.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNama.Visible = false;
            // 
            // lblErrorKTP
            // 
            lblErrorKTP.AutoSize = true;
            lblErrorKTP.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorKTP.ForeColor = Color.Red;
            lblErrorKTP.Location = new Point(139, 378);
            lblErrorKTP.Name = "lblErrorKTP";
            lblErrorKTP.Size = new Size(171, 17);
            lblErrorKTP.TabIndex = 78;
            lblErrorKTP.Text = "⚠️ Harap mengisi No KTP !";
            lblErrorKTP.TextAlign = ContentAlignment.MiddleRight;
            lblErrorKTP.Visible = false;
            // 
            // lblErrorTelepon
            // 
            lblErrorTelepon.AutoSize = true;
            lblErrorTelepon.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTelepon.ForeColor = Color.Red;
            lblErrorTelepon.Location = new Point(139, 455);
            lblErrorTelepon.Name = "lblErrorTelepon";
            lblErrorTelepon.Size = new Size(214, 17);
            lblErrorTelepon.TabIndex = 79;
            lblErrorTelepon.Text = "⚠️ Harap mengisi nomor telepon !";
            lblErrorTelepon.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTelepon.Visible = false;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(619, 104);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(194, 17);
            lblErrorEmail.TabIndex = 80;
            lblErrorEmail.Text = "⚠️ Masukkan email yang valid !";
            lblErrorEmail.TextAlign = ContentAlignment.MiddleRight;
            lblErrorEmail.Visible = false;
            // 
            // lblErrorPassword
            // 
            lblErrorPassword.AutoSize = true;
            lblErrorPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorPassword.ForeColor = Color.Red;
            lblErrorPassword.Location = new Point(619, 181);
            lblErrorPassword.Name = "lblErrorPassword";
            lblErrorPassword.Size = new Size(184, 17);
            lblErrorPassword.TabIndex = 81;
            lblErrorPassword.Text = "⚠️ Harap mengisi password !";
            lblErrorPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorPassword.Visible = false;
            // 
            // lblErrorCPassword
            // 
            lblErrorCPassword.AutoSize = true;
            lblErrorCPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorCPassword.ForeColor = Color.Red;
            lblErrorCPassword.Location = new Point(619, 258);
            lblErrorCPassword.Name = "lblErrorCPassword";
            lblErrorCPassword.Size = new Size(248, 17);
            lblErrorCPassword.TabIndex = 82;
            lblErrorCPassword.Text = "⚠️ Harap mengisi konfirmasi password !";
            lblErrorCPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorCPassword.Visible = false;
            // 
            // comboPegawai
            // 
            comboPegawai.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPegawai.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboPegawai.FormattingEnabled = true;
            comboPegawai.Location = new Point(619, 425);
            comboPegawai.Name = "comboPegawai";
            comboPegawai.Size = new Size(293, 28);
            comboPegawai.TabIndex = 83;
            // 
            // lblErrorAlamat
            // 
            lblErrorAlamat.AutoSize = true;
            lblErrorAlamat.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorAlamat.ForeColor = Color.Red;
            lblErrorAlamat.Location = new Point(619, 378);
            lblErrorAlamat.Name = "lblErrorAlamat";
            lblErrorAlamat.Size = new Size(167, 17);
            lblErrorAlamat.TabIndex = 84;
            lblErrorAlamat.Text = "⚠️ Harap mengisi Alamat !";
            lblErrorAlamat.TextAlign = ContentAlignment.MiddleRight;
            lblErrorAlamat.Visible = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(210, 60, 60);
            btnDelete.BackgroundColor = Color.FromArgb(210, 60, 60);
            btnDelete.BorderColor = Color.PaleVioletRed;
            btnDelete.BorderRadius = 0;
            btnDelete.BorderSize = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(139, 203);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 27);
            btnDelete.TabIndex = 85;
            btnDelete.Text = "Hapus";
            btnDelete.TextColor = Color.White;
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtNoTelepon
            // 
            txtNoTelepon.BackColor = Color.White;
            txtNoTelepon.BeforeTouchSize = new Size(238, 31);
            txtNoTelepon.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoTelepon.BorderStyle = BorderStyle.FixedSingle;
            txtNoTelepon.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoTelepon.Location = new Point(139, 426);
            txtNoTelepon.Name = "txtNoTelepon";
            txtNoTelepon.PlaceholderText = " Masukkan nomor telepon";
            txtNoTelepon.Size = new Size(293, 27);
            txtNoTelepon.TabIndex = 86;
            txtNoTelepon.ThemeName = "Default";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(765, 208);
            label1.Name = "label1";
            label1.Size = new Size(107, 17);
            label1.TabIndex = 87;
            label1.Text = "Reset password?";
            // 
            // linkReset
            // 
            linkReset.AutoSize = true;
            linkReset.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            linkReset.Location = new Point(873, 208);
            linkReset.Name = "linkReset";
            linkReset.Size = new Size(40, 17);
            linkReset.TabIndex = 88;
            linkReset.TabStop = true;
            linkReset.Text = "Reset";
            // 
            // FormInputKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 561);
            Controls.Add(linkReset);
            Controls.Add(label1);
            Controls.Add(txtNoTelepon);
            Controls.Add(btnDelete);
            Controls.Add(pictureBoxProfile);
            Controls.Add(btnChooseFile);
            Controls.Add(lblErrorAlamat);
            Controls.Add(comboPegawai);
            Controls.Add(lblErrorCPassword);
            Controls.Add(lblErrorPassword);
            Controls.Add(lblErrorEmail);
            Controls.Add(lblErrorTelepon);
            Controls.Add(lblErrorKTP);
            Controls.Add(lblErrorNama);
            Controls.Add(btnCancel);
            Controls.Add(txtAlamat);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(txtKonfirPassword);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtNoKTP);
            Controls.Add(btnSave);
            Controls.Add(txtNama);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputKaryawan";
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNama).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoKTP).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKonfirPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAlamat).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelepon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label3;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoKTP;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Label label9;
        private Label label10;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTelepon;
        private Label label12;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKonfirPassword;
        private Label label13;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAlamat;
        private Label label5;
        private YogaButton btnCancel;
        private RJCircularPictureBox pictureBoxProfile;
        private YogaButton btnChooseFile;
        private Label lblErrorNama;
        private Label lblErrorKTP;
        private Label lblErrorTelepon;
        private Label lblErrorEmail;
        private Label lblErrorPassword;
        private Label lblErrorCPassword;
        private ComboBox comboPegawai;
        private Label lblErrorAlamat;
        private YogaButton btnDelete;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoTelepon;
        private Label label1;
        private LinkLabel linkReset;
    }
}