namespace Bengkel_Yoga_UKK
{
    partial class Image2
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
            pictureBoxProfile = new RJCircularPictureBox();
            btnEditImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxProfile.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            pictureBoxProfile.BorderColor = Color.RoyalBlue;
            pictureBoxProfile.BorderColor2 = Color.HotPink;
            pictureBoxProfile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pictureBoxProfile.BorderSize = 2;
            pictureBoxProfile.GradientAngle = 50F;
            pictureBoxProfile.Location = new Point(283, 12);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(122, 122);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // btnEditImage
            // 
            btnEditImage.Location = new Point(306, 140);
            btnEditImage.Name = "btnEditImage";
            btnEditImage.Size = new Size(75, 23);
            btnEditImage.TabIndex = 1;
            btnEditImage.Text = "Upload Image";
            btnEditImage.UseVisualStyleBackColor = true;
            // 
            // Image2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 450);
            Controls.Add(btnEditImage);
            Controls.Add(pictureBoxProfile);
            Name = "Image2";
            Text = "Image2";
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RJCircularPictureBox pictureBoxProfile;
        private Button btnEditImage;
    }
}