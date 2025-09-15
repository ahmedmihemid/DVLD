using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_DataAccess
{
    public class clsCountryData
    {


        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT CountryID, CountryName FROM Countries;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCountries.Load(reader);
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
            return dtCountries;
        }



        public static DataTable GetCountryByID(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            DataTable dtCountry = new DataTable();
            string query = "SELECT CountryID, CountryName FROM Countries WHERE CountryID = @CountryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCountry.Load(reader);
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

            return dtCountry;
        }




    }
}
