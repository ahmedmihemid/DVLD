using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypesData
    {

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
          
            string query = "SELECT * FROM TestTypes";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            { 
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while retrieving test types.", ex);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public static bool Find(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestFees)
        {
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestTypeDescription = reader["TestTypeDescription"].ToString();
                    TestFees = (decimal)reader["TestTypeFees"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while finding the test type.", ex);
                isFound = false;
            }
            finally
            {
                con.Close();
            }

            return isFound;
        }

        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestFees)
        {
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE TestTypes SET TestTypeTitle = @TestTypeTitle," +
                " TestTypeDescription = @TestTypeDescription, " +
                "TestTypeFees = @TestTypeFees WHERE TestTypeID = @TestTypeID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestFees);

            int efecctedRows = 0;
            try
            {
                con.Open();
                efecctedRows = cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the test type.", ex);
            }
            finally
            {
                con.Close();
            }
            return efecctedRows > 0;

        }

    }
}
