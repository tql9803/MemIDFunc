using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MainUI_namespace;
using System.Threading;
using System.Xml.Serialization;

namespace MemIDFunc_namespace
{
    public class CardThreading
    {
        public int retCode, hContext, hCard, Protocol;
        private bool connActive = false;
        private byte[] SendBuff = new byte[263];
        private byte[] RecvBuff = new byte[263];
        private int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        private ModWinsCard.SCARD_READERSTATE RdrState;
        private ModWinsCard.SCARD_IO_REQUEST pioSendRequest;

        public string KeyNo;

        public bool Present = false;
        public bool Success = false;

        public delegate void CardPresentEventHandler(object sender, EventArgs e);
        public event CardPresentEventHandler CardPresent;
        public event CardPresentEventHandler CardAbsent;
        public event CardPresentEventHandler CardResourceFailed;

        public delegate void CardFunction();
        public CardFunction CardChecking;
        public CardFunction CardReading;
        public CardFunction CardWriting;
        public CardFunction CardReseting;
        public CardThreading()
        {
            CardChecking = new CardFunction(CardCk);
            CardReading = new CardFunction(CardRead);
            CardWriting = new CardFunction(CardWrite);
            CardReseting = new CardFunction(CardReset);
        }

        private void CardCk()
        {
            bool absent = false;

            //Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode == ModWinsCard.SCARD_S_SUCCESS)
            { 
                while (!Present)
                {
                    Success = true;
                    RdrState.RdrName = "ACS ACR122 0";
                    //Check Card Status
                    retCode = ModWinsCard.SCardGetStatusChangeA(this.hContext, 0, ref RdrState, 1);

                    if (retCode == ModWinsCard.SCARD_S_SUCCESS)
                    {
                        Success = true;
                        if ((Convert.ToUInt32(RdrState.RdrEventState) & ModWinsCard.SCARD_STATE_PRESENT) == ModWinsCard.SCARD_STATE_PRESENT)
                        {
                            retCode = ModWinsCard.SCardConnect(hContext, RdrState.RdrName, ModWinsCard.SCARD_SHARE_SHARED,
                                              ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

                            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                            {
                                Success = false;
                                MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode));
                            }
                            else
                            {
                                Success = true;
                                connActive = true;
                                Present = true;
                            }

                        }
                        if ((Convert.ToUInt32(RdrState.RdrEventState) & ModWinsCard.SCARD_STATE_EMPTY) == ModWinsCard.SCARD_STATE_EMPTY
                            && !absent)
                        {
                            absent = true;
                            connActive = false;
                        }
                    }
                    else
                    {
                        Success = false;
                        MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode));
                    }
                }
                    
                        
            }
            else
            {
                Success = false;
                MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode));
            }

                OnCardPresent();
                //OnCardAbsent();
            
        }

        private void CardConnectionMaintainace()
        {
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

        }

        private void CardRead()
        {
            OnCardResourceFailed();

            int indx;
            string tmpStr;

            Authorization();

            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x00;
            SendBuff[3] = (byte)0;
            SendBuff[4] = 0x10;

            SendLen = 5;
            RecvLen = SendBuff[4] + 2;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Error " + retCode.ToString());
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

                    tmpStr = tmpStr +' '+ RecvBuff[indx].ToString();
                }


                KeyNo = tmpStr; 

            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void CardWrite() 
        {
            OnCardResourceFailed();

            int indx, blkNo = 4;
            int SendDataLn;
            string tmpStr;

            tmpStr = KeyNo;
            //byte[] Keybuff = Encoding.ASCII.GetBytes(tmpStr);

            //for (int i = 0; i < Keybuff.Length; i++)
            //{
            //    KeyNo = KeyNo + Convert.ToChar(Keybuff[i]);
            //}
            SendDataLn = (KeyNo.Length < 16)? KeyNo.Length : 16;

            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)blkNo;            // P2 : Starting Block No.
            SendBuff[4] = Convert.ToByte(SendDataLn);            // P3 : Data length/////////////////////////Error????

            for (indx = 0; indx <= SendDataLn-1; indx++)
            {

                SendBuff[indx + 5] = (byte)tmpStr[indx];

            }
            
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Error " + retCode.ToString());
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
        }

        private void CardGetData() 
        {

            string tmpStr;
            int indx;

            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xCA;
            SendBuff[2] = 0x01;
            SendBuff[3] = 0x00;
            SendBuff[4] = 0x00;

            SendLen = SendBuff[4] + 5;
            RecvLen = 0xFF;

            retCode = SendAPDU();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                return;

            }


                tmpStr = "";
                for (indx = 0; indx <= (RecvLen - 3); indx++)
                {

                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }
        }

        private void CardReset()
        {
            if (connActive)
            {

                retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            }

            retCode = ModWinsCard.SCardReleaseContext(hCard);
        }

        private void Authorization()
        {
            int indx;
            string tmpStr;

            ClearBuffers();
            // Load Authentication Keys command
            SendBuff[0] = 0xFF; // Class
            SendBuff[1] = 0x82; // INS
            SendBuff[2] = 0x00; // P1 : Key Structure
            SendBuff[3] = 0x00; // key # 
            SendBuff[4] = 0x06; // P3 : Lc
            SendBuff[5] = 0xff; // key input val
            SendBuff[6] = 0xff; // key input val
            SendBuff[7] = 0xff; // key input val
            SendBuff[8] = 0xff; // key input val
            SendBuff[9] = 0xff; // key input val
            SendBuff[10] = 0xff; // key input val

            SendLen = 11;
            RecvLen = 2;

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
            if (tmpStr.Trim() != "90 00")
            {
                MessageBox.Show("Load authentication keys error!");
            }

            ClearBuffers();

            SendBuff[0] = 0xFF;                             // Class
            SendBuff[1] = 0x86;                             // INS
            SendBuff[2] = 0x00;                             // P1
            SendBuff[3] = 0x00;                             // P2
            SendBuff[4] = 0x05;                             // Lc
            SendBuff[5] = 0x01;                             // Byte 1 : Version number
            SendBuff[6] = 0x00;                             // Byte 2
            SendBuff[7] = (byte)0x00;                          // Byte 3 : Block number

            SendBuff[8] = 0x60;                             // Key A Authentication


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
                }
                else
                {
                    MessageBox.Show("Authentication failed!");
                }

            }

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

        private int SendAPDU()
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
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

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

        private protected void OnCardPresent()
        {
            if (CardPresent != null && Present)
            {
                CardRead();
                CardPresent(this, EventArgs.Empty);
            }
        }

        private protected void OnCardAbsent()
        {
            if (CardAbsent != null && !Present)
            {
                CardAbsent(this, EventArgs.Empty);
                CardReset();
            }
        }

        private protected void OnCardResourceFailed()
        {
            if (CardResourceFailed != null && retCode == ModWinsCard.SCARD_E_SERVICE_STOPPED)
            {
                CardResourceFailed(this, EventArgs.Empty);
                CardReset();
                CardCk();
            }
        }
    }

}
