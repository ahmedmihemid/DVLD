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

        public static bool IdIsExist(string nationalID)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalID);

            try 
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return exists;

        }

        public static int AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateofBirth, int gender, string address, string phone, string email,
            int narionalityCountryID, string imagePath)
        {
            int newPersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People 
                        (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                         VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateofBirth);
            command.Parameters.AddWithValue("@Gendor", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@NationalityCountryID", narionalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", imagePath);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    newPersonID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return newPersonID;

        }


        public static DataTable GetPersonByID(int personID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" SELECT  PersonID, NationalNo, FirstName,  SecondName, ThirdName,  LastName,  DateOfBirth, 
                CASE 
                WHEN Gendor = 0 THEN 'MALE'
                WHEN Gendor = 1 THEN 'FEMALE'
                ELSE 'UNKNOWN'  
                END AS GenderString,
                Address,Phone,  Email ,People.NationalityCountryID , ImagePath FROM  People INNER JOIN Countries
                ON People.NationalityCountryID = Countries.CountryID  WHERE PersonID = @personID ; ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
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
            return dt;
        }


        public static bool UpdatePerson(int personID, string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateofBirth, int gender, string address, string phone, string email,
            int narionalityCountryID, string imagePath)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE People SET 
                        NationalNo = @NationalNo, 
                        FirstName = @FirstName, 
                        SecondName = @SecondName, 
                        ThirdName = @ThirdName, 
                        LastName = @LastName, 
                        DateOfBirth = @DateOfBirth, 
                        Gendor = @Gendor, 
                        Address = @Address, 
                        Phone = @Phone, 
                        Email = @Email, 
                        NationalityCountryID = @NationalityCountryID, 
                        ImagePath = @ImagePath
                        WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateofBirth);
            command.Parameters.AddWithValue("@Gendor", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@NationalityCountryID", narionalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", imagePath);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }



        public static bool DeletePersonByID(int personID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE People WHERE personID =@personID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

            try
            { 
             connection.Open();
             rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }



    }
}