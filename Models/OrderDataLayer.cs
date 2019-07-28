using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class OrderDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;Persist Security Info=True;User ID=Team8;Password=WSCpassword8";


        public IEnumerable<Order> GetAllCustomerOrder(int CustomerID)
        {
            List<Order> lstOrder = new List<Order>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM OrderInformation WHERE CustomerID =  '" + CustomerID + "'";

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Order order = new Order();

                    order.OrderID = Convert.ToInt32(rdr["OrderID"]);
                    order.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    order.CatalogID = Convert.ToInt32(rdr["CatalogID"]);
                    order.JobType = rdr["JobType"].ToString();
                    order.Media = rdr["Media"].ToString();
                    order.Content = rdr["Content"].ToString();
                    order.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    order.Total = Convert.ToDecimal(rdr["Total"]);
                    order.OrderStatus = rdr["OrderStatus"].ToString();
                    order.PaymentType = rdr["PaymentType"].ToString();                 


                    lstOrder.Add(order);
                }
                con.Close();
            }
            return lstOrder;
        }

        //get details for a single order
        public Order GetOrderData(int? OrderID)
        {

            Order order = new Order();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM OrderInformation WHERE OrderID = " + OrderID;

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.OrderID = Convert.ToInt32(rdr["OrderID"]);
                    order.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    order.CatalogID = Convert.ToInt32(rdr["CatalogID"]);
                    order.JobType = rdr["JobType"].ToString();
                    order.Media = rdr["Media"].ToString();
                    order.Content = rdr["Content"].ToString();
                    order.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    order.Total = Convert.ToDecimal(rdr["Total"]);
                    order.OrderStatus = rdr["OrderStatus"].ToString();
                    order.PaymentType = rdr["PaymentType"].ToString();



                }
            }
            return order;

        }

        public void AddOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@CatalogID", order.CatalogID);
                cmd.Parameters.AddWithValue("@JobType", order.JobType);
                cmd.Parameters.AddWithValue("@Media", order.Media);
                cmd.Parameters.AddWithValue("@Content", order.Content);
                cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@Total", order.Total);
                cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                cmd.Parameters.AddWithValue("@PaymentType", order.PaymentType);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
       


    }
}
