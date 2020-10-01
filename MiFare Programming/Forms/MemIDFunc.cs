

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

        //Server Variable
        public string connectionString;
        public SqlConnection ServerConnect;
        
        //Delegates for new UI
        public delegate void NewMemEventHandler(object sender, EventArgs e);
        public event NewMemEventHandler NewMemTriggered;

        public delegate void CheckInEventHandler(object sender, EventArgs e, object ds);
        public event CheckInEventHandler CheckInTriggered;
        //Delegates for Card resource fail
        public delegate void CardResourceEventHandler(object sender, EventArgs e);
        public event CardResourceEventHandler CardResourceFailed;

        public delegate void myVoiddelegate();

        //Add Member UI
        AddMemForm addMem;
        MemInfoForm infoform;
        DatabaseAccess dbAccess = new DatabaseAccess();
        public string KeyToWrite = "";

        //Global Thread
        CardThreading CardThread = new CardThreading();
        Task CardState;
        private object threadLock = new object();


        public MainUI()
        {
            InitializeComponent();            
        }

        private void InitMenu()
        {
            connActive = false;

            dbAccess.NewMemTriggered += this.ExNewMemTriggered;
            dbAccess.CheckInTriggered += this.ExCheckInTriggered;
            //this.CardResourceFailed += this.ExCardResourceReset;
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberID_dbConnectionString"].ConnectionString;

            //CardState = new Task(CardThread.CardChecking);
            //CardState.Start();

            CardState = new Task(CardThread.CardChecking.Invoke);
            CardState.Start();

            CardThread.CardPresent += this.AutoSetup;
            CardThread.CardAbsent += this.AutoReverse;
            CardThread.CardResourceFailed += this.ExCardResourceReset;
        }

        private void ClearBuffers()
        {

            long indx;

            for (indx = 0; indx <= 262; indx++)
            {

                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;

            }

        }

        public int SendAPDU()
        {
            int indx;
            string tmpStr;

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            tmpStr = "";
            for (indx = 0; indx <= SendLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);

            }
            retCode = ModWinsCard.SCardTransmit(CardThread.hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return retCode;
            }

            tmpStr = "";
            for (indx = 0; indx <= RecvLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

            }
            return retCode;

        }

        private void MiFareCardProg_Load(object sender, EventArgs e)
        {
            this.memIDTableAdapter.Fill(this.memberID_dbDataSet.MemID);
            InitMenu();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            CardThread.CardReseting.Invoke();
            InitMenu();

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
            this.bQuit.Location = new Point(this.ClientSize.Width / 2 - 75, this.ClientSize.Height * 9 / 10);
            this.bReset.Location = new Point(this.ClientSize.Width / 2 + 75, this.ClientSize.Height * 9 / 10);
        }

        private void ExNewMemTriggered(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            BeginInvoke(new myVoiddelegate(addMem.Show));
            addMem.FormClosing += new FormClosingEventHandler(AddMemForm_Closing);
        }

        private void ExCheckInTriggered(object sender, EventArgs e, DataTable datasource)
        {
            //Thread.CurrentThread.Join();
            infoform = new MemInfoForm();
            infoform.DataSource = datasource;
            BeginInvoke(new myVoiddelegate(infoform.Show));
            //infoform.UDatasource.Invoke(datasource);
        }

        private void AddMemForm_Closing(object sender, EventArgs e)
        {
            addMem = (AddMemForm)sender;
            if (addMem.DBUpdated)
            {
                CardThread.KeyNo = addMem.KeyNo;
                CardThread.CardWriting.Invoke();
                //WriteToCard(addMem.KeyNo);
                infoform = new MemInfoForm();
                infoform.DataSource = dbAccess.PopServerMem(CardThread.KeyNo);
                BeginInvoke(new myVoiddelegate(infoform.Show));
            }

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