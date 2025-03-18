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
            SuspendLayout();
            // 
            // TglEditSync1
            // 
            TglEditSync1.DateTimeIcon = null;
            TglEditSync1.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync1.Format = "d MMMM yyyy";
            TglEditSync1.Location = new Point(24, 70);
            TglEditSync1.Name = "TglEditSync1";
            TglEditSync1.Size = new Size(323, 33);
            TglEditSync1.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync1.TabIndex = 175;
            TglEditSync1.ToolTipText = "";
            // 
            // lblErrorTanggal
            // 
            lblErrorTanggal.AutoSize = true;
            lblErrorTanggal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorTanggal.ForeColor = Color.Red;
            lblErrorTanggal.Location = new Point(24, 106);
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
            label3.Location = new Point(24, 46);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 177;
            label3.Text = "Tanggal";
            // 
            // TglEditSync2
            // 
            TglEditSync2.DateTimeIcon = null;
            TglEditSync2.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync2.Format = "d MMMM yyyy";
            TglEditSync2.Location = new Point(24, 178);
            TglEditSync2.Name = "TglEditSync2";
            TglEditSync2.Size = new Size(323, 33);
            TglEditSync2.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync2.TabIndex = 178;
            TglEditSync2.ToolTipText = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(24, 214);
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
            label2.Location = new Point(24, 154);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 180;
            label2.Text = "Tanggal";
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
            btnCancel.Location = new Point(37, 355);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
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
            btnSave.Location = new Point(197, 355);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 184;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // FormRentangTanggalLaporan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(TglEditSync2);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(TglEditSync1);
            Controls.Add(lblErrorTanggal);
            Controls.Add(label3);
            Name = "FormRentangTanggalLaporan";
            Text = "FormRentangTanggalLaporan";
            ResumeLayout(false);
            PerformLayout();
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
    }
}