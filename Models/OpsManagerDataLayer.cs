using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class OpsManagerDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;User ID=Team8;Password=WSCpassword8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //get all opsmanagers 
        public IEnumerable<OpsManager> GetAllOps()
        {
            List<OpsManager> lstOps = new List<OpsManager>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM OpsManager";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    OpsManager ops = new OpsManager();


                    ops.OpsManagerID = Convert.ToInt32(rdr["OpsManagerID"]);
                    ops.OpsManagerFirstName = rdr["OpsManagerFirstName"].ToString();
                    ops.OpsManagerLastName = rdr["OpsManagerLastName"].ToString();
                    ops.OpsManagerAddress = rdr["OpsManagerAddress"].ToString();
                    ops.OpsManagerCity = rdr["OpsManagerCity"].ToString();
                    ops.OpsManagerState = rdr["OpsManagerState"].ToString();
                    ops.OpsManagerZipcode = Convert.ToInt32(rdr["OpsManagerZipcode"]);
                    ops.OpsManagerPhoneNumber = rdr["OpsManagerPhoneNumber"].ToString();
                    ops.JobTitle = rdr["OpsManagerJobTitle"].ToString();
                    ops.OpsManagerUserName = rdr["OpsManagerUserName"].ToString();
                    ops.OpsManagerPassword = rdr["OpsManagerPassword"].ToString();

                    lstOps.Add(ops);
                }
                con.Close();
            }
            return lstOps;
        }

    }
}
