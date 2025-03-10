namespace Bengkel_Yoga_UKK
{
    partial class RegisterLanjutan
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
            lblErrorPassword = new Label();
            lblErrorEmail = new Label();
            label5 = new Label();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label3 = new Label();
            label2 = new Label();
            btnRegister = new Button();
            label1 = new Label();
            txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorNama = new Label();
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label9 = new Label();
            label10 = new Label();
            textBoxExt2 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label11 = new Label();
            textBoxExt3 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBoxExt1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(textBoxExt2);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(textBoxExt3);
            panel1.Controls.Add(lblErrorPassword);
            panel1.Controls.Add(lblErrorEmail);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNama);
            panel1.Controls.Add(lblErrorNama);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(34, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(873, 453);
            panel1.TabIndex = 106;
            // 
            // lblErrorPassword
            // 
            lblErrorPassword.AutoSize = true;
            lblErrorPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorPassword.ForeColor = Color.Red;
            lblErrorPassword.Location = new Point(37, 327);
            lblErrorPassword.Name = "lblErrorPassword";
            lblErrorPassword.Size = new Size(374, 17);
            lblErrorPassword.TabIndex = 117;
            lblErrorPassword.Text = "⚠️ Password minimal 8 karakter, huruf besar, kecil, dan angka.";
            lblErrorPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorPassword.Visible = false;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(37, 237);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(173, 17);
            lblErrorEmail.TabIndex = 116;
            lblErrorEmail.Text = "⚠️ Format email tidak valid!";
            lblErrorEmail.TextAlign = ContentAlignment.MiddleRight;
            lblErrorEmail.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(37, 179);
            label5.Name = "label5";
            label5.Size = new Size(48, 21);
            label5.TabIndex = 111;
            label5.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(370, 31);
            txtEmail.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(37, 203);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = " Masukkan Email";
            txtEmail.Size = new Size(370, 31);
            txtEmail.TabIndex = 109;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(37, 269);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 106;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(37, 89);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 105;
            label2.Text = "Nama";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(74, 92, 110);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(699, 380);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(138, 36);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Save";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(3, 30);
            label1.Name = "label1";
            label1.Size = new Size(867, 37);
            label1.TabIndex = 0;
            label1.Text = "PROFILE ANDA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNama
            // 
            txtNama.BeforeTouchSize = new Size(370, 31);
            txtNama.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtNama.Location = new Point(37, 113);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = " Masukkan Nama";
            txtNama.Size = new Size(370, 31);
            txtNama.TabIndex = 0;
            // 
            // lblErrorNama
            // 
            lblErrorNama.AutoSize = true;
            lblErrorNama.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNama.ForeColor = Color.Red;
            lblErrorNama.Location = new Point(37, 147);
            lblErrorNama.Name = "lblErrorNama";
            lblErrorNama.Size = new Size(155, 17);
            lblErrorNama.TabIndex = 102;
            lblErrorNama.Text = "⚠️ Harap mengisi nama!";
            lblErrorNama.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNama.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.BeforeTouchSize = new Size(370, 31);
            txtPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(37, 293);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = " Masukkan password";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(370, 31);
            txtPassword.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(467, 327);
            label6.Name = "label6";
            label6.Size = new Size(162, 17);
            label6.TabIndex = 126;
            label6.Text = "⚠️ Harap mengisi alamat!";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(467, 237);
            label7.Name = "label7";
            label7.Size = new Size(218, 17);
            label7.TabIndex = 125;
            label7.Text = "⚠️ Nomor telepon sudah terdaftar!";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(467, 179);
            label8.Name = "label8";
            label8.Size = new Size(123, 21);
            label8.TabIndex = 124;
            label8.Text = "Nomor telepon";
            // 
            // textBoxExt1
            // 
            textBoxExt1.BeforeTouchSize = new Size(370, 31);
            textBoxExt1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxExt1.Location = new Point(467, 203);
            textBoxExt1.Name = "textBoxExt1";
            textBoxExt1.PlaceholderText = " Masukkan nomor telepon";
            textBoxExt1.Size = new Size(370, 31);
            textBoxExt1.TabIndex = 123;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(467, 269);
            label9.Name = "label9";
            label9.Size = new Size(61, 21);
            label9.TabIndex = 122;
            label9.Text = "Alamat";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(467, 89);
            label10.Name = "label10";
            label10.Size = new Size(98, 21);
            label10.TabIndex = 121;
            label10.Text = "Nomor  KTP";
            // 
            // textBoxExt2
            // 
            textBoxExt2.BeforeTouchSize = new Size(370, 31);
            textBoxExt2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxExt2.Location = new Point(467, 113);
            textBoxExt2.Name = "textBoxExt2";
            textBoxExt2.PlaceholderText = " Masukkan nomor KTP";
            textBoxExt2.Size = new Size(370, 31);
            textBoxExt2.TabIndex = 118;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(467, 147);
            label11.Name = "label11";
            label11.Size = new Size(196, 17);
            label11.TabIndex = 120;
            label11.Text = "⚠️ Nomor KTP sudah terdaftar!";
            label11.TextAlign = ContentAlignment.MiddleRight;
            label11.Visible = false;
            // 
            // textBoxExt3
            // 
            textBoxExt3.BeforeTouchSize = new Size(370, 31);
            textBoxExt3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxExt3.Location = new Point(467, 293);
            textBoxExt3.Name = "textBoxExt3";
            textBoxExt3.PlaceholderText = " Masukkan alamat lengkap";
            textBoxExt3.Size = new Size(370, 31);
            textBoxExt3.TabIndex = 119;
            // 
            // RegisterLanjutan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 514);
            Controls.Add(panel1);
            Name = "RegisterLanjutan";
            Text = "PROFILE ANDA";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNama).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt2).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblErrorPassword;
        private Label lblErrorEmail;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Label label3;
        private Label label2;
        private Button btnRegister;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Label lblErrorNama;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Label label6;
        private Label label7;
        private Label label8;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
        private Label label9;
        private Label label10;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt2;
        private Label label11;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt3;
    }
}