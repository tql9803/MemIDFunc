/*=========================================================================================
'  Copyright(C):    Advanced Card Systems Ltd 
' 
'  Description:     This sample program outlines the steps on how to
'                   transact with Mifare 1K/4K cards using ACR122
'  
'  File   :         MifareProg.cs    
'
'  Author :         Daryl M. Rojas
'
'  Module :         ModWinscard.cs
'   
'  Date   :         June 28, 2008
'
'  Revision Trail:  (Date/Author/Description) 
'
'=========================================================================================*/

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

namespace MiFare_Programming
{
    public partial class MemIDFunc : Form
    {
        public int retCode, hContext, hCard, Protocol;
        public bool connActive = false;
        public bool autoDet;
        public bool NewMem = false;
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public ModWinsCard.SCARD_READERSTATE RdrState;
        public ModWinsCard.SCARD_IO_REQUEST pioSendRequest;

        public string connectionString;
        public SqlConnection ServerConnect;

        public delegate void NewMemEventHandler(object sender, EventArgs e);
        public event NewMemEventHandler NewMemTriggered;

        public delegate void CardResourceEventHandler(object sender, EventArgs e);
        public event CardResourceEventHandler CardResourceFailed;

        AddMemForm addMem = new AddMemForm();
        public string KeyToWrite="";
        
        public MemIDFunc()
        {
            InitializeComponent();

            this.NewMemTriggered += this.ExNewMemTriggered;
            this.CardResourceFailed += this.ExCardResourceReset;
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberID_dbConnectionString"].ConnectionString;

            //PInitialize();
        }

        private void PopServerMem()
        {
            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlDataAdapter nadapter = new SqlDataAdapter("select*from MemID", ServerConnect))
            { 
                //Normally need to open and close the SQLConnection with ServerConnec.Open/Close.
                //But sqlDataAdapter will handle the open and close connection for us.

                DataTable MemTable = new DataTable();
                nadapter.Fill(MemTable);

                //lstMemID.DataSource = MemTable;
                //=BlstMemID.DisplayMember = "Id";
                //lstMemID.ValueMember = "PhoneNum";

                lstMemName.DataSource = MemTable;
                lstMemName.DisplayMember = "Name";
            }
        }

        private void CkDatabase(string KeyNo)
        {
            string query = "select*from MemID " + "where KeyNum = @ReadKey";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            using (SqlDataAdapter nadapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@ReadKey", KeyNo);

                DataTable MemTable = new DataTable();
                nadapter.Fill(MemTable);
                if (MemTable.Rows.Count == 0)
                {
                    NewMem = true;

                    OnNewMemTriggered();
                    return;
                }
                lstMemName.DataSource = MemTable;
                lstMemName.DisplayMember = "Name";
                lstMemName.ValueMember = "Id";
            }
        }

        private void InitMenu()
        {
            connActive = false;
            cbReader.Text = "";
            mMsg.Text = "";
            mMsg.Clear();
            bInit.Enabled = true;
            bConnect.Enabled = false;
            bLoadKey.Enabled = false;
            bClear.Enabled = false;
            displayOut(0, 0, "Program ready");
            AuthBox.Enabled = false;
            gbBinOps.Enabled = false;

            tBinData.MaxLength = 0;

            PopServerMem();

        }

        private void EnableButtons()
        {

            bInit.Enabled = false;
            //bConnect.Enabled = true;            
            bClear.Enabled = true;
            bLoadKey.Enabled = true;
            AuthBox.Enabled = true;
            gbBinOps.Enabled = true;
            rbKType1.Checked = true;

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

        private void displayOut(int errType, int retVal, string PrintText)
        {

            switch (errType)
            {

                case 0:
                    mMsg.SelectionColor = Color.Green;
                    break;
                case 1:
                    mMsg.SelectionColor = Color.Red;
                    PrintText = ModWinsCard.GetScardErrMsg(retVal);
                    break;
                case 2:
                    mMsg.SelectionColor = Color.Black;
                    PrintText = "<" + PrintText;
                    break;
                case 3:
                    mMsg.SelectionColor = Color.Black;
                    PrintText = ">" + PrintText;
                    break;
                case 4:
                    mMsg.SelectionColor = Color.Red;
                    break;

            }

            mMsg.AppendText(PrintText);
            mMsg.AppendText("\n");
            mMsg.SelectionColor = Color.Black;
            mMsg.Focus();

            OnCardResourceFailed();
        }

        private void bInit_Click(object sender, EventArgs e)
        {
            PInitialize();                       
        }

        private void bConnect_Click(object sender, EventArgs e)
        {

            retCode = ModWinsCard.SCardConnect(hContext, cbReader.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_SHARED,
                                              ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)

                displayOut(1, retCode, "");
            else
            {
                displayOut(0, 0, "Successful connection to " + cbReader.Text);

            }
            connActive = true;
            bLoadKey.Enabled = true;
            AuthBox.Enabled = true;
            gbBinOps.Enabled = true;
            rbKType1.Checked = true;
        }

        private void bLoadKey_Click(object sender, EventArgs e)
        {
            PLoadAu();
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
            displayOut(2, 0, tmpStr);
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "");
                return retCode;

            }

