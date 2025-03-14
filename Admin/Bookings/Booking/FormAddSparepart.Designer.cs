﻿namespace Bengkel_Yoga_UKK
{
    partial class FormAddSparepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddSparepart));
            gridSparepart = new DataGridView();
            txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            gridSparepartUse = new DataGridView();
            btnSave = new YogaButton();
            btnCancel = new YogaButton();
            label1 = new Label();
            panel1 = new Panel();
            btnSearch = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)gridSparepart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSparepartUse).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gridSparepart
            // 
            gridSparepart.BackgroundColor = Color.Gainsboro;
            gridSparepart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSparepart.Location = new Point(12, 50);
            gridSparepart.Name = "gridSparepart";
            gridSparepart.RowTemplate.Height = 25;
            gridSparepart.Size = new Size(382, 276);
            gridSparepart.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BeforeTouchSize = new Size(300, 95);
            txtSearch.BorderColor = Color.FromArgb(209, 211, 212);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.ForeColor = SystemColors.ControlText;
            txtSearch.Location = new Point(12, 12);
            txtSearch.Metrocolor = SystemColors.ControlDarkDark;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " Cari Sparepart";
            txtSearch.Size = new Size(201, 27);
            txtSearch.TabIndex = 49;
            txtSearch.ThemeName = "Default";
            // 
            // gridSparepartUse
            // 
            gridSparepartUse.BackgroundColor = Color.Gainsboro;
            gridSparepartUse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSparepartUse.Location = new Point(410, 50);
            gridSparepartUse.Name = "gridSparepartUse";
            gridSparepartUse.RowTemplate.Height = 25;
            gridSparepartUse.Size = new Size(382, 276);
            gridSparepartUse.TabIndex = 51;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(704, 347);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 37);
            btnSave.TabIndex = 78;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundColor = Color.Transparent;
            btnCancel.BorderColor = SystemColors.ControlDarkDark;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 2;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.ControlDarkDark;
            btnCancel.Location = new Point(610, 347);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 37);
            btnCancel.TabIndex = 79;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(382, 33);
            label1.TabIndex = 80;
            label1.Text = "Sparepart digunakan";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(410, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 33);
            panel1.TabIndex = 81;
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
            btnSearch.Location = new Point(219, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(47, 27);
            btnSearch.TabIndex = 82;
            btnSearch.TextColor = Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // FormAddSparepart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 396);
            Controls.Add(btnSearch);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(gridSparepartUse);
            Controls.Add(txtSearch);
            Controls.Add(gridSparepart);
            Name = "FormAddSparepart";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddSparepart";
            ((System.ComponentModel.ISupportInitialize)gridSparepart).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSparepartUse).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridSparepart;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private DataGridView gridSparepartUse;
        private YogaButton btnSave;
        private YogaButton btnCancel;
        private Label label1;
        private Panel panel1;
        private YogaButton btnSearch;
    }
}