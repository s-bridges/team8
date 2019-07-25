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
                    order.OrderStatus = rdr["OrderStatus"].ToString();
                    order.PaymentType = rdr["PaymentType"].ToString();


                }
            }
            return order;

        }


    }
}
