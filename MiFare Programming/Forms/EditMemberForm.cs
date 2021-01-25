using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using MainUI_namespace.Object;
using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Classes;
using MainUI_namespace.Forms;

namespace MainUI_namespace.Forms
{
    public partial class EditMemberForm : Form
    {
        public CardClass Card;
        public MemberClass Member;

        private CapturePicture CapForm;

        private string Param;
        public EditMemberForm()
        {
            InitializeComponent();
        }

        private void CardMemForm_Load(object sender, EventArgs e)
        {
            ///Populate Combo box
            string[] SearchParam = new string[] {
                "Name", 
                "Date of Birth", 
                "Member Valid ID", 
                "Phone Number",
                "Email Address"
            };

            cbParam.Items.AddRange(SearchParam);
            cbParam.SelectedItem = "Name"; 
        }

        private void SearchMember()
        {
            //MemberClass Member;
            MemberTableAccess MemberAccess = new MemberTableAccess();

            Member = MemberAccess.FindMember(Param, tParamVal.Text);

            ListViewItem MemberItem = new ListViewItem(Member.ID.ToString());
            MemberItem.SubItems.Add(Member.Name);
            MemberItem.SubItems.Add(Member.DOB.Date.ToString("yyyy/MM/dd"));
            MemberItem.SubItems.Add(Member.MemberID);
            MemberItem.SubItems.Add(Member.PhoneNum);
            


            lvMember.Items.Add(MemberItem);

        }

        private void EditPicture()
        {
            byte[] BuffPicture;
            CapForm = new CapturePicture();

            CapForm = new CapturePicture();
            CapForm.Show();
            CapForm.Focus();

            //CapForm.EventImageSaved += ExPictureAdded;
            //Member.Picture = BuffPicture;
        }

        private void SearchParamSelected(object sender, EventArgs e)
        {
            tParamVal.Text = "";

            switch (cbParam.SelectedItem)
            {
                case "Name":
                    Param = "Name";
                    lDes.Text = "Put in the Member Name as it is on file";
                    break;
                case "Date of Birth":
                    Param = "DOB";
                    lDes.Text = "Put in the Date of Birth of Member. Format yyyy/mm/dd";

                    break;
                case "Member Valid ID":
                    Param = "MemberID";
                    lDes.Text = "Put in the Member's Identification that is on file. Driver License, Service Card, Student ID";
                    break;
                case "Phone Number":
                    Param = "PhoneNum";
                    lDes.Text = "Put in the Member's Phone Number that is on file. xxx xxx xxxx";
                    break;
                case "Email Address":
                    Param = "Email";
                    lDes.Text = "Put in the Member's Email that is on file.";
                    break;
                default:
                    Param = "Name";
                    lDes.Text = "Put in the Member Name as it is on file";
                    break;
            }
        }

        private void ValueRestriction(object sender, KeyPressEventArgs e)
        {
            switch (cbParam.SelectedItem)
            {
                case "Date of Birth":
                    Param = "DOB";

                    if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == '/'))
                    {
                        e.Handled = true;
                    }

                    break;
                case "Phone Number":
                    Param = "PhoneNum";

                    if (!char.IsNumber(e.KeyChar) && !char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }

            
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        private void LV_RowSelect(object sender, EventArgs e)
        {
            string NameSelect;
            if (lvMember.FullRowSelect)
            {
                //NameSelect = lvMember.SelectedItems[1].Text;

                Image newImage;
                using (MemoryStream ms = new MemoryStream(Member.Picture, 0, Member.Picture.Length))
                {
                    ms.Write(Member.Picture, 0, Member.Picture.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                pBox.Image = newImage;
                pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void bAssign_Click(object sender, EventArgs e)
        {
            CardTableAccess CardAccess = new CardTableAccess();
            DocumentTableAccess DocumentAccess = new DocumentTableAccess();
            MemberTableAccess MemberAccess = new MemberTableAccess();

            DocumentClass buffDoc;
            List<CardClass> CardList;

            if (!Member.IsMember)
            {
                MessageBox.Show("Person is not a member, Please Sign up first");
            }
            else
            {
                CardList = CardAccess.FindCard("CustomerID", Member.ID);

                if (CardList.Count != 0)
                {
                    foreach (CardClass buff in CardList)
                    {
                        buff.IsActive = false;
                        buff.EndDate = DateTime.Today;

                        CardAccess.UpdateExistingCard(buff);
                    }

                    buffDoc = DocumentAccess.FindDocument("SystemID", Member.ID);
                    DocumentAccess.UpdatePersonalLog(buffDoc, EventLogManipulation.EventTranslationFirst.Card_Loss);
                    ////Update Daily log
                    ///
                    Card.CustomerID = Member.ID;

                    Card.IsActive = Member.Validity;
                    Card.EffDate = Member.EffDate;
                    Card.EndDate = Member.EndDate;

                    CardAccess.UpdateExistingCard(Card);
                    //MemberAccess.UpdateExistingMember(Member);

                    DocumentAccess.UpdatePersonalLog(buffDoc, EventLogManipulation.EventTranslationFirst.Card_Replace);

                }
                else
                {
                    Card.CustomerID = Member.ID;

                    Card.IsActive = Member.Validity;
                    Card.EffDate = Member.EffDate;
                    Card.EndDate = Member.EndDate;

                    CardAccess.UpdateExistingCard(Card);
                    //MemberAccess.UpdateExistingMember(Member);

                    buffDoc = DocumentAccess.FindDocument("SystemID", Member.ID);
                    DocumentAccess.UpdatePersonalLog(buffDoc, EventLogManipulation.EventTranslationFirst.Card_Replace);
                    //// Update daily log

                }

            }
        }
    }
}
