

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MemIDFunc_namespace;
using System.Threading;
using System.Threading.Tasks;
using MemIDFunc_namespace.Properties;
using MemIDFunc_namespace.Classes;

namespace MainUI_namespace
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
        //Server Variable

        public delegate void myVoiddelegate();

        //Add Member UI
        AddMemForm addMem;
        MemInfoForm infoform;
        DatabaseAccess dbAccess;
        public string KeyToWrite = "";

        //Global Thread
        CardThreading CardThread;
        Task CardState;
        private object threadLock = new object();


        public MainUI()
        {
            InitializeComponent();
        }

        private void InitMenu()
        {
            CardThread = new CardThreading();
            dbAccess = new DatabaseAccess();

            connActive = false;

            dbAccess.NewMemTriggered += this.ExNewMemTriggered;
            dbAccess.CheckInTriggered += this.ExCheckInTriggered;

            CardState = new Task(CardThread.CardChecking.Invoke);
            CardState.Start();

            CardThread.CardPresent += this.AutoSetup;
            CardThread.CardAbsent += this.AutoReverse;
            CardThread.CardResourceFailed += this.ExCardResourceReset;

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
            InitMenu();
        }

        private void memberInformationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberInformationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.memberInfo_dbDataSet);

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
            this.bQuit.Location = new Point(this.Size.Width / 2 - 75 - 75, this.Size.Height * 9 / 10);
            this.bReset.Location = new Point(this.Size.Width / 2 + 75 - 75, this.Size.Height * 9 / 10);
        }

        private void ExNewMemTriggered(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            addMem.KeyNo = CardThread.KeyNo;
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
        }

        private void AddMemForm_Closing(object sender, EventArgs e)
        {
            addMem = (AddMemForm)sender;
            if (addMem.DBUpdated)
            {
                this.MainMember = addMem.NewMem;

                //CardThread.KeyNo = addMem.KeyNo;
                //CardThread.CardWriting.Invoke();
                //WriteToCard(addMem.KeyNo);
                infoform = new MemInfoForm();
                infoform.DataSource = dbAccess.PopServerMem(CardThread.KeyNo);
                BeginInvoke(new myVoiddelegate(infoform.Show));
                infoform.FormClosed += new FormClosedEventHandler(MemInfoForm_Closed);
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

        private void AutoSetup(object sender, EventArgs e)
        {
            connActive = true;

            dbAccess.CkDatabase(CardThread.KeyNo);
        }

        private void AutoReverse(object sender, EventArgs e)
        {

        }
    }
}