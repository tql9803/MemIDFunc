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

using System.IO;
using MainUI_namespace.Forms;
using MainUI_namespace.Classes;
using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Object;
using System.Globalization;

namespace MainUI_namespace.Forms
{
    public partial class AddMemForm : Form
    {
        public bool Membership;

        public bool DBUpdated = false;
        private MemberTableAccess MemberAccess;
        private DocumentTableAccess DocumentAccess;
        private CardTableAccess CardAccess;

        private bool UnderAge = false;
        private string waiverpath = "Waiver.docx";
        private string memberpath = "Membership Agreement.v1.docx";
        private Image MemberImage;
        private CapturePicture CapPic;

        public bool NewMem;

        public MemberClass Member;
        public DocumentClass Document;
        public CardClass Card;

        private DateTime EffectiveDate;
        private DateTime EndDate;
        public AddMemForm()
        {
            InitializeComponent();
        }

        private void AddMemForm_Load(object sender, EventArgs e)
        {
            string[] memDetails, IDType;


            gParentInfo.Enabled = false;
            gbMemDetail.Enabled = false;

            MemberAccess = new MemberTableAccess();

            
            if (!NewMem)
            {
                memDetails = new string[1] { "Drop-In" };

                cbMemDetail.Items.AddRange(memDetails);
                cbMemDetail.SelectedItem = "Drop-In";
            }                
            else
            {
                memDetails = new string[3] { "1 Month", "4 Months", "12Months" };

                cbMemDetail.Items.AddRange(memDetails);
                gbMemDetail.Enabled = true;
                cbMemDetail.SelectedItem = "1 Month";
            }

            IDType = new string[4] { "Driver License", "StudentID", "ServiceCard", "Other" };
            cbIDType.Items.AddRange(IDType);
            cbIDType.SelectedItem = "Driver License";

            EffectiveDate = System.DateTime.Today;

            tEffDate.Text = EffectiveDate.Date.ToString("yyyy/MM/dd");
        }

        private void bFinish_Click(object sender, EventArgs e)
        {
            FinalizeDoc();
            if(DBUpdated)
            this.Close();
        }