            tmpStr = "";
            for (indx = 0; indx <= RecvLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

            }

            displayOut(3, 0, tmpStr);
            return retCode;

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            mMsg.Clear();
        }

        private void MiFareCardProg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'memberID_dbDataSet.MemID' table. You can move, or remove it, as needed.
            this.memIDTableAdapter.Fill(this.memberID_dbDataSet.MemID);
            InitMenu();
        }

        private void bReset_Click(object sender, EventArgs e)
        {

            if (connActive)
            {

                retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            }

            retCode = ModWinsCard.SCardReleaseContext(hCard);
            InitMenu();
        
        }

        private void bQuit_Click(object sender, EventArgs e)
        {

            // terminate the application
            retCode = ModWinsCard.SCardReleaseContext(hContext);
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            System.Environment.Exit(0);

        }


        private void Authorization(int blk)
        {
            int indx;
            string tmpStr;

            ClearBuffers();

            SendBuff[0] = 0xFF;                             // Class
            SendBuff[1] = 0x86;                             // INS
            SendBuff[2] = 0x00;                             // P1
            SendBuff[3] = 0x00;                             // P2
            SendBuff[4] = 0x05;                             // Lc
            SendBuff[5] = 0x01;                             // Byte 1 : Version number
            SendBuff[6] = 0x00;                             // Byte 2
            SendBuff[7] = (byte)blk;     // Byte 3 : Block number

            if (rbKType1.Checked == true)
            {
                SendBuff[8] = 0x60;

            }
            else if (rbKType2.Checked == true)
            {
                SendBuff[8] = 0x61;
            }

            SendBuff[9] = 0x00;        // Key 5 value

            SendLen = 10;
            RecvLen = 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

                if (tmpStr.Trim() == "90 00")
                {
                    displayOut(0, 0, "Authentication success!");
                }
                else
                {
                    displayOut(4, 0, "Authentication failed!");
                }

            }
        }
        private void bBinUpd_Click(object sender, EventArgs e)
        {

            string tmpStr;
            int indx, tempInt;

            int blkNo;

            if (tBinBlk.Text == "" | !int.TryParse(tBinBlk.Text, out tempInt))
            {

                tBinBlk.Focus();
                tBinBlk.Text = "";
                return;

            }

            if (int.Parse(tBinBlk.Text) > 319)
            {

                tBinBlk.Text = "319";
                return;

            }


            if (tBinData.Text == "")
            {

                tBinData.Focus();
                return;

            }

            if (int.Parse(tBinBlk.Text) % 4 == 0)
                blkNo = int.Parse(tBinBlk.Text);
            else
                blkNo = int.Parse(tBinBlk.Text) - int.Parse(tBinBlk.Text) % 4;

            Authorization(blkNo);

            tmpStr = tBinData.Text;
            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)blkNo;            // P2 : Starting Block No.
            SendBuff[4] = 0x10;            // P3 : Data length

            for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
            {

                SendBuff[indx + 5] = (byte)tmpStr[indx];

            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                tBinData.Text = "";
            }
            else
            {
                displayOut(2, 0, "");
            }
        
        }

        private void bBinRead_Click(object sender, EventArgs e)
        {

            string tmpStr;
            int indx;

            int blkNo;
            // Validate Inputs
            tBinData.Text = "";

            if (tBinBlk.Text == "")
            {

                tBinBlk.Focus();
                return;

            }

            if (int.Parse(tBinBlk.Text) > 319)
            {

                tBinBlk.Text = "319";
                return;
            }

            if (int.Parse(tBinBlk.Text) % 4 == 0)
                blkNo = int.Parse(tBinBlk.Text);
            else
                blkNo = int.Parse(tBinBlk.Text) - int.Parse(tBinBlk.Text) % 4;

            Authorization(blkNo);

            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x00;
            SendBuff[3] = (byte)blkNo;
            SendBuff[4] = 0x10;

            SendLen = 5;
            RecvLen = SendBuff[4] + 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 3; indx++)
                {

                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }

                tBinData.Text = tmpStr;

                CkDatabase(tmpStr);

            }
            else
            {
                displayOut(4, 0, "Read block error!");
            }

        }
        
        private void PLoadAu()
        {
            string tmpStr;

            ClearBuffers();
            // Load Authentication Keys command
            SendBuff[0] = 0xFF;                                                                        // Class
            SendBuff[1] = 0x82;                                                                        // INS
            SendBuff[2] = 0x00;                                                                        // P1 : Key Structure
            SendBuff[3] = 0x00; // key # 
            SendBuff[4] = 0x06;                                                                        // P3 : Lc
            SendBuff[5] = 0xFF; // key input val
            SendBuff[6] = 0xFF; // key input val
            SendBuff[7] = 0xFF; // key input val
            SendBuff[8] = 0xFF; // key input val
            SendBuff[9] = 0xFF; // key input val
            SendBuff[10] = 0xFF; // key input val

            SendLen = 11;
            RecvLen = 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tBinData.MaxLength = 16;
                tmpStr = "";
                for (int indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() != "90 00")
            {
                displayOut(4, 0, "Load authentication keys error!");
            }

        }

        private void PInitialize()
        {
            int indx;
            int pcchReaders = 0;
            string rName = "";

            //Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "");

                return;

            }

            // 2. List PC/SC card readers installed in the system

            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                displayOut(1, retCode, "");

                return;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                mMsg.AppendText("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));

                return;
            }
            else
            {
                displayOut(0, 0, " ");
            }

            rName = "";
            indx = 0;

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {

                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                //Add reader name to list
                cbReader.Items.Add(rName);
                //rName = "";
                indx = indx + 1;

            }

            RdrState.RdrName = rName;

            retCode = ModWinsCard.SCardGetStatusChangeA(this.hContext, 20000, ref RdrState, 1);
            OnCardResourceFailed();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                mMsg.AppendText("SCardGetStatus Error: " + ModWinsCard.GetScardErrMsg(retCode));

                return;
            }

            if ((Convert.ToUInt32(RdrState.RdrEventState) & 0x10) == 0x10)
            {
                mMsg.AppendText("No Card is presented");
                RdrState = new ModWinsCard.SCARD_READERSTATE();

                return;
            }

            RdrState = new ModWinsCard.SCARD_READERSTATE();

            retCode = ModWinsCard.SCardConnect(hContext, rName, ModWinsCard.SCARD_SHARE_SHARED,
                                              ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)

                displayOut(1, retCode, "");
            else
            {
                displayOut(0, 0, "Successful connection to " + rName);

                EnableButtons();
                connActive = true;
            }

            if (cbReader.Items.Count > 0)
            {
                cbReader.SelectedIndex = 0;

            }
        }
        private void WriteToCard(string CardData)
        {
            int indx, blkNo;
            string tmpStr;

            if (int.Parse(tBinBlk.Text) % 4 == 0)
                blkNo = int.Parse(tBinBlk.Text);
            else
                blkNo = int.Parse(tBinBlk.Text) - int.Parse(tBinBlk.Text) % 4;

            Authorization(blkNo);

            tmpStr = CardData;
            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)blkNo;            // P2 : Starting Block No.
            SendBuff[4] = 0x10;            // P3 : Data length

            for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
            {

                SendBuff[indx + 5] = (byte)tmpStr[indx];

            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

            }
            if (tmpStr.Trim() == "90 00")
            {
                tBinData.Text = "";
            }
            else
            {
                displayOut(2, 0, "");
            }
        }

        protected virtual void OnNewMemTriggered()
        {
            if (NewMemTriggered != null && NewMem)
                NewMemTriggered(this, EventArgs.Empty);
        }

        public void ExNewMemTriggered(object sender, EventArgs e)
        {
            addMem = new AddMemForm();
            addMem.Show();
            addMem.FormClosing += new FormClosingEventHandler(AddMemForm_Closing);
        }

        public void AddMemForm_Closing(object sender, EventArgs e)
        {
            addMem = (AddMemForm)sender;
            if (addMem.DBUpdated)
            {
                WriteToCard(addMem.KeyNo);
                PopServerMem();
            }
            
        }

        protected virtual void OnCardResourceFailed()
        {
            if (CardResourceFailed != null && retCode == ModWinsCard.SCARD_E_SERVICE_STOPPED)
                CardResourceFailed(this, EventArgs.Empty);
        }

        public void ExCardResourceReset(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Program is reseting");

            if (connActive)
            {

                retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            }

            retCode = ModWinsCard.SCardReleaseContext(hCard);
            InitMenu();

            PInitialize();

            PLoadAu();
        }

    }

    //class Mifare_Ex
    //{
        
    //}

}