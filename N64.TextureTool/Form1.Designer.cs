namespace N64.TextureTool
{
    partial class Form1
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
            this.FileName = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonConvert = new System.Windows.Forms.Button();
            this.ButtonSplit = new System.Windows.Forms.Button();
            this.ButtonCake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(30, 33);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(278, 20);
            this.FileName.TabIndex = 0;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(314, 31);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowse.TabIndex = 1;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.OnBrowse);
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "(*.png)|*.png|(*.gif)|*.gif|(*.bmp)|*.bmp|(*.jpg)|*.jpg";
            // 
            // ButtonConvert
            // 
            this.ButtonConvert.Location = new System.Drawing.Point(30, 59);
            this.ButtonConvert.Name = "ButtonConvert";
            this.ButtonConvert.Size = new System.Drawing.Size(75, 23);
            this.ButtonConvert.TabIndex = 2;
            this.ButtonConvert.Text = "Convert";
            this.ButtonConvert.UseVisualStyleBackColor = true;
            this.ButtonConvert.Click += new System.EventHandler(this.OnConvert);
            // 
            // ButtonSplit
            // 
            this.ButtonSplit.Location = new System.Drawing.Point(134, 59);
            this.ButtonSplit.Name = "ButtonSplit";
            this.ButtonSplit.Size = new System.Drawing.Size(75, 23);
            this.ButtonSplit.TabIndex = 3;
            this.ButtonSplit.Text = "Split";
            this.ButtonSplit.UseVisualStyleBackColor = true;
            this.ButtonSplit.Click += new System.EventHandler(this.OnSplit);
            // 
            // ButtonCake
            // 
            this.ButtonCake.Location = new System.Drawing.Point(233, 59);
            this.ButtonCake.Name = "ButtonCake";
            this.ButtonCake.Size = new System.Drawing.Size(75, 23);
            this.ButtonCake.TabIndex = 4;
            this.ButtonCake.Text = "Cake";
            this.ButtonCake.UseVisualStyleBackColor = true;
            this.ButtonCake.Click += new System.EventHandler(this.OnCake);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 109);
            this.Controls.Add(this.ButtonCake);
            this.Controls.Add(this.ButtonSplit);
            this.Controls.Add(this.ButtonConvert);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.FileName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button ButtonConvert;
        private System.Windows.Forms.Button ButtonSplit;
        private System.Windows.Forms.Button ButtonCake;
    }
}

