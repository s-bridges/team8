using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class EmployeeDataLayer
    {
        string connectionString = "Data Source=wscteam8.database.windows.net;Initial Catalog=WSC_Team_8;User ID=Team8;Password=WSCpassword8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //look for a specific employee---- useful with account information
        public Employee GetEmployeeData(int? EmployeeID)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM Employee WHERE EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeFirstName = rdr["EmployeeFirstName"].ToString();
                    employee.EmployeeLastName = rdr["EmployeeLastName"].ToString();
                    employee.EmployeeAddress = rdr["EmployeeAddress"].ToString();
                    employee.EmployeeCity = rdr["EmployeeCity"].ToString();
                    employee.EmployeeState = rdr["EmployeeState"].ToString();
                    employee.EmployeeZipcode = Convert.ToInt32(rdr["EmployeeZipcode"]);
                    employee.EmployeePhoneNumber = rdr["EmployeePhoneNumber"].ToString();
                    employee.JobTitle = rdr["EmployeeJobTitle"].ToString();
                    employee.EmployeeUserName = rdr["EmployeeUserName"].ToString();
                    employee.EmployeePassword = rdr["EmployeePassword"].ToString();
                }

                return employee;
            }

        }

        //update record employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("@EmployeeCity", employee.EmployeeCity);
                cmd.Parameters.AddWithValue("@EmployeeState", employee.EmployeeState);
                cmd.Parameters.AddWithValue("@EmployeeZipcode", employee.EmployeeZipcode);
                cmd.Parameters.AddWithValue("@EmployeePhoneNumber", employee.EmployeePhoneNumber);
                cmd.Parameters.AddWithValue("@EmployeeJobTitle", employee.JobTitle);

                cmd.Parameters.AddWithValue("@EmployeeUserName", employee.EmployeeUserName);
                cmd.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();


                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeFirstName = rdr["EmployeeFirstName"].ToString();
                    employee.EmployeeLastName = rdr["EmployeeLastName"].ToString();
                    employee.EmployeeAddress = rdr["EmployeeAddress"].ToString();
                    employee.EmployeeCity = rdr["EmployeeCity"].ToString();
                    employee.EmployeeState = rdr["EmployeeState"].ToString();
                    employee.EmployeeZipcode = Convert.ToInt32(rdr["EmployeeZipcode"]);
                    employee.EmployeePhoneNumber = rdr["EmployeePhoneNumber"].ToString();
                    employee.JobTitle = rdr["EmployeeJobTitle"].ToString();
                    employee.EmployeeUserName = rdr["EmployeeUserName"].ToString();
                    employee.EmployeePassword = rdr["EmployeePassword"].ToString();

                    lstEmployee.Add(employee);
                }
                con.Close();                
            } 
            return lstEmployee;

        }
        

        //add a new employee 
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("@EmployeeCity", employee.EmployeeCity);
                cmd.Parameters.AddWithValue("@EmployeeState", employee.EmployeeState);
                cmd.Parameters.AddWithValue("@EmployeeZipcode", employee.EmployeeZipcode);
                cmd.Parameters.AddWithValue("@EmployeePhoneNumber", employee.EmployeePhoneNumber);
                cmd.Parameters.AddWithValue("@EmployeeJobTitle", employee.JobTitle);

                cmd.Parameters.AddWithValue("@EmployeeUserName", employee.EmployeeUserName);
                cmd.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //delete a customer        
        public void DeleteEmployee(int? EmployeeID)
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
