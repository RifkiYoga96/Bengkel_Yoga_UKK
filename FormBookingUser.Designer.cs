namespace Bengkel_Yoga_UKK
{
    partial class FormBookingUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBookingUser));
            label1 = new Label();
            label2 = new Label();
            txtKeluhan = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblErrorKeluhan = new Label();
            lblErrorTanggal = new Label();
            TglEditSync = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            label3 = new Label();
            yogaPanel1 = new YogaPanel();
            panelProfile = new Panel();
            lblProfile = new Label();
            lblNoPol = new Label();
            lblTipe = new Label();
            label5 = new Label();
            label6 = new Label();
            lblMerk = new Label();
            yogaPanel2 = new YogaPanel();
            btnSave = new YogaButton();
            btnCancel = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)txtKeluhan).BeginInit();
            yogaPanel1.SuspendLayout();
            panelProfile.SuspendLayout();
            yogaPanel2.SuspendLayout();
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
            label1.Size = new Size(504, 46);
            label1.TabIndex = 2;
            label1.Text = "Booking Servis";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(72, 119);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 171;
            label2.Text = "Keluhan";
            // 
            // txtKeluhan
            // 
            txtKeluhan.BeforeTouchSize = new Size(323, 106);
            txtKeluhan.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtKeluhan.Location = new Point(72, 143);
            txtKeluhan.Multiline = true;
            txtKeluhan.Name = "txtKeluhan";
            txtKeluhan.PlaceholderText = " Masukkan Keluhan Anda";
            txtKeluhan.Size = new Size(323, 106);
            txtKeluhan.TabIndex = 169;
            // 
            // lblErrorKeluhan
            // 
            lblErrorKeluhan.AutoSize = true;
            lblErrorKeluhan.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorKeluhan.ForeColor = Color.Red;
            lblErrorKeluhan.Location = new Point(72, 252);
            lblErrorKeluhan.Name = "lblErrorKeluhan";
            lblErrorKeluhan.Size = new Size(155, 17);
            lblErrorKeluhan.TabIndex = 170;
            lblErrorKeluhan.Text = "⚠️ Harap mengisi nama!";
            lblErrorKeluhan.TextAlign = ContentAlignment.MiddleRight;
            lblErrorKeluhan.Visible = false;
            // 
            // lblErrorTanggal
            // 
            lblErrorTanggal.AutoSize = true;
            lblErrorTanggal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTanggal.ForeColor = Color.Red;
            lblErrorTanggal.Location = new Point(72, 84);
            lblErrorTanggal.Name = "lblErrorTanggal";
            lblErrorTanggal.Size = new Size(268, 17);
            lblErrorTanggal.TabIndex = 173;
            lblErrorTanggal.Text = "⚠️ Antrean penuh, Mohon pilih tanggal lain!";
            lblErrorTanggal.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTanggal.Visible = false;
            // 
            // TglEditSync
            // 
            TglEditSync.DateTimeIcon = null;
            TglEditSync.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync.Format = "d MMMM yyyy";
            TglEditSync.Location = new Point(72, 48);
            TglEditSync.Name = "TglEditSync";
            TglEditSync.Size = new Size(323, 33);
            TglEditSync.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync.TabIndex = 172;
            TglEditSync.ToolTipText = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(72, 24);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 174;
            label3.Text = "Tanggal";
            // 
            // yogaPanel1
            // 
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 15;
            yogaPanel1.BorderSize = 0;
            yogaPanel1.Controls.Add(panelProfile);
            yogaPanel1.Controls.Add(lblNoPol);
            yogaPanel1.Controls.Add(lblTipe);
            yogaPanel1.Controls.Add(label5);
            yogaPanel1.Controls.Add(label6);
            yogaPanel1.Controls.Add(lblMerk);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(18, 63);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(467, 124);
            yogaPanel1.TabIndex = 175;
            // 
            // panelProfile
            // 
            panelProfile.BackgroundImage = (Image)resources.GetObject("panelProfile.BackgroundImage");
            panelProfile.BackgroundImageLayout = ImageLayout.Zoom;
            panelProfile.Controls.Add(lblProfile);
            panelProfile.Location = new Point(34, 16);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(78, 78);
            panelProfile.TabIndex = 138;
            // 
            // lblProfile
            // 
            lblProfile.BackColor = Color.Transparent;
            lblProfile.Font = new Font("Microsoft New Tai Lue", 36.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblProfile.ForeColor = Color.White;
            lblProfile.Location = new Point(17, 11);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(50, 54);
            lblProfile.TabIndex = 10;
            lblProfile.Text = "H";
            lblProfile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNoPol
            // 
            lblNoPol.AutoSize = true;
            lblNoPol.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNoPol.ForeColor = SystemColors.ControlText;
            lblNoPol.Location = new Point(195, 71);
            lblNoPol.Name = "lblNoPol";
            lblNoPol.Size = new Size(84, 23);
            lblNoPol.TabIndex = 137;
            lblNoPol.Text = "AB 123 FS";
            // 
            // lblTipe
            // 
            lblTipe.AutoEllipsis = true;
            lblTipe.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipe.ForeColor = SystemColors.ControlText;
            lblTipe.Location = new Point(176, 43);
            lblTipe.Name = "lblTipe";
            lblTipe.Size = new Size(288, 23);
            lblTipe.TabIndex = 136;
            lblTipe.Text = "Honda Vario LED 125cc (2016)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(128, 71);
            label5.Name = "label5";
            label5.Size = new Size(61, 23);
            label5.TabIndex = 135;
            label5.Text = "No Pol";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(128, 43);
            label6.Name = "label6";
            label6.Size = new Size(42, 23);
            label6.TabIndex = 134;
            label6.Text = "Tipe";
            // 
            // lblMerk
            // 
            lblMerk.AutoSize = true;
            lblMerk.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMerk.ForeColor = SystemColors.ControlText;
            lblMerk.Location = new Point(128, 16);
            lblMerk.Name = "lblMerk";
            lblMerk.Size = new Size(62, 23);
            lblMerk.TabIndex = 133;
            lblMerk.Text = "Honda";
            // 
            // yogaPanel2
            // 
            yogaPanel2.BackColor = Color.White;
            yogaPanel2.BorderColor = Color.PaleVioletRed;
            yogaPanel2.BorderRadius = 15;
            yogaPanel2.BorderSize = 0;
            yogaPanel2.Controls.Add(TglEditSync);
            yogaPanel2.Controls.Add(lblErrorTanggal);
            yogaPanel2.Controls.Add(label2);
            yogaPanel2.Controls.Add(lblErrorKeluhan);
            yogaPanel2.Controls.Add(label3);
            yogaPanel2.Controls.Add(txtKeluhan);
            yogaPanel2.ForeColor = Color.White;
            yogaPanel2.Location = new Point(18, 206);
            yogaPanel2.Name = "yogaPanel2";
            yogaPanel2.Size = new Size(467, 296);
            yogaPanel2.TabIndex = 176;
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
            btnSave.Location = new Point(335, 516);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 182;
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
            btnCancel.Location = new Point(175, 516);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 183;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormBookingUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 235, 240);
            ClientSize = new Size(504, 571);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(yogaPanel2);
            Controls.Add(yogaPanel1);
            Controls.Add(label1);
            Name = "FormBookingUser";
            Text = "FormBookingUser";
            ((System.ComponentModel.ISupportInitialize)txtKeluhan).EndInit();
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            panelProfile.ResumeLayout(false);
            yogaPanel2.ResumeLayout(false);
            yogaPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKeluhan;
        private Label lblErrorKeluhan;
        private Label lblErrorTanggal;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync;
        private Label label3;
        private YogaPanel yogaPanel1;
        private Panel panelProfile;
        private Label lblProfile;
        private Label lblNoPol;
        private Label lblTipe;
        private Label label5;
        private Label label6;
        private Label lblMerk;
        private YogaPanel yogaPanel2;
        private YogaButton btnSave;
        private YogaButton btnCancel;
    }
}