using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace team8.Models
{
    public class CatalogDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;Persist Security Info=True;User ID=Team8;Password=WSCpassword8";

        //get allitems
        public IEnumerable<Catalog> GetAllItems()
        {


            List<Catalog> lstCatalog = new List<Catalog>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM ItemCatalog";

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Catalog catalog = new Catalog();

                    catalog.CatalogID = Convert.ToInt32(rdr["CatalogID"]);
                    catalog.ItemName = rdr["ItemName"].ToString();
                    //get the image
                    catalog.ItemPhoto = rdr["ItemPhoto"].ToString();

                    catalog.ItemStock = rdr["ItemStock"].ToString();
                    catalog.ItemPrice = Convert.ToDecimal(rdr["ItemPrice"]);

                    
                    lstCatalog.Add(catalog);
                }
                con.Close();
            }
            return lstCatalog;

        }

        //get one item
        public Catalog GetOrderCatalog(int? CatalogID)
        {

            Catalog catalog = new Catalog();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM ItemCatalog WHERE CatalogID = " + CatalogID;

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    catalog.CatalogID = Convert.ToInt32(rdr["CatalogID"]);
                    catalog.ItemName = rdr["ItemName"].ToString();
                    //get the image as a url string - imgsrc = url  view
                    catalog.ItemPhoto = rdr["ItemPhoto"].ToString();

                    catalog.ItemStock = rdr["ItemStock"].ToString();
                    catalog.ItemPrice = Convert.ToDecimal(rdr["ItemPrice"]);


                }
            }
            return catalog;

        }

        //get the price of the option
        public Catalog GetItemPrice(int? CatalogID)
        {

            Catalog catalog = new Catalog();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT ItemPrice FROM ItemCatalog WHERE CatalogID = " + CatalogID;

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    catalog.ItemPrice = Convert.ToDecimal(rdr["ItemPrice"]);
                }
            }
            return catalog;

        }

        //updates the catalog
        public void UpdateCatalog(Catalog catalog)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCatalog", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CatalogID", catalog.CatalogID);
                cmd.Parameters.AddWithValue("@ItemName", catalog.ItemName);
                cmd.Parameters.AddWithValue("@ItemPhoto", catalog.ItemPhoto);
                cmd.Parameters.AddWithValue("@ItemStock", catalog.ItemStock);
                cmd.Parameters.AddWithValue("@ItemPrice", catalog.ItemPrice);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        //add catalog item
        public void AddCatalog(Catalog catalog)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCatalog", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@ItemName", catalog.ItemName);
                cmd.Parameters.AddWithValue("@ItemPhoto", catalog.ItemPhoto);
                cmd.Parameters.AddWithValue("@ItemStock", catalog.ItemStock);
                cmd.Parameters.AddWithValue("@ItemPrice", catalog.ItemPrice);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //delete a catalog entry
        public void DeleteCatalog(int? CatalogID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCatalog", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CatalogID", CatalogID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //get one item
        public IEnumerable<Catalog> GetCatalogName(char ItemName)
        {

            List<Catalog> lstCatalog = new List<Catalog>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM ItemCatalog WHERE ItemName LIKE '"+ ItemName + "%'";

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Catalog catalog = new Catalog();

                    catalog.CatalogID = Convert.ToInt32(rdr["CatalogID"]);
                    catalog.ItemName = rdr["ItemName"].ToString();
                    //get the image
                    catalog.ItemPhoto = rdr["ItemPhoto"].ToString();

                    catalog.ItemStock = rdr["ItemStock"].ToString();
                    catalog.ItemPrice = Convert.ToDecimal(rdr["ItemPrice"]);


                    lstCatalog.Add(catalog);

                }
            }
            return lstCatalog;

        }

    }
}
