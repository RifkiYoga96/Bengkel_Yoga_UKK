namespace Bengkel_Yoga_UKK
{
    partial class Form3
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
            button1 = new Button();
            sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(87, 395);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // sfButton1
            // 
            sfButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            sfButton1.Location = new Point(178, 353);
            sfButton1.Name = "sfButton1";
            sfButton1.Size = new Size(96, 28);
            sfButton1.TabIndex = 2;
            sfButton1.Text = "sfButton1";
            // 
            // sfButton2
            // 
            sfButton2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            sfButton2.Location = new Point(286, 125);
            sfButton2.Name = "sfButton2";
            sfButton2.Size = new Size(96, 28);
            sfButton2.TabIndex = 3;
            sfButton2.Text = "sfButton2";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 508);
            Controls.Add(sfButton2);
            Controls.Add(sfButton1);
            Controls.Add(button1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
    }
}