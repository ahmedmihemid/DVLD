using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DVLD_DataAccess
{
    public class clsDriversData
    {

        public static int AddNewDriver(int personID, int createdByUserID)
        {
          SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate) 
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            int newDriverID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newDriverID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return newDriverID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //we dont update the createddate for the driver.
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool GetDriverInfoByPersonID(int personID, ref int driverID, ref int createdByUserID, ref DateTime createdDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT DriverID, CreatedByUserID, CreatedDate FROM Drivers WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
           
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    driverID = reader.GetInt32(0);
                    createdByUserID = reader.GetInt32(1);
                    createdDate = reader.GetDateTime(2);
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetDriverInfoByDriverID(int driverID, ref int personID, ref int createdByUserID, ref DateTime createdDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PersonID, CreatedByUserID, CreatedDate FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personID = reader.GetInt32(0);
                    createdByUserID = reader.GetInt32(1);
                    createdDate = reader.GetDateTime(2);
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllDrivers ()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
           string query = "SELECT * FROM Drivers_View";



            SqlCommand command = new SqlCommand(query, connection);

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
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }


        


    }
}
