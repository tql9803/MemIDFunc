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
    class DocumentTableAccess
    {

        private string connectionString;
        private SqlConnection ServerConnect;

        private const string AddDocQuery = "INSERT INTO [DocumentTable]" +
            "(Eventlog, Waiver, Membership, DocID)" +
            " VALUES " +
            "(@EventLog,@Waiver,@Membership,@DocID)"; 
        private const string FindDocQuery = "select*from [DocumentTable] ";
        private const string FindNewestDocQuery = "Select max(DocID) as LastDocID from [DocumentTable]"; // For systemID
        private const string UpdateExDocumentQuery = "UPDATE [DocumentTable] SET ";

        public DocumentTableAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberInfo_dbConnectionString"].ConnectionString;
            //MainDocument = new DocumentClass();
        }


        /// <summary>
        /// Find the document with parameter
        /// </summary>
        /// <param Column Name="Para"></param>
        /// <param Value in of the document column="Value"></param>
        /// <returns></returns>
        public DocumentClass FindDocument(object Para, object Value)
        {
            string FindQuery;
            DocumentClass buffDoc = new DocumentClass();
            object[] buffer = new object[5];

            FindQuery = FindDocQuery + $" where  [{Para}] = @ParameterValue";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(FindQuery, ServerConnect))
            {

                ServerConnect.Open();
                try
                {
                    command.Parameters.AddWithValue("@ParameterValue", Value);

                    SqlDataReader rd;
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        rd.GetValues(buffer);

                        buffDoc.ReadDocument(buffer);
                    }

                    ServerConnect.Close();

                    return buffDoc;
                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    Application.Exit();
                    return buffDoc;
                }

            }
        }

        /// <summary>
        /// Find the Last Document ID
        /// </summary>
        /// <returns></returns>
        public int FindLastDocID()
        {
            int ResultID;

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(FindNewestDocQuery, ServerConnect))
            {
                ServerConnect.Open();

                command.CommandType = CommandType.Text;
                var res = command.ExecuteScalar();
                ResultID = (res == DBNull.Value) ? 0 : (int)res;


                ServerConnect.Close();
            }

            return ResultID;
        }

        /// <summary>
        /// Add new record of document into document table
        /// </summary>
        /// <param Document of a member="Document"></param>
        /// <param Message to update into the persaonal log="Message"></param>
        public void AddDocument(DocumentClass NewDoc)
        {
            int RowAffected;

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(AddDocQuery, ServerConnect))
            {
                ServerConnect.Open();

                command.Parameters.AddWithValue("@SystemID", NewDoc.SystemID);
                command.Parameters.AddWithValue("@EventLog", NewDoc.EventLog);
                command.Parameters.AddWithValue("@Waiver", NewDoc.Waiver);
                command.Parameters.AddWithValue("@Membership", NewDoc.MembershipDoc);
                command.Parameters.AddWithValue("@DocID", NewDoc.DocID);

                try
                {
                    RowAffected = command.ExecuteNonQuery();

                    if (RowAffected != 0)
                    {
                    }
                    else
                    {
                        throw new Exception("Document does not exist in the system, Check the source code");
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
        /// Update data to to exist document
        /// </summary>
        /// <param Document to be update="Doc"></param>
        public void UpdateExistingDoc(DocumentClass doc)
        {
            int RowAffected;
            string Updatequery;

            Updatequery = UpdateExDocumentQuery + $"Waiver = {doc.Waiver}, Membership = {doc.MembershipDoc}," +
                $" DocID = {doc.DocID}" + " WHERE " + $"SystemID = {doc.SystemID}";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Updatequery, ServerConnect))
            {
                ServerConnect.Open();

                try
                {
                    RowAffected = command.ExecuteNonQuery();

                    if (RowAffected != 0)
                    {
                        //UpdatePersonalLog(doc, Msg);
                    }
                    else
                    {
                        throw new Exception("Document does not exist in the system, Check the source code");
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
        /// Update Personal Eventlog
        /// </summary>
        /// <param Document of a member="Document"></param>
        /// <param Message to update into the persaonal log="Message"></param>
        public void UpdatePersonalLog(DocumentClass Document, EventLogManipulation.EventTranslationFirst Message)
        {
            string PersonalLog =(string.IsNullOrEmpty(Document.EventLog)) ? null : Document.EventLog;

            using (StreamWriter fstream = new StreamWriter(PersonalLog, true))
            {
                fstream.WriteLine(Message.ToString() + "," + DateTime.Now.ToString("yy/MM/dd hh:mm"));
            }

        }
    }
}
