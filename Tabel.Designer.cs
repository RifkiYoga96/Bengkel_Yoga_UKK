namespace Bengkel_Yoga_UKK
{
    partial class Tabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabel));
            dataGridView1 = new DataGridView();
            label2 = new Label();
            yogaPanel1 = new YogaPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            lblHalaman = new Label();
            btnNext = new YogaButton();
            btnPrevious = new YogaButton();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            yogaButton1 = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            yogaPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(46, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(995, 306);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(28, 25);
            label2.Name = "label2";
            label2.Size = new Size(110, 32);
            label2.TabIndex = 10;
            label2.Text = "PRODUK";
            // 
            // yogaPanel1
            // 
            yogaPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            yogaPanel1.BackColor = Color.White;
            yogaPanel1.BorderColor = Color.PaleVioletRed;
            yogaPanel1.BorderRadius = 10;
            yogaPanel1.BorderSize = 0;
            yogaPanel1.Controls.Add(panel1);
            yogaPanel1.Controls.Add(label4);
            yogaPanel1.Controls.Add(textBox1);
            yogaPanel1.Controls.Add(label3);
            yogaPanel1.Controls.Add(label1);
            yogaPanel1.Controls.Add(numericUpDown1);
            yogaPanel1.Controls.Add(dataGridView1);
            yogaPanel1.Controls.Add(yogaButton1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(28, 78);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(1086, 528);
            yogaPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrevious);
            panel1.Location = new Point(878, 464);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 40);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.Controls.Add(lblHalaman);
            panel2.Location = new Point(67, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(45, 39);
            panel2.TabIndex = 10;
            // 
            // lblHalaman
            // 
            lblHalaman.AutoSize = true;
            lblHalaman.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblHalaman.ForeColor = Color.White;
            lblHalaman.Location = new Point(13, 9);
            lblHalaman.Name = "lblHalaman";
            lblHalaman.Size = new Size(18, 20);
            lblHalaman.TabIndex = 10;
            lblHalaman.Text = "1";
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.BackgroundColor = Color.White;
            btnNext.BorderColor = Color.PaleVioletRed;
            btnNext.BorderRadius = 5;
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
            btnPrevious.BorderRadius = 5;
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
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(767, 104);
            label4.Name = "label4";
            label4.Size = new Size(65, 23);
            label4.TabIndex = 7;
            label4.Text = "Search:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(838, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 27);
            textBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(164, 104);
            label3.Name = "label3";
            label3.Size = new Size(61, 23);
            label3.TabIndex = 5;
            label3.Text = "entries";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(46, 104);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 4;
            label1.Text = "Show";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.White;
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(98, 103);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(64, 27);
            numericUpDown1.TabIndex = 3;
            // 
            // yogaButton1
            // 
            yogaButton1.BackColor = Color.RoyalBlue;
            yogaButton1.BackgroundColor = Color.RoyalBlue;
            yogaButton1.BorderColor = Color.PaleVioletRed;
            yogaButton1.BorderRadius = 5;
            yogaButton1.BorderSize = 0;
            yogaButton1.FlatAppearance.BorderSize = 0;
            yogaButton1.FlatStyle = FlatStyle.Flat;
            yogaButton1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            yogaButton1.ForeColor = Color.White;
            yogaButton1.Image = (Image)resources.GetObject("yogaButton1.Image");
            yogaButton1.Location = new Point(46, 16);
            yogaButton1.Name = "yogaButton1";
            yogaButton1.Padding = new Padding(10, 0, 0, 0);
            yogaButton1.Size = new Size(124, 37);
            yogaButton1.TabIndex = 1;
            yogaButton1.Text = " Add Data";
            yogaButton1.TextColor = Color.White;
            yogaButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            yogaButton1.UseVisualStyleBackColor = false;
            // 
            // Tabel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1143, 635);
            Controls.Add(yogaPanel1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Tabel";
            Text = "Tabel";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            yogaPanel1.ResumeLayout(false);
            yogaPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label2;
        private YogaPanel yogaPanel1;
        private YogaButton yogaButton1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private Panel panel1;
        private YogaButton btnNext;
        private YogaButton btnPrevious;
        private Label label4;
        private Panel panel2;
        private Label lblHalaman;
    }
}