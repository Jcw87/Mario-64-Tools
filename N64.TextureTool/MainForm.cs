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
    public partial class MainForm : Form
    {
        private ConvertOptions Options;

        public MainForm()
        {
            InitializeComponent();

            Options = new ConvertOptions
            {
                TileWidth = 32,
                TileHeight = 32,
            };

            // TextBox controls have issues binding to nullable integers when using the form designer, so bind them manually
            ImageWidth.DataBindings.Add(new Binding("Text", OptionsBindingSource, "ImageWidth", true, DataSourceUpdateMode.OnPropertyChanged, String.Empty));
            ImageHeight.DataBindings.Add(new Binding("Text", OptionsBindingSource, "ImageHeight", true, DataSourceUpdateMode.OnPropertyChanged, String.Empty));

            OutputType.DataSource = Enum.GetValues(typeof(ConvertOptions.Output));
            OutputFormat.DataSource = Enum.GetValues(typeof(TextureFormat));

            OptionsBindingSource.DataSource = Options;
        }

        private void OnInputBrowse(object sender, EventArgs e)
        {
            var dir = Options.InputFileName ?? "";
            try
            {
                while (!Directory.Exists(dir)) dir = Path.GetDirectoryName(dir);
            }
            catch (ArgumentException ex)
            {
                dir = Directory.GetCurrentDirectory();
            }
            FileDialog.InitialDirectory = dir;

            var result = FileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Options.InputFileName = FileDialog.FileName;
            if (String.IsNullOrEmpty(Options.OutputFolder)) Options.OutputFolder = Path.GetDirectoryName(Options.InputFileName);
            OptionsBindingSource.ResetCurrentItem();
        }

        private void OnOutputBrowse(object sender, EventArgs e)
        {
            FolderDialog.SelectedPath = OutputFolder.Text;

            var result = FolderDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            OutputFolder.Text = FolderDialog.SelectedPath;
        }

        private void OnOutputTypeChanged(object sender, EventArgs e)
        {
            if ((ConvertOptions.Output)OutputType.SelectedItem == ConvertOptions.Output.EndCake)
            {
                Options.OutputType = ConvertOptions.Output.EndCake;
                Options.OutputFormat = TextureFormat.RGBA5551;
                Options.ImageWidth = 320;
                Options.ImageHeight = 240;
                Options.TileWidth = 64;
                Options.TileHeight = 32;
                OptionsBindingSource.ResetCurrentItem();

                OutputFormat.Enabled = false;
                ImageWidth.Enabled = false;
                ImageHeight.Enabled = false;
                TileWidth.Enabled = false;
                TileHeight.Enabled = false;
            }
            else
            {
                OutputFormat.Enabled = true;
                ImageWidth.Enabled = true;
                ImageHeight.Enabled = true;
                TileWidth.Enabled = true;
                TileHeight.Enabled = true;
            }
        }

        private void OnTileSizeChanged(object sender, EventArgs e)
        {
            var ctrl = (TextBox)sender;
            int value;
            if (!Int32.TryParse(ctrl.Text, out value)) return;
            value = Tile.NextPowerOf2(value);
            ctrl.Text = value.ToString();
        }

        private void OnConvert(object sender, EventArgs e)
        {
            ImageConverter.Convert((ConvertOptions)Options.Clone());
        }

        /*
        private void OnConvert(object sender, EventArgs e)
        {
            var options = new ConvertOptions
            {
                InputFileName = InputFile.Text,
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
                InputFileName = InputFile.Text,
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
                InputFileName = InputFile.Text,
                OutputType = ConvertOptions.Output.EndCake,
                OutputFormat = TextureFormat.RGBA5551,
                TileWidth = 64,
                TileHeight = 32,
            };

            ImageConverter.Convert(options);
        }
        */
    }
}
