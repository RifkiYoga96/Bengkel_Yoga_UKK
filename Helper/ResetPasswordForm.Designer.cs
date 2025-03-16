namespace Bengkel_Yoga_UKK
{
    partial class ResetPasswordForm
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
            txtPasswordLama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnLogin = new Button();
            lblErrorOldPassword = new Label();
            panel1 = new Panel();
            label8 = new Label();
            lblErrorCPassword = new Label();
            txtKonfirmasiPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label6 = new Label();
            lblErrorNewPassword = new Label();
            txtPasswordBaru = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtPasswordLama).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKonfirmasiPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPasswordBaru).BeginInit();
            SuspendLayout();
            // 
            // txtPasswordLama
            // 
            txtPasswordLama.BeforeTouchSize = new Size(325, 31);
            txtPasswordLama.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordLama.Location = new Point(34, 54);
            txtPasswordLama.Name = "txtPasswordLama";
            txtPasswordLama.PlaceholderText = " Masukkan password lama";
            txtPasswordLama.Size = new Size(325, 31);
            txtPasswordLama.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogin.BackColor = Color.FromArgb(74, 92, 110);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(34, 329);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(325, 36);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Reset Password";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblErrorOldPassword
            // 
            lblErrorOldPassword.AutoSize = true;
            lblErrorOldPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorOldPassword.ForeColor = Color.Red;
            lblErrorOldPassword.Location = new Point(34, 88);
            lblErrorOldPassword.Name = "lblErrorOldPassword";
            lblErrorOldPassword.Size = new Size(156, 17);
            lblErrorOldPassword.TabIndex = 103;
            lblErrorOldPassword.Text = "⚠️ Password lama salah!";
            lblErrorOldPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorOldPassword.Visible = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblErrorCPassword);
            panel1.Controls.Add(txtKonfirmasiPassword);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblErrorNewPassword);
            panel1.Controls.Add(txtPasswordBaru);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblErrorOldPassword);
            panel1.Controls.Add(txtPasswordLama);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 509);
            panel1.TabIndex = 104;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(34, 213);
            label8.Name = "label8";
            label8.Size = new Size(198, 21);
            label8.TabIndex = 118;
            label8.Text = "Konfirmasi Password Baru";
            // 
            // lblErrorCPassword
            // 
            lblErrorCPassword.AutoSize = true;
            lblErrorCPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorCPassword.ForeColor = Color.Red;
            lblErrorCPassword.Location = new Point(34, 271);
            lblErrorCPassword.Name = "lblErrorCPassword";
            lblErrorCPassword.Size = new Size(188, 17);
            lblErrorCPassword.TabIndex = 117;
            lblErrorCPassword.Text = "⚠️ Konfrmasi password salah!";
            lblErrorCPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorCPassword.Visible = false;
            // 
            // txtKonfirmasiPassword
            // 
            txtKonfirmasiPassword.BeforeTouchSize = new Size(325, 31);
            txtKonfirmasiPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtKonfirmasiPassword.Location = new Point(34, 237);
            txtKonfirmasiPassword.Name = "txtKonfirmasiPassword";
            txtKonfirmasiPassword.PlaceholderText = "Konfirmasi pasword baru";
            txtKonfirmasiPassword.Size = new Size(325, 31);
            txtKonfirmasiPassword.TabIndex = 115;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(34, 121);
            label6.Name = "label6";
            label6.Size = new Size(116, 21);
            label6.TabIndex = 114;
            label6.Text = "Password Baru";
            // 
            // lblErrorNewPassword
            // 
            lblErrorNewPassword.AutoSize = true;
            lblErrorNewPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorNewPassword.ForeColor = Color.Red;
            lblErrorNewPassword.Location = new Point(34, 179);
            lblErrorNewPassword.Name = "lblErrorNewPassword";
            lblErrorNewPassword.Size = new Size(337, 17);
            lblErrorNewPassword.TabIndex = 113;
            lblErrorNewPassword.Text = "⚠️ Password baru tidak boleh sama dengan yang lama!";
            lblErrorNewPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorNewPassword.Visible = false;
            // 
            // txtPasswordBaru
            // 
            txtPasswordBaru.BeforeTouchSize = new Size(325, 31);
            txtPasswordBaru.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordBaru.Location = new Point(34, 145);
            txtPasswordBaru.Name = "txtPasswordBaru";
            txtPasswordBaru.PlaceholderText = "Masukkan password baru";
            txtPasswordBaru.Size = new Size(325, 31);
            txtPasswordBaru.TabIndex = 111;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(62, 418);
            label5.Name = "label5";
            label5.Size = new Size(267, 43);
            label5.TabIndex = 110;
            label5.Text = "Silahkan menghubungi bengkel dan jelaskan bahwa anda lupa password!";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Visible = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(262, 397);
            label4.Name = "label4";
            label4.Size = new Size(97, 17);
            label4.TabIndex = 109;
            label4.Text = "_________________";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.Visible = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(34, 397);
            label2.Name = "label2";
            label2.Size = new Size(90, 17);
            label2.TabIndex = 108;
            label2.Text = "_________________";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(129, 401);
            label1.Name = "label1";
            label1.Size = new Size(134, 17);
            label1.TabIndex = 107;
            label1.Text = "Lupa Password lama?";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(34, 30);
            label3.Name = "label3";
            label3.Size = new Size(121, 21);
            label3.TabIndex = 106;
            label3.Text = "Password Lama";
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 235, 240);
            ClientSize = new Size(423, 533);
            Controls.Add(panel1);
            Name = "ResetPasswordForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)txtPasswordLama).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKonfirmasiPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPasswordBaru).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPasswordLama;
        private Button btnLogin;
        private Label lblErrorOldPassword;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label6;
        private Label lblErrorNewPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPasswordBaru;
        private Label label8;
        private Label lblErrorCPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKonfirmasiPassword;
    }
}