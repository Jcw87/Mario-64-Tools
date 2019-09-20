using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using JeremyAnsel.Media.WavefrontObj;
using N64.F3D;

namespace N64.TextureTool
{
    public class ImageConverter
    {
        private static Int32Rect[][] GenerateTiles(ConvertOptions options)
        {
            var xcount = (options.ImageWidth.Value + options.TileWidth - 1) / options.TileWidth;
            var ycount = (options.ImageHeight.Value + options.TileHeight - 1) / options.TileHeight;

            var starty = 0;
            var rects = new Int32Rect[ycount][];
            for (var y = 0; y < rects.Length; y++)
            {
                var height = Math.Min(options.TileHeight, options.ImageHeight.Value - starty);
                var startx = 0;
                rects[y] = new Int32Rect[xcount];
                for (var x = 0; x < xcount; x++)
                {
                    var width = Math.Min(options.TileWidth, options.ImageWidth.Value - startx);
                    rects[y][x] = new Int32Rect(startx, starty, width, height);
                    startx += width;
                }
                starty += height;
            }
            return rects;
        }

        private static BitmapSource[][] SplitFrame(BitmapSource rawframe, ConvertOptions options)
        {
            var scalex = (double)options.ImageWidth.Value / rawframe.PixelWidth;
            var scaley = (double)options.ImageHeight.Value / rawframe.PixelHeight;
            var frame = new TransformedBitmap(rawframe, new ScaleTransform(scalex, scaley));
            Debug.Assert(frame.PixelWidth == options.ImageWidth.Value);
            Debug.Assert(frame.PixelHeight == options.ImageHeight.Value);

            var xcount = (options.ImageWidth.Value + options.TileWidth - 1) / options.TileWidth;
            var ycount = (options.ImageHeight.Value + options.TileHeight - 1) / options.TileHeight;

            var ret = new BitmapSource[ycount][];

            for (var y = 0; y < ycount; y++)
            {
                ret[y] = new BitmapSource[xcount];
                for (var x = 0; x < xcount; x++)
                {
                    var rect = new Int32Rect(x * options.TileWidth, y * options.TileHeight, options.TileWidth, options.TileHeight);
                    if (rect.X + rect.Width > frame.PixelWidth) rect.Width = frame.PixelWidth - rect.X;
                    if (rect.Y + rect.Height > frame.PixelHeight) rect.Height = frame.PixelHeight - rect.Y;
                    var cropped = new CroppedBitmap(frame, rect);
                    ret[y][x] = cropped;
                }
            }

            return ret;
        }

        private static BitmapSource[][][] SplitImage(IList<BitmapFrame> frames, ConvertOptions options)
        {
            var imagedata = new BitmapSource[frames.Count][][];
            for (var i = 0; i < frames.Count; i++)
            {
                imagedata[i] = SplitFrame(frames[i], options);
            }
            return imagedata;
        }

        private static Vertex[][][] GenerateVertices(ConvertOptions options)
        {
            if (options.OutputType != ConvertOptions.Output.Obj && options.OutputType != ConvertOptions.Output.EndCake) return null;

            var xcount = (options.ImageWidth.Value + options.TileWidth - 1) / options.TileWidth;
            var ycount = (options.ImageHeight.Value + options.TileHeight - 1) / options.TileHeight;

            var normal = new Vector3(0, 0, 1);
            var ret = new Vertex[ycount][][];
            for (var y = 0; y < ycount; y++)
            {
                ret[y] = new Vertex[xcount][];
                for (var x = 0; x < xcount; x++)
                {
                    ret[y][x] = new Vertex[]
                    {
                        new Vertex
                        {
                            Position = new Vector3((x + 0) * options.TileWidth, options.ImageHeight.Value - (y + 1) * options.TileHeight, 0),
                            Normal = normal,
                            UV = new Vector2(0, 1),
                        },
                        new Vertex
                        {
                            Position = new Vector3((x + 1) * options.TileWidth, options.ImageHeight.Value - (y + 1) * options.TileHeight, 0),
                            Normal = normal,
                            UV = new Vector2(1, 1),
                        },
                        new Vertex
                        {
                            Position = new Vector3((x + 1) * options.TileWidth, options.ImageHeight.Value - (y + 0) * options.TileHeight, 0),
                            Normal = normal,
                            UV = new Vector2(1, 0),
                        },
                        new Vertex
                        {
                            Position = new Vector3((x + 0) * options.TileWidth, options.ImageHeight.Value - (y + 0) * options.TileHeight, 0),
                            Normal = normal,
                            UV = new Vector2(0, 0)
                        }
                    };
                }
            }
            return ret;
        }

