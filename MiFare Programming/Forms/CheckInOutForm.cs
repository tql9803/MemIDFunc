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

using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Classes;
using MainUI_namespace.Object;

namespace MainUI_namespace.Forms
{
    public partial class CheckInOutForm : Form
    {
        string LogPath = @"C:\Users\Public\Documents\";
        string DailyLog = "CCSheet ";
        DateTime TodayDate;

        CardThreading CardThread;

        MemberTableAccess MemberAccess;
        CardTableAccess CardAccess;
        DocumentTableAccess DocAccess;

        CardClass Card;
        MemberClass Member;
        DocumentClass Doc;

        public string LogFile;
        string SaveAsDocPath = @"C:\MemIDDocument\ClientsDocuments\";

        public CheckInOutForm()
        {
            InitializeComponent();
        }

        private void FindTodayLog(bool InOut)
        {
            /////
            string ddLog = LogPath + DailyLog + DateTime.Today.Date.ToString("yyyy MM dd") + ".csv";

            using (System.IO.StreamWriter streamWriter = File.AppendText(ddLog))
            {
                if(InOut)
                    streamWriter.WriteLine(Member.Name + "," + DateTime.Now.ToString("yy/MM/dd hh:mm"));
                else
                    streamWriter.Write("," + DateTime.Now.ToString("yy/MM/dd hh:mm"));
            }
        }
        private void InitMenu()
        {
            CardThread = new CardThreading();
            CardAccess = new CardTableAccess();


            Task cardState = new Task(CardThread.CardChecking.Invoke);
            cardState.Start();

            CardThread.CardPresent += this.OnCardPresent;

            Member = new MemberClass();
        }


        private void OnCardPresent(object sender, EventArgs e)
        {
            MemberAccess = new MemberTableAccess();
            DocAccess = new DocumentTableAccess();

            List<CardClass> CardList;

            byte[] bufferKey;

            string LastLine = "";
            string[] LineComp;

            bufferKey = CardThread.KeyNo;
            CardList = CardAccess.FindCard("CardNo", bufferKey);

            if (CardList.Count != 0)
            {
                if (CardList[0].IsActive) 
                {
                    Member = MemberAccess.FindMember("Id", CardList[0].CustomerID);

                    Doc = DocAccess.FindDocument("SystemID", Member.ID);
                    if (Doc != null)
                    {
                        if(string.IsNullOrEmpty(Doc.EventLog))
                        {
                            char[] Trimmer = { '\r', '\n' };
                            Doc.EventLog = SaveAsDocPath + Member.Name.Trim(Trimmer);
                            System.IO.DirectoryInfo dir = Directory.CreateDirectory(Doc.EventLog);

                            Doc.EventLog = Doc.EventLog + @"\" + "EventLog " + Member.Name.Trim(Trimmer) + ".csv";
                            DocAccess.UpdateExistingDoc(Doc);
                        }


                        if (File.Exists(Doc.EventLog))
                            LastLine = File.ReadLines(Doc.EventLog).Last();

                        LineComp = LastLine.Split(',');

                        switch (LineComp[0])
                        {
                            case "CheckIn":
                                FindTodayLog(false);
                                DocAccess.UpdatePersonalLog(Doc, EventLogManipulation.EventTranslationFirst.CheckOut);
                                break;
                            case "CheckOut":
                                FindTodayLog(true);
                                DocAccess.UpdatePersonalLog(Doc, EventLogManipulation.EventTranslationFirst.CheckIn);

                                break;
                            default:
                                FindTodayLog(true);
                                DocAccess.UpdatePersonalLog(Doc, EventLogManipulation.EventTranslationFirst.CheckIn);

                                break;
                        }

                    }
                    
                }
                else
                {
                    MessageBox.Show("The card is not Active");
                }
            }
            else
            {
                MessageBox.Show("The card is not in the system");
            }
        }

        //private void UpdateDailyLog(EventLogManipulation.EventTranslationFirst Msg)
        //{
        //    using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(LogFile, true))
        //    {
        //        streamWriter.WriteLine(Msg.ToString() + "," + DateTime.Now.ToString("yy/MM/dd hh:mm"));
        //    }
        //}


        private void bScan_Click(object sender, EventArgs e)
        {
            InitMenu();
            bScan.Enabled = false;
        }
    }
}
