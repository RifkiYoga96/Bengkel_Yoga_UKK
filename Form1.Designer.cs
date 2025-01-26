namespace Bengkel_Yoga_UKK
{
    partial class Dashboardd
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboardd));
            panelTop = new Panel();
            btnMin = new Button();
            btnMax = new Button();
            btnClose = new Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(26, 124, 151);
            panelTop.Controls.Add(btnMin);
            panelTop.Controls.Add(btnMax);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(855, 39);
            panelTop.TabIndex = 10;
            // 
            // btnMin
            // 
            btnMin.BackgroundImageLayout = ImageLayout.Zoom;
            btnMin.Dock = DockStyle.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMin.Image = (Image)resources.GetObject("btnMin.Image");
            btnMin.Location = new Point(690, 0);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(55, 39);
            btnMin.TabIndex = 15;
            btnMin.UseVisualStyleBackColor = true;
            // 
            // btnMax
            // 
            btnMax.BackgroundImageLayout = ImageLayout.Zoom;
            btnMax.Dock = DockStyle.Right;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMax.Image = (Image)resources.GetObject("btnMax.Image");
            btnMax.Location = new Point(745, 0);
            btnMax.Name = "btnMax";
            btnMax.Size = new Size(55, 39);
            btnMax.TabIndex = 14;
            btnMax.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.BackgroundImageLayout = ImageLayout.Zoom;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnClose.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(800, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(55, 39);
            btnClose.TabIndex = 13;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // Dashboardd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 479);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboardd";
            Text = "Dashboard";
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnMin;
        private Button btnMax;
        private Button btnClose;
    }
}
