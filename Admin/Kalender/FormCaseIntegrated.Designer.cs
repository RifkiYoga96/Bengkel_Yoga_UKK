namespace Bengkel_Yoga_UKK
{
    partial class FormCaseIntegrated
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
            btnRiwayat = new Button();
            lblTanggal = new Label();
            btnBooking = new Button();
            SuspendLayout();
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Gray;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnRiwayat.ForeColor = Color.White;
            btnRiwayat.Location = new Point(200, 61);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(150, 105);
            btnRiwayat.TabIndex = 0;
            btnRiwayat.Text = "Pesanan\r\nSelesai/Batal";
            btnRiwayat.UseVisualStyleBackColor = false;
            // 
            // lblTanggal
            // 
            lblTanggal.Dock = DockStyle.Top;
            lblTanggal.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTanggal.Location = new Point(0, 0);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(376, 43);
            lblTanggal.TabIndex = 1;
            lblTanggal.Text = "8 Februari 2025";
            lblTanggal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.FromArgb(31, 133, 235);
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnBooking.ForeColor = Color.White;
            btnBooking.Location = new Point(24, 61);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(150, 105);
            btnBooking.TabIndex = 2;
            btnBooking.Text = "Pesanan\r\nPending";
            btnBooking.UseVisualStyleBackColor = false;
            // 
            // FormCaseIntegrated
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 189);
            Controls.Add(btnBooking);
            Controls.Add(lblTanggal);
            Controls.Add(btnRiwayat);
            Name = "FormCaseIntegrated";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormCaseIntegrated";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRiwayat;
        private Label lblTanggal;
        private Button btnBooking;
    }
}