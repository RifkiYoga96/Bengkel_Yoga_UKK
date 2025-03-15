namespace Bengkel_Yoga_UKK
{
    partial class JasaServisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JasaServisForm));
            dataGridView1 = new DataGridView();
            yogaPanel1 = new YogaPanel();
            lblShowingEntries = new Label();
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddData = new YogaButton();
            btnDataDihapus = new YogaButton();
            contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStripEx2 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            restoreStripMenuItem2 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            yogaPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEntries).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            contextMenuStripEx1.SuspendLayout();
            contextMenuStripEx2.SuspendLayout();
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
            dataGridView1.Size = new Size(995, 374);
            dataGridView1.TabIndex = 0;
            // 
            // yogaPanel1
            // 
            yogaPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 0;
            yogaPanel1.BorderSize = 0;
            yogaPanel1.Controls.Add(lblShowingEntries);
            yogaPanel1.Controls.Add(btnSearch);
            yogaPanel1.Controls.Add(panel1);
            yogaPanel1.Controls.Add(txtSearch);
            yogaPanel1.Controls.Add(label3);
            yogaPanel1.Controls.Add(label1);
            yogaPanel1.Controls.Add(numericEntries);
            yogaPanel1.Controls.Add(dataGridView1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(28, 75);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(1086, 531);
            yogaPanel1.TabIndex = 11;
            // 
            // lblShowingEntries
            // 
            lblShowingEntries.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblShowingEntries.AutoSize = true;
            lblShowingEntries.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblShowingEntries.ForeColor = Color.DimGray;
            lblShowingEntries.Location = new Point(46, 474);
            lblShowingEntries.Name = "lblShowingEntries";
            lblShowingEntries.Size = new Size(198, 19);
            lblShowingEntries.TabIndex = 13;
            lblShowingEntries.Text = "Showing 1 to 14 of 120 entries";
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
            btnSearch.Image = Properties.Resources.kacaPembesar;
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
            panel1.Location = new Point(878, 467);
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
            label3.Location = new Point(978, 33);
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
            label1.Location = new Point(860, 33);
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
            numericEntries.Location = new Point(912, 32);
            numericEntries.Name = "numericEntries";
            numericEntries.Size = new Size(64, 27);
            numericEntries.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnAddData);
            flowLayoutPanel1.Controls.Add(btnDataDihapus);
            flowLayoutPanel1.Location = new Point(28, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(345, 57);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // btnAddData
            // 
            btnAddData.AutoSize = true;
            btnAddData.BackColor = Color.FromArgb(52, 152, 219);
            btnAddData.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnAddData.BorderColor = Color.PaleVioletRed;
            btnAddData.BorderRadius = 4;
            btnAddData.BorderSize = 0;
            btnAddData.FlatAppearance.BorderSize = 0;
            btnAddData.FlatStyle = FlatStyle.Flat;
            btnAddData.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddData.ForeColor = Color.White;
            btnAddData.Image = Properties.Resources.plusPutih;
            btnAddData.Location = new Point(3, 3);
            btnAddData.Name = "btnAddData";
            btnAddData.Padding = new Padding(10, 0, 0, 0);
            btnAddData.Size = new Size(165, 42);
            btnAddData.TabIndex = 1;
            btnAddData.Text = " Add Pelanggan";
            btnAddData.TextColor = Color.White;
            btnAddData.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddData.UseVisualStyleBackColor = false;
            // 
            // btnDataDihapus
            // 
            btnDataDihapus.BackColor = Color.Transparent;
            btnDataDihapus.BackgroundColor = Color.Transparent;
            btnDataDihapus.BorderColor = Color.PaleVioletRed;
            btnDataDihapus.BorderRadius = 4;
            btnDataDihapus.BorderSize = 0;
            btnDataDihapus.FlatAppearance.BorderSize = 0;
            btnDataDihapus.FlatStyle = FlatStyle.Flat;
            btnDataDihapus.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDataDihapus.ForeColor = SystemColors.ControlDarkDark;
            btnDataDihapus.Image = Properties.Resources.sampahDark;
            btnDataDihapus.Location = new Point(174, 3);
            btnDataDihapus.Name = "btnDataDihapus";
            btnDataDihapus.Padding = new Padding(10, 0, 0, 0);
            btnDataDihapus.Size = new Size(153, 42);
            btnDataDihapus.TabIndex = 2;
            btnDataDihapus.Text = " Data Dihapus";
            btnDataDihapus.TextColor = SystemColors.ControlDarkDark;
            btnDataDihapus.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDataDihapus.UseVisualStyleBackColor = false;
            // 
            // contextMenuStripEx1
            // 
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStripEx1.MetroColor = Color.FromArgb(204, 236, 249);
            contextMenuStripEx1.Name = "contextMenuStripEx1";
            contextMenuStripEx1.Size = new Size(127, 60);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
            editToolStripMenuItem.Image = (Image)resources.GetObject("editToolStripMenuItem.Image");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(126, 28);
            editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
            deleteToolStripMenuItem.Image = Properties.Resources.bin__1_;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(126, 28);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // contextMenuStripEx2
            // 
            contextMenuStripEx2.Items.AddRange(new ToolStripItem[] { restoreStripMenuItem2 });
            contextMenuStripEx2.MetroColor = Color.FromArgb(204, 236, 249);
            contextMenuStripEx2.Name = "contextMenuStripEx1";
            contextMenuStripEx2.Size = new Size(136, 32);
            // 
            // restoreStripMenuItem2
            // 
            restoreStripMenuItem2.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
            restoreStripMenuItem2.Image = (Image)resources.GetObject("restoreStripMenuItem2.Image");
            restoreStripMenuItem2.Name = "restoreStripMenuItem2";
            restoreStripMenuItem2.Size = new Size(135, 28);
            restoreStripMenuItem2.Text = "Restore";
            // 
            // JasaServisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1143, 635);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(yogaPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "JasaServisForm";
            Text = "Tabel";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericEntries).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            contextMenuStripEx1.ResumeLayout(false);
            contextMenuStripEx2.ResumeLayout(false);
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
        private Label lblShowingEntries;
        private FlowLayoutPanel flowLayoutPanel1;
        private YogaButton btnAddData;
        private YogaButton btnDataDihapus;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx2;
        private ToolStripMenuItem restoreStripMenuItem2;
    }
}