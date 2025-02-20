namespace Bengkel_Yoga_UKK
{
    partial class Login
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
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnShowPassword = new Button();
            btnLogin = new Button();
            lblErrorEmail = new Label();
            lblErrorPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(238, 31);
            txtEmail.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(12, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = " Masukkan Email";
            txtEmail.Size = new Size(238, 31);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BeforeTouchSize = new Size(238, 31);
            txtPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(12, 117);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = " Masukkan password";
            txtPassword.Size = new Size(238, 31);
            txtPassword.TabIndex = 1;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(216, 121);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(31, 23);
            btnShowPassword.TabIndex = 2;
            btnShowPassword.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 187);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(235, 34);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(12, 84);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(173, 17);
            lblErrorEmail.TabIndex = 102;
            lblErrorEmail.Text = "⚠️ Format email tidak valid!";
            lblErrorEmail.TextAlign = ContentAlignment.MiddleRight;
            lblErrorEmail.Visible = false;
            // 
            // lblErrorPassword
            // 
            lblErrorPassword.AutoSize = true;
            lblErrorPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorPassword.ForeColor = Color.Red;
            lblErrorPassword.Location = new Point(12, 151);
            lblErrorPassword.Name = "lblErrorPassword";
            lblErrorPassword.Size = new Size(174, 17);
            lblErrorPassword.TabIndex = 103;
            lblErrorPassword.Text = "⚠️ No KTP tidak ditemukan!";
            lblErrorPassword.TextAlign = ContentAlignment.MiddleRight;
            lblErrorPassword.Visible = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 282);
            Controls.Add(lblErrorPassword);
            Controls.Add(lblErrorEmail);
            Controls.Add(btnLogin);
            Controls.Add(btnShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Button btnShowPassword;
        private Button btnLogin;
        private Label lblErrorEmail;
        private Label lblErrorPassword;
    }
}