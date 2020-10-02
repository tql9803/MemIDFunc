using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using Microsoft.Office.Interop.Word;

namespace MemIDFunc_namespace.Forms
{
    public partial class CapturePicture : Form
    {
        private FilterInfoCollection videoDevices;
        public System.Drawing.Image SaveImage;

        public delegate void ImageSaved(object sender, EventArgs e);
        public event ImageSaved EventImageSaved ;

        public bool bSavedToImage = false;
        public CapturePicture()
        { 
            InitializeComponent();
        }

        private void CapturePicture_Load(object sender, EventArgs e)
        {
            UpdateVideoDevices();
        }

        public void ImageIsSaved()
        {
            if (EventImageSaved != null && bSavedToImage)
                EventImageSaved(this, EventArgs.Empty);
        }

        private void UpdateVideoDevices()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            for (int i = 1, n = videoDevices.Count; i <= n; i++)
            {
                string cameraName = i + " : " + videoDevices[i - 1].Name;

                cbCamera.Items.Add(cameraName);
            }


        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            SaveImage = pBPicture.Image;
            bSavedToImage = true;
            ImageIsSaved();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            StartCameras();

            bStart.Enabled = false;
            bCapture.Enabled = true;
            bSave.Enabled = true;
        }

        private void bCapture_Click(object sender, EventArgs e)
        {
            Bitmap BufferPicture;
            BufferPicture = VVideoSource.GetCurrentVideoFrame();
            pBPicture.Image = BufferPicture;
            pBPicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void StartCameras()
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[cbCamera.SelectedIndex].MonikerString);

            VVideoSource.VideoSource = videoSource;
            VVideoSource.Start();

        }

        private void StopCamera()
        {
            VVideoSource.SignalToStop();
            VVideoSource.WaitForStop();
        }

        private void Form_closing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }
}
