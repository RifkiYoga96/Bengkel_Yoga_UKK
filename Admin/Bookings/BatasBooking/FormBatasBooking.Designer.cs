namespace Bengkel_Yoga_UKK
{
    partial class FormBatasBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatasBooking));
            TglEditSync = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            label1 = new Label();
            txtBatas = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            label2 = new Label();
            btnSave = new YogaButton();
            btnNew = new YogaButton();
            dataGridView1 = new DataGridView();
            btnClose = new YogaButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)txtBatas).BeginInit();
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
            TglEditSync.Location = new Point(12, 38);
            TglEditSync.Name = "TglEditSync";
            TglEditSync.Size = new Size(251, 28);
            TglEditSync.Style.BorderColor = Color.FromArgb(64, 64, 64);
            TglEditSync.TabIndex = 115;
            TglEditSync.ToolTipText = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 116;
            label1.Text = "Tanggal";
            // 
            // txtBatas
            // 
            txtBatas.AccessibilityEnabled = true;
            txtBatas.BackGroundColor = Color.White;
            txtBatas.BeforeTouchSize = new Size(146, 28);
            txtBatas.BorderStyle = BorderStyle.FixedSingle;
            txtBatas.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBatas.ForeColor = SystemColors.WindowText;
            txtBatas.IntegerValue = 0L;
            txtBatas.Location = new Point(285, 38);
            txtBatas.Margin = new Padding(3, 2, 3, 2);
            txtBatas.Metrocolor = Color.White;
            txtBatas.Multiline = true;
            txtBatas.Name = "txtBatas";
            txtBatas.ReadOnlyBackColor = Color.WhiteSmoke;
            txtBatas.Size = new Size(146, 28);
            txtBatas.TabIndex = 117;
            txtBatas.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(285, 16);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 118;
            label2.Text = "Batas Booking";
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
            btnSave.Location = new Point(333, 89);
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
            btnNew.Location = new Point(229, 89);
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
            dataGridView1.Location = new Point(12, 154);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(419, 212);
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
            contextMenuStrip1.Size = new Size(137, 36);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = (Image)resources.GetObject("deleteToolStripMenuItem.Image");
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Padding = new Padding(0, 2, 0, 2);
            deleteToolStripMenuItem.Size = new Size(136, 32);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // FormBatasBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 427);
            Controls.Add(btnClose);
            Controls.Add(dataGridView1);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(txtBatas);
            Controls.Add(label1);
            Controls.Add(TglEditSync);
            Name = "FormBatasBooking";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Batas Booking";
            ((System.ComponentModel.ISupportInitialize)txtBatas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.WinForms.Input.SfDateTimeEdit TglEditSync;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtBatas;
        private Label label2;
        private YogaButton btnSave;
        private YogaButton btnNew;
        private DataGridView dataGridView1;
        private YogaButton btnClose;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}