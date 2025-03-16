namespace Bengkel_Yoga_UKK
{
    partial class TambahKendaraanUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TambahKendaraanUC));
            btnTambah = new YogaButton();
            SuspendLayout();
            // 
            // btnTambah
            // 
            btnTambah.Anchor = AnchorStyles.None;
            btnTambah.BackColor = Color.FromArgb(52, 152, 219);
            btnTambah.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnTambah.BorderColor = Color.PaleVioletRed;
            btnTambah.BorderRadius = 10;
            btnTambah.BorderSize = 0;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnTambah.ForeColor = Color.White;
            btnTambah.Image = (Image)resources.GetObject("btnTambah.Image");
            btnTambah.ImageAlign = ContentAlignment.MiddleRight;
            btnTambah.Location = new Point(195, 28);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(1035, 83);
            btnTambah.TabIndex = 1;
            btnTambah.Text = "   Tambah Kendaraan";
            btnTambah.TextColor = Color.White;
            btnTambah.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTambah.UseVisualStyleBackColor = false;
            // 
            // TambahKendaraanUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnTambah);
            Margin = new Padding(0);
            Name = "TambahKendaraanUC";
            Size = new Size(1430, 121);
            ResumeLayout(false);
        }

        #endregion
        private YogaButton btnTambah;
    }
}
