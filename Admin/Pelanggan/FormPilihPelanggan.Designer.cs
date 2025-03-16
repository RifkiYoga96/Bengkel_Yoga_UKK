namespace Bengkel_Yoga_UKK
{
    partial class FormPilihPelanggan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPilihPelanggan));
            dataGridView1 = new DataGridView();
            txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSearch = new YogaButton();
            label3 = new Label();
            label1 = new Label();
            numericEntries = new NumericUpDown();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnPilih = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEntries).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(535, 254);
            dataGridView1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BeforeTouchSize = new Size(219, 26);
            txtSearch.BorderColor = Color.FromArgb(209, 211, 212);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.ForeColor = SystemColors.ControlText;
            txtSearch.Location = new Point(12, 12);
            txtSearch.Metrocolor = SystemColors.ControlDarkDark;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " Cari Pelanggan";
            txtSearch.Size = new Size(219, 26);
            txtSearch.TabIndex = 50;
            txtSearch.ThemeName = "Default";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(230, 126, 34);
            btnSearch.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnSearch.BorderColor = Color.PaleVioletRed;
            btnSearch.BorderRadius = 3;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(237, 11);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(47, 27);
            btnSearch.TabIndex = 83;
            btnSearch.TextColor = Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(127, 318);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 86;
            label3.Text = "entries";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(11, 318);
            label1.Name = "label1";
            label1.Size = new Size(44, 19);
            label1.TabIndex = 85;
            label1.Text = "Show";
            // 
            // numericEntries
            // 
            numericEntries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEntries.BackColor = Color.White;
            numericEntries.BorderStyle = BorderStyle.FixedSingle;
            numericEntries.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            numericEntries.Location = new Point(61, 315);
            numericEntries.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericEntries.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericEntries.Name = "numericEntries";
            numericEntries.Size = new Size(64, 26);
            numericEntries.TabIndex = 84;
            numericEntries.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnPilih
            // 
            btnPilih.BackColor = Color.FromArgb(0, 192, 0);
            btnPilih.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnPilih.BorderColor = Color.PaleVioletRed;
            btnPilih.BorderRadius = 3;
            btnPilih.BorderSize = 0;
            btnPilih.FlatAppearance.BorderSize = 0;
            btnPilih.FlatStyle = FlatStyle.Flat;
            btnPilih.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnPilih.ForeColor = Color.White;
            btnPilih.Image = Properties.Resources.plusPutih;
            btnPilih.Location = new Point(456, 314);
            btnPilih.Name = "btnPilih";
            btnPilih.Size = new Size(91, 29);
            btnPilih.TabIndex = 87;
            btnPilih.Text = " Pilih";
            btnPilih.TextColor = Color.White;
            btnPilih.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPilih.UseVisualStyleBackColor = false;
            // 
            // FormPilihPelanggan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(559, 357);
            Controls.Add(btnPilih);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(numericEntries);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Name = "FormPilihPelanggan";
            Text = "Cari Pelanggan";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private YogaButton btnSearch;
        private Label label3;
        private Label label1;
        private NumericUpDown numericEntries;
        private FolderBrowserDialog folderBrowserDialog1;
        private YogaButton btnPilih;
    }
}