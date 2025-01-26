namespace Bengkel_Yoga_UKK
{
    partial class Form2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            label2 = new Label();
            profilePicture = new PictureBox();
            lblNama = new Label();
            button16 = new Button();
            btnHome = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnService = new Button();
            btnProduk = new Button();
            btnBooking = new Button();
            btn = new Button();
            button2 = new Button();
            button15 = new Button();
            panelMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(profilePicture);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(button16);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1095, 59);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(64, 13);
            label2.Name = "label2";
            label2.Size = new Size(81, 32);
            label2.TabIndex = 0;
            label2.Text = "ProFix";
            // 
            // profilePicture
            // 
            profilePicture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profilePicture.BackgroundImage = (Image)resources.GetObject("profilePicture.BackgroundImage");
            profilePicture.BackgroundImageLayout = ImageLayout.Stretch;
            profilePicture.Location = new Point(1038, 7);
            profilePicture.Name = "profilePicture";
            profilePicture.Size = new Size(45, 45);
            profilePicture.TabIndex = 7;
            profilePicture.TabStop = false;
            // 
            // lblNama
            // 
            lblNama.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNama.AutoSize = true;
            lblNama.Location = new Point(923, 22);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(110, 15);
            lblNama.TabIndex = 8;
            lblNama.Text = "Rifki Yoga Syahbani";
            // 
            // button16
            // 
            button16.BackColor = Color.Transparent;
            button16.FlatAppearance.BorderSize = 0;
            button16.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button16.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button16.ForeColor = Color.White;
            button16.Image = (Image)resources.GetObject("button16.Image");
            button16.Location = new Point(9, 9);
            button16.Margin = new Padding(0);
            button16.Name = "button16";
            button16.Size = new Size(47, 44);
            button16.TabIndex = 6;
            button16.TextImageRelation = TextImageRelation.ImageBeforeText;
            button16.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(46, 134, 171);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHome.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(0);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 0, 0);
            btnHome.Size = new Size(264, 60);
            btnHome.TabIndex = 5;
            btnHome.Text = "    Dashboard";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(46, 134, 171);
            flowLayoutPanel2.Controls.Add(btnHome);
            flowLayoutPanel2.Controls.Add(btnService);
            flowLayoutPanel2.Controls.Add(btnProduk);
            flowLayoutPanel2.Controls.Add(btnBooking);
            flowLayoutPanel2.Controls.Add(btn);
            flowLayoutPanel2.Controls.Add(button2);
            flowLayoutPanel2.Controls.Add(button15);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.ForeColor = SystemColors.ControlText;
            flowLayoutPanel2.Location = new Point(2, 61);
            flowLayoutPanel2.MaximumSize = new Size(264, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(264, 597);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // btnService
            // 
            btnService.BackColor = Color.FromArgb(46, 134, 171);
            btnService.FlatAppearance.BorderSize = 0;
            btnService.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnService.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnService.FlatStyle = FlatStyle.Flat;
            btnService.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnService.ForeColor = Color.White;
            btnService.Image = (Image)resources.GetObject("btnService.Image");
            btnService.ImageAlign = ContentAlignment.MiddleLeft;
            btnService.Location = new Point(0, 60);
            btnService.Margin = new Padding(0);
            btnService.Name = "btnService";
            btnService.Padding = new Padding(10, 0, 0, 0);
            btnService.Size = new Size(264, 60);
            btnService.TabIndex = 8;
            btnService.Text = "    Service";
            btnService.TextAlign = ContentAlignment.MiddleLeft;
            btnService.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnService.UseVisualStyleBackColor = false;
            // 
            // btnProduk
            // 
            btnProduk.BackColor = Color.FromArgb(46, 134, 171);
            btnProduk.FlatAppearance.BorderSize = 0;
            btnProduk.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnProduk.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnProduk.FlatStyle = FlatStyle.Flat;
            btnProduk.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnProduk.ForeColor = Color.White;
            btnProduk.Image = (Image)resources.GetObject("btnProduk.Image");
            btnProduk.ImageAlign = ContentAlignment.MiddleLeft;
            btnProduk.Location = new Point(0, 120);
            btnProduk.Margin = new Padding(0);
            btnProduk.Name = "btnProduk";
            btnProduk.Padding = new Padding(10, 0, 0, 0);
            btnProduk.Size = new Size(264, 60);
            btnProduk.TabIndex = 7;
            btnProduk.Text = "    Produk";
            btnProduk.TextAlign = ContentAlignment.MiddleLeft;
            btnProduk.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProduk.UseVisualStyleBackColor = false;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.FromArgb(46, 134, 171);
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBooking.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBooking.ForeColor = Color.White;
            btnBooking.Image = (Image)resources.GetObject("btnBooking.Image");
            btnBooking.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooking.Location = new Point(0, 180);
            btnBooking.Margin = new Padding(0);
            btnBooking.Name = "btnBooking";
            btnBooking.Padding = new Padding(10, 0, 0, 0);
            btnBooking.Size = new Size(264, 60);
            btnBooking.TabIndex = 6;
            btnBooking.Text = "    Booking";
            btnBooking.TextAlign = ContentAlignment.MiddleLeft;
            btnBooking.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooking.UseVisualStyleBackColor = false;
            // 
            // btn
            // 
            btn.BackColor = Color.FromArgb(46, 134, 171);
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn.ForeColor = Color.White;
            btn.Image = (Image)resources.GetObject("btn.Image");
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Location = new Point(0, 240);
            btn.Margin = new Padding(0);
            btn.Name = "btn";
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Size = new Size(264, 60);
            btn.TabIndex = 10;
            btn.Text = "    Pelanggan";
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(46, 134, 171);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 300);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Padding = new Padding(10, 0, 0, 0);
            button2.Size = new Size(264, 60);
            button2.TabIndex = 11;
            button2.Text = "    Invoice";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            button15.BackColor = Color.FromArgb(46, 134, 171);
            button15.FlatAppearance.BorderSize = 0;
            button15.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button15.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button15.FlatStyle = FlatStyle.Flat;
            button15.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button15.ForeColor = Color.White;
            button15.Image = (Image)resources.GetObject("button15.Image");
            button15.ImageAlign = ContentAlignment.MiddleLeft;
            button15.Location = new Point(0, 360);
            button15.Margin = new Padding(0);
            button15.Name = "button15";
            button15.Padding = new Padding(10, 0, 0, 0);
            button15.Size = new Size(264, 60);
            button15.TabIndex = 9;
            button15.Text = "    Setting";
            button15.TextAlign = ContentAlignment.MiddleLeft;
            button15.TextImageRelation = TextImageRelation.ImageBeforeText;
            button15.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(2, 61);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1095, 597);
            panelMain.TabIndex = 6;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 660);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            Name = "Form2";
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Dashboard2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnHome;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button16;
        private Button btnBooking;
        private Button btnProduk;
        private Button btnService;
        private Button button15;
        private Panel panelMain;
        private PictureBox profilePicture;
        private Label lblNama;
        private Button btn;
        private Button button2;
        private Label label2;
    }
}
