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

        public void UpdateDB(string buName, string buPhone, string buEmail, string buMdetail,
            string KeyNo, byte[] picture, string buAdd, string MembershipDoc, string EventLog)
        {

            string query = "INSERT INTO MemberInformation (Name, PhoneNum, Email, MemDetail, KeyNum, Picture, Address, MembershipDoc, EventLog)" +
                " VALUES " + "(@MemName, @MemPhoneNum, @MemEmail, @Memdetail, @KeyNum, @Picture, @MemAdd, @MemDoc, @Log)";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@MemName", buName);
                command.Parameters.AddWithValue("@MemPhoneNum", buPhone);
                command.Parameters.AddWithValue("@MemEmail", buEmail);
                command.Parameters.AddWithValue("@Memdetail", buMdetail);
                command.Parameters.AddWithValue("@KeyNum", KeyNo);
                command.Parameters.AddWithValue("@Picture", picture);
                command.Parameters.AddWithValue("@MemAdd", buAdd);
                command.Parameters.AddWithValue("@MemDoc", MembershipDoc);
                command.Parameters.AddWithValue("@Log", EventLog);

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
