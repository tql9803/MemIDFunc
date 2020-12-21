using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using MainUI_namespace;
using System.Drawing.Text;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace MainUI_namespace.Forms
{
    public partial class MemInfoForm : Form
    {


        public byte[] MemPic;

        public bool DBUpdated = false;

        public System.Data.DataTable DataSource;

        public MemInfoForm()
        {
            InitializeComponent();
        }

        public void UpdateDatasource()
        {
            string memName;
            memName = (string)DataSource.Rows[0]["Name"];

            CheckInOut((string)DataSource.Rows[0]["EventLog"], memName);

            MemPic = (byte[])DataSource.Rows[0]["Picture"];
            Image newImage;

            using (MemoryStream ms = new MemoryStream(MemPic, 0, MemPic.Length))
            {
                ms.Write(MemPic, 0, MemPic.Length);

                //Set image variable value using memory stream.
                newImage = Image.FromStream(ms, true);
            }

            pictureBox1.Image = newImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            

        }

        private void CheckInOut(string eventlogpath, string MemberName)
        {
            string buffer;
            string[] stringBuf;
            char[] splitchar = { ',', '\n' };
            int LengthOfFile;

            using (System.IO.StreamReader streamReader = new StreamReader(eventlogpath))
            {
                buffer = streamReader.ReadToEnd();
                stringBuf = buffer.Split(splitchar);
                LengthOfFile = stringBuf.Length;
            }

            using (System.IO.StreamWriter streamWriter = new StreamWriter(eventlogpath, true))
            {
                if (LengthOfFile % 2 == 0)
                {
                    streamWriter.Write(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm ,"));
                }
                else
                {
                    streamWriter.Write(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm \r\n"));
                }
                
            }

            if (LengthOfFile % 2 == 0)
            {
                lGreeting.Text = "Welcome " + MemberName;
            }
            else
            {
                lGreeting.Text = "Goodbye " + MemberName;
            }

            lGreeting.Location = new System.Drawing.Point((this.Size.Width - lGreeting.Size.Width)/2,
                this.Size.Height*8/10);
        }

        private void MemInfoForm_Load(object sender, EventArgs e)
        {
            UpdateDatasource();
        }
    }
}
