namespace Bengkel_Yoga_UKK
{
    partial class ServisUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServisUC));
            btnBooking = new YogaButton();
            btnRiwayat = new YogaButton();
            SuspendLayout();
            // 
            // btnBooking
            // 
            btnBooking.Anchor = AnchorStyles.None;
            btnBooking.BackColor = Color.FromArgb(218, 37, 29);
            btnBooking.BackgroundColor = Color.FromArgb(218, 37, 29);
            btnBooking.BorderColor = Color.PaleVioletRed;
            btnBooking.BorderRadius = 20;
            btnBooking.BorderSize = 0;
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBooking.ForeColor = Color.White;
            btnBooking.Image = (Image)resources.GetObject("btnBooking.Image");
            btnBooking.Location = new Point(252, 272);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(389, 249);
            btnBooking.TabIndex = 0;
            btnBooking.Text = "Booking Servis";
            btnBooking.TextAlign = ContentAlignment.BottomCenter;
            btnBooking.TextColor = Color.White;
            btnBooking.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBooking.UseVisualStyleBackColor = false;
            // 
            // btnRiwayat
            // 
            btnRiwayat.Anchor = AnchorStyles.None;
            btnRiwayat.BackColor = Color.FromArgb(109, 110, 113);
            btnRiwayat.BackgroundColor = Color.FromArgb(109, 110, 113);
            btnRiwayat.BorderColor = Color.PaleVioletRed;
            btnRiwayat.BorderRadius = 20;
            btnRiwayat.BorderSize = 0;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRiwayat.ForeColor = Color.White;
            btnRiwayat.Image = (Image)resources.GetObject("btnRiwayat.Image");
            btnRiwayat.Location = new Point(808, 272);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(389, 249);
            btnRiwayat.TabIndex = 1;
            btnRiwayat.Text = "Riwayat Servis";
            btnRiwayat.TextAlign = ContentAlignment.BottomCenter;
            btnRiwayat.TextColor = Color.White;
            btnRiwayat.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRiwayat.UseVisualStyleBackColor = false;
            // 
            // ServisUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBooking);
            Controls.Add(btnRiwayat);
            Name = "ServisUC";
            Size = new Size(1435, 812);
            ResumeLayout(false);
        }

        #endregion

        private YogaButton btnBooking;
        private YogaButton btnRiwayat;
    }
}
