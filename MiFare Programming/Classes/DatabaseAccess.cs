using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MemIDFunc_namespace.Classes;

namespace MemIDFunc_namespace
{
    public class DatabaseAccess
    {
        private string connectionString;
        private SqlConnection ServerConnect;


        public delegate void NewMemEventHandler(object sender, EventArgs e);
        public event NewMemEventHandler NewMemTriggered;

        public delegate void CheckInEventHandler(object sender, EventArgs e, DataTable ds);
        public event CheckInEventHandler CheckInTriggered;

        public bool NewMem = false;
        public string DocumentDir;

        public DatabaseAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberInfo_dbConnectionString"].ConnectionString;
            

        }


        public DataTable PopServerMem(string KeyNo)
        {
            DataTable datasource = new DataTable();
            string query = "select [Name], [PhoneNum], [Picture], [EventLog] from [MemberInformation] " + "where  KeyNum = @ReadKey";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            using (SqlDataAdapter nadapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@ReadKey", KeyNo);

                nadapter.Fill(datasource);
            }

            return datasource;
        }

        public void CkDatabase(string KeyNo)
        {
            string query = "select [Name], [PhoneNum], [Picture], [EventLog] from [MemberInformation] " + "where  KeyNum = @ReadKey";
            int RowAffected;
            DataTable buffer = new DataTable();

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            using (SqlDataAdapter nadapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@ReadKey", KeyNo);

                
                RowAffected = nadapter.Fill(buffer);

                if(RowAffected != 0)
                {
                    NewMem = false;
                    OnCheckInTriggered(buffer);
                }
                else
                {
                    NewMem = true;
                    OnNewMemTriggered();
                }

            }
        }

        public void UpdateDB(MemberClass newMem)
        {

            string query = "INSERT INTO MemberInformation (Name, DOB, IDType, MemberID, PhoneNum," +
                " Email, MemDetail, KeyNum, Picture, Address, MembershipDoc, EventLog, EffDate)" +
                " VALUES " + "(@MemName, @MemDOB, @MemIDType, @MemID, @MemPhoneNum, @MemEmail," +
                " @Memdetail, @KeyNum, @Picture, @MemAdd, @MemDoc, @Log, @Effective)";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@MemName", newMem.Name);
                command.Parameters.AddWithValue("@MemDOB", newMem.DOB.Date);
                command.Parameters.AddWithValue("@MemIDType", newMem.IDType);
                command.Parameters.AddWithValue("@MemID", newMem.MemberID);
                command.Parameters.AddWithValue("@MemPhoneNum", newMem.PhoneNum);
                command.Parameters.AddWithValue("@MemEmail", newMem.Email);
                command.Parameters.AddWithValue("@Memdetail", newMem.MemDetail);
                command.Parameters.AddWithValue("@KeyNum", newMem.KeyNum);
                command.Parameters.AddWithValue("@Picture", newMem.Picture);
                command.Parameters.AddWithValue("@MemAdd", newMem.Address);
                command.Parameters.AddWithValue("@MemDoc", newMem.MembershipDoc);
                command.Parameters.AddWithValue("@Log", newMem.EventLog);
                command.Parameters.AddWithValue("@Effective", newMem.EffDate.Date);

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