        private static void WriteObj(Int32Rect[][] tiles, BitmapSource[][][] imagedata, ConvertOptions options)
        {
            var positions = new Dictionary<Vector3, int>();
            var normals = new Dictionary<Vector3, int>();
            var uvs = new Dictionary<Vector2, int>();

            var normal = new Vector3(0, 0, 1);

            var xcount = (options.ImageWidth.Value + options.TileWidth - 1) / options.TileWidth;
            var ycount = (options.ImageHeight.Value + options.TileHeight - 1) / options.TileHeight;

            var folder = Path.GetDirectoryName(options.InputFileName);
            var filename = Path.GetFileNameWithoutExtension(options.InputFileName);

            var mtl = new ObjMaterialFile();
            var obj = new ObjFile();

            obj.MaterialLibraries.Add($"{filename}.mtl");

            for (var y = 0; y < ycount; y++)
            {
                for (var x = 0; x < xcount; x++)
                {
                    var tile = tiles[y][x];
                    var texture = imagedata[0][y][x];
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(texture));
                    var matname = $"{filename}_{y:D3}_{x:D3}";
                    using (var outfile = File.Open(Path.Combine(folder, $"{matname}.png"), FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        encoder.Save(outfile);
                    }

                    var material = new ObjMaterial(matname);
                    material.DiffuseMap = new ObjMaterialMap($"{matname}.png");
                    mtl.Materials.Add(material);
                    var face = new ObjFace();
                    face.MaterialName = matname;
                   
                    face.Vertices.Add(new ObjTriplet(
                        positions.AddUniqueIndex(new Vector3(tile.X, -(tile.Y), 0)),
                        uvs.AddUniqueIndex(new Vector2(0, (float)tile.Height / texture.PixelHeight)),
                        normals.AddUniqueIndex(normal)
                    ));
                    face.Vertices.Add(new ObjTriplet(
                        positions.AddUniqueIndex(new Vector3(tile.X + tile.Width, -(tile.Y), 0)),
                        uvs.AddUniqueIndex(new Vector2((float)tile.Width / texture.PixelWidth, (float)tile.Height / texture.PixelHeight)),
                        normals.AddUniqueIndex(normal)
                    ));
                    face.Vertices.Add(new ObjTriplet(
                        positions.AddUniqueIndex(new Vector3(tile.X + tile.Width, -(tile.Y + tile.Height), 0)),
                        uvs.AddUniqueIndex(new Vector2((float)tile.Width / texture.PixelWidth, 0)),
                        normals.AddUniqueIndex(normal)
                    ));
                    face.Vertices.Add(new ObjTriplet(
                        positions.AddUniqueIndex(new Vector3(tile.X, -(tile.Y + tile.Height), 0)),
                        uvs.AddUniqueIndex(new Vector2(0, 0)),
                        normals.AddUniqueIndex(normal)
                    ));

                    obj.Faces.Add(face);
                }
            }

            (from x in positions orderby x.Value select x.Key).ToList().ForEach(x => obj.Vertices.Add(x.ToObjVertex()));
            (from x in normals orderby x.Value select x.Key).ToList().ForEach(x => obj.VertexNormals.Add(x.ToObjVector3()));
            (from x in uvs orderby x.Value select x.Key).ToList().ForEach(x => obj.TextureVertices.Add(x.ToObjVector3()));

            mtl.WriteTo(Path.Combine(folder, $"{filename}.mtl"));
            obj.WriteTo(Path.Combine(folder, $"{filename}.obj"));
        }

        private static Texture[][][] ToN64Textures(BitmapSource[][][] imagedata, TextureFormat format)
        {
            var framecount = imagedata.Length;
            var textures = new Texture[framecount][][];
            for (var i = 0; i < framecount; i++)
            {
                var ycount = imagedata[i].Length;
                textures[i] = new Texture[ycount][];
                for (var y = 0; y < ycount; y++)
                {
                    var xcount = imagedata[i][y].Length;
                    textures[i][y] = new Texture[xcount];
                    for (var x = 0; x < xcount; x++)
                    {
                        textures[i][y][x] = imagedata[i][y][x].ToN64Texture(format);
                    }
                }
            }
            return textures;
        }

