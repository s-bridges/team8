using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class PaymentDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;User ID=Team8;Password=WSCpassword8;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        
        //show all cards for a user
        public IEnumerable<Payment> GetAllCustomerPayment(int CustomerID)
        {
            

            List<Payment> lstPayment = new List<Payment>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM Payment WHERE CustomerID =  '" + CustomerID + "'";
                    
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Payment payment = new Payment();

                    payment.CardID = Convert.ToInt32(rdr["CardID"]);
                    payment.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    payment.BillingAddress = rdr["BillingAddress"].ToString();
                    payment.BillingCity = rdr["BillingCity"].ToString();
                    payment.BillingSTate = rdr["BillingSTate"].ToString();
                    payment.BillingZipcode = rdr["BillingZipcode"].ToString();
                    payment.CardType = rdr["CardType"].ToString();
                    payment.CardName = rdr["CardName"].ToString();
                    payment.CardExpDate = rdr["CardExpDate"].ToString();
                    payment.CardCVV = rdr["CardCVV"].ToString();


                    lstPayment.Add(payment);
                }
                con.Close();
            }
            return  lstPayment;

        }


       


        //update existing card

        public void UpdatePayment(Payment payment)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePayment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CardID", payment.CardID);
                cmd.Parameters.AddWithValue("@CustomerID", payment.CustomerID);
                cmd.Parameters.AddWithValue("@BillingAddress", payment.BillingAddress);
                cmd.Parameters.AddWithValue("@BillingCity", payment.BillingCity);
                cmd.Parameters.AddWithValue("@BillingSTate", payment.BillingSTate);
                cmd.Parameters.AddWithValue("@BillingZipcode", payment.BillingZipcode);
                cmd.Parameters.AddWithValue("@CardType", payment.CardType);
                cmd.Parameters.AddWithValue("@CardName", payment.CardName);
                cmd.Parameters.AddWithValue("@CardExpDate", payment.CardExpDate);
                cmd.Parameters.AddWithValue("@CardCVV", payment.CardCVV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
    

        //Add new Card
        public void AddPayment(Payment payment)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPayment", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@CustomerID", payment.CustomerID);
                cmd.Parameters.AddWithValue("@BillingAddress", payment.BillingAddress);
                cmd.Parameters.AddWithValue("@BillingCity", payment.BillingCity);
                cmd.Parameters.AddWithValue("@BillingSTate", payment.BillingSTate);
                cmd.Parameters.AddWithValue("@BillingZipcode", payment.BillingZipcode);
                cmd.Parameters.AddWithValue("@CardType", payment.CardType);
                cmd.Parameters.AddWithValue("@CardName", payment.CardName);
                cmd.Parameters.AddWithValue("@CardExpDate", payment.CardExpDate);
                cmd.Parameters.AddWithValue("@CardCVV", payment.CardCVV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }


        //Every card linked to a customer
        public Payment GetPaymentData(int? CardID)
        {
            
            Payment payment = new Payment();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM Payment WHERE CardID = " + CardID;

                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    payment.CardID = Convert.ToInt32(rdr["CardID"]);
                    payment.CustomerID  = Convert.ToInt32(rdr["CustomerID"]);
                    payment.BillingAddress = rdr["BillingAddress"].ToString();
                    payment.BillingCity = rdr["BillingCity"].ToString();
                    payment.BillingSTate = rdr["BillingSTate"].ToString();
                    payment.BillingZipcode = rdr["BillingZipcode"].ToString();
                    payment.CardType = rdr["CardType"].ToString();
                    payment.CardName = rdr["CardName"].ToString();
                    payment.CardExpDate = rdr["CardExpDate"].ToString();
                    payment.CardCVV = payment.CardCVV = rdr["CardCVV"].ToString();

                    
                }
            }
            return payment;

        }

    


        //delete Card 

        public void DeletePayment(int? CardID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePayment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CardID", CardID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}

