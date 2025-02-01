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
    public partial class Image2 : Form
    {
        public static Image _imageResult;
        public Image2()
        {
            InitializeComponent();
            btnEditImage.Click += BtnEditImage_Click;
        }

        private void BtnEditImage_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);


                    if(new ImageCropTest(originalImage).ShowDialog(this) != DialogResult.OK) return;

                    pictureBoxProfile.BackgroundImage = _imageResult;
                    pictureBoxProfile.BackgroundImageLayout = ImageLayout.Zoom;


                    return;
                    pictureBoxProfile.Image = originalImage;

                    int size = Math.Min(pictureBoxProfile.Width, pictureBoxProfile.Height) / 3;
                    //cropRect = new Rectangle((pictureBoxProfile.Width - size) / 2, (pictureBoxProfile.Height - size) / 2, size, size);

                    pictureBoxProfile.Invalidate();
                }
            }
        }
    }
}
