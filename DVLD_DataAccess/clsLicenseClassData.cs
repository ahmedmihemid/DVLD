using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT * FROM LicenseClasses";
            SqlCommand command = new SqlCommand(sql, connection);

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
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while retrieving license classes.", ex);
            }
            finally
            {
                connection.Close();

            }
            return dt;
        }


        public static bool Find(int licenseClassID, ref string className, ref string classDescription, ref int minimumAllowedAge, ref int defaultValidityLength, ref float classFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string sql = "SELECT ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        className = reader["ClassName"].ToString();
                        classDescription = reader["ClassDescription"].ToString();
                        minimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                        defaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                        classFees = Convert.ToSingle(reader["ClassFees"]);
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                    }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while finding the license class.", ex);
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
