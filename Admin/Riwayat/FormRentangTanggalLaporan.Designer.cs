namespace Bengkel_Yoga_UKK
{
    partial class FormRentangTanggalLaporan
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
            TglEditSync1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            lblErrorTanggal = new Label();
            label3 = new Label();
            TglEditSync2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            label1 = new Label();
            label2 = new Label();
            btnCancel = new YogaButton();
            btnSave = new YogaButton();
            yogaPanel1 = new YogaPanel();
            lblHeader = new Label();
            yogaPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TglEditSync1
            // 
            TglEditSync1.DateTimeIcon = null;
            TglEditSync1.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync1.Format = "d MMMM yyyy";
            TglEditSync1.Location = new Point(22, 101);
            TglEditSync1.Name = "TglEditSync1";
            TglEditSync1.Size = new Size(288, 28);
            TglEditSync1.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync1.TabIndex = 175;
            TglEditSync1.ToolTipText = "";
            // 
            // lblErrorTanggal
            // 
            lblErrorTanggal.AutoSize = true;
            lblErrorTanggal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTanggal.ForeColor = Color.Red;
            lblErrorTanggal.Location = new Point(22, 137);
            lblErrorTanggal.Name = "lblErrorTanggal";
            lblErrorTanggal.Size = new Size(268, 17);
            lblErrorTanggal.TabIndex = 176;
            lblErrorTanggal.Text = "⚠️ Antrean penuh, Mohon pilih tanggal lain!";
            lblErrorTanggal.TextAlign = ContentAlignment.MiddleRight;
            lblErrorTanggal.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(22, 77);
            label3.Name = "label3";
            label3.Size = new Size(99, 21);
            label3.TabIndex = 177;
            label3.Text = "Dari Tanggal";
            // 
            // TglEditSync2
            // 
            TglEditSync2.DateTimeIcon = null;
            TglEditSync2.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync2.Format = "d MMMM yyyy";
            TglEditSync2.Location = new Point(22, 209);
            TglEditSync2.Name = "TglEditSync2";
            TglEditSync2.Size = new Size(288, 28);
            TglEditSync2.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync2.TabIndex = 178;
            TglEditSync2.ToolTipText = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(22, 245);
            label1.Name = "label1";
            label1.Size = new Size(268, 17);
            label1.TabIndex = 179;
            label1.Text = "⚠️ Antrean penuh, Mohon pilih tanggal lain!";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(22, 185);
            label2.Name = "label2";
            label2.Size = new Size(123, 21);
            label2.TabIndex = 180;
            label2.Text = "Sampai Tanggal";
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
            btnCancel.Location = new Point(46, 338);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(128, 36);
            btnCancel.TabIndex = 185;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
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
            btnSave.Location = new Point(180, 338);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 36);
            btnSave.TabIndex = 184;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // yogaPanel1
            // 
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 10;
            yogaPanel1.BorderSize = 2;
            yogaPanel1.Controls.Add(lblHeader);
            yogaPanel1.Controls.Add(TglEditSync1);
            yogaPanel1.Controls.Add(btnCancel);
            yogaPanel1.Controls.Add(label3);
            yogaPanel1.Controls.Add(btnSave);
            yogaPanel1.Controls.Add(lblErrorTanggal);
            yogaPanel1.Controls.Add(TglEditSync2);
            yogaPanel1.Controls.Add(label2);
            yogaPanel1.Controls.Add(label1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(12, 12);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(332, 403);
            yogaPanel1.TabIndex = 186;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, -3);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(334, 51);
            lblHeader.TabIndex = 186;
            lblHeader.Text = "Download Laporan";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRentangTanggalLaporan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 428);
            Controls.Add(yogaPanel1);
            Name = "FormRentangTanggalLaporan";
            Text = "FormRentangTanggalLaporan";
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync1;
        private Label lblErrorTanggal;
        private Label label3;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync2;
        private Label label1;
        private Label label2;
        private YogaButton btnCancel;
        private YogaButton btnSave;
        private YogaPanel yogaPanel1;
        private Label lblHeader;
    }
}