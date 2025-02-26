namespace Bengkel_Yoga_UKK
{
    partial class FormJadwal
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
            components = new System.ComponentModel.Container();
            TglEditSync = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            btnSave = new YogaButton();
            btnNew = new YogaButton();
            dataGridView1 = new DataGridView();
            btnClose = new YogaButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            btnTanggal = new YogaButton();
            btnHarian = new YogaButton();
            comboHari = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TglEditSync
            // 
            TglEditSync.DateTimeIcon = null;
            TglEditSync.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync.Format = "d MMMM yyyy";
            TglEditSync.Location = new Point(12, 94);
            TglEditSync.Name = "TglEditSync";
            TglEditSync.Size = new Size(193, 28);
            TglEditSync.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync.TabIndex = 115;
            TglEditSync.ToolTipText = "";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 3;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(333, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 31);
            btnSave.TabIndex = 119;
            btnSave.Text = "✔ Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(230, 126, 34);
            btnNew.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnNew.BorderColor = Color.PaleVioletRed;
            btnNew.BorderRadius = 3;
            btnNew.BorderSize = 0;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(229, 161);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(98, 31);
            btnNew.TabIndex = 120;
            btnNew.Text = "➕ Baru";
            btnNew.TextColor = Color.White;
            btnNew.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 211);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(419, 155);
            dataGridView1.TabIndex = 121;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.Control;
            btnClose.BackgroundColor = SystemColors.Control;
            btnClose.BorderColor = Color.PaleVioletRed;
            btnClose.BorderRadius = 3;
            btnClose.BorderSize = 2;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.ControlDarkDark;
            btnClose.Location = new Point(321, 377);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 122;
            btnClose.Text = "❌ Close";
            btnClose.TextColor = SystemColors.ControlDarkDark;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(129, 32);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Padding = new Padding(0, 2, 0, 2);
            deleteToolStripMenuItem.Size = new Size(128, 28);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // btnTanggal
            // 
            btnTanggal.BackColor = Color.FromArgb(128, 128, 255);
            btnTanggal.BackgroundColor = Color.FromArgb(128, 128, 255);
            btnTanggal.BorderColor = Color.PaleVioletRed;
            btnTanggal.BorderRadius = 20;
            btnTanggal.BorderSize = 0;
            btnTanggal.FlatAppearance.BorderSize = 0;
            btnTanggal.FlatStyle = FlatStyle.Flat;
            btnTanggal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTanggal.ForeColor = Color.White;
            btnTanggal.Location = new Point(12, 28);
            btnTanggal.Name = "btnTanggal";
            btnTanggal.Size = new Size(193, 40);
            btnTanggal.TabIndex = 123;
            btnTanggal.Text = "Tanggal";
            btnTanggal.TextColor = Color.White;
            btnTanggal.UseVisualStyleBackColor = false;
            // 
            // btnHarian
            // 
            btnHarian.BackColor = Color.Gainsboro;
            btnHarian.BackgroundColor = Color.Gainsboro;
            btnHarian.BorderColor = Color.PaleVioletRed;
            btnHarian.BorderRadius = 20;
            btnHarian.BorderSize = 0;
            btnHarian.FlatAppearance.BorderSize = 0;
            btnHarian.FlatStyle = FlatStyle.Flat;
            btnHarian.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnHarian.ForeColor = SystemColors.ControlDarkDark;
            btnHarian.Location = new Point(238, 28);
            btnHarian.Name = "btnHarian";
            btnHarian.Size = new Size(193, 40);
            btnHarian.TabIndex = 124;
            btnHarian.Text = "Harian";
            btnHarian.TextColor = SystemColors.ControlDarkDark;
            btnHarian.UseVisualStyleBackColor = false;
            // 
            // comboHari
            // 
            comboHari.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboHari.FormattingEnabled = true;
            comboHari.Location = new Point(238, 94);
            comboHari.Name = "comboHari";
            comboHari.Size = new Size(193, 28);
            comboHari.TabIndex = 125;
            // 
            // FormJadwal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 427);
            Controls.Add(comboHari);
            Controls.Add(btnHarian);
            Controls.Add(btnTanggal);
            Controls.Add(btnClose);
            Controls.Add(dataGridView1);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(TglEditSync);
            Name = "FormJadwal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Jadwal Libur";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync;
        private YogaButton btnSave;
        private YogaButton btnNew;
        private DataGridView dataGridView1;
        private YogaButton btnClose;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private YogaButton btnTanggal;
        private YogaButton btnHarian;
        private ComboBox comboHari;
    }
}