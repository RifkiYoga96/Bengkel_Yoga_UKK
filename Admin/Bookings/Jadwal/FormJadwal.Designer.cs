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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJadwal));
            toolStripMenuItem1 = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            jam2 = new DateTimePicker();
            jam1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblMode = new Label();
            comboHari = new ComboBox();
            btnClose = new YogaButton();
            gridOperasional = new DataGridView();
            btnNew = new YogaButton();
            btnSave = new YogaButton();
            tabPage2 = new TabPage();
            lblMode2 = new Label();
            comboHari2 = new ComboBox();
            btnHarian2 = new YogaButton();
            btnTanggal2 = new YogaButton();
            btnClose2 = new YogaButton();
            gridLibur = new DataGridView();
            btnNew2 = new YogaButton();
            btnSave2 = new YogaButton();
            TglEditSync2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            lblHeader = new Label();
            contextMenuStripLibur = new ContextMenuStrip(components);
            toolStripDeleteLibur = new ToolStripMenuItem();
            contextMenuOperasional = new ContextMenuStrip(components);
            toolStripDeleteOperasional = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridOperasional).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLibur).BeginInit();
            contextMenuStripLibur.SuspendLayout();
            contextMenuOperasional.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = (Image)resources.GetObject("toolStripMenuItem1.Image");
            toolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Padding = new Padding(0, 2, 0, 2);
            toolStripMenuItem1.Size = new Size(136, 32);
            toolStripMenuItem1.Text = "Delete";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 43);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(460, 459);
            tabControl1.TabIndex = 127;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(jam2);
            tabPage1.Controls.Add(jam1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lblMode);
            tabPage1.Controls.Add(comboHari);
            tabPage1.Controls.Add(btnClose);
            tabPage1.Controls.Add(gridOperasional);
            tabPage1.Controls.Add(btnNew);
            tabPage1.Controls.Add(btnSave);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(452, 425);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Operasional";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(348, 16);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 153;
            label1.Text = "Jam tutup";
            // 
            // jam2
            // 
            jam2.CustomFormat = "   HH:mm";
            jam2.Format = DateTimePickerFormat.Custom;
            jam2.Location = new Point(348, 40);
            jam2.Name = "jam2";
            jam2.ShowUpDown = true;
            jam2.Size = new Size(88, 29);
            jam2.TabIndex = 152;
            // 
            // jam1
            // 
            jam1.CalendarForeColor = Color.Yellow;
            jam1.CalendarTitleBackColor = Color.Yellow;
            jam1.CalendarTitleForeColor = SystemColors.ControlLightLight;
            jam1.CustomFormat = "   HH:mm";
            jam1.Format = DateTimePickerFormat.Custom;
            jam1.Location = new Point(234, 40);
            jam1.Name = "jam1";
            jam1.ShowUpDown = true;
            jam1.Size = new Size(88, 29);
            jam1.TabIndex = 151;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(326, 44);
            label4.Name = "label4";
            label4.Size = new Size(18, 20);
            label4.TabIndex = 148;
            label4.Text = "━";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(234, 16);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 147;
            label3.Text = "Jam buka";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(17, 16);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 144;
            label2.Text = "Hari";
            // 
            // lblMode
            // 
            lblMode.Anchor = AnchorStyles.Top;
            lblMode.AutoSize = true;
            lblMode.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblMode.Location = new Point(17, 122);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(117, 21);
            lblMode.TabIndex = 143;
            lblMode.Text = "Mode : Normal";
            // 
            // comboHari
            // 
            comboHari.Anchor = AnchorStyles.Top;
            comboHari.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboHari.FormattingEnabled = true;
            comboHari.Location = new Point(17, 40);
            comboHari.Name = "comboHari";
            comboHari.Size = new Size(169, 28);
            comboHari.TabIndex = 142;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = Color.White;
            btnClose.BackgroundColor = Color.White;
            btnClose.BorderColor = Color.PaleVioletRed;
            btnClose.BorderRadius = 3;
            btnClose.BorderSize = 2;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.ControlDarkDark;
            btnClose.Location = new Point(326, 372);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 141;
            btnClose.Text = "❌ Close";
            btnClose.TextColor = SystemColors.ControlDarkDark;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // gridOperasional
            // 
            gridOperasional.Anchor = AnchorStyles.Top;
            gridOperasional.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOperasional.Location = new Point(17, 168);
            gridOperasional.Name = "gridOperasional";
            gridOperasional.RowTemplate.Height = 25;
            gridOperasional.Size = new Size(419, 187);
            gridOperasional.TabIndex = 140;
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
            btnNew.Location = new Point(234, 118);
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
            btnSave.Location = new Point(338, 118);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 31);
            btnSave.TabIndex = 138;
            btnSave.Text = "✔ Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(lblMode2);
            tabPage2.Controls.Add(comboHari2);
            tabPage2.Controls.Add(btnHarian2);
            tabPage2.Controls.Add(btnTanggal2);
            tabPage2.Controls.Add(btnClose2);
            tabPage2.Controls.Add(gridLibur);
            tabPage2.Controls.Add(btnNew2);
            tabPage2.Controls.Add(btnSave2);
            tabPage2.Controls.Add(TglEditSync2);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(452, 425);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Libur";
            // 
            // lblMode2
            // 
            lblMode2.Anchor = AnchorStyles.Top;
            lblMode2.AutoSize = true;
            lblMode2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblMode2.Location = new Point(17, 161);
            lblMode2.Name = "lblMode2";
            lblMode2.Size = new Size(117, 21);
            lblMode2.TabIndex = 136;
            lblMode2.Text = "Mode : Normal";
            // 
            // comboHari2
            // 
            comboHari2.Anchor = AnchorStyles.Top;
            comboHari2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboHari2.FormattingEnabled = true;
            comboHari2.Location = new Point(243, 90);
            comboHari2.Name = "comboHari2";
            comboHari2.Size = new Size(193, 28);
            comboHari2.TabIndex = 135;
            // 
            // btnHarian2
            // 
            btnHarian2.Anchor = AnchorStyles.Top;
            btnHarian2.BackColor = Color.Gainsboro;
            btnHarian2.BackgroundColor = Color.Gainsboro;
            btnHarian2.BorderColor = Color.PaleVioletRed;
            btnHarian2.BorderRadius = 20;
            btnHarian2.BorderSize = 0;
            btnHarian2.FlatAppearance.BorderSize = 0;
            btnHarian2.FlatStyle = FlatStyle.Flat;
            btnHarian2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnHarian2.ForeColor = SystemColors.ControlDarkDark;
            btnHarian2.Location = new Point(243, 24);
            btnHarian2.Name = "btnHarian2";
            btnHarian2.Size = new Size(193, 40);
            btnHarian2.TabIndex = 134;
            btnHarian2.Text = "Harian";
            btnHarian2.TextColor = SystemColors.ControlDarkDark;
            btnHarian2.UseVisualStyleBackColor = false;
            // 
            // btnTanggal2
            // 
            btnTanggal2.Anchor = AnchorStyles.Top;
            btnTanggal2.BackColor = Color.FromArgb(128, 128, 255);
            btnTanggal2.BackgroundColor = Color.FromArgb(128, 128, 255);
            btnTanggal2.BorderColor = Color.PaleVioletRed;
            btnTanggal2.BorderRadius = 20;
            btnTanggal2.BorderSize = 0;
            btnTanggal2.FlatAppearance.BorderSize = 0;
            btnTanggal2.FlatStyle = FlatStyle.Flat;
            btnTanggal2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTanggal2.ForeColor = Color.White;
            btnTanggal2.Location = new Point(17, 24);
            btnTanggal2.Name = "btnTanggal2";
            btnTanggal2.Size = new Size(193, 40);
            btnTanggal2.TabIndex = 133;
            btnTanggal2.Text = "Tanggal";
            btnTanggal2.TextColor = Color.White;
            btnTanggal2.UseVisualStyleBackColor = false;
            // 
            // btnClose2
            // 
            btnClose2.Anchor = AnchorStyles.Top;
            btnClose2.BackColor = SystemColors.Control;
            btnClose2.BackgroundColor = SystemColors.Control;
            btnClose2.BorderColor = Color.PaleVioletRed;
            btnClose2.BorderRadius = 3;
            btnClose2.BorderSize = 2;
            btnClose2.FlatAppearance.BorderSize = 0;
            btnClose2.FlatStyle = FlatStyle.Flat;
            btnClose2.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose2.ForeColor = SystemColors.ControlDarkDark;
            btnClose2.Location = new Point(326, 374);
            btnClose2.Name = "btnClose2";
            btnClose2.Size = new Size(110, 38);
            btnClose2.TabIndex = 132;
            btnClose2.Text = "❌ Close";
            btnClose2.TextColor = SystemColors.ControlDarkDark;
            btnClose2.UseVisualStyleBackColor = false;
            // 
            // gridLibur
            // 
            gridLibur.Anchor = AnchorStyles.Top;
            gridLibur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLibur.Location = new Point(17, 207);
            gridLibur.Name = "gridLibur";
            gridLibur.RowTemplate.Height = 25;
            gridLibur.Size = new Size(419, 155);
            gridLibur.TabIndex = 131;
            // 
            // btnNew2
            // 
            btnNew2.Anchor = AnchorStyles.Top;
            btnNew2.BackColor = Color.FromArgb(230, 126, 34);
            btnNew2.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnNew2.BorderColor = Color.PaleVioletRed;
            btnNew2.BorderRadius = 3;
            btnNew2.BorderSize = 0;
            btnNew2.FlatAppearance.BorderSize = 0;
            btnNew2.FlatStyle = FlatStyle.Flat;
            btnNew2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew2.ForeColor = Color.White;
            btnNew2.Location = new Point(234, 157);
            btnNew2.Name = "btnNew2";
            btnNew2.Size = new Size(98, 31);
            btnNew2.TabIndex = 130;
            btnNew2.Text = "➕ Baru";
            btnNew2.TextColor = Color.White;
            btnNew2.UseVisualStyleBackColor = false;
            // 
            // btnSave2
            // 
            btnSave2.Anchor = AnchorStyles.Top;
            btnSave2.BackColor = Color.FromArgb(0, 192, 0);
            btnSave2.BackgroundColor = Color.FromArgb(0, 192, 0);
            btnSave2.BorderColor = Color.PaleVioletRed;
            btnSave2.BorderRadius = 3;
            btnSave2.BorderSize = 0;
            btnSave2.FlatAppearance.BorderSize = 0;
            btnSave2.FlatStyle = FlatStyle.Flat;
            btnSave2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave2.ForeColor = Color.White;
            btnSave2.Location = new Point(338, 157);
            btnSave2.Name = "btnSave2";
            btnSave2.Size = new Size(98, 31);
            btnSave2.TabIndex = 129;
            btnSave2.Text = "✔ Save";
            btnSave2.TextColor = Color.White;
            btnSave2.UseVisualStyleBackColor = false;
            // 
            // TglEditSync2
            // 
            TglEditSync2.Anchor = AnchorStyles.Top;
            TglEditSync2.DateTimeIcon = null;
            TglEditSync2.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            TglEditSync2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TglEditSync2.Format = "d MMMM yyyy";
            TglEditSync2.Location = new Point(17, 90);
            TglEditSync2.Name = "TglEditSync2";
            TglEditSync2.Size = new Size(193, 28);
            TglEditSync2.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync2.TabIndex = 128;
            TglEditSync2.ToolTipText = "";
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(460, 43);
            lblHeader.TabIndex = 126;
            lblHeader.Text = "Jadwal";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStripLibur
            // 
            contextMenuStripLibur.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contextMenuStripLibur.Items.AddRange(new ToolStripItem[] { toolStripDeleteLibur });
            contextMenuStripLibur.Name = "contextMenuStrip1";
            contextMenuStripLibur.Size = new Size(137, 36);
            // 
            // toolStripDeleteLibur
            // 
            toolStripDeleteLibur.Image = (Image)resources.GetObject("toolStripDeleteLibur.Image");
            toolStripDeleteLibur.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDeleteLibur.Name = "toolStripDeleteLibur";
            toolStripDeleteLibur.Padding = new Padding(0, 2, 0, 2);
            toolStripDeleteLibur.Size = new Size(188, 32);
            toolStripDeleteLibur.Text = "Delete";
            // 
            // contextMenuOperasional
            // 
            contextMenuOperasional.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contextMenuOperasional.Items.AddRange(new ToolStripItem[] { toolStripDeleteOperasional });
            contextMenuOperasional.Name = "contextMenuStrip1";
            contextMenuOperasional.Size = new Size(137, 36);
            // 
            // toolStripDeleteOperasional
            // 
            toolStripDeleteOperasional.Image = (Image)resources.GetObject("toolStripDeleteOperasional.Image");
            toolStripDeleteOperasional.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDeleteOperasional.Name = "toolStripDeleteOperasional";
            toolStripDeleteOperasional.Padding = new Padding(0, 2, 0, 2);
            toolStripDeleteOperasional.Size = new Size(136, 32);
            toolStripDeleteOperasional.Text = "Delete";
            // 
            // FormJadwal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 502);
            Controls.Add(tabControl1);
            Controls.Add(lblHeader);
            Name = "FormJadwal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Jadwal";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridOperasional).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLibur).EndInit();
            contextMenuStripLibur.ResumeLayout(false);
            contextMenuOperasional.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblMode2;
        private ComboBox comboHari2;
        private YogaButton btnHarian2;
        private YogaButton btnTanggal2;
        private YogaButton btnClose2;
        private DataGridView gridLibur;
        private YogaButton btnNew2;
        private YogaButton btnSave2;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync2;
        private Label lblHeader;
        private Label lblMode;
        private ComboBox comboHari;
        private YogaButton btnClose;
        private DataGridView gridOperasional;
        private YogaButton btnNew;
        private YogaButton btnSave;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker jam1;
        private DateTimePicker jam2;
        private Label label1;
        private ContextMenuStrip contextMenuStripLibur;
        private ToolStripMenuItem toolStripDeleteLibur;
        private ContextMenuStrip contextMenuOperasional;
        private ToolStripMenuItem toolStripDeleteOperasional;
    }
}