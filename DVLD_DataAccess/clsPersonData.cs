using DVLD_Shared;
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
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }


        public static bool IdIsExist(string nationalID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalID);

            try 
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                IsExists = count > 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return IsExists;

        }

        public static bool IdIsExist(int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                IsExists = count > 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return IsExists;

        }
    

        public static int AddNewPerson(string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, DateTime dateofBirth, int gender, string address, string phone, string email,
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
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return newPersonID;

        }


        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
         ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
          ref short Gendor, ref string Address, ref string Phone, ref string Email,
          ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    NationalNo = (string)reader["NationalNo"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName,  string NationalNo, ref DateTime DateOfBirth,
         ref short Gendor, ref string Address, ref string Phone, ref string Email,
         ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        
        public static bool UpdatePerson(int personID, string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, DateTime dateofBirth, int gender, string address, string phone, string email,
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
                EventLogger.LogEvent(ex);
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
                EventLogger.LogEvent(ex);
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }



    }
}