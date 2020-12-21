using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MainUI_namespace.Object;
using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Classes;

namespace MainUI_namespace.DataBase_Access
{
    public class CardTableAccess
    {
        private string connectionString;
        private SqlConnection ServerConnect;

        private const string AddCardQuery = "INSERT INTO [CardTable] (CardNo, EffDate, EndDate, IsActive, CustomerID)" +
            " VALUES " +
            "(@CardNo, @EffDate, @EndDate, @IsActive, @CustomerID)";
        private const string FindCardQuery = "select*from [CardTable] " + "where ";
        private const string FindNewestCardQuery = "Select max(CardID) as LastCardID from[CardTable]"; // For CardID
        private const string UpdateExCardQuery = "UPDATE [CardTable] SET ";
        public CardTableAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberInfo_dbConnectionString"].ConnectionString;
            //MainCard = new CardClass();
        }

        /// <summary>
        /// Update the Card Information in CardTable
        /// </summary>
        /// <param TargetCard = "Card"></param>
        public void UpdateExistingCard(CardClass card)
        {
            int RowAffected;
            string Updatequery;

            Updatequery = UpdateExCardQuery + $"[EffDate] = @EffDate," +
                $" [EndDate] = @EndDate, [IsActive] = @IsActive, [CustomerID] = @CustomerID" +
                " WHERE " + $"[CardID] = @CardID";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Updatequery, ServerConnect))
            {
                ServerConnect.Open();

                try
                {
                    command.Parameters.AddWithValue("@EffDate", card.EffDate.Date);
                    command.Parameters.AddWithValue("@EndDate", card.EndDate.Date);
                    command.Parameters.AddWithValue("@IsActive", card.IsActive);
                    command.Parameters.AddWithValue("@CustomerID", card.CustomerID);

                    command.Parameters.AddWithValue("@CardID", card.CardID);
                    RowAffected = command.ExecuteNonQuery();

                    if (RowAffected != 0)
                    {
                    }
                    else
                    {
                    }

                    ServerConnect.Close();
                }
                catch (Exception e)
                    {
                    MessageBox.Show(e.ToString());
                    Application.Exit();
                }
            }
        }
        /// <summary>
        /// Add New Card in the system
        /// </summary>
        /// <param TargetCard = "NewCard"></param>
        public void AddCard(CardClass NewCard)
        {
            int RowAffected;

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(AddCardQuery, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@CardNo", NewCard.CardNumber);
                command.Parameters.AddWithValue("@EffDate", NewCard.EffDate);
                command.Parameters.AddWithValue("@EndDate", NewCard.EndDate);
                command.Parameters.AddWithValue("@IsActive", NewCard.IsActive);
                command.Parameters.AddWithValue("@CustomerID", NewCard.CustomerID);

                try
                {
                    RowAffected = command.ExecuteNonQuery();

                    if (RowAffected != 0)
                    {
                        MessageBox.Show("Card is Successfully Added");

                    }
                    else
                    {
                        throw new Exception("Document does not exist in the system, Check the source code");
                    }

                    ServerConnect.Close();
                }
                catch (Exception e)
                {
                    ServerConnect.Close();

                    MessageBox.Show(e.ToString());
                    Application.Exit();


                }
            }
        }
        /// <summary>
        /// Looking for a card in CardTable Table from the Database using info that is assign to card.
        /// </summary>
        /// <param Column Name="Para"></param>
        /// <param Column Value="Value"></param>
        public List<CardClass> FindCard(object Para, object Value)
        {
            string FinalString = FindCardQuery + $"[{Para}] = @ParamVal";
            object[] buffer = new object[6];

            List<CardClass> CardList = new List<CardClass>();
            CardClass ReadCard = new CardClass();

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(FinalString, ServerConnect))
            {
                ServerConnect.Open();

                try
                {
                    command.Parameters.AddWithValue("@ParamVal", Value);

                    SqlDataReader rd;
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        rd.GetValues(buffer);

                        ReadCard.ReadCard(buffer);

                        CardList.Add(ReadCard);
                    }

                    ServerConnect.Close();

                    return (CardList == new List<CardClass>()) ? null : CardList;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString()); 
                    return null;
                }
            }
        }

        /// <summary>
        /// Assign Card Existed from Card Table to a Member in Membertable
        /// </summary>
        /// <param Target Member = "Member"></param>
        /// <param Unassign Card to be assign = "eCard"></param>
        public void AssignCard(MemberClass Member, CardClass eCard)
        {
            MemberTableAccess MemberAccess = new MemberTableAccess();
            DocumentTableAccess DocumentAccess = new DocumentTableAccess();

            List<CardClass> CardList;

            MemberClass buffMember;
            CardClass buffCard;
            DocumentClass buffDoc;

            buffMember = MemberAccess.FindMember("Name", Member.Name);

            if (buffMember != new MemberClass())
            {
                CardList = this.FindCard("CustomerID", buffMember.ID);

                if(CardList != null)
                {
                    foreach(CardClass buff in CardList)
                    {
                        buff.IsActive = false;
                        buff.EndDate = DateTime.Today;

                        this.UpdateExistingCard(buff);
                    }

                    buffDoc = DocumentAccess.FindDocument("SystemID", buffMember.ID);
                    DocumentAccess.UpdatePersonalLog(buffDoc, EventLogManipulation.EventTranslationFirst.Card_Loss);
                    ////Update Daily log
                }
                else
                {
                    CardList = this.FindCard("CardID", eCard.CardID);

                    if(CardList.Count != 0)
                    {
                        buffCard = CardList[0];

                        buffCard.CustomerID = buffMember.ID;

                        buffCard.IsActive = buffMember.Validity;
                        buffCard.EffDate = buffMember.EffDate;
                        buffCard.EndDate = buffMember.EndDate;

                        this.UpdateExistingCard(buffCard);
                        MemberAccess.UpdateExistingMember(buffMember);

                        buffDoc = DocumentAccess.FindDocument("SystemID", buffMember.ID);
                        DocumentAccess.UpdatePersonalLog(buffDoc, EventLogManipulation.EventTranslationFirst.Card_Replace);
                        //// Update daily log
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Add Member First");
            }           


        }


        /// <summary>
        /// Fing the latest cardID on the database
        /// </summary>
        public int FindLastCardID()
        {
            int ResultID;

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(FindNewestCardQuery, ServerConnect))
            {
                ServerConnect.Open();

                string IDstring;
                command.CommandType = CommandType.Text;
                IDstring = command.ExecuteScalar().ToString();

                int.TryParse(IDstring, out ResultID);


                ServerConnect.Close();
            }

            return ResultID;
        }
               

    }
}
