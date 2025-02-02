using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_Yoga_UKK
{
    public partial class FormInputKaryawan : Form
    {
        public FormInputKaryawan()
        {
            InitializeComponent();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            btnChooseFile.Click += BtnChooseFile_Click;
        }

        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);


                    if (new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK) return;

                    pictureBoxProfile.BackgroundImage = ImageDirectory._imageResult;
                    pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;

                }
            }
        }
    }
}
