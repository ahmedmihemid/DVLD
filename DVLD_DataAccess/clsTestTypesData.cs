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

        public static bool Find(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref float TestFees)
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
                    TestFees = Convert.ToSingle(reader["TestTypeFees"]);
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

        public static int AddNew(string TestTypeTitle, string TestTypeDescription, float TestFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestTypes (TestTypeTitle,TestTypeDescription,TestFees) 
                            VALUES(@TestTypeTitle,@TestTypeDescription,@TestFees);
                           SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestFees", TestFees);

            int TestTypeID = -1;

            try
            {
                connection.Open();
                TestTypeID = (int)command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return TestTypeID;
        }

        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestFees)
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
