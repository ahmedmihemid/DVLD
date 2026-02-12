using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {



        public static int GetNumberOfPassedTests(int localDrivingLicenseApplicationID )
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = @"SELECT COUNT(*) FROM Tests t
                           INNER JOIN TestAppointments ta ON t.TestAppointmentID = ta.TestAppointmentID
                           WHERE ta.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND t.TestResult = 1;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            int passedTestsCount = 0;
            try
            {
                connection.Open();
                passedTestsCount = Convert.ToInt32(command.ExecuteScalar());
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
 

        public static bool HasTestResult(int localDrivingLicenseApplicationID, int testTypeID,int testResult)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sql = @"Select count(*) 
                   from Tests 
                   inner join TestAppointments 
                   on Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                   where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                   AND Tests.TestResult = @testResult
                   AND TestAppointments.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@testResult", testResult);

            int failedTestsCount = 0;

            try
            {
                connection.Open();
                failedTestsCount = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                failedTestsCount = 0;
            }
            finally
            {
                connection.Close();
            }

            return failedTestsCount > 0;
        }
        public static int AddNew(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                           VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                           SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);   
            command.Parameters.AddWithValue("@TestResult", testResult);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            int newID = 0;

            try
            { 
                connection.Open();
                newID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                newID = 0;
            }
            finally
            {
                connection.Close();
            }

            return newID;
        }

        public static bool FindLastTestPerPersonAndLicenseClass(int ApplicantPersonID,int  LicenseClassID, int TestTypeID,ref int  TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID )
        {
          
        }


    }

}
