namespace Bengkel_Yoga_UKK
{
    partial class ucKalender
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnBooking1 = new YogaButton();
            btnCountNotif = new YogaButton();
            btnBooking2 = new YogaButton();
            btnBooking3 = new YogaButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(128, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 25);
            label1.TabIndex = 2;
            label1.Text = "12";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBooking1
            // 
            btnBooking1.BackColor = Color.MediumSlateBlue;
            btnBooking1.BackgroundColor = Color.MediumSlateBlue;
            btnBooking1.BorderColor = Color.PaleVioletRed;
            btnBooking1.BorderRadius = 3;
            btnBooking1.BorderSize = 0;
            btnBooking1.FlatAppearance.BorderSize = 0;
            btnBooking1.FlatStyle = FlatStyle.Flat;
            btnBooking1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBooking1.ForeColor = Color.White;
            btnBooking1.Location = new Point(3, 37);
            btnBooking1.Margin = new Padding(0);
            btnBooking1.Name = "btnBooking1";
            btnBooking1.Size = new Size(163, 28);
            btnBooking1.TabIndex = 3;
            btnBooking1.Text = "Nama Pelanggan";
            btnBooking1.TextColor = Color.White;
            btnBooking1.UseVisualStyleBackColor = false;
            btnBooking1.Visible = false;
            // 
            // btnCountNotif
            // 
            btnCountNotif.BackColor = Color.Coral;
            btnCountNotif.BackgroundColor = Color.Coral;
            btnCountNotif.BorderColor = Color.PaleVioletRed;
            btnCountNotif.BorderRadius = 3;
            btnCountNotif.BorderSize = 0;
            btnCountNotif.FlatAppearance.BorderSize = 0;
            btnCountNotif.FlatStyle = FlatStyle.Flat;
            btnCountNotif.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCountNotif.ForeColor = Color.White;
            btnCountNotif.Location = new Point(134, 92);
            btnCountNotif.Margin = new Padding(0);
            btnCountNotif.Name = "btnCountNotif";
            btnCountNotif.Size = new Size(35, 35);
            btnCountNotif.TabIndex = 7;
            btnCountNotif.Text = "9+";
            btnCountNotif.TextColor = Color.White;
            btnCountNotif.UseVisualStyleBackColor = false;
            btnCountNotif.Visible = false;
            // 
            // btnBooking2
            // 
            btnBooking2.BackColor = Color.FromArgb(0, 192, 0);
            btnBooking2.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnBooking2.BorderColor = Color.PaleVioletRed;
            btnBooking2.BorderRadius = 3;
            btnBooking2.BorderSize = 0;
            btnBooking2.FlatAppearance.BorderSize = 0;
            btnBooking2.FlatStyle = FlatStyle.Flat;
            btnBooking2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBooking2.ForeColor = Color.White;
            btnBooking2.Location = new Point(3, 65);
            btnBooking2.Margin = new Padding(0);
            btnBooking2.Name = "btnBooking2";
            btnBooking2.Size = new Size(163, 28);
            btnBooking2.TabIndex = 8;
            btnBooking2.Text = "Nama Pelanggan";
            btnBooking2.TextColor = Color.White;
            btnBooking2.UseVisualStyleBackColor = false;
            btnBooking2.Visible = false;
            // 
            // btnBooking3
            // 
            btnBooking3.BackColor = Color.MediumSlateBlue;
            btnBooking3.BackgroundColor = Color.MediumSlateBlue;
            btnBooking3.BorderColor = Color.PaleVioletRed;
            btnBooking3.BorderRadius = 3;
            btnBooking3.BorderSize = 0;
            btnBooking3.FlatAppearance.BorderSize = 0;
            btnBooking3.FlatStyle = FlatStyle.Flat;
            btnBooking3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBooking3.ForeColor = Color.White;
            btnBooking3.Location = new Point(3, 93);
            btnBooking3.Margin = new Padding(0);
            btnBooking3.Name = "btnBooking3";
            btnBooking3.Size = new Size(163, 28);
            btnBooking3.TabIndex = 9;
            btnBooking3.Text = "Nama Pelanggan";
            btnBooking3.TextColor = Color.White;
            btnBooking3.UseVisualStyleBackColor = false;
            btnBooking3.Visible = false;
            // 
            // ucKalender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCountNotif);
            Controls.Add(btnBooking3);
            Controls.Add(btnBooking2);
            Controls.Add(btnBooking1);
            Controls.Add(label1);
            Name = "ucKalender";
            Size = new Size(169, 127);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private YogaButton btnBooking1;
        private YogaButton btnCountNotif;
        private YogaButton btnBooking2;
        private YogaButton btnBooking3;
    }
}