        private void FinalizeDoc()
        {
            DocumentSign Signature = new DocumentSign();
            DocumentAccess = new DocumentTableAccess();

            string buName, buPhone, buMdetail, buAdd, buEmail;
            DateTime buDOB = DateTime.Today;
            string buPName = "", buPPhone = "", buPEmail = "";
            string buMemID = "", buIDType = "";
            string buEMEName, buEMEPhone, buEMERel;

            string SourceDocPath = @"C:\MemIDDocument\SourceDocuments\";
            string SaveAsDocPath = @"C:\MemIDDocument\ClientsDocuments\";
            string SavePath = "";

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

            /////////////buEffDate = DateTime.ParseExact(tEffDate.Text," yyyy MM dd", CultureInfo.InvariantCulture);

            SaveAsDocPath = SaveAsDocPath + buName + @"\";
            DirectoryInfo DirInfo = System.IO.Directory.CreateDirectory(SaveAsDocPath);

            DateRangeCaculation();

            #endregion Member Info Verification

            #region Membership Detail Verification

            if (cbMemDetail.SelectedItem.ToString() != "Drop-In")
            {

                if (tDOB.Text == "")
                {
                    tDOB.Focus();
                    tDOB.Text = "";
                    return;
                }
                else
                    try {
                        buDOB = DateTime.ParseExact(tDOB.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture); 
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Date Format: yyyy/MM/dd");
                    }


                if (tMemID.Text == "")
                    {
                        tMemID.Focus();
                        tMemID.Text = "";
                        return;
                    }
                else
                    buMemID = tMemID.Text;

                buIDType = cbIDType.SelectedItem.ToString();

                SavePath = SaveAsDocPath + "Membership " + buName + EffectiveDate.Date.ToString("_yy_MM_dd") + ".docx";


            }
            else
            {
                SavePath = SaveAsDocPath + "Waiver " + buName + EffectiveDate.Date.ToString("_yy_MM_dd") + ".docx";


            }

            #endregion

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

            #region Take Picture

            byte[] ConvertedPics;

            MemberImage = CapPic.SaveImage;
            ConvertedPics = ConvertPicture(MemberImage);

            #endregion

            #region Create Path
            
            string EventPath;
            EventPath = SaveAsDocPath + "EventLog " + buName + EffectiveDate.Date.ToString("_yy_MM_dd") + ".csv";

            #endregion

            //////////////////////////////////////////////////

            Signature.UnderAge = UnderAge;

            if (cbMemDetail.SelectedItem.ToString() == "Drop-In")
            {
                
                Member = new MemberClass();

                ////Create Document here

                
                Member.CreateDropIn(buName, buPhone, buEmail, buAdd, EffectiveDate, ConvertedPics);
                var MemAccRet = MemberAccess.AddMember(Member);

                switch (MemAccRet)
                {
                    case EventLogManipulation.EventTranslationFirst.Member_DropIn:
                        CreateEventLog(EventPath);

                        Signature.SignWaiverMethod(SourceDocPath + waiverpath, SavePath, buName,
                    buAdd, buPhone, buEmail, buPName, buPPhone, buPEmail, buEMEName,
                    buEMEPhone, buEMERel, EffectiveDate.Date.ToString("yyyy/MM/dd"));

                        Document = new DocumentClass();
                        Document.CreateDocument(EventPath, SavePath, "",null);

                        DocumentAccess.AddDocument(Document);
                        //update event logw
                        DocumentAccess.UpdatePersonalLog(Document,MemAccRet);
                        break;
                    case EventLogManipulation.EventTranslationFirst.Member_New:
                        break;
                    default:
                        break;
                }

                

            }
            else
            {
                Member = new MemberClass();


                ////Create Document here
                
                
                Member.CreateNewMember(buName, buDOB, buIDType, buMemID, buPhone, buEmail, buAdd, EffectiveDate,
                    EndDate, true, ConvertedPics);
                var MemAccRet = MemberAccess.AddMember(Member);
                
                

                switch (MemAccRet)
                {
                    case EventLogManipulation.EventTranslationFirst.Member_New:
                        CreateEventLog(EventPath);

                        Document = new DocumentClass();
                        Document.CreateDocument(EventPath, "", SavePath, DocumentAccess.FindLastDocID() + 1);
                        
                        DocumentAccess.AddDocument(Document);
                        //update event log
                        DocumentAccess.UpdatePersonalLog(Document, MemAccRet);
                        Signature.SignMembershipMethod(SourceDocPath + memberpath, SavePath, buName,
                    buAdd, buPhone, buEmail, buDOB.Date.ToString("yyyy/MM/dd"), buMemID,
                    buPName, buPPhone, buPEmail, buEMEName,
                    buEMEPhone, buEMERel, EffectiveDate.Date.ToString("yyyy/MM/dd"));                        
                        
                        
                        break;
                    case EventLogManipulation.EventTranslationFirst.Member_Promote:

                        Document = new DocumentClass();
                        Document = DocumentAccess.FindDocument("Id", Member.ID);
                        Document.MembershipDoc = SavePath;
                        Document.DocID = DocumentAccess.FindLastDocID() + 1;

                        DocumentAccess.UpdateExistingDoc(Document);
                        //update event log
                        DocumentAccess.UpdatePersonalLog(Document, MemAccRet);

                        Signature.SignMembershipMethod(SourceDocPath + memberpath, SavePath, buName,
                    buAdd, buPhone, buEmail, buDOB.Date.ToString("yyyy/MM/dd"), buMemID,
                    buPName, buPPhone, buPEmail, buEMEName,
                    buEMEPhone, buEMERel, EffectiveDate.Date.ToString("yyyy/MM/dd"));                        

                        
                        break;
                    case EventLogManipulation.EventTranslationFirst.Process_Cancel:
                        break;
                    default:
                        break;
                }               
                                
            }

            


            Signature.OpentoSignMethod(SavePath);

            DBUpdated = true;

        }

        private void CreateEventLog(string EventPath)
        {
            //using(System.IO.StreamWriter streamWriter = new StreamWriter(EventPath, true))
            
               

        }

        private byte[] ConvertPicture(Image Im)
        {
            ImageConverter IConverter = new ImageConverter();
            return (byte[])IConverter.ConvertTo(Im, typeof(byte[]));
        }

        

        private void DateRangeCaculation()
        {
            EffectiveDate = DateTime.ParseExact(tEffDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            switch (cbMemDetail.SelectedItem.ToString()) 
            {
                case "1 Month":
                    EndDate = EffectiveDate.AddMonths(1);
                    break;
                case "4 Months":
                    EndDate = EffectiveDate.AddMonths(4);
                    break;
                case "12 Months":
                    EndDate = EffectiveDate.AddMonths(12);
                    break;
                default:
                    EndDate = EffectiveDate;
                    break;
                    
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

        private void MemDetail_Changed(object sender, EventArgs e)
        {
            if (cbMemDetail.SelectedItem.ToString() == "Drop-In")
                gbMemDetail.Enabled = false;
            else
                gbMemDetail.Enabled = true;
            
        }
    }
}
