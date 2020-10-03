using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using System.Configuration;
using System.Data.SqlClient;
using MainUI_namespace;

using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using System.IO;
using MemIDFunc_namespace.Forms;

namespace MemIDFunc_namespace
{
    public partial class AddMemForm : Form
    {
        public string KeyNo;

        public bool DBUpdated = false;
        private DatabaseAccess DBAccess;

        private bool UnderAge = false;
        private string date;
        private string waiverpath = "Waiver.docx";
        private string memberpath = "Membership Agreement.v1.docx";
        private string[] memDetails;
        private Image MemberImage;
        private CapturePicture CapPic;

        public AddMemForm()
        {
            InitializeComponent();
        }

        private void AddMemForm_Load(object sender, EventArgs e)
        {

            DBAccess = new DatabaseAccess();

            memDetails = new string[4] { "Drop-In", "1-Month", "4-Month", "12-Month" };

            cbMemDetail.Items.AddRange(memDetails);
            cbMemDetail.SelectedItem = "Drop-In";

            gParentInfo.Enabled = false;
        }

        private void bFinish_Click(object sender, EventArgs e)
        {
            FinalizeDoc();
            if(DBUpdated)
            this.Close();
        }

        private void FinalizeDoc()
        {
            string buName, buPhone, buMdetail, buAdd, buEmail;
            string buPName = "", buPPhone = "", buPEmail = "";
            string buEMEName, buEMEPhone, buEMERel;

            string SourceDocPath = @"C:\MemIDDocument\SourceDocuments\";
            string SaveAsDocPath = @"C:\MemIDDocument\ClientsDocuments\";
            KeyNo = "BGF";

            #region Member Info Verification 
            if (tName.Text == "")
            {
                tName.Focus();
                tName.Text = "";
                return;
            }
            else
                buName = tName.Text;

            if (tPhoneNum.Text == "")
            {
                tPhoneNum.Focus();
                tPhoneNum.Text = "";
                return;
            }
            else
                buPhone = tPhoneNum.Text;

            if (tAddress.Text == "")
            {
                tAddress.Focus();
                tAddress.Text = "";
                return;
            }
            else
                buAdd = tAddress.Text;

            if (tMemEmail.Text == "")
            {
                tMemEmail.Focus();
                tMemEmail.Text = "";
                return;
            }
            else
                buEmail = tMemEmail.Text;

            buMdetail = cbMemDetail.SelectedItem.ToString();

            #endregion Member Info Verification

            #region Emegency Contact varification
            if (tEMEName.Text == "")
            {
                tEMEName.Focus();
                tEMEName.Text = "";
                return;
            }
            else
                buEMEName = tEMEName.Text;

            if (tEMEPhone.Text == "")
            {
                tEMEPhone.Focus();
                tEMEPhone.Text = "";
                return;
            }
            else
                buEMEPhone = tEMEPhone.Text;

            if (tEMERel.Text == "")
            {
                tEMERel.Focus();
                tEMERel.Text = "";
                return;
            }
            else
                buEMERel = tEMERel.Text;

            #endregion Emegency Contact varification

            #region KeyNO Generation

            string[] buff = buName.Split(' ');
            for (int i = 0; i < buff.Length; i++)
            {
                KeyNo = KeyNo + buff[i][0];
            }

            KeyNo = KeyNo + cbMemDetail.SelectedItem.ToString();


            #endregion KeyNO Generation

            #region Under Age Check

            if (UnderAge)
            {

                if (tParentName.Text == "")
                {
                    tParentName.Focus();
                    tParentName.Text = "";
                    return;
                }
                else
                    buPName = tParentName.Text;

                if (tParentPhone.Text == "")
                {
                    tParentPhone.Focus();
                    tParentPhone.Text = "";
                    return;
                }
                else
                    buPPhone = tParentPhone.Text;

                if (tParentEmail.Text == "")
                {
                    tParentEmail.Focus();
                    tParentEmail.Text = "";
                    return;
                }
                else
                    buPEmail = tParentEmail.Text;
            }

            #endregion Under Age Check
            //////////////////////////////////////////////////

            string SavePath = "";
            date = System.DateTime.Now.ToString(" yyyy MM dd");

            SaveAsDocPath = SaveAsDocPath + buName + @"\";
            DirectoryInfo DirInfo =  System.IO.Directory.CreateDirectory(SaveAsDocPath);

            if (cbMemDetail.SelectedItem.ToString() == "Drop-In")
            {
                SavePath = SaveAsDocPath + "Waiver "     + buName + date + ".docx";

                SignWaiverMethod(SourceDocPath + waiverpath, SavePath, buName,
                    buAdd, buPhone, buEmail, buPName, buPPhone, buPEmail, buEMEName, buEMEPhone, buEMERel);
            }
            else
            {
                SavePath = SaveAsDocPath + "Membership " + buName + date + ".docx";

                SignMembershipMethod(SourceDocPath + memberpath, SavePath, buName, 
                    buAdd, buPhone, buEmail, buPName, buPPhone, buPEmail);
            }

            string EventPath;
            EventPath = SaveAsDocPath + "EventLog " + buName + date + ".csv";
            CreateEventLog(EventPath);

            byte[] defaultPics;

            MemberImage = CapPic.SaveImage;
            defaultPics = ConvertPicture(MemberImage);

            DBAccess.UpdateDB(buName, buPhone, buEmail, buMdetail, KeyNo, defaultPics,
                buAdd, SavePath, EventPath);
            DBUpdated = true;


            OpentoSignMethod(SavePath);
            
        }

