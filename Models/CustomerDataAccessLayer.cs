using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    //Data Access Layer for customer information
    public class CustomerDataAccessLayer
    {
     
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;User ID=Team8;Password=WSCpassword8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //this class displays all of the users in the system as a way to test, 
        //also useful when working witht the ops manager becuase it will show 
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> lstCustomer = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer();

                    customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    customer.CustomerFirstName = rdr["CustomerFirstName"].ToString();
                    customer.CustomerLastName = rdr["CustomerLastName"].ToString();
                    customer.CustomerAddress = rdr["CustomerAddress"].ToString();
                    customer.CustomerCity = rdr["CustomerCity"].ToString();
                    customer.CustomerState = rdr["CustomerState"].ToString();
                    customer.CustomerZipcode = Convert.ToInt32(rdr["CustomerZipcode"]);
                    customer.CustomerPhoneNumber = rdr["CustomerPhoneNumber"].ToString();
                    customer.CustomerUserName = rdr["CustomerUserName"].ToString();
                    customer.CustomerPassword = rdr["CustomerPassword"].ToString();

                    lstCustomer.Add(customer);
                }
                con.Close();
            }
            return lstCustomer;
        }

        //add new customer
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
                cmd.Parameters.AddWithValue("@CustomerLastname", customer.CustomerLastName);
                cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerState", customer.CustomerState);
                cmd.Parameters.AddWithValue("@CustomerZipcode", customer.CustomerZipcode);
                cmd.Parameters.AddWithValue("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
                cmd.Parameters.AddWithValue("@CustomerUserName", customer.CustomerUserName);
                cmd.Parameters.AddWithValue("@CustomerPassword", customer.CustomerPassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //update records of customers
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
                cmd.Parameters.AddWithValue("@CustomerLastname", customer.CustomerLastName);
                cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerState", customer.CustomerState);
                cmd.Parameters.AddWithValue("@CustomerZipcode", customer.CustomerZipcode);
                cmd.Parameters.AddWithValue("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
                cmd.Parameters.AddWithValue("@CustomerUserName", customer.CustomerUserName);
                cmd.Parameters.AddWithValue("@CustomerPassword", customer.CustomerPassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //look for a specific customer ---- useful with account information
        public Customer GetCustomerData(int? CustomerID)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM Customer WHERE CustomerID = " + CustomerID;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    customer.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    customer.CustomerFirstName = rdr["CustomerFirstName"].ToString();
                    customer.CustomerLastName = rdr["CustomerLastName"].ToString();
                    customer.CustomerAddress = rdr["CustomerAddress"].ToString();
                    customer.CustomerCity = rdr["CustomerCity"].ToString();
                    customer.CustomerState = rdr["CustomerState"].ToString();
                    customer.CustomerZipcode = Convert.ToInt32(rdr["CustomerZipcode"]);
                    customer.CustomerPhoneNumber = rdr["CustomerPhoneNumber"].ToString();
                    customer.CustomerUserName = rdr["CustomerUserName"].ToString();
                    customer.CustomerPassword = rdr["CustomerPassword"].ToString();
                }

                return customer;
            }

        }

        //delete a customer        
        public void DeleteCustomer(int? CustomerID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
