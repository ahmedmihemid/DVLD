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



        public static int GetNumberOfPassedTests(int localDrivingLicenseApplicationID)
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




    }

}