        private void CreateEventLog(string EventPath)
        {
            using(System.IO.StreamWriter streamWriter = new StreamWriter(EventPath, true))
            {
                streamWriter.Write("Created" + System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm") + "\r\n");
                streamWriter.Write("Check-In , Check-Out \r\n");
            }

        }

        private byte[] ConvertPicture(Image Im)
        {
            ImageConverter IConverter = new ImageConverter();
            return (byte[])IConverter.ConvertTo(Im, typeof(byte[]));
        }

        private void ReplacementMethod(Word.Application WordApp, object FindText, object ReplaceText)
        {
            object matchcase = true;
            object matchWholeword = true;
            object matchWildcard = false;
            object matchSoundlike = false;
            object matchAllform = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object warp = 1;



            WordApp.Selection.Find.Execute(ref FindText, ref matchcase, ref matchWholeword, ref matchWildcard,
                ref matchSoundlike, ref matchAllform, ref forward, ref warp, ref format, ref ReplaceText,
                ref replace, ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        private void SignWaiverMethod(object TempFile, object SaveFile, object MemName, object MemAdd,
            object MemPhone, object MemEmail, object ParentName, object ParentPhone, object ParentEmail,
            object EMEName, object EMEPhone, object EMERel)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDocument = null;

            object ReadOnly = false;
            object isVisible = false;
            wordApp.Visible = false;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;

            try
            {
                myDocument = wordApp.Documents.Open(ref TempFile, ref missing, ref ReadOnly, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();

                ReplacementMethod(wordApp, "[MEMBER NAME]", MemName);
                ReplacementMethod(wordApp, "[MEMBER ADDRESS]", MemAdd);
                ReplacementMethod(wordApp, "[MEMBER PHONE]", MemPhone);
                ReplacementMethod(wordApp, "[MEMBER EMAIL]", MemEmail);

                ReplacementMethod(wordApp, "[EME NAME]", EMEName);
                ReplacementMethod(wordApp, "[EME PHONE]", EMEPhone);
                ReplacementMethod(wordApp, "[EME RELATIONSHIP]", EMERel);

                if (UnderAge)
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", ParentName);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", ParentPhone);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", ParentEmail);
                }
                else
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", null);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", null);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", null);
                }

                ReplacementMethod(wordApp, "[DATE]", date);

                myDocument.SaveAs2(ref SaveFile, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);

                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
            
        }

        private void SignMembershipMethod(object TempFile, object SaveFile, object MemName, object MemAdd,
            object MemPhone, object MemEmail, object ParentName, object ParentPhone, object ParentEmail)
        {
            date = System.DateTime.Now.ToString("yyyy-mm-dd");

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDocument = null;

            object ReadOnly = false;
            object isVisible = false;
            wordApp.Visible = false;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;
            try 
            {
                myDocument = wordApp.Documents.Open(ref TempFile, ref missing, ref ReadOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();

                ReplacementMethod(wordApp, "[MEMBER NAME]", MemName);
                ReplacementMethod(wordApp, "[MEMBER ADDRESS]", MemAdd);
                ReplacementMethod(wordApp, "[MEMBER PHONE]", MemPhone);
                ReplacementMethod(wordApp, "[MEMBER EMAIL]", MemEmail);

                if (UnderAge)
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", ParentName);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", ParentPhone);
                    ReplacementMethod(wordApp, "[PARENT ADDRESS]", MemAdd);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", ParentEmail);
                }
                else
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", null);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", null);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", null);
                }

                ReplacementMethod(wordApp, "[DATE]", date);

                myDocument.SaveAs2(ref SaveFile, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);

                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
}

        private void OpentoSignMethod(object FilePath)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document myDocument = null;
            
            object missing = Missing.Value;
            object ReadOnly = false;
            object isVisible = true;
            wordApp.Visible = true;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;

            try
            {
                myDocument = wordApp.Documents.Open(ref FilePath, ref missing, ref ReadOnly, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
        }
        private void AtFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DBUpdated)
            {
                _ = MessageBox.Show("Member Added");
            }
            else
                _ = MessageBox.Show("Process is terminated");
        }

        private void UnderAgeCheckChanged(object sender, EventArgs e)
        {
            UnderAge = ckBUnderAge.Checked;

            if (UnderAge)
                gParentInfo.Enabled = true;
            else
                gParentInfo.Enabled = false;
        }

        private void bAddPic_Click(object sender, EventArgs e)
        {
            CapPic = new CapturePicture();
            CapPic.Show();
            CapPic.Focus();

            CapPic.EventImageSaved += ExPictureAdded;
        }

        private void ExPictureAdded(object sender, EventArgs e)
        {
            bFinish.Enabled = true;
        }
    }
}
