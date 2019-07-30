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
        public Customer CustomerLogin(string UserName, string Password)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT CustomerID FROM Customer WHERE CustomerUserName = '" + UserName + "' AND CustomerPassword = '" + Password + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    Session.CustomerID = customer.CustomerID;
                }
            }
            return customer;                       
        }
        public Employee EmployeeLogin(string UserName, string Password)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT EmployeeID FROM Employee WHERE EmployeeUserName = '" + UserName + "' AND EmployeePassword = '" + Password + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    Session.EmployeeID = employee.EmployeeID;
                }
            }
            return employee;
        }
        public OpsManager OpsManagerLogin(string UserName, string Password)
        {
            OpsManager opsManager = new OpsManager();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT OpsManagerID FROM OpsManager WHERE OpsManagerUserName = '" + UserName + "' AND OpsManagerPassword = '" + Password + "'";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    opsManager.OpsManagerID = Convert.ToInt32(rdr["OpsManagerID"]);
                    Session.OpsManagerID = opsManager.OpsManagerID;
                }
            }
            return opsManager;
        }
    }
}
