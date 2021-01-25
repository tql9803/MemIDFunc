

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

using MainUI_namespace.Object;
using MainUI_namespace.Forms;
using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Classes;

namespace MainUI_namespace.Forms
{
    public partial class MainUI : Form
    {
        //Card Variable
        public int retCode, hContext, hCard, Protocol;
        public bool connActive = false;
        public bool NewMem = false;
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public ModWinsCard.SCARD_READERSTATE RdrState;
        public ModWinsCard.SCARD_IO_REQUEST pioSendRequest;

        private MemberClass MainMember;
        private CardClass MainCard;
        private DocumentClass MainDoc;
        //Server Variable

        public delegate void myVoiddelegate();

        //Add Member UI
        AddMemForm addMem;
        MemInfoForm infoform;
        CardMemForm CardMem;
        CheckInOutForm CForm;
        EditMemberForm EditMem;

        MemberTableAccess MemberAccess;
        public string KeyToWrite = "";

        public string DailyLog;

        //Global Thread
        CardThreading CardThread;
        //Task CardState;

        AddCard AddCardF;


        public MainUI()
        {
            InitializeComponent();
        }

        private void InitMenu()
        {
            CardThread = new CardThreading();
            MemberAccess = new MemberTableAccess();

            connActive = false;

            MemberAccess.NewMemTriggered += this.ExNewMemTriggered;
            MemberAccess.CheckInTriggered += this.ExCheckInTriggered;

            Task cardState = new Task(CardThread.CardChecking.Invoke);
            cardState.Start();
            //CardState = new Task(CardThread.CardChecking.Invoke);
            //CardState.Start();

            //CardThread.CardPresent += this.WhenCardPresent;
            //CardThread.CardAbsent += this.AutoReverse;
            //CardThread.CardResourceFailed += this.ExCardResourceReset;

            bSCard.Enabled = false;
        }


        

        private void MiFareCardProg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'memberInfo_dbDataSet.MemberInformation' table. You can move, or remove it, as needed.
            this.memberInformationTableAdapter.Fill(this.memberInfo_dbDataSet.MemberInformation);
            bSCard.Enabled = true;

            MainMember = new MemberClass();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            CardThread.CardReseting.Invoke();
            bSCard.Enabled = true;
        }

        private void bSCard_Click(object sender, EventArgs e)
        {
            bSCard.Enabled = false;
            CForm = new CheckInOutForm();
            CForm.Show();
            CForm.Focus();
        }

