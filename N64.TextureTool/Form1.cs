using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            if (!File.Exists(FileName.Text))
            {
                MessageBox.Show(this, $"File '{FileName.Text}' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var folder = Path.GetDirectoryName(FileName.Text);
            var filename = Path.GetFileNameWithoutExtension(FileName.Text);

            var uri = new Uri(FileName.Text);
            var decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            var outpath = Path.Combine(folder, filename + ".bin");
            var outfile = File.Create(outpath);
            foreach (var frame in decoder.Frames)
            {
                var converted = new ImageRgba5551(frame);
                converted.WriteTo(outfile);
            }
            outfile.Close();

            MessageBox.Show(this, $"Wrote '{outpath}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnSplit(object sender, EventArgs e)
        {
            const int TILE_WIDTH = 64;
            const int TILE_HEIGHT = 32;

            if (!File.Exists(FileName.Text))
            {
                MessageBox.Show(this, $"File '{FileName.Text}' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var folder = Path.GetDirectoryName(FileName.Text);
            var filename = Path.GetFileNameWithoutExtension(FileName.Text);

            var uri = new Uri(FileName.Text);
            var decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            var objpath = Path.Combine(folder, $"{filename}.obj");
            var obj = File.Open(objpath, FileMode.Create, FileAccess.Write, FileShare.None);
            var objwriter = new StreamWriter(obj);

            objwriter.WriteLine($"mtllib {filename}.mtl");
            objwriter.WriteLine($"o {filename}");

            var objmatpath = Path.Combine(folder, $"{filename}.mtl");
            var objmat = File.Open(objmatpath, FileMode.Create, FileAccess.Write, FileShare.None);
            var objmatwriter = new StreamWriter(objmat);

            var image = new FormatConvertedBitmap(decoder.Frames[0], PixelFormats.Bgra32, null, 0);
            if (image.PixelWidth % TILE_WIDTH != 0)
            {
                MessageBox.Show(this, $"Image width must be a multiple of {TILE_WIDTH}. Width is {image.PixelWidth}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (image.PixelHeight % TILE_HEIGHT != 0)
            {
                MessageBox.Show(this, $"Image height must be a multiple of {TILE_HEIGHT}. Height is {image.PixelHeight}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var xcount = image.PixelWidth / TILE_WIDTH;
            var ycount = image.PixelHeight / TILE_HEIGHT;

            for (var y = 0; y <= ycount; y++)
            {
                for (var x = 0; x <= xcount; x++)
                {
                    objwriter.WriteLine($"v {x * 2} {-y} 0");
                }
            }

            objwriter.WriteLine("vt 0 1");
            objwriter.WriteLine("vt 1 1");
            objwriter.WriteLine("vt 0 0");
            objwriter.WriteLine("vt 1 0");
            objwriter.WriteLine("vn 0 0 1");

            for (var y = 0; y < ycount; y++)
            {
                for (var x = 0; x < xcount; x++)
                {
                    var rect = new Int32Rect(x * TILE_WIDTH, y * TILE_HEIGHT, TILE_WIDTH, TILE_HEIGHT);
                    var cropped = new CroppedBitmap(image, rect);
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(cropped));
                    var outfname = $"{filename}_{y:D3}_{x:D3}";
                    using (var outfile = File.Open(Path.Combine(folder, $"{outfname}.png"), FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        encoder.Save(outfile);
                    }

                    objmatwriter.WriteLine();
                    objmatwriter.WriteLine($"newmtl {outfname}");
                    objmatwriter.WriteLine("Ns 96.078431");
                    objmatwriter.WriteLine("Ka 1.000000 1.000000 1.000000");
                    objmatwriter.WriteLine("Kd 0.640000 0.640000 0.640000");
                    objmatwriter.WriteLine("Ks 0.500000 0.500000 0.500000");
                    objmatwriter.WriteLine("Ke 0.000000 0.000000 0.000000");
                    objmatwriter.WriteLine("Ni 1.000000");
                    objmatwriter.WriteLine("d 1.000000");
                    objmatwriter.WriteLine("illum 2");
                    objmatwriter.WriteLine($"map_Kd {outfname}.png");

                    objwriter.WriteLine($"usemtl {outfname}");
                    var v1 = y * (xcount + 1) + x + 1;
                    var v2 = v1 + 1;
                    var v3 = (y + 1) * (xcount + 1) + x + 1;
                    var v4 = v3 + 1;
                    objwriter.WriteLine($"f {v1}/1/1 {v3}/3/1 {v4}/4/1 {v2}/2/1");
                }
            }

            objwriter.Dispose();
            objmatwriter.Dispose();
            obj.Dispose();
            objmat.Dispose();

            MessageBox.Show(this, $"Wrote '{objpath}' with {xcount * ycount} tiles.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnCake(object sender, EventArgs e)
        {
            const int TILE_WIDTH = 64;
            const int TILE_HEIGHT = 32;

            if (!File.Exists(FileName.Text))
            {
                MessageBox.Show(this, $"File '{FileName.Text}' does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var folder = Path.GetDirectoryName(FileName.Text);
            var filename = Path.GetFileNameWithoutExtension(FileName.Text);

            var uri = new Uri(FileName.Text);
            var decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            BitmapSource image = new FormatConvertedBitmap(decoder.Frames[0], PixelFormats.Bgra32, null, 0);
            var scalex = 320.0 / image.PixelWidth;
            var scaley = 240.0 / image.PixelHeight;
            image = new TransformedBitmap(image, new ScaleTransform(scalex, scaley));
            Debug.Assert(image.PixelWidth == 320);
            Debug.Assert(image.PixelHeight == 240);

            var xcount = (image.PixelWidth + TILE_WIDTH - 1)/ TILE_WIDTH;
            var ycount = (image.PixelHeight + TILE_HEIGHT - 1)/ TILE_HEIGHT;

            var textures = new ImageRgba5551[xcount * ycount];
            var vertices = new F3D.Vertex[xcount * ycount * 4];
            var displaylist = new F3D.DisplayList();

            displaylist.Add(new F3D.Commands.RdpPipeSync());
            displaylist.Add(new F3D.Commands.SetCombine(0xFCFFFFFFFFFCF87C));
            displaylist.Add(new F3D.Commands.SetOtherModeL(0x03, 0x1D, 0x00552048));
            displaylist.Add(new F3D.Commands.Texture(0, 0, 1, 0xFFFF, 0xFFFF));

            var color = new Color(0xFF, 0xFF, 0xFF, 0xFF);
            uint textureoffset = 0;

            for (var y = 0; y < ycount; y++)
            {
                for (var x = 0; x < xcount; x++)
                {
                    var i = y * xcount + x;

                    var rect = new Int32Rect(x * TILE_WIDTH, y * TILE_HEIGHT, TILE_WIDTH, TILE_HEIGHT);
                    if (rect.X + rect.Width > image.PixelWidth) rect.Width = image.PixelWidth - rect.X;
                    if (rect.Y + rect.Height > image.PixelHeight) rect.Height = image.PixelHeight - rect.Y;
                    var cropped = new CroppedBitmap(image, rect);
                    textures[i] = new ImageRgba5551(cropped);

                    vertices[i * 4 + 0] = new F3D.Vertex { Position = new Vector3s((x + 0) * 0x40, 0xF0 - (y + 1) * 0x20, -1), U = 0x0000, V = 0x0400, Color = color };
                    vertices[i * 4 + 1] = new F3D.Vertex { Position = new Vector3s((x + 1) * 0x40, 0xF0 - (y + 1) * 0x20, -1), U = 0x0800, V = 0x0400, Color = color };
                    vertices[i * 4 + 2] = new F3D.Vertex { Position = new Vector3s((x + 1) * 0x40, 0xF0 - (y + 0) * 0x20, -1), U = 0x0800, V = 0x0000, Color = color };
                    vertices[i * 4 + 3] = new F3D.Vertex { Position = new Vector3s((x + 0) * 0x40, 0xF0 - (y + 0) * 0x20, -1), U = 0x0000, V = 0x0000, Color = color };

                    displaylist.Add(new F3D.Commands.SetTImg(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, textureoffset + 0x07000000));
                    displaylist.Add(new F3D.Commands.SetTile(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, 0, 0, 7, 0, 2, 6, 0, 2, 7, 0));
                    displaylist.Add(new F3D.Commands.RdpLoadSync());
                    displaylist.Add(new F3D.Commands.LoadBlock(0, 0, 7, (ushort)(rect.Width * rect.Height), 0x80));
                    displaylist.Add(new F3D.Commands.RdpPipeSync());
                    displaylist.Add(new F3D.Commands.SetTile(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, (byte)(rect.Width / 4), 0, 0, 0, 2, (byte)Math.Log(rect.Height, 2), 0, 2, (byte)Math.Log(rect.Width, 2), 0));
                    displaylist.Add(new F3D.Commands.SetTileSize((ushort)rect.Width, (ushort)rect.Height));
                    displaylist.Add(new F3D.Commands.Vtx(4, 0, (uint)i * 0x40 + 0x07025800));
                    displaylist.Add(new F3D.Commands.Tri1(0, 1, 2));
                    displaylist.Add(new F3D.Commands.Tri1(0, 2, 3));

                    textureoffset += (uint)(rect.Width * rect.Height * 2);
                }
            }

            displaylist.Add(new F3D.Commands.RdpPipeSync());
            displaylist.Add(new F3D.Commands.Texture(0, 0, 0, 0xFFFF, 0xFFFF));
            displaylist.Add(new F3D.Commands.SetGeometryMode(F3D.GeometryMode.Lighting));
            displaylist.Add(new F3D.Commands.SetCombine(0xFCFFFFFFFFFE793C));
            displaylist.Add(new F3D.Commands.SetOtherModeL(3, 0x1D, 0x00552078));

            var outpath = Path.Combine(folder, "endcake.bin");
            var file = File.Open(outpath, FileMode.Create, FileAccess.Write, FileShare.None);
            file.SetLength(0x00027350);
            foreach (var texture in textures) texture.WriteTo(file);
            Debug.Assert(file.Position == 0x00025800);
            foreach (var vertex in vertices) vertex.WriteTo(file);
            file.Position = 0x00026400;
            displaylist.WriteTo(file);
            Debug.Assert(file.Position <= 0x00027350);
            file.Close();

            MessageBox.Show(this, $"Wrote '{outpath}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
