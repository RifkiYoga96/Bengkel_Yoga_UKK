namespace Bengkel_Yoga_UKK
{
    partial class FormDashboardUser
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
            lblBeranda = new Label();
            lblServis = new Label();
            lblTentangKami = new Label();
            btnLogout = new YogaButton();
            panel1 = new Panel();
            panelSide2 = new Panel();
            lblProFix = new Label();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panelSide2.SuspendLayout();
            SuspendLayout();
            // 
            // lblBeranda
            // 
            lblBeranda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBeranda.AutoSize = true;
            lblBeranda.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBeranda.ForeColor = SystemColors.Control;
            lblBeranda.Location = new Point(984, 25);
            lblBeranda.Name = "lblBeranda";
            lblBeranda.Size = new Size(82, 25);
            lblBeranda.TabIndex = 2;
            lblBeranda.Text = "Beranda";
            // 
            // lblServis
            // 
            lblServis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblServis.AutoSize = true;
            lblServis.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblServis.ForeColor = SystemColors.Control;
            lblServis.Location = new Point(1095, 25);
            lblServis.Name = "lblServis";
            lblServis.Size = new Size(63, 25);
            lblServis.TabIndex = 3;
            lblServis.Text = "Servis";
            // 
            // lblTentangKami
            // 
            lblTentangKami.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTentangKami.AutoSize = true;
            lblTentangKami.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTentangKami.ForeColor = SystemColors.Control;
            lblTentangKami.Location = new Point(1190, 25);
            lblTentangKami.Name = "lblTentangKami";
            lblTentangKami.Size = new Size(129, 25);
            lblTentangKami.TabIndex = 4;
            lblTentangKami.Text = "Tentang Kami";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.MediumSlateBlue;
            btnLogout.BackgroundColor = Color.MediumSlateBlue;
            btnLogout.BorderColor = Color.PaleVioletRed;
            btnLogout.BorderRadius = 8;
            btnLogout.BorderSize = 0;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1352, 18);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(111, 40);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.TextColor = Color.White;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(panelSide2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1511, 75);
            panel1.TabIndex = 7;
            // 
            // panelSide2
            // 
            panelSide2.Controls.Add(lblBeranda);
            panelSide2.Controls.Add(lblServis);
            panelSide2.Controls.Add(lblTentangKami);
            panelSide2.Controls.Add(btnLogout);
            panelSide2.Controls.Add(lblProFix);
            panelSide2.Location = new Point(0, 0);
            panelSide2.Name = "panelSide2";
            panelSide2.Size = new Size(1511, 75);
            panelSide2.TabIndex = 6;
            panelSide2.Paint += panelSide2_Paint;
            // 
            // lblProFix
            // 
            lblProFix.AutoSize = true;
            lblProFix.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblProFix.ForeColor = Color.White;
            lblProFix.Location = new Point(13, 21);
            lblProFix.Name = "lblProFix";
            lblProFix.Size = new Size(86, 32);
            lblProFix.TabIndex = 0;
            lblProFix.Text = "ProFix";
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 75);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1511, 725);
            panelMain.TabIndex = 8;
            // 
            // FormDashboardUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1511, 800);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "FormDashboardUser";
            Text = "FormDashboardUser";
            panel1.ResumeLayout(false);
            panelSide2.ResumeLayout(false);
            panelSide2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblBeranda;
        private Label lblServis;
        private Label lblTentangKami;
        private YogaButton btnLogout;
        private Panel panel1;
        private Label lblProFix;
        private Panel panelMain;
        private Panel panelSide2;
    }
}