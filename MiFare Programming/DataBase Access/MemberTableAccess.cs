using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Imaging;
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
    public class MemberTableAccess
    {
        private string connectionString;
        private SqlConnection ServerConnect;


        public delegate void NewMemEventHandler(object sender, EventArgs e);
        public event NewMemEventHandler NewMemTriggered;

        public delegate void CheckInEventHandler(object sender, EventArgs e, DataTable ds);
        public event CheckInEventHandler CheckInTriggered;

        public bool NewMem = false;
        public string DocumentDir;

        private const string UpdateMemQuery = "UPDATE [MemberTable] SET";
        private const string AddMemQuery = "INSERT INTO [MemberTable] " +
                "(Name, DOB, IDType, MemberID, PhoneNum," +
                " Email, Address, EffDate, EndDate, IsValid, IsMember, Picture)" +
                " VALUES " +
                "(@Name, @DOB, @IDType, @MemberID, @PhoneNum," +
                " @Email, @Address, @EffDate, @EndDate, @IsValid, @IsMember, @Picture)";
        private const string AddDropQuery = "INSERT INTO [MemberTable] " +
                "(Name, PhoneNum, Email, Address, EffDate, IsMember, Picture)" +
                " VALUES " +
                "(@Name, @PhoneNum, @Email, @Address, @EffDate, @IsMember, @Picture)";
        private const string FindMemQuery = "select*from [MemberTable] where ";
        public int MemID;

        public MemberTableAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MainUI_namespace.Properties.Settings.MemberInfo_dbConnectionString"].ConnectionString;
            
        }


        public int PopServerMem(string KeyNo)
        {
            int datasource;

            string query = "select MAX([Id]) from [MemberInformation] ";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            {

                ServerConnect.Open();

                try
                {
                    datasource = (int)command.ExecuteScalar();

                    ServerConnect.Close();
                    return datasource;
                }
                catch(Exception e){
                    MessageBox.Show(e.ToString());

                    ServerConnect.Close();
                    return 0;

                }
                
            }
        }

        /// <summary>
        /// Looking for a Member in CardTable Table from the Database
        /// </summary>
        /// <param Column Name="Para"></param>
        /// <param Column Value="Value"></param>
        public MemberClass FindMember(object Para, object Value)
        {
            string FindQuery;

            if ((string)Para == "Name")
                FindQuery = FindMemQuery + $"[{Para}] like @ParamVal " +
                $"or [{Para}] like @ParamVal + CHAR(10) +'%' " +
                $"or [{Para}] like @ParamVal + CHAR(13) +'%' ";
            else
                FindQuery = FindMemQuery + $"[{Para}] = @ParamVal ";

            MemberClass Member = new MemberClass();

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(FindQuery, ServerConnect))
            {
                ServerConnect.Open();

                try
                {
                    command.Parameters.AddWithValue("@ParamVal", Value);

                    SqlDataReader rd;
                    rd = command.ExecuteReader();

                    if (rd.Read())
                    {
                        object[] BufferValue = new object[13];

                        rd.GetValues(BufferValue);

                        Member.ReadMember(BufferValue);


                        ServerConnect.Close();
                        return Member;
                    }
                    else
                    {
                        ServerConnect.Close();
                        return null;
                    }

                    
                }
                catch (Exception e)
                {
                    ServerConnect.Close();
                    MessageBox.Show(e.ToString());
                    Application.Exit();
                    return null;
                }
                


            }
        }


        

        
        /// <summary>
        /// Add member into the database
        /// </summary>
        /// <param member to be add="newMem"></param>
        public EventLogManipulation.EventTranslationFirst AddMember(MemberClass newMem, DocumentClass docpath = null)
        {
            //DocumentTableAccess DocAccess = new DocumentTableAccess();

            MemberClass buffMember;

            buffMember = this.FindMember("Name", newMem.Name);

            if (newMem.IsMember)
            {
                

                if (buffMember != null)
                {
                    
                    DialogResult dialogResult = MessageBox.Show("Member exist as DropIn in the system. Do you want to Promote(Ok), Add(No) or (Cancel)?", "Member's Name Existed"
                        , MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //buffMember = newMem;
                        //this.UpdateExistingMember(buffMember);
                        //DocAccess.UpdateExistingDoc(docpath);

                        return EventLogManipulation.EventTranslationFirst.Process_Cancel;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        buffMember = newMem;
                        this.AddNewMember(buffMember);
                        //DocAccess.AddDocument(docpath);

                        return EventLogManipulation.EventTranslationFirst.Member_New;
                    }
                    else
                    {
                        return EventLogManipulation.EventTranslationFirst.Process_Cancel;
                    }
                }
                else
                {
                    buffMember = newMem;
                    this.AddNewMember(buffMember);
                    //DocAccess.AddDocument(docpath);

                    return EventLogManipulation.EventTranslationFirst.Member_New;
                }


            }
            else
            {

                if (buffMember != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Person exist in the system. Do you want to Add DropIn(Ok) or (Cancel)?", "Member's Name Existed"
                        , MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        buffMember = newMem;
                        this.AddNewMember(buffMember);

                        //DocAccess.AddDocument(docpath);

                        return EventLogManipulation.EventTranslationFirst.Member_DropIn;
                    }
                    else
                    {
                        return EventLogManipulation.EventTranslationFirst.Process_Cancel;
                    }

                }
                else
                {
                    buffMember = newMem;
                    this.AddNewMember(buffMember);
                    //DocAccess.AddDocument(docpath);
                    
                    return EventLogManipulation.EventTranslationFirst.Member_DropIn;
                }
            }
        }
            
            
        
        
        /// <summary>
        /// Not working yet.
        /// For update existed member
        /// </summary>
        /// <param name="member"></param>
        public void UpdateExistingMember(MemberClass member)
        {
            string columnstring, conditionstring;
            string finalstring;
            columnstring = $" [Name] = '{member.Name}', [DOB] = '{member.DOB.Date}', [IDType] = '{member.IDType}'," +
                $" [MemberID] = '{member.MemberID}', [PhoneNum] = '{member.PhoneNum}', [Email] = '{member.Email}'," +
                $" [Address] = '{member.Address}', [EffDate] = '{member.EffDate.Date}', [EndDate] = '{member.EndDate}'," +
                $" [IsValid] = '{member.Validity}', [IsMember] = '{member.IsMember}', [Picture] = '{member.Picture}'";

            conditionstring = $" WHERE [Id] = {member.ID}";

            finalstring = UpdateMemQuery + columnstring + conditionstring;

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(finalstring, ServerConnect))
            {
                int Affected;
                ServerConnect.Open();
                try
                {
                    Affected = command.ExecuteNonQuery();
                    if(Affected != 0)
                    {
                        MessageBox.Show("Operation success");
                    }
                }
                catch(Exception e)
                {

                }
                ServerConnect.Close();
            }
        }
            

        

        public void AddNewMember(MemberClass newMem)
        {
            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(AddMemQuery, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@Name", newMem.Name);
                command.Parameters.AddWithValue("@DOB", newMem.DOB.Date);
                command.Parameters.AddWithValue("@IDType", newMem.IDType);
                command.Parameters.AddWithValue("@MemberID", newMem.MemberID);

                command.Parameters.AddWithValue("@PhoneNum", newMem.PhoneNum);
                command.Parameters.AddWithValue("@Email", newMem.Email);
                command.Parameters.AddWithValue("@Address", newMem.Address);


                command.Parameters.AddWithValue("@EffDate", newMem.EffDate.Date);
                command.Parameters.AddWithValue("@EndDate", newMem.EndDate.Date);
                command.Parameters.AddWithValue("@IsValid", newMem.Validity);
                command.Parameters.AddWithValue("@IsMember", newMem.IsMember);

                command.Parameters.AddWithValue("@Picture", newMem.Picture);


                int testa;
                testa = command.ExecuteNonQuery();

                ServerConnect.Close();
            }
        }

        public void AddNewDropin(MemberClass newMem)
        {
            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(AddDropQuery, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@Name", newMem.Name);

                command.Parameters.AddWithValue("@PhoneNum", newMem.PhoneNum);
                command.Parameters.AddWithValue("@Email", newMem.Email);
                command.Parameters.AddWithValue("@Address", newMem.Address);


                command.Parameters.AddWithValue("@EffDate", newMem.EffDate.Date);
                command.Parameters.AddWithValue("@IsMember", newMem.IsMember);

                command.Parameters.AddWithValue("@Picture", newMem.Picture);


                int testa;
                testa = command.ExecuteNonQuery();

                ServerConnect.Close();
            }
        }
        protected virtual void OnNewMemTriggered()
        {
            if (NewMemTriggered != null && NewMem)
                NewMemTriggered(this, EventArgs.Empty);
        }

        protected virtual void OnCheckInTriggered(DataTable ds)
        {
            if (CheckInTriggered != null && !NewMem)
                CheckInTriggered(this, EventArgs.Empty, ds);
        }
    }
}
