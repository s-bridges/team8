using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class LoginDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;User ID=Team8;Password=WSCpassword8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //see if a customer may login.
        public Customer CustomerLogin(string CustomerUserName, string CustomerPassword)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT CustomerID FROM Customer WHERE CustomerUserName = '" + CustomerUserName + "' AND CustomerPassword = '" + CustomerPassword + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);

                }

            }

            return customer;



        }
    }
}