        private void memberInformationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberInformationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.memberInfo_dbDataSet);

        }

        private void bAddMem_Click(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            addMem.NewMem = true;
            BeginInvoke(new myVoiddelegate(addMem.Show));
            addMem.FormClosing += new FormClosingEventHandler(AddMemForm_Closing);
        }

        private void bDropIn_Click(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            addMem.NewMem = false;
            BeginInvoke(new myVoiddelegate(addMem.Show));
            addMem.FormClosing += new FormClosingEventHandler(AddMemForm_Closing);
        }

        private void bAssignCard_Click(object sender, EventArgs e)
        {
            ButtonControl(false);

            CardThread = new CardThreading();

            CardThread.CardPresent += this.AssignCard_WhenCardPresent;

            this.Invoke(CardThread.CardChecking);

            
        }

        private void ButtonControl(bool OnOff)
        {
            bDropIn.Enabled = OnOff;
            bAssignCard.Enabled = OnOff;
            bAddMem.Enabled = OnOff;
            bSCard.Enabled = OnOff;
        }


        private void bADDCard_Click(object sender, EventArgs e)
        {
            AddCardF = new AddCard();
            AddCardF.Show();
        }

        private void bQuit_Click(object sender, EventArgs e)
        {

            // terminate the application
            retCode = ModWinsCard.SCardReleaseContext(hContext);
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            System.Environment.Exit(0);

        }

        private void UI_OnSizeChanged(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSCard.Location = new Point(this.Size.Width / 2 - 75, this.Size.Height / 2);
            this.bAddMem.Location = new Point(this.Size.Width / 2 - 75, this.Size.Height / 2 - 75);
            this.bDropIn.Location = new Point(this.Size.Width / 2 - 75, this.Size.Height / 2 - 75*2);
            this.bAssignCard.Location = new Point(this.Size.Width / 2 - 75, this.Size.Height / 2 - 75*3);

            this.bQuit.Location = new Point(this.Size.Width / 2 - 75 - 75, this.Size.Height * 9 / 10);
            this.bReset.Location = new Point(this.Size.Width / 2 + 75 - 75, this.Size.Height * 9 / 10);
        }

        private void bAddPic_Click(object sender, EventArgs e)
        {
            
        }

        private void ExNewMemTriggered(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            //addMem.KeyNo = CardThread.KeyNo;
            BeginInvoke(new myVoiddelegate(addMem.Show));
            addMem.FormClosing += new FormClosingEventHandler(AddMemForm_Closing);
        }

        private void ExCheckInTriggered(object sender, EventArgs e, DataTable datasource)
        {
            //Thread.CurrentThread.Join();
            infoform = new MemInfoForm();
            infoform.DataSource = datasource;
            BeginInvoke(new myVoiddelegate(infoform.Show));
            infoform.FormClosed += new FormClosedEventHandler(MemInfoForm_Closed);

            CardThread.CardReset();
        }

        private void AddMemForm_Closing(object sender, EventArgs e)
        {
            addMem = (AddMemForm)sender;
            if (addMem.DBUpdated)
            {
                this.MainMember = addMem.Member;

            }

        }

        private void MemInfoForm_Closed(object sender, EventArgs e)
        {
            infoform = (MemInfoForm)sender;
            bSCard.Enabled = true;
        }

        private void ExCardResourceReset(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Program is reseting");

            CardThread.CardReseting.Invoke();

            InitMenu();

            CardThread.CardChecking.Invoke();
        }

        private void AssignCard_WhenCardPresent(object sender, EventArgs e)
        {
            ////Button Manipulation
            ///

            MemberAccess = new MemberTableAccess();
            CardTableAccess cardTable = new CardTableAccess();
            CardClass CardThis;
            List<CardClass> CardList;

            byte[] bufferKey;

            bufferKey = CardThread.KeyNo;
            CardList = cardTable.FindCard("CardNo", bufferKey);

            if (CardList.Count != 0)
            {
                CardMem = new CardMemForm();
                CardMem.Card = CardList[0];
                CardMem.Show();
                //CardMem.FormClosing += CardMemForm_Closing; 
            }
            else
            {
                MessageBox.Show("The card is not in the system, please Add card into the system");
                //AssignCard();
                ButtonControl(true);
            }
        }

        private void AutoSetup(object sender, EventArgs e)
        {
            //connActive = true;

            //dbAccess.CkDatabase(CardThread.KeyNo);
        }
        private void AutoReverse(object sender, EventArgs e)
        {

        }

        //public void ExecuteEventlogMsg(EventLogManipulation.EventTranslationFirst LogMsg, string PersonalLog)
        //{
        //    EventLogManipulation Maner = new EventLogManipulation();
        //    Maner.LogFile = PersonalLog;

        //    switch (LogMsg)
        //    {
        //        case EventLogManipulation.EventTranslationFirst.CheckIn:
        //            //////////Write to Daily log
        //            Maner.WriteToLog(LogMsg);
        //            this.WriteDailyLog(MainMember.Name);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.CheckOut:
        //            //////////Write to Daily log
        //            Maner.WriteToLog(LogMsg);
        //            this.WriteDailyLog(MainMember.Name);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_New:
        //            /////Disable Member
        //            Maner.CreateLog();
        //            Maner.WriteToLog(LogMsg);

        //            MemberAccess = new MemberTableAccess();
        //            /////Add MEM Form ????
        //            MemberAccess.AddMember(MainMember);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_DropIn:
        //            //////////Write to Daily log
        //            Maner.WriteToLog(LogMsg);
        //            WriteDailyLog(MainMember.Name);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_Expelled:
        //            /////Disable Member, disable card, deactive Document
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_Inactived:
        //            //////Disable member, disable card, deactive Doc
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_Renew:
        //            /////Renew Member, renew Card, Renew Document
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_FeeDue:
        //            /////Disable Member
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Member_FeePaid:
        //            /////Disable Member
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Card_Loss:
        //            /////Disable Member
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Card_New:
        //            /////Disable Member
        //            Maner.WriteToLog(LogMsg);
        //            break;
        //        case EventLogManipulation.EventTranslationFirst.Card_Replace:
        //            /////Disable Member
        //            Maner.WriteToLog(LogMsg);
        //            break;

        //        default:
        //            MessageBox.Show("Unrecognize message code");
        //            break;

        //    }
        //}

        public void WriteDailyLog(string ClientName)
        {
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(DailyLog, true))
            {
                streamWriter.WriteLine(ClientName + "," + DateTime.Now.ToString("yy/MM/dd hh:mm"));
            }
        }
    }
}