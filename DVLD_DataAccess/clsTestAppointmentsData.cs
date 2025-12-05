using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsData
    {

        public static bool FindIfTestAppointment(int testAppointmentID, ref int testTypeID, ref int localDrivingLicenseApplicationID, ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID, ref bool isLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked " +
                         "FROM TestAppointments " +
                         "WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testTypeID = reader.GetInt32(0);
                    localDrivingLicenseApplicationID = reader.GetInt32(1);
                    appointmentDate = reader.GetDateTime(2);
                    paidFees = (float)reader.GetDecimal(3);
                    createdByUserID = reader.GetInt32(4);
                    isLocked = reader.GetBoolean(5);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in FindIfTestAppointment: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public static int addTestAppointment(int TestType,int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, int RetakeTestApplicationID ,bool IsLocked)
        {
          SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, RetakeTestApplicationID, IsLocked) " +
                         "VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @RetakeTestApplicationID, @IsLocked); " +
                         "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sql, connection);   
            command.Parameters.AddWithValue("@TestTypeID", TestType);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (RetakeTestApplicationID <= 0)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                int newID = Convert.ToInt32(command.ExecuteScalar());
                return newID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in addTestAppointment: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }



    }
}
