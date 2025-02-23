namespace Bengkel_Yoga_UKK
{
    partial class FormRiwayat
    {
        // </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRiwayat));
            dataGridView1 = new DataGridView();
            yogaPanel1 = new YogaPanel();
            comboFilterStatus = new ComboBox();
            panelTanggalFilter = new Panel();
            panelComboFilter = new Panel();
            lblTo = new Label();
            tgl2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            tgl1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            lblShowingEntries = new Label();
            comboFilterWaktu = new ComboBox();
            btnSearch = new YogaButton();
            panel1 = new Panel();
            panel2 = new Panel();
            lblHalaman = new Label();
            btnNext = new YogaButton();
            btnPrevious = new YogaButton();
            txtSearch = new TextBox();
            label3 = new Label();
            label1 = new Label();
            numericEntries = new NumericUpDown();
            contextMenuStrip1 = new ContextMenuStrip(components);
            nNToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            InvoiceStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            yogaPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEntries).BeginInit();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(46, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1249, 422);
            dataGridView1.TabIndex = 0;
            // 
            // yogaPanel1
            // 
            yogaPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 0;
            yogaPanel1.BorderSize = 0;
            yogaPanel1.Controls.Add(comboFilterStatus);
            yogaPanel1.Controls.Add(panelTanggalFilter);
            yogaPanel1.Controls.Add(panelComboFilter);
            yogaPanel1.Controls.Add(lblTo);
            yogaPanel1.Controls.Add(tgl2);
            yogaPanel1.Controls.Add(tgl1);
            yogaPanel1.Controls.Add(lblShowingEntries);
            yogaPanel1.Controls.Add(comboFilterWaktu);
            yogaPanel1.Controls.Add(btnSearch);
            yogaPanel1.Controls.Add(panel1);
            yogaPanel1.Controls.Add(txtSearch);
            yogaPanel1.Controls.Add(label3);
            yogaPanel1.Controls.Add(label1);
            yogaPanel1.Controls.Add(numericEntries);
            yogaPanel1.Controls.Add(dataGridView1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(29, 75);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(1340, 579);
            yogaPanel1.TabIndex = 11;
            // 
            // comboFilterStatus
            // 
            comboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFilterStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboFilterStatus.FormattingEnabled = true;
            comboFilterStatus.Location = new Point(376, 33);
            comboFilterStatus.Name = "comboFilterStatus";
            comboFilterStatus.Size = new Size(100, 28);
            comboFilterStatus.TabIndex = 120;
            // 
            // panelTanggalFilter
            // 
            panelTanggalFilter.BackColor = Color.FromArgb(62, 162, 229);
            panelTanggalFilter.Location = new Point(675, 66);
            panelTanggalFilter.Name = "panelTanggalFilter";
            panelTanggalFilter.Size = new Size(382, 5);
            panelTanggalFilter.TabIndex = 119;
            // 
            // panelComboFilter
            // 
            panelComboFilter.BackColor = Color.FromArgb(62, 162, 229);
            panelComboFilter.Location = new Point(482, 66);
            panelComboFilter.Name = "panelComboFilter";
            panelComboFilter.Size = new Size(176, 5);
            panelComboFilter.TabIndex = 118;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTo.ForeColor = Color.DimGray;
            lblTo.Location = new Point(855, 22);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(22, 30);
            lblTo.TabIndex = 117;
            lblTo.Text = "_";
            // 
            // tgl2
            // 
            tgl2.DateTimeIcon = null;
            tgl2.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            tgl2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tgl2.Format = "d MMMM yyyy";
            tgl2.Location = new Point(880, 33);
            tgl2.Name = "tgl2";
            tgl2.Size = new Size(177, 28);
            tgl2.Style.BorderColor = Color.FromArgb(64, 64, 64);
            tgl2.TabIndex = 116;
            tgl2.ToolTipText = "";
            // 
            // tgl1
            // 
            tgl1.DateTimeIcon = null;
            tgl1.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            tgl1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tgl1.Format = "d MMMM yyyy";
            tgl1.Location = new Point(675, 33);
            tgl1.Name = "tgl1";
            tgl1.Size = new Size(177, 28);
            tgl1.Style.BorderColor = Color.FromArgb(64, 64, 64);
            tgl1.TabIndex = 115;
            tgl1.ToolTipText = "";
            // 
            // lblShowingEntries
            // 
            lblShowingEntries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblShowingEntries.AutoSize = true;
            lblShowingEntries.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblShowingEntries.ForeColor = Color.DimGray;
            lblShowingEntries.Location = new Point(46, 522);
            lblShowingEntries.Name = "lblShowingEntries";
            lblShowingEntries.Size = new Size(238, 23);
            lblShowingEntries.TabIndex = 13;
            lblShowingEntries.Text = "Showing 1 to 14 of 120 entries";
            // 
            // comboFilterWaktu
            // 
            comboFilterWaktu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFilterWaktu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboFilterWaktu.FormattingEnabled = true;
            comboFilterWaktu.Location = new Point(482, 33);
            comboFilterWaktu.Name = "comboFilterWaktu";
            comboFilterWaktu.Size = new Size(176, 28);
            comboFilterWaktu.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(230, 126, 34);
            btnSearch.BackgroundColor = Color.FromArgb(230, 126, 34);
            btnSearch.BorderColor = Color.PaleVioletRed;
            btnSearch.BorderRadius = 0;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(323, 33);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(47, 27);
            btnSearch.TabIndex = 12;
            btnSearch.TextColor = Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrevious);
            panel1.Location = new Point(1132, 515);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 40);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.Controls.Add(lblHalaman);
            panel2.Location = new Point(67, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(45, 39);
            panel2.TabIndex = 10;
            // 
            // lblHalaman
            // 
            lblHalaman.BackColor = Color.FromArgb(230, 126, 34);
            lblHalaman.Dock = DockStyle.Fill;
            lblHalaman.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblHalaman.ForeColor = Color.White;
            lblHalaman.Location = new Point(0, 0);
            lblHalaman.Name = "lblHalaman";
            lblHalaman.Size = new Size(45, 39);
            lblHalaman.TabIndex = 10;
            lblHalaman.Text = "1";
            lblHalaman.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.BackgroundColor = Color.White;
            btnNext.BorderColor = Color.PaleVioletRed;
            btnNext.BorderRadius = 0;
            btnNext.BorderSize = 2;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.ForeColor = SystemColors.ControlText;
            btnNext.Location = new Point(105, 0);
            btnNext.Margin = new Padding(0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(58, 40);
            btnNext.TabIndex = 9;
            btnNext.Text = "Next";
            btnNext.TextColor = SystemColors.ControlText;
            btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.White;
            btnPrevious.BackgroundColor = Color.White;
            btnPrevious.BorderColor = Color.PaleVioletRed;
            btnPrevious.BorderRadius = 0;
            btnPrevious.BorderSize = 2;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.ForeColor = SystemColors.ControlText;
            btnPrevious.Location = new Point(0, 0);
            btnPrevious.Margin = new Padding(0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(76, 40);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "Previous";
            btnPrevious.TextColor = SystemColors.ControlText;
            btnPrevious.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(46, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " Search";
            txtSearch.Size = new Size(271, 27);
            txtSearch.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(1232, 33);
            label3.Name = "label3";
            label3.Size = new Size(61, 23);
            label3.TabIndex = 5;
            label3.Text = "entries";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(1114, 33);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 4;
            label1.Text = "Show";
            // 
            // numericEntries
            // 
            numericEntries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericEntries.BackColor = Color.White;
            numericEntries.BorderStyle = BorderStyle.FixedSingle;
            numericEntries.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numericEntries.Location = new Point(1166, 32);
            numericEntries.Name = "numericEntries";
            numericEntries.Size = new Size(64, 27);
            numericEntries.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { nNToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Size = new Size(188, 82);
            // 
            // nNToolStripMenuItem
            // 
            nNToolStripMenuItem.Name = "nNToolStripMenuItem";
            nNToolStripMenuItem.Size = new Size(187, 26);
            nNToolStripMenuItem.Text = "Detail Booking";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(187, 26);
            editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(187, 26);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.DropShadowEnabled = false;
            contextMenuStrip.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { InvoiceStripMenuItem });
            contextMenuStrip.MetroColor = Color.FromArgb(204, 236, 249);
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(134, 30);
            contextMenuStrip.ThemeName = "Office2016Colorful";
            contextMenuStrip.ThemeStyle.BackColor = Color.FromArgb(52, 152, 219);
            contextMenuStrip.ThemeStyle.DisabledForeColor = Color.FromArgb(52, 152, 219);
            contextMenuStrip.ThemeStyle.HoverBackColor = Color.FromArgb(52, 152, 219);
            contextMenuStrip.ThemeStyle.PressedBackColor = Color.FromArgb(52, 152, 219);
            // 
            // InvoiceStripMenuItem
            // 
            InvoiceStripMenuItem.Name = "InvoiceStripMenuItem";
            InvoiceStripMenuItem.Size = new Size(133, 26);
            InvoiceStripMenuItem.Text = "Invoice";
            // 
            // FormRiwayat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1397, 683);
            Controls.Add(yogaPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRiwayat";
            Text = "Tabel";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericEntries).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private YogaPanel yogaPanel1;
        private NumericUpDown numericEntries;
        private Label label1;
        private TextBox txtSearch;
        private Label label3;
        private Panel panel1;
        private YogaButton btnNext;
        private YogaButton btnPrevious;
        private Panel panel2;
        private Label lblHalaman;
        private YogaButton btnSearch;
        private ComboBox comboFilterWaktu;
        private Label lblShowingEntries;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem nNToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Syncfusion.WinForms.Input.SfDateTimeEdit tgl2;
        private Syncfusion.WinForms.Input.SfDateTimeEdit tgl1;
        private Label lblTo;
        private Panel panelTanggalFilter;
        private Panel panelComboFilter;
        private ComboBox comboFilterStatus;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStrip;
        private ToolStripMenuItem InvoiceStripMenuItem;
    }
}