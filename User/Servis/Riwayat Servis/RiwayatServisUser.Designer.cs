namespace Bengkel_Yoga_UKK
{
    partial class RiwayatServisUser
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
            yogaPanel1 = new YogaPanel();
            SuspendLayout();
            // 
            // yogaPanel1
            // 
            yogaPanel1.BackColor = Color.MediumSlateBlue;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 10;
            yogaPanel1.BorderSize = 2;
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(93, 106);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(988, 583);
            yogaPanel1.TabIndex = 0;
            // 
            // RiwayatServisUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(yogaPanel1);
            Name = "RiwayatServisUser";
            Size = new Size(1195, 751);
            ResumeLayout(false);
        }

        #endregion

        private YogaPanel yogaPanel1;
    }
}
