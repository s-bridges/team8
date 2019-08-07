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

        //get one ops
        public OpsManager GetOpsManager(int? OpsManagerID)
        {
            OpsManager ops = new OpsManager();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM OpsManager WHERE OpsManagerID = " + OpsManagerID;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

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
                }

                return ops;
            }
        }

        //update ops manager
        public void UpdateOps(OpsManager ops)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateOps", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OpsManagerID", ops.OpsManagerID);
                cmd.Parameters.AddWithValue("@OpsManagerFirstName", ops.OpsManagerFirstName);
                cmd.Parameters.AddWithValue("@OpsManagerLastName", ops.OpsManagerLastName);
                cmd.Parameters.AddWithValue("@OpsManagerAddress", ops.OpsManagerAddress);
                cmd.Parameters.AddWithValue("@OpsManagerCity", ops.OpsManagerCity);
                cmd.Parameters.AddWithValue("@OpsManagerState", ops.OpsManagerState);
                cmd.Parameters.AddWithValue("@OpsManagerZipcode", ops.OpsManagerZipcode);
                cmd.Parameters.AddWithValue("@OpsManagerPhoneNumber", ops.OpsManagerPhoneNumber);
                cmd.Parameters.AddWithValue("@OpsManagerJobTitle", ops.JobTitle);

                cmd.Parameters.AddWithValue("@OpsManagerUserName", ops.OpsManagerUserName);
                cmd.Parameters.AddWithValue("@OpsManagerPassword", ops.OpsManagerPassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //add an operations manager
        public void AddOps(OpsManager ops)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOps", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OpsManagerFirstName", ops.OpsManagerFirstName);
                cmd.Parameters.AddWithValue("@OpsManagerLastName", ops.OpsManagerLastName);
                cmd.Parameters.AddWithValue("@OpsManagerAddress", ops.OpsManagerAddress);
                cmd.Parameters.AddWithValue("@OpsManagerCity", ops.OpsManagerCity);
                cmd.Parameters.AddWithValue("@OpsManagerState", ops.OpsManagerState);
                cmd.Parameters.AddWithValue("@OpsManagerZipcode", ops.OpsManagerZipcode);
                cmd.Parameters.AddWithValue("@OpsManagerPhoneNumber", ops.OpsManagerPhoneNumber);
                cmd.Parameters.AddWithValue("@OpsManagerJobTitle", ops.JobTitle);

                cmd.Parameters.AddWithValue("@OpsManagerUserName", ops.OpsManagerUserName);
                cmd.Parameters.AddWithValue("@OpsManagerPassword", ops.OpsManagerPassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }



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

        //delete an ops manager
        //delete a customer        
        public void DeleteOps(int? EmployeeID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

    }
}
