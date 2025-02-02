namespace Bengkel_Yoga_UKK
{
    partial class ucCalendar
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
            yogaButton1 = new YogaButton();
            yogaButton2 = new YogaButton();
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
            // 
            // btnCountNotif
            // 
            btnCountNotif.BackColor = Color.FromArgb(0, 192, 0);
            btnCountNotif.BackgroundColor = Color.FromArgb(0, 192, 0);
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
            // yogaButton1
            // 
            yogaButton1.BackColor = Color.MediumSlateBlue;
            yogaButton1.BackgroundColor = Color.MediumSlateBlue;
            yogaButton1.BorderColor = Color.PaleVioletRed;
            yogaButton1.BorderRadius = 3;
            yogaButton1.BorderSize = 0;
            yogaButton1.FlatAppearance.BorderSize = 0;
            yogaButton1.FlatStyle = FlatStyle.Flat;
            yogaButton1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            yogaButton1.ForeColor = Color.White;
            yogaButton1.Location = new Point(3, 65);
            yogaButton1.Margin = new Padding(0);
            yogaButton1.Name = "yogaButton1";
            yogaButton1.Size = new Size(163, 28);
            yogaButton1.TabIndex = 8;
            yogaButton1.Text = "Nama Pelanggan";
            yogaButton1.TextColor = Color.White;
            yogaButton1.UseVisualStyleBackColor = false;
            yogaButton1.Visible = false;
            // 
            // yogaButton2
            // 
            yogaButton2.BackColor = Color.MediumSlateBlue;
            yogaButton2.BackgroundColor = Color.MediumSlateBlue;
            yogaButton2.BorderColor = Color.PaleVioletRed;
            yogaButton2.BorderRadius = 3;
            yogaButton2.BorderSize = 0;
            yogaButton2.FlatAppearance.BorderSize = 0;
            yogaButton2.FlatStyle = FlatStyle.Flat;
            yogaButton2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            yogaButton2.ForeColor = Color.White;
            yogaButton2.Location = new Point(3, 93);
            yogaButton2.Margin = new Padding(0);
            yogaButton2.Name = "yogaButton2";
            yogaButton2.Size = new Size(163, 28);
            yogaButton2.TabIndex = 9;
            yogaButton2.Text = "Nama Pelanggan";
            yogaButton2.TextColor = Color.White;
            yogaButton2.UseVisualStyleBackColor = false;
            yogaButton2.Visible = false;
            // 
            // ucCalendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCountNotif);
            Controls.Add(yogaButton2);
            Controls.Add(yogaButton1);
            Controls.Add(btnBooking1);
            Controls.Add(label1);
            Name = "ucCalendar";
            Size = new Size(169, 127);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private YogaButton btnBooking1;
        private YogaButton btnCountNotif;
        private YogaButton yogaButton1;
        private YogaButton yogaButton2;
    }
}
