using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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


        public static bool Update(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = @"UPDATE LocalDrivingLicenseApplications SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID 
                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            bool isUpdated = false;

            try
            {
                connection.Open();
                int num = command.ExecuteNonQuery();
                isUpdated = num > 0;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                isUpdated = false;
            }
            finally
            {
                connection.Close();
            }
            return isUpdated;
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
                           and Applications.ApplicantPersonID = @ApplicantPersonID and Applications.ApplicationStatus <> 2;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            //command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
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

        public static bool Find(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
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

        public static DataTable GetAllLocalDrivingLicenseApplicationInfo()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT * FROM LocalDrivingLicenseApplications_View;";
            SqlCommand command = new SqlCommand(sql, connection);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                else
                {
                    dataTable = null;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                dataTable = null;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static int GetLocalDrivingLicenseApplicationPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = @"select COUNT(*) from TestAppointments inner join Tests on 
                           Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                           where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           and Tests.TestResult= 1;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            int passedTestsCount = 0;
            try
            {
                connection.Open();
                passedTestsCount = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
                passedTestsCount = 0;
            }
            finally
            {
                connection.Close();
            }
            return passedTestsCount;
        }
    
        
        




    }
}
