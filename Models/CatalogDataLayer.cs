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
                    //convert to 64

                    catalog.ItemStock = rdr["ItemStock"].ToString();
                    catalog.ItemPrice = rdr["ItemPrice"].ToString();

                    
                    lstCatalog.Add(catalog);
                }
                con.Close();
            }
            return lstCatalog;

        }

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
                    //get the image
                    byte[] photo = ((byte[])(rdr["ItemPhoto"]));
                    //convert to 64
                    catalog.ItemPhoto = Convert.ToBase64String(photo);
                    //format the string

                    catalog.ItemStock = rdr["ItemStock"].ToString();
                    catalog.ItemPrice = rdr["ItemPrice"].ToString();


                }
            }
            return catalog;

        }
    }
}
