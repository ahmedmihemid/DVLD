using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
             string sql = "SELECT * FROM ApplicationTypes;";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool Find(int ApplicationTypeID, ref string ApplicationTypeTitle , ref decimal ApplicationFees)
        {
     
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                  isFound = true;
             
                  ApplicationTypeTitle =(string) reader["ApplicationTypeTitle"];
                  ApplicationFees =(decimal) reader["ApplicationFees"];


                }
                else
                {
                    isFound = false;
                }

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool Update(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE ApplicationTypes set
                          ApplicationTypeTitle =@ApplicationTypeTitle,
                          ApplicationFees = @ApplicationFees WHERE ApplicationTypeID = @ApplicationTypeID;  ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            int efecctedRows = 0;

            try
            {
                connection.Open();
                efecctedRows = command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (efecctedRows > 0);
        }
    }
}