        private static void WriteCake(Int32Rect[][] tiles, Texture[][][] textures, ConvertOptions options)
        {
            var xcount = (options.ImageWidth.Value + options.TileWidth - 1) / options.TileWidth;
            var ycount = (options.ImageHeight.Value + options.TileHeight - 1) / options.TileHeight;

            var folder = Path.GetDirectoryName(options.InputFileName);

            var f3dvertices = new F3D.Vertex[xcount * ycount * 4];
            var displaylist = new DisplayList();

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
                    var xy = y * xcount + x;

                    var tile = tiles[y][x];
                    var texture = textures[0][y][x];

                    short u = (short)(texture.Width * 0x20);
                    short v = (short)(texture.Height * 0x20);

                    f3dvertices[xy * 4 + 0] = new F3D.Vertex { Position = new Vector3s(tile.X,              0xF0 - (tile.Y + tile.Height), -1), U = 0, V = v, Color = color };
                    f3dvertices[xy * 4 + 1] = new F3D.Vertex { Position = new Vector3s(tile.X + tile.Width, 0xF0 - (tile.Y + tile.Height), -1), U = u, V = v, Color = color };
                    f3dvertices[xy * 4 + 2] = new F3D.Vertex { Position = new Vector3s(tile.X + tile.Width, 0xF0 - tile.Y,                 -1), U = u, V = 0, Color = color };
                    f3dvertices[xy * 4 + 3] = new F3D.Vertex { Position = new Vector3s(tile.X,              0xF0 - tile.Y,                 -1), U = 0, V = 0, Color = color };

                    displaylist.Add(new F3D.Commands.SetTImg(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, textureoffset + 0x07000000));
                    displaylist.Add(new F3D.Commands.SetTile(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, 0, 0, 7, 0, 2, 6, 0, 2, 7, 0));
                    displaylist.Add(new F3D.Commands.RdpLoadSync());
                    displaylist.Add(new F3D.Commands.LoadBlock(0, 0, 7, (ushort)(tile.Width * tile.Height), 0x80));
                    displaylist.Add(new F3D.Commands.RdpPipeSync());
                    displaylist.Add(new F3D.Commands.SetTile(F3D.PixelFormat.RGBA, F3D.BitsPerPixel.B16, (byte)(tile.Width / 4), 0, 0, 0, 2, (byte)Math.Log(tile.Height, 2), 0, 2, (byte)Math.Log(tile.Width, 2), 0));
                    displaylist.Add(new F3D.Commands.SetTileSize((ushort)tile.Width, (ushort)tile.Height));
                    displaylist.Add(new F3D.Commands.Vtx(4, 0, (uint)xy * 0x40 + 0x07025800));
                    displaylist.Add(new F3D.Commands.Tri1(0, 1, 2));
                    displaylist.Add(new F3D.Commands.Tri1(0, 2, 3));

                    textureoffset += (uint)(tile.Width * tile.Height * 2);
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
            foreach (var texture in textures) file.Write(texture);
            Debug.Assert(file.Position == 0x00025800);
            foreach (var vertex in f3dvertices) vertex.WriteTo(file);
            file.Position = 0x00026400;
            file.WriteBE(displaylist);
            Debug.Assert(file.Position <= 0x00027350);
            file.Close();
        }

        public static void Convert(ConvertOptions options)
        {
            if (!File.Exists(options.InputFileName)) throw new FileNotFoundException("File does not exist!", options.InputFileName);
            if (options.OutputFolder == null) options.OutputFolder = Path.GetDirectoryName(options.InputFileName);
            if (options.OutputType == ConvertOptions.Output.EndCake)
            {
                options.OutputFormat = TextureFormat.RGBA5551;
                options.ImageWidth = 320;
                options.ImageHeight = 240;
                options.TileWidth = 64;
                options.TileHeight = 32;
            }

            var filename = Path.GetFileNameWithoutExtension(options.InputFileName);

            var uri = new Uri(options.InputFileName);
            var decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            if (!options.ImageWidth.HasValue) options.ImageWidth = decoder.Frames[0].PixelWidth;
            if (!options.ImageHeight.HasValue) options.ImageHeight = decoder.Frames[0].PixelHeight;

            var imagedata = SplitImage(decoder.Frames, options);
            var tiles = GenerateTiles(options);

            if (options.OutputType == ConvertOptions.Output.Obj)
            {
                WriteObj(tiles, imagedata, options);
                return;
            }

            var textures = ToN64Textures(imagedata, options.OutputFormat);

            if (options.OutputType == ConvertOptions.Output.RawImage)
            {
                var outpath = Path.Combine(options.OutputFolder, filename + ".bin");
                var outfile = File.Create(outpath);
                outfile.Write(textures);
                outfile.Close();
                return;
            }

            if (options.OutputType == ConvertOptions.Output.EndCake)
            {
                WriteCake(tiles, textures, options);
                return;
            }

            throw new NotImplementedException();
        }
    }
}
