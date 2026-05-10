using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            string query = "SELECT * FROM DetainedLicenses_View";
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
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddDetainedLicense(int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool isReleased = false)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate,FineFees, CreatedByUserID, isReleased) " +
                           "VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @isReleased); " +
                           "SELECT SCOPE_IDENTITY();"; // Get the ID of the newly inserted record

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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
                EventLogger.LogEvent(ex);
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
                EventLogger.LogEvent(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool FineByDetainedID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref int FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToInt32(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MinValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref int FineFees,
           ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM  DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToInt32(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MinValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                    isFound=true;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                isFound =false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
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
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out count))
                {
                   return count > 0;
                }

            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return count > 0;
        }

        public static bool LicenseIsExist(int LicenseID)
        {
         
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        
        }


    }

}
