using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using N64.F3D;

namespace N64.TextureTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnBrowse(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            FileName.Text = FileDialog.FileName;
        }

        private void OnConvert(object sender, EventArgs e)
        {
            var options = new ConvertOptions
            {
                InputFileName = FileName.Text,
                OutputType = ConvertOptions.Output.RawImage,
                OutputFormat = TextureFormat.RGBA5551,
                TileWidth = 32,
                TileHeight = 32,
            };

            ImageConverter.Convert(options);
        }

        private void OnSplit(object sender, EventArgs e)
        {
            var options = new ConvertOptions
            {
                InputFileName = FileName.Text,
                OutputType = ConvertOptions.Output.Obj,
                OutputFormat = TextureFormat.RGBA5551,
                TileWidth = 64,
                TileHeight = 32,
            };

            ImageConverter.Convert(options);
        }

        private void OnCake(object sender, EventArgs e)
        {
            var options = new ConvertOptions
            {
                InputFileName = FileName.Text,
                OutputType = ConvertOptions.Output.EndCake,
                OutputFormat = TextureFormat.RGBA5551,
                TileWidth = 64,
                TileHeight = 32,
            };

            ImageConverter.Convert(options);
        }
    }
}
