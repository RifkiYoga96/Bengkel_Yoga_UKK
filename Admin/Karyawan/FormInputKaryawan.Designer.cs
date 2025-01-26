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
            panel1 = new Panel();
            lblHeader = new Label();
            label1 = new Label();
            label3 = new Label();
            btnFile = new YogaButton();
            txtFile = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label4 = new Label();
            txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            label5 = new Label();
            btnSave = new YogaButton();
            txtNoKTP = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtNoTelp = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label2 = new Label();
            radioKaryawan = new MaterialSkin.Controls.MaterialRadioButton();
            radioSuperAdmin = new MaterialSkin.Controls.MaterialRadioButton();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoKTP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelp).BeginInit();
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
            lblHeader.Text = "Input Karyawan";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(20, 81);
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
            label3.Location = new Point(20, 154);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 15;
            label3.Text = "Nama:";
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
            txtFile.BeforeTouchSize = new Size(293, 27);
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
            label4.Location = new Point(20, 227);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 24;
            label4.Text = "No KTP:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.White;
            txtNama.BeforeTouchSize = new Size(293, 27);
            txtNama.BorderColor = Color.FromArgb(209, 211, 212);
            txtNama.BorderStyle = BorderStyle.FixedSingle;
            txtNama.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNama.Location = new Point(162, 154);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(293, 27);
            txtNama.TabIndex = 26;
            txtNama.ThemeName = "Default";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(20, 300);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 28;
            label6.Text = "Email:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(20, 373);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 36;
            label5.Text = "Password:";
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
            btnSave.Location = new Point(347, 578);
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
            txtNoKTP.BeforeTouchSize = new Size(293, 27);
            txtNoKTP.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoKTP.BorderStyle = BorderStyle.FixedSingle;
            txtNoKTP.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoKTP.Location = new Point(162, 227);
            txtNoKTP.Name = "txtNoKTP";
            txtNoKTP.Size = new Size(293, 27);
            txtNoKTP.TabIndex = 39;
            txtNoKTP.ThemeName = "Default";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BeforeTouchSize = new Size(293, 27);
            txtEmail.BorderColor = Color.FromArgb(209, 211, 212);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(162, 300);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(293, 27);
            txtEmail.TabIndex = 40;
            txtEmail.ThemeName = "Default";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BeforeTouchSize = new Size(293, 27);
            txtPassword.BorderColor = Color.FromArgb(209, 211, 212);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(162, 373);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(293, 27);
            txtPassword.TabIndex = 41;
            txtPassword.ThemeName = "Default";
            // 
            // txtNoTelp
            // 
            txtNoTelp.BackColor = Color.White;
            txtNoTelp.BeforeTouchSize = new Size(293, 27);
            txtNoTelp.BorderColor = Color.FromArgb(209, 211, 212);
            txtNoTelp.BorderStyle = BorderStyle.FixedSingle;
            txtNoTelp.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNoTelp.Location = new Point(162, 446);
            txtNoTelp.Name = "txtNoTelp";
            txtNoTelp.Size = new Size(293, 27);
            txtNoTelp.TabIndex = 43;
            txtNoTelp.ThemeName = "Default";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(20, 446);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 42;
            label2.Text = "No Telpon:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioKaryawan
            // 
            radioKaryawan.AutoSize = true;
            radioKaryawan.Depth = 0;
            radioKaryawan.Location = new Point(162, 505);
            radioKaryawan.Margin = new Padding(0);
            radioKaryawan.MouseLocation = new Point(-1, -1);
            radioKaryawan.MouseState = MaterialSkin.MouseState.HOVER;
            radioKaryawan.Name = "radioKaryawan";
            radioKaryawan.Ripple = true;
            radioKaryawan.Size = new Size(106, 37);
            radioKaryawan.TabIndex = 44;
            radioKaryawan.TabStop = true;
            radioKaryawan.Text = "Karyawan";
            radioKaryawan.UseVisualStyleBackColor = true;
            // 
            // radioSuperAdmin
            // 
            radioSuperAdmin.AutoSize = true;
            radioSuperAdmin.Depth = 0;
            radioSuperAdmin.Location = new Point(329, 505);
            radioSuperAdmin.Margin = new Padding(0);
            radioSuperAdmin.MouseLocation = new Point(-1, -1);
            radioSuperAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            radioSuperAdmin.Name = "radioSuperAdmin";
            radioSuperAdmin.Ripple = true;
            radioSuperAdmin.Size = new Size(126, 37);
            radioSuperAdmin.TabIndex = 45;
            radioSuperAdmin.TabStop = true;
            radioSuperAdmin.Text = "Super Admin";
            radioSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(20, 509);
            label7.Name = "label7";
            label7.Size = new Size(79, 25);
            label7.TabIndex = 46;
            label7.Text = "Jabatan:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormInputKaryawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 626);
            Controls.Add(label7);
            Controls.Add(radioSuperAdmin);
            Controls.Add(radioKaryawan);
            Controls.Add(txtNoTelp);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtNoKTP);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtNama);
            Controls.Add(label4);
            Controls.Add(txtFile);
            Controls.Add(btnFile);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputKaryawan";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtFile).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoKTP).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoTelp).EndInit();
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
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Label label6;
        private Label label5;
        private YogaButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoKTP;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoTelp;
        private Label label2;
        private MaterialSkin.Controls.MaterialRadioButton radioKaryawan;
        private MaterialSkin.Controls.MaterialRadioButton radioSuperAdmin;
        private Label label7;
    }
}