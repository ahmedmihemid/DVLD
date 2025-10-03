using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {

        public static int AddNew(int ApplicationID, int LicenseClassID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) " +
                         "VALUES (@ApplicationID, @LicenseClassID); " +
                         "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            int newID = -1;
            try
            {
                connection.Open();
                newID = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                newID = -1;
            }
            finally
            {
                connection.Close();
            }
            return newID;
        }


        public static bool IsExist(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT COUNT(*) FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID AND LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            bool exists = false;

            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                exists = false;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }


        public static bool HasApplicationForLicenseClass(int ApplicantPersonID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Count(*) from LocalDrivingLicenseApplications inner join Applications on 
                           Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                           where LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID 
                           and Applications.ApplicantPersonID = @ApplicantPersonID  and Applications.ApplicationStatus = 1 ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            bool hasApplication = false;
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                hasApplication = count > 0;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                hasApplication = false;
            }
            finally
            {
                connection.Close();
            }

            return hasApplication;
        }

        public static bool FindByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                {
                    isFound = false;
                }


            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
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
