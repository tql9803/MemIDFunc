using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using MiFare_Programming;

namespace MemIDFunc_namespace
{
    public partial class AddMemForm : Form
    {
        private string connectionString;
        private SqlConnection ServerConnect;
        public string KeyNo;

        public bool DBUpdated = false;

        public AddMemForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MemIDFunc_namespace.Properties.Settings.MemberID_dbConnectionString"].ConnectionString;
        }

        private void bFinish_Click(object sender, EventArgs e)
        {
            UpdateDB();
            if(DBUpdated)
            this.Close();
        }

        private void UpdateDB()
        {
            string buName, buPhone, buMdetail, buAdd;
            KeyNo = "";

            if (tName.Text == "")
            {
                tName.Focus();
                tName.Text = "";
                return;
            }
            else
                buName = tName.Text;

            if (tPhoneNum.Text == "")
            {
                tPhoneNum.Focus();
                tPhoneNum.Text = "";
                return;
            }
            else
                buPhone = tPhoneNum.Text;

            if (tMemDetail.Text == "")
            {
                tMemDetail.Focus();
                tMemDetail.Text = "";
                return;
            }
            else
                buMdetail = tMemDetail.Text;

            buAdd = "";
            if (tAddress.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to put in address?", "Address confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tAddress.Focus();
                    return;
                }
            }
            else
                buAdd = tAddress.Text;

            string[] buff = buName.Split(' ');
            for (int i = 0; i < buff.Length; i++)
            {
                KeyNo = KeyNo + buff[i][0];
            }

            byte[] Keybuff = Encoding.ASCII.GetBytes(KeyNo);
            KeyNo = "BF";
            for(int i = 0; i < Keybuff.Length; i++)
            {
                KeyNo = KeyNo + Convert.ToChar(Keybuff[i]);
            }

            DBUpdated = true;

            string query = "INSERT INTO MemID VALUES (@MemName, @MemPhoneNum, @nKeyNum, @MemPic, @MemAdd)";

            using (ServerConnect = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, ServerConnect))
            {
                ServerConnect.Open();
                
                command.Parameters.AddWithValue("@MemName",buName);
                command.Parameters.AddWithValue("@MemPhoneNum", buPhone);
                command.Parameters.AddWithValue("@nKeyNum", KeyNo);
                command.Parameters.AddWithValue("@MemPic","");
                command.Parameters.AddWithValue("@MemAdd", buAdd);

                command.ExecuteNonQuery();

                ServerConnect.Close();
            }
        }

        private void AtFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DBUpdated)
            {
                _ = MessageBox.Show("Member Added");
            }
            else
                _ = MessageBox.Show("Process is terminated");
        }
    }
}
