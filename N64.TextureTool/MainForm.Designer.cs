namespace N64.TextureTool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.GroupPaths = new System.Windows.Forms.GroupBox();
            this.TablePaths = new System.Windows.Forms.TableLayoutPanel();
            this.LabelInputFile = new System.Windows.Forms.Label();
            this.InputFile = new System.Windows.Forms.TextBox();
            this.OptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonInputBrowse = new System.Windows.Forms.Button();
            this.LabelOutputFolder = new System.Windows.Forms.Label();
            this.OutputFolder = new System.Windows.Forms.TextBox();
            this.ButtonOutputBrowse = new System.Windows.Forms.Button();
            this.TableMid = new System.Windows.Forms.TableLayoutPanel();
            this.GroupOutput = new System.Windows.Forms.GroupBox();
            this.TableOutput = new System.Windows.Forms.TableLayoutPanel();
            this.LabelOutputType = new System.Windows.Forms.Label();
            this.OutputType = new System.Windows.Forms.ComboBox();
            this.LabelOutputFormat = new System.Windows.Forms.Label();
            this.OutputFormat = new System.Windows.Forms.ComboBox();
            this.GroupImage = new System.Windows.Forms.GroupBox();
            this.TableImage = new System.Windows.Forms.TableLayoutPanel();
            this.LabelImageWidth = new System.Windows.Forms.Label();
            this.ImageWidth = new System.Windows.Forms.TextBox();
            this.LabelImageHeight = new System.Windows.Forms.Label();
            this.ImageHeight = new System.Windows.Forms.TextBox();
            this.GroupTile = new System.Windows.Forms.GroupBox();
            this.TableTile = new System.Windows.Forms.TableLayoutPanel();
            this.LabelTileWidth = new System.Windows.Forms.Label();
            this.TileWidth = new System.Windows.Forms.TextBox();
            this.LabelTileHeight = new System.Windows.Forms.Label();
            this.TileHeight = new System.Windows.Forms.TextBox();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonConvert = new System.Windows.Forms.Button();
            this.GroupPaths.SuspendLayout();
            this.TablePaths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsBindingSource)).BeginInit();
            this.TableMid.SuspendLayout();
            this.GroupOutput.SuspendLayout();
            this.TableOutput.SuspendLayout();
            this.GroupImage.SuspendLayout();
            this.TableImage.SuspendLayout();
            this.GroupTile.SuspendLayout();
            this.TableTile.SuspendLayout();
            this.TableButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "(*.png)|*.png|(*.gif)|*.gif|(*.bmp)|*.bmp|(*.jpg)|*.jpg";
            // 
            // GroupPaths
            // 
            this.GroupPaths.AutoSize = true;
            this.GroupPaths.Controls.Add(this.TablePaths);
            this.GroupPaths.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupPaths.Location = new System.Drawing.Point(0, 0);
            this.GroupPaths.Name = "GroupPaths";
            this.GroupPaths.Size = new System.Drawing.Size(415, 77);
            this.GroupPaths.TabIndex = 0;
            this.GroupPaths.TabStop = false;
            this.GroupPaths.Text = "Paths";
            // 
            // TablePaths
            // 
            this.TablePaths.AutoSize = true;
            this.TablePaths.ColumnCount = 3;
            this.TablePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TablePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TablePaths.Controls.Add(this.LabelInputFile, 0, 0);
            this.TablePaths.Controls.Add(this.InputFile, 1, 0);
            this.TablePaths.Controls.Add(this.ButtonInputBrowse, 2, 0);
            this.TablePaths.Controls.Add(this.LabelOutputFolder, 0, 1);
            this.TablePaths.Controls.Add(this.OutputFolder, 1, 1);
            this.TablePaths.Controls.Add(this.ButtonOutputBrowse, 2, 1);
            this.TablePaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePaths.Location = new System.Drawing.Point(3, 16);
            this.TablePaths.Name = "TablePaths";
            this.TablePaths.RowCount = 2;
            this.TablePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TablePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TablePaths.Size = new System.Drawing.Size(409, 58);
            this.TablePaths.TabIndex = 0;
            // 
            // LabelInputFile
            // 
            this.LabelInputFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelInputFile.AutoSize = true;
            this.LabelInputFile.Location = new System.Drawing.Point(11, 8);
            this.LabelInputFile.Name = "LabelInputFile";
            this.LabelInputFile.Size = new System.Drawing.Size(66, 13);
            this.LabelInputFile.TabIndex = 0;
            this.LabelInputFile.Text = "Input Image:";
            // 
            // InputFile
            // 
            this.InputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OptionsBindingSource, "InputFileName", true));
            this.InputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputFile.Location = new System.Drawing.Point(83, 3);
            this.InputFile.Name = "InputFile";
            this.InputFile.Size = new System.Drawing.Size(242, 20);
            this.InputFile.TabIndex = 0;
            // 
            // OptionsBindingSource
            // 
            this.OptionsBindingSource.DataSource = typeof(N64.TextureTool.ConvertOptions);
            // 
            // ButtonInputBrowse
            // 
            this.ButtonInputBrowse.Location = new System.Drawing.Point(331, 3);
            this.ButtonInputBrowse.Name = "ButtonInputBrowse";
            this.ButtonInputBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonInputBrowse.TabIndex = 0;
            this.ButtonInputBrowse.Text = "Browse";
            this.ButtonInputBrowse.UseVisualStyleBackColor = true;
            this.ButtonInputBrowse.Click += new System.EventHandler(this.OnInputBrowse);
            // 
            // LabelOutputFolder
            // 
            this.LabelOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelOutputFolder.AutoSize = true;
            this.LabelOutputFolder.Location = new System.Drawing.Point(3, 37);
            this.LabelOutputFolder.Name = "LabelOutputFolder";
            this.LabelOutputFolder.Size = new System.Drawing.Size(74, 13);
            this.LabelOutputFolder.TabIndex = 0;
            this.LabelOutputFolder.Text = "Output Folder:";
            // 
            // OutputFolder
            // 
            this.OutputFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OptionsBindingSource, "OutputFolder", true));
            this.OutputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputFolder.Location = new System.Drawing.Point(83, 32);
            this.OutputFolder.Name = "OutputFolder";
            this.OutputFolder.Size = new System.Drawing.Size(242, 20);
            this.OutputFolder.TabIndex = 0;
            // 
            // ButtonOutputBrowse
            // 
            this.ButtonOutputBrowse.Location = new System.Drawing.Point(331, 32);
            this.ButtonOutputBrowse.Name = "ButtonOutputBrowse";
            this.ButtonOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonOutputBrowse.TabIndex = 0;
            this.ButtonOutputBrowse.Text = "Browse";
            this.ButtonOutputBrowse.UseVisualStyleBackColor = true;
            this.ButtonOutputBrowse.Click += new System.EventHandler(this.OnOutputBrowse);
            // 
            // TableMid
            // 
            this.TableMid.AutoSize = true;
            this.TableMid.ColumnCount = 3;
            this.TableMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableMid.Controls.Add(this.GroupOutput, 0, 0);
            this.TableMid.Controls.Add(this.GroupImage, 1, 0);
            this.TableMid.Controls.Add(this.GroupTile, 2, 0);
            this.TableMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableMid.Location = new System.Drawing.Point(0, 77);
            this.TableMid.Name = "TableMid";
            this.TableMid.RowCount = 1;
            this.TableMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableMid.Size = new System.Drawing.Size(415, 79);
            this.TableMid.TabIndex = 27;
            // 
            // GroupOutput
            // 
            this.GroupOutput.AutoSize = true;
            this.GroupOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupOutput.Controls.Add(this.TableOutput);
            this.GroupOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupOutput.Location = new System.Drawing.Point(3, 3);
            this.GroupOutput.Name = "GroupOutput";
            this.GroupOutput.Size = new System.Drawing.Size(183, 73);
            this.GroupOutput.TabIndex = 0;
            this.GroupOutput.TabStop = false;
            this.GroupOutput.Text = "Output";
            // 
            // TableOutput
            // 
            this.TableOutput.AutoSize = true;
            this.TableOutput.ColumnCount = 2;
            this.TableOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableOutput.Controls.Add(this.LabelOutputType, 0, 0);
            this.TableOutput.Controls.Add(this.OutputType, 1, 0);
            this.TableOutput.Controls.Add(this.LabelOutputFormat, 0, 1);
            this.TableOutput.Controls.Add(this.OutputFormat, 1, 1);
            this.TableOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableOutput.Location = new System.Drawing.Point(3, 16);
            this.TableOutput.Name = "TableOutput";
            this.TableOutput.RowCount = 2;
            this.TableOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableOutput.Size = new System.Drawing.Size(177, 54);
            this.TableOutput.TabIndex = 0;
            // 
            // LabelOutputType
            // 
            this.LabelOutputType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelOutputType.AutoSize = true;
            this.LabelOutputType.Location = new System.Drawing.Point(11, 7);
            this.LabelOutputType.Name = "LabelOutputType";
            this.LabelOutputType.Size = new System.Drawing.Size(34, 13);
            this.LabelOutputType.TabIndex = 0;
            this.LabelOutputType.Text = "Type:";
            // 
            // OutputType
            // 
            this.OutputType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.OptionsBindingSource, "OutputType", true));
            this.OutputType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputType.FormattingEnabled = true;
            this.OutputType.Location = new System.Drawing.Point(51, 3);
            this.OutputType.Name = "OutputType";
            this.OutputType.Size = new System.Drawing.Size(123, 21);
            this.OutputType.TabIndex = 0;
            this.OutputType.SelectionChangeCommitted += new System.EventHandler(this.OnOutputTypeChanged);
            // 
            // LabelOutputFormat
            // 
            this.LabelOutputFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelOutputFormat.AutoSize = true;
            this.LabelOutputFormat.Location = new System.Drawing.Point(3, 34);
            this.LabelOutputFormat.Name = "LabelOutputFormat";
            this.LabelOutputFormat.Size = new System.Drawing.Size(42, 13);
            this.LabelOutputFormat.TabIndex = 0;
            this.LabelOutputFormat.Text = "Format:";
            // 
            // OutputFormat
            // 
            this.OutputFormat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.OptionsBindingSource, "OutputFormat", true));
            this.OutputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputFormat.FormattingEnabled = true;
            this.OutputFormat.Location = new System.Drawing.Point(51, 30);
            this.OutputFormat.Name = "OutputFormat";
            this.OutputFormat.Size = new System.Drawing.Size(123, 21);
            this.OutputFormat.TabIndex = 0;
            // 
            // GroupImage
            // 
            this.GroupImage.AutoSize = true;
            this.GroupImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupImage.Controls.Add(this.TableImage);
            this.GroupImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupImage.Location = new System.Drawing.Point(192, 3);
            this.GroupImage.Name = "GroupImage";
            this.GroupImage.Size = new System.Drawing.Size(107, 73);
            this.GroupImage.TabIndex = 0;
            this.GroupImage.TabStop = false;
            this.GroupImage.Text = "Image";
            // 
            // TableImage
            // 
            this.TableImage.AutoSize = true;
            this.TableImage.ColumnCount = 2;
            this.TableImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableImage.Controls.Add(this.LabelImageWidth, 0, 0);
            this.TableImage.Controls.Add(this.ImageWidth, 1, 0);
            this.TableImage.Controls.Add(this.LabelImageHeight, 0, 1);
            this.TableImage.Controls.Add(this.ImageHeight, 1, 1);
            this.TableImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableImage.Location = new System.Drawing.Point(3, 16);
            this.TableImage.Name = "TableImage";
            this.TableImage.RowCount = 2;
            this.TableImage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableImage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableImage.Size = new System.Drawing.Size(101, 54);
            this.TableImage.TabIndex = 0;
            // 
            // LabelImageWidth
            // 
            this.LabelImageWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelImageWidth.AutoSize = true;
            this.LabelImageWidth.Location = new System.Drawing.Point(6, 6);
            this.LabelImageWidth.Name = "LabelImageWidth";
            this.LabelImageWidth.Size = new System.Drawing.Size(38, 13);
            this.LabelImageWidth.TabIndex = 0;
            this.LabelImageWidth.Text = "Width:";
            // 
            // ImageWidth
            // 
            this.ImageWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageWidth.Location = new System.Drawing.Point(50, 3);
            this.ImageWidth.Name = "ImageWidth";
            this.ImageWidth.Size = new System.Drawing.Size(48, 20);
            this.ImageWidth.TabIndex = 0;
            // 
            // LabelImageHeight
            // 
            this.LabelImageHeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelImageHeight.AutoSize = true;
            this.LabelImageHeight.Location = new System.Drawing.Point(3, 33);
            this.LabelImageHeight.Name = "LabelImageHeight";
            this.LabelImageHeight.Size = new System.Drawing.Size(41, 13);
            this.LabelImageHeight.TabIndex = 0;
            this.LabelImageHeight.Text = "Height:";
            // 
            // ImageHeight
            // 
            this.ImageHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageHeight.Location = new System.Drawing.Point(50, 29);
            this.ImageHeight.Name = "ImageHeight";
            this.ImageHeight.Size = new System.Drawing.Size(48, 20);
            this.ImageHeight.TabIndex = 0;
            // 
            // GroupTile
            // 
            this.GroupTile.AutoSize = true;
            this.GroupTile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupTile.Controls.Add(this.TableTile);
            this.GroupTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupTile.Location = new System.Drawing.Point(305, 3);
            this.GroupTile.Name = "GroupTile";
            this.GroupTile.Size = new System.Drawing.Size(107, 73);
            this.GroupTile.TabIndex = 0;
            this.GroupTile.TabStop = false;
            this.GroupTile.Text = "Tile";
            // 
            // TableTile
            // 
            this.TableTile.AutoSize = true;
            this.TableTile.ColumnCount = 2;
            this.TableTile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableTile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableTile.Controls.Add(this.LabelTileWidth, 0, 0);
            this.TableTile.Controls.Add(this.TileWidth, 1, 0);
            this.TableTile.Controls.Add(this.LabelTileHeight, 0, 1);
            this.TableTile.Controls.Add(this.TileHeight, 1, 1);
            this.TableTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableTile.Location = new System.Drawing.Point(3, 16);
            this.TableTile.Name = "TableTile";
            this.TableTile.RowCount = 2;
            this.TableTile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableTile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableTile.Size = new System.Drawing.Size(101, 54);
            this.TableTile.TabIndex = 0;
            // 
            // LabelTileWidth
            // 
            this.LabelTileWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelTileWidth.AutoSize = true;
            this.LabelTileWidth.Location = new System.Drawing.Point(6, 6);
            this.LabelTileWidth.Name = "LabelTileWidth";
            this.LabelTileWidth.Size = new System.Drawing.Size(38, 13);
            this.LabelTileWidth.TabIndex = 0;
            this.LabelTileWidth.Text = "Width:";
            // 
            // TileWidth
            // 
            this.TileWidth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OptionsBindingSource, "TileWidth", true));
            this.TileWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileWidth.Location = new System.Drawing.Point(50, 3);
            this.TileWidth.Name = "TileWidth";
            this.TileWidth.Size = new System.Drawing.Size(48, 20);
            this.TileWidth.TabIndex = 0;
            this.TileWidth.Validated += new System.EventHandler(this.OnTileSizeChanged);
            // 
            // LabelTileHeight
            // 
            this.LabelTileHeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelTileHeight.AutoSize = true;
            this.LabelTileHeight.Location = new System.Drawing.Point(3, 33);
            this.LabelTileHeight.Name = "LabelTileHeight";
            this.LabelTileHeight.Size = new System.Drawing.Size(41, 13);
            this.LabelTileHeight.TabIndex = 0;
            this.LabelTileHeight.Text = "Height:";
            // 
            // TileHeight
            // 
            this.TileHeight.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OptionsBindingSource, "TileHeight", true));
            this.TileHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileHeight.Location = new System.Drawing.Point(50, 29);
            this.TileHeight.Name = "TileHeight";
            this.TileHeight.Size = new System.Drawing.Size(48, 20);
            this.TileHeight.TabIndex = 0;
            this.TileHeight.Validated += new System.EventHandler(this.OnTileSizeChanged);
            // 
            // TableButtons
            // 
            this.TableButtons.AutoSize = true;
            this.TableButtons.ColumnCount = 2;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableButtons.Controls.Add(this.ButtonConvert, 1, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableButtons.Location = new System.Drawing.Point(0, 156);
            this.TableButtons.Name = "TableButtons";
            this.TableButtons.RowCount = 1;
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableButtons.Size = new System.Drawing.Size(415, 34);
            this.TableButtons.TabIndex = 0;
            // 
            // ButtonConvert
            // 
            this.ButtonConvert.Location = new System.Drawing.Point(337, 3);
            this.ButtonConvert.Name = "ButtonConvert";
            this.ButtonConvert.Size = new System.Drawing.Size(75, 23);
            this.ButtonConvert.TabIndex = 0;
            this.ButtonConvert.Text = "Convert";
            this.ButtonConvert.UseVisualStyleBackColor = true;
            this.ButtonConvert.Click += new System.EventHandler(this.OnConvert);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 190);
            this.Controls.Add(this.TableButtons);
            this.Controls.Add(this.TableMid);
            this.Controls.Add(this.GroupPaths);
            this.Name = "MainForm";
            this.Text = "N64.TextureTool";
            this.GroupPaths.ResumeLayout(false);
            this.GroupPaths.PerformLayout();
            this.TablePaths.ResumeLayout(false);
            this.TablePaths.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsBindingSource)).EndInit();
            this.TableMid.ResumeLayout(false);
            this.TableMid.PerformLayout();
            this.GroupOutput.ResumeLayout(false);
            this.GroupOutput.PerformLayout();
            this.TableOutput.ResumeLayout(false);
            this.TableOutput.PerformLayout();
            this.GroupImage.ResumeLayout(false);
            this.GroupImage.PerformLayout();
            this.TableImage.ResumeLayout(false);
            this.TableImage.PerformLayout();
            this.GroupTile.ResumeLayout(false);
            this.GroupTile.PerformLayout();
            this.TableTile.ResumeLayout(false);
            this.TableTile.PerformLayout();
            this.TableButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource OptionsBindingSource;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.GroupBox GroupPaths;
        private System.Windows.Forms.TableLayoutPanel TablePaths;
        private System.Windows.Forms.Label LabelInputFile;
        private System.Windows.Forms.TextBox InputFile;
        private System.Windows.Forms.Button ButtonInputBrowse;
        private System.Windows.Forms.Label LabelOutputFolder;
        private System.Windows.Forms.TextBox OutputFolder;
        private System.Windows.Forms.Button ButtonOutputBrowse;
        private System.Windows.Forms.TableLayoutPanel TableMid;
        private System.Windows.Forms.GroupBox GroupOutput;
        private System.Windows.Forms.TableLayoutPanel TableOutput;
        private System.Windows.Forms.Label LabelOutputType;
        private System.Windows.Forms.ComboBox OutputType;
        private System.Windows.Forms.Label LabelOutputFormat;
        private System.Windows.Forms.ComboBox OutputFormat;
        private System.Windows.Forms.GroupBox GroupImage;
        private System.Windows.Forms.TableLayoutPanel TableImage;
        private System.Windows.Forms.Label LabelImageWidth;
        private System.Windows.Forms.TextBox ImageWidth;
        private System.Windows.Forms.Label LabelImageHeight;
        private System.Windows.Forms.TextBox ImageHeight;
        private System.Windows.Forms.GroupBox GroupTile;
        private System.Windows.Forms.TableLayoutPanel TableTile;
        private System.Windows.Forms.Label LabelTileWidth;
        private System.Windows.Forms.TextBox TileWidth;
        private System.Windows.Forms.Label LabelTileHeight;
        private System.Windows.Forms.TextBox TileHeight;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button ButtonConvert;
    }
}

