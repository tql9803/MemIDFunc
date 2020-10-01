namespace MemIDFunc_namespace.Forms
{
    partial class CapturePicture
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
            this.VVideoSource = new AForge.Controls.VideoSourcePlayer();
            this.pBPicture = new AForge.Controls.PictureBox();
            this.bCapture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // VVideoSource
            // 
            this.VVideoSource.Location = new System.Drawing.Point(24, 170);
            this.VVideoSource.Name = "VVideoSource";
            this.VVideoSource.Size = new System.Drawing.Size(361, 346);
            this.VVideoSource.TabIndex = 0;
            this.VVideoSource.Text = "videoSourcePlayer1";
            this.VVideoSource.VideoSource = null;
            // 
            // pBPicture
            // 
            this.pBPicture.Image = null;
            this.pBPicture.InitialImage = global::MemIDFunc_namespace.Properties.Resources.Logo11;
            this.pBPicture.Location = new System.Drawing.Point(402, 172);
            this.pBPicture.Name = "pBPicture";
            this.pBPicture.Size = new System.Drawing.Size(357, 343);
            this.pBPicture.TabIndex = 1;
            this.pBPicture.TabStop = false;
            // 
            // bCapture
            // 
            this.bCapture.Enabled = false;
            this.bCapture.Location = new System.Drawing.Point(456, 55);
            this.bCapture.Name = "bCapture";
            this.bCapture.Size = new System.Drawing.Size(75, 22);
            this.bCapture.TabIndex = 12;
            this.bCapture.Text = "Capture";
            this.bCapture.UseVisualStyleBackColor = true;
            this.bCapture.Click += new System.EventHandler(this.bCapture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Camera";
            // 
            // bSave
            // 
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(375, 84);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 9;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(375, 55);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 10;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(248, 57);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(121, 21);
            this.cbCamera.TabIndex = 8;
            // 
            // CapturePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 542);
            this.Controls.Add(this.bCapture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.pBPicture);
            this.Controls.Add(this.VVideoSource);
            this.Name = "CapturePicture";
            this.Text = "CapturePicture";
            this.Load += new System.EventHandler(this.CapturePicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer VVideoSource;
        private AForge.Controls.PictureBox pBPicture;
        private System.Windows.Forms.Button bCapture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox cbCamera;
    }
}