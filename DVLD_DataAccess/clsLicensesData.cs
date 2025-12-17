using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicensesData
    {

        public static int AddNew(int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive, int issueReason, int createdByUserID)
        {
           SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID) 
                             VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@Notes",string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            int newLicenseID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    newLicenseID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return newLicenseID;
        }

        public static bool Find (int licenseID, ref int applicationID, ref int driverID, ref int licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref float paidFees, ref bool isActive, ref int issueReason, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID 
                             FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = reader.GetInt32(0);
                    driverID = reader.GetInt32(1);
                    licenseClass = reader.GetInt32(2);
                    issueDate = reader.GetDateTime(3);
                    expirationDate = reader.GetDateTime(4);

                    if (!reader.IsDBNull(5))
                        notes = reader.GetString(5);
                    else
                        notes = string.Empty;

                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = reader.GetBoolean(7);
                    issueReason = reader.GetByte(8);
                    createdByUserID = reader.GetInt32(9);
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseID FROM Licenses WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            int licenseID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    licenseID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return licenseID;
        }









        //public static bool IsFirstTimeIssue(int applicationID, int localDrivingLicenseApplicationID, int licenseClassID)
        //{
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = @"SELECT COUNT(*) FROM Licenses L
        //                     INNER JOIN Applications A ON L.ApplicationID = A.ApplicationID
        //                     INNER JOIN LocalDrivingLicenseApplications LDLA ON A.ApplicationID = LDLA.ApplicationID
        //                     WHERE L.ApplicationID = @ApplicationID AND LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND LDLA.LicenseClassID = @LicenseClassID";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@ApplicationID", applicationID);
        //    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
        //    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
        //    int count = 0;

        //    try
        //    {
        //        connection.Open();
        //        count = (int)command.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return count == 0;
        //}




    }
}
