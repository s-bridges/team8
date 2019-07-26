using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class Order_CatalogDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;Persist Security Info=True;User ID=Team8;Password=WSCpassword8";


        public void AddOrder_Catalog(Order_Catalog order_Catalog)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder_Catalog", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@OrderID", order_Catalog.OrderID);
                cmd.Parameters.AddWithValue("@CatalogID", order_Catalog.CatalogID);
                cmd.Parameters.AddWithValue("@jobDescription", order_Catalog.jobDescription);
                cmd.Parameters.AddWithValue("@media", order_Catalog.media);
                cmd.Parameters.AddWithValue("@content", order_Catalog.content);
                cmd.Parameters.AddWithValue("@quantity", order_Catalog.quantity);
                cmd.Parameters.AddWithValue("@priceEach", order_Catalog.priceEach);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }




        
    }
}
