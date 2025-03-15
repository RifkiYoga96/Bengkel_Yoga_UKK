namespace Bengkel_Yoga_UKK
{
    partial class FormInputJasaServis
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
            panel1 = new Panel();
            lblHeader = new Label();
            label3 = new Label();
            txtNamaJasa = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new YogaButton();
            lblErrorJasa = new Label();
            label4 = new Label();
            txtHarga = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            lblErrorHarga = new Label();
            btnCancel = new YogaButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNamaJasa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHarga).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 42);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(52, 152, 219);
            lblHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(476, 43);
            lblHeader.TabIndex = 11;
            lblHeader.Text = "Input Jasa Servis";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(16, 105);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 15;
            label3.Text = "Nama Jasa";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNamaJasa
            // 
            txtNamaJasa.BackColor = Color.White;
            txtNamaJasa.BeforeTouchSize = new Size(293, 70);
            txtNamaJasa.BorderColor = Color.FromArgb(209, 211, 212);
            txtNamaJasa.BorderStyle = BorderStyle.FixedSingle;
            txtNamaJasa.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNamaJasa.Location = new Point(177, 105);
            txtNamaJasa.Name = "txtNamaJasa";
            txtNamaJasa.Size = new Size(278, 27);
            txtNamaJasa.TabIndex = 26;
            txtNamaJasa.ThemeName = "Default";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnSave.BorderColor = Color.PaleVioletRed;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 0;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(347, 309);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 36);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.TextColor = Color.White;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lblErrorJasa
            // 
            lblErrorJasa.AutoSize = true;
            lblErrorJasa.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorJasa.ForeColor = Color.Red;
            lblErrorJasa.Location = new Point(177, 135);
            lblErrorJasa.Name = "lblErrorJasa";
            lblErrorJasa.Size = new Size(186, 17);
            lblErrorJasa.TabIndex = 102;
            lblErrorJasa.Text = "⚠️ Harap isi nama jasa servis!";
            lblErrorJasa.TextAlign = ContentAlignment.MiddleRight;
            lblErrorJasa.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(16, 182);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 24;
            label4.Text = "Harga";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtHarga
            // 
            txtHarga.AccessibilityEnabled = true;
            txtHarga.BeforeTouchSize = new Size(293, 70);
            txtHarga.BorderColor = Color.FromArgb(209, 211, 212);
            txtHarga.BorderStyle = BorderStyle.FixedSingle;
            txtHarga.DecimalValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtHarga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtHarga.Location = new Point(177, 182);
            txtHarga.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtHarga.Name = "txtHarga";
            txtHarga.Size = new Size(278, 27);
            txtHarga.TabIndex = 30;
            txtHarga.Text = "Rp0";
            txtHarga.ThemeName = "Metro";
            // 
            // lblErrorHarga
            // 
            lblErrorHarga.AutoSize = true;
            lblErrorHarga.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorHarga.ForeColor = Color.Red;
            lblErrorHarga.Location = new Point(177, 212);
            lblErrorHarga.Name = "lblErrorHarga";
            lblErrorHarga.Size = new Size(146, 17);
            lblErrorHarga.TabIndex = 103;
            lblErrorHarga.Text = "⚠️ Harga tidak boleh 0";
            lblErrorHarga.TextAlign = ContentAlignment.MiddleRight;
            lblErrorHarga.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundColor = Color.Transparent;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 2;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = SystemColors.ControlDarkDark;
            btnCancel.Location = new Point(229, 309);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 36);
            btnCancel.TabIndex = 104;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlDarkDark;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormInputJasaServis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 368);
            Controls.Add(btnCancel);
            Controls.Add(lblErrorHarga);
            Controls.Add(lblErrorJasa);
            Controls.Add(btnSave);
            Controls.Add(txtHarga);
            Controls.Add(txtNamaJasa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormInputJasaServis";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNamaJasa).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHarga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label label3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaJasa;
        private YogaButton btnSave;
        private Label lblErrorJasa;
        private Label label4;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtHarga;
        private Label lblErrorHarga;
        private YogaButton btnCancel;
    }
}