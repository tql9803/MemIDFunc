using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient; 
using System.Data;
using System.IO;

using MainUI_namespace.Object;

namespace MainUI_namespace.DataBase_Access
{
    public class InventoryTableAccess
    {

        public List<Item> ItemsList;

        private string cnstr;
        private SqlConnection connect;

        private const string GetInventoryQuery = "SELECT [ID], [Name], [Price] FROM [Inventory]";

        public InventoryTableAccess()
        {
            cnstr = ConfigurationManager.ConnectionStrings["MainUI_namespace.Properties.Settings.MemberInfo_dbConnectionString"].ConnectionString;  
        }

        public void UpdateInvnetory()
        {
            ItemsList = new List<Item>();
            
            using (connect = new SqlConnection(cnstr))
            using (SqlCommand command = new SqlCommand(GetInventoryQuery, connect))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable ds = new DataTable();
                int rowaffect;
                try
                {
                    rowaffect = adapter.Fill(ds);

                    if (rowaffect != 0)
                    {
                        foreach (DataRow dr in ds.Rows)
                        {
                            var bID = dr["ID"];
                            var bName = dr["Name"].ToString();
                            var bPrice = dr["Price"];

                            int bbID;
                            double bbPrice;

                            int.TryParse(bID.ToString(), out bbID);
                            double.TryParse(bPrice.ToString(), out bbPrice);

                            ItemsList.Add(new Item
                            {
                                ItemID = bbID,
                                Name = bName,
                                Price = bbPrice,
                                Category = ""
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    Application.Exit();
                    return;
                }
                

            }
            
        }
    }
}
