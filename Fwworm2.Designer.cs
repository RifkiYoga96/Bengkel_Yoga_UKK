namespace Bengkel_Yoga_UKK
{
    partial class Fwworm2
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
            tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            lblMode = new Label();
            comboHari = new ComboBox();
            btnHarian = new YogaButton();
            btnTanggal = new YogaButton();
            btnClose = new YogaButton();
            dataGridView1 = new DataGridView();
            btnNew = new YogaButton();
            btnSave = new YogaButton();
            TglEditSync = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).BeginInit();
            tabControlAdv1.SuspendLayout();
            tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControlAdv1
            // 
            tabControlAdv1.ActiveTabFont = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControlAdv1.BeforeTouchSize = new Size(444, 472);
            tabControlAdv1.Controls.Add(tabPageAdv2);
            tabControlAdv1.Controls.Add(tabPageAdv1);
            tabControlAdv1.Dock = DockStyle.Fill;
            tabControlAdv1.FocusOnTabClick = false;
            tabControlAdv1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabControlAdv1.Location = new Point(0, 0);
            tabControlAdv1.Name = "tabControlAdv1";
            tabControlAdv1.Padding = new Point(10, 7);
            tabControlAdv1.Size = new Size(444, 472);
            tabControlAdv1.TabIndex = 0;
            tabControlAdv1.TabPanelBackColor = Color.LightGray;
            tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererDockingWhidbey);
            tabControlAdv1.ThemeName = "TabRendererDockingWhidbey";
            tabControlAdv1.ThemeStyle.TabStyle.InactiveFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            // 
            // tabPageAdv2
            // 
            tabPageAdv2.BackColor = Color.White;
            tabPageAdv2.Image = null;
            tabPageAdv2.ImageSize = new Size(16, 16);
            tabPageAdv2.Location = new Point(1, 42);
            tabPageAdv2.Name = "tabPageAdv2";
            tabPageAdv2.ShowCloseButton = true;
            tabPageAdv2.Size = new Size(441, 443);
            tabPageAdv2.TabFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tabPageAdv2.TabIndex = 2;
            tabPageAdv2.Text = "Jadwal Operasional";
            tabPageAdv2.ThemesEnabled = false;
            // 
            // tabPageAdv1
            // 
            tabPageAdv1.BackColor = Color.White;
            tabPageAdv1.Controls.Add(lblMode);
            tabPageAdv1.Controls.Add(comboHari);
            tabPageAdv1.Controls.Add(btnHarian);
            tabPageAdv1.Controls.Add(btnTanggal);
            tabPageAdv1.Controls.Add(btnClose);
            tabPageAdv1.Controls.Add(dataGridView1);
            tabPageAdv1.Controls.Add(btnNew);
            tabPageAdv1.Controls.Add(btnSave);
            tabPageAdv1.Controls.Add(TglEditSync);
            tabPageAdv1.Image = null;
            tabPageAdv1.ImageSize = new Size(16, 16);
            tabPageAdv1.Location = new Point(1, 42);
            tabPageAdv1.Name = "tabPageAdv1";
            tabPageAdv1.Padding = new Padding(15);
            tabPageAdv1.ShowCloseButton = true;
            tabPageAdv1.Size = new Size(441, 428);
            tabPageAdv1.TabFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tabPageAdv1.TabIndex = 1;
            tabPageAdv1.Text = "Jadwal Libur";
            tabPageAdv1.ThemesEnabled = false;
            // 
            // lblMode
            // 
            lblMode.Anchor = AnchorStyles.Top;
            lblMode.AutoSize = true;
            lblMode.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblMode.Location = new Point(11, 165);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(117, 21);
            lblMode.TabIndex = 145;
            lblMode.Text = "Mode : Normal";
            // 
            // comboHari
            // 
            comboHari.Anchor = AnchorStyles.Top;
            comboHari.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboHari.FormattingEnabled = true;
            comboHari.Location = new Point(237, 94);
            comboHari.Name = "comboHari";
            comboHari.Size = new Size(193, 28);
            comboHari.TabIndex = 144;
            // 
            // btnHarian
            // 
            btnHarian.Anchor = AnchorStyles.Top;
            btnHarian.BackColor = Color.Gainsboro;
            btnHarian.BackgroundColor = Color.Gainsboro;
            btnHarian.BorderColor = Color.PaleVioletRed;
            btnHarian.BorderRadius = 20;
            btnHarian.BorderSize = 0;
            btnHarian.FlatAppearance.BorderSize = 0;
            btnHarian.FlatStyle = FlatStyle.Flat;
            btnHarian.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnHarian.ForeColor = SystemColors.ControlDarkDark;
            btnHarian.Location = new Point(237, 28);
            btnHarian.Name = "btnHarian";
            btnHarian.Size = new Size(193, 40);
            btnHarian.TabIndex = 143;
            btnHarian.Text = "Harian";
            btnHarian.TextColor = SystemColors.ControlDarkDark;
            btnHarian.UseVisualStyleBackColor = false;
            // 
            // btnTanggal
            // 
            btnTanggal.Anchor = AnchorStyles.Top;
            btnTanggal.BackColor = Color.FromArgb(128, 128, 255);
            btnTanggal.BackgroundColor = Color.FromArgb(128, 128, 255);
            btnTanggal.BorderColor = Color.PaleVioletRed;
            btnTanggal.BorderRadius = 20;
            btnTanggal.BorderSize = 0;
            btnTanggal.FlatAppearance.BorderSize = 0;
            btnTanggal.FlatStyle = FlatStyle.Flat;
            btnTanggal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTanggal.ForeColor = Color.White;
            btnTanggal.Location = new Point(11, 28);
            btnTanggal.Name = "btnTanggal";
            btnTanggal.Size = new Size(193, 40);
            btnTanggal.TabIndex = 142;
            btnTanggal.Text = "Tanggal";
            btnTanggal.TextColor = Color.White;
            btnTanggal.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = SystemColors.Control;
            btnClose.BackgroundColor = SystemColors.Control;
            btnClose.BorderColor = Color.PaleVioletRed;
            btnClose.BorderRadius = 3;
            btnClose.BorderSize = 2;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.ControlDarkDark;
            btnClose.Location = new Point(320, 377);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 141;
            btnClose.Text = "❌ Close";
            btnClose.TextColor = SystemColors.ControlDarkDark;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 211);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(419, 155);
            dataGridView1.TabIndex = 140;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top;
            btnNew.BackColor = Color.FromArgb(230, 126, 34);
            btnNew.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnNew.BorderColor = Color.PaleVioletRed;
            btnNew.BorderRadius = 3;
            btnNew.BorderSize = 0;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(228, 161);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(98, 31);
            btnNew.TabIndex = 139;
            btnNew.Text = "➕ Baru";
            btnNew.TextColor = Color.White;
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 3;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(332, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 31);
            btnSave.TabIndex = 138;
            btnSave.Text = "✔ Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // TglEditSync
            // 
            TglEditSync.Anchor = AnchorStyles.Top;
            TglEditSync.DateTimeIcon = null;
            TglEditSync.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync.Format = "d MMMM yyyy";
            TglEditSync.Location = new Point(11, 94);
            TglEditSync.Name = "TglEditSync";
            TglEditSync.Size = new Size(193, 28);
            TglEditSync.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync.TabIndex = 137;
            TglEditSync.ToolTipText = "";
            // 
            // Fwworm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 472);
            Controls.Add(tabControlAdv1);
            Name = "Fwworm2";
            Text = "Jadwal";
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).EndInit();
            tabControlAdv1.ResumeLayout(false);
            tabPageAdv1.ResumeLayout(false);
            tabPageAdv1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Label lblMode;
        private ComboBox comboHari;
        private YogaButton btnHarian;
        private YogaButton btnTanggal;
        private YogaButton btnClose;
        private DataGridView dataGridView1;
        private YogaButton btnNew;
        private YogaButton btnSave;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync;
    }
}