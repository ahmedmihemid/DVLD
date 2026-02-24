using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainedLicensesData
    {


        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM DetainedLicenses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while retrieving detained licenses.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddDetainedLicense(int driverID, DateTime detentionDate, string reason, int createdByUserID, bool isReleased = false)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO DetainedLicenses (DriverID, DetentionDate, Reason, CreatedByUserID, isReleased) " +
                           "VALUES (@DriverID, @DetentionDate, @Reason, @CreatedByUserID, @isReleased); " +
                           "SELECT SCOPE_IDENTITY();"; // Get the ID of the newly inserted record

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@DetentionDate", detentionDate);
            command.Parameters.AddWithValue("@Reason", reason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isReleased", isReleased);
            int newID = -1; // Default value in case of failure
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out newID))
                {
                    return newID; // Return the ID of the newly inserted record
                }

            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while adding a detained license.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static bool ReleaseDetainedLicense(int detainID, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE DetainedLicenses " +
                           "SET IsReleased = 1, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID " +
                           "WHERE DetainID = @DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);
            command.Parameters.AddWithValue("@DetainID", detainID);
            int rowsAffected = -1;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while releasing a detained license.", ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool FineDetainedLicense(int detainID, ref int LicenseID, ref DateTime DetainDate, ref int FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainID);

            int rowsAffected = -1;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    LicenseID = Convert.ToInt32(reader["DriverID"]);
                    DetainDate = Convert.ToDateTime(reader["DetentionDate"]);
                    FineFees = 100; // Example fine fee, you can calculate it based on your logic
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                    ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                    ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
                    ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                }
                else
                {
                    return false; // No record found with the given DetainID
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while retrieving detained license details.", ex);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public static bool IsLicenseDetained(int detainID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(*) FROM DetainedLicenses WHERE DetainID = @DetainID AND IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainID);
            int count = -1;
            try
            {
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while checking if the license is detained.", ex);
            }
            finally
            {
                connection.Close();
            }
            return count > 0; // If count is greater than 0, the license is detained
        }

        public static bool LicenseIsExist(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 1;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            int count = -1;
            try
            {
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
           
            }
            finally
            {
                connection.Close();
            }
            return count > 0;
        }


    }

}
