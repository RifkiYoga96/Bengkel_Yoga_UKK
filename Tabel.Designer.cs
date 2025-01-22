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
            yogaButton1 = new YogaButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            yogaPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(46, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(995, 342);
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
            yogaPanel1.BorderRadius = 20;
            yogaPanel1.BorderSize = 0;
            yogaPanel1.Controls.Add(dataGridView1);
            yogaPanel1.Controls.Add(yogaButton1);
            yogaPanel1.ForeColor = Color.White;
            yogaPanel1.Location = new Point(28, 88);
            yogaPanel1.Name = "yogaPanel1";
            yogaPanel1.Size = new Size(1086, 453);
            yogaPanel1.TabIndex = 11;
            // 
            // yogaButton1
            // 
            yogaButton1.BackColor = Color.RoyalBlue;
            yogaButton1.BackgroundColor = Color.RoyalBlue;
            yogaButton1.BorderColor = Color.PaleVioletRed;
            yogaButton1.BorderRadius = 6;
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
            ClientSize = new Size(1143, 570);
            Controls.Add(yogaPanel1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Tabel";
            Text = "Tabel";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            yogaPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label2;
        private YogaPanel yogaPanel1;
        private YogaButton yogaButton1;
    }
}