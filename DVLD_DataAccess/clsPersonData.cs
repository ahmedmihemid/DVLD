using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPeopleData
    {

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" SELECT  PersonID, NationalNo, FirstName,  SecondName, ThirdName,  LastName,  DateOfBirth, 
                CASE 
                WHEN Gendor = 0 THEN 'MALE'
                WHEN Gendor = 1 THEN 'FEMALE'
                ELSE 'UNKNOWN'  
                END AS GenderString,
                Phone, Countries.CountryName,  Email  FROM  People INNER JOIN Countries
                ON People.NationalityCountryID = Countries.CountryID ;";

            SqlCommand command = new SqlCommand(query, connection);

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
                // Log the exception or handle it as needed
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static DataTable GetFilteredPeople(string columnName, string filterValue)
        {
            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = $@"
            SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
            CASE 
                WHEN Gendor = 0 THEN 'MALE'
                WHEN Gendor = 1 THEN 'FEMALE'
                ELSE 'UNKNOWN'  
            END AS GenderString,
            Phone, Countries.CountryName, Email  
            FROM People 
            INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
            WHERE {columnName} LIKE @FilterValue;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilterValue", $"%{filterValue}%");

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return dt;
        }


    }
}