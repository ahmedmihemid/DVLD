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
    public class clsUserData
    {



        public static bool FindByUserName(string UserName, ref int  UserID , ref int PersonID, ref string Password , ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT * FROM Users WHERE UserName = @UserName; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    IsFound = true;
                }
                IsFound = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindByUserID(int UserID, ref string UserName, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Users WHERE UserID = @UserID; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserName = (string)reader["UserName"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    IsFound = true;
                }
                IsFound = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindByPersonID(int PersonID, ref string UserName, ref int UserID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Users WHERE PersonID = @PersonID; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserName = (string)reader["UserName"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    IsFound = true;
                }
                IsFound = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(ex);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool GetUserInfoByUsernameAndPassword(string userName, string password , ref int userID, ref int personID,  ref bool isActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Users WHERE UserName = @userName AND Password = @password; ";
            SqlCommand command = new SqlCommand(query, connection);
             command.Parameters.AddWithValue("@userName", userName);
             command.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                    IsFound = true;
                }
                
                reader.Close();
            }
            catch(Exception ex)
            {
                EventLogger.LogEvent(ex);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT UserID,Users.PersonID,People.FirstName +' '
             + People.SecondName+' '+People.ThirdName +' '+ People.LastName AS FullName
             ,UserName,IsActive
             FROM USERS INNER JOIN People ON Users.PersonID = People.PersonID ;";

            SqlCommand command = new SqlCommand(query,connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
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

        public static bool IsExistByPersonID(int PersonID)
        {

            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM Users WHERE PersonID = @PersonID";
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

        public static bool IsExistByUserID(int UserID)
        {

            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsExistByUserName(string UserName)
        {

            bool IsExists = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM Users WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

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

        public static int addNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {
         
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query =@"INSERT INTO Users (PersonID,UserName,Password,IsActive) 
                           VALUES(@PersonID,@UserName,@Password,@IsActive);
                           SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int newUserID = -1;

            try
            {
                connection.Open();
                newUserID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                newUserID = -1;
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return newUserID;

        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET 
                          UserName =@UserName,
                          Password =@Password,
                          IsActive =@IsActive WHERE UserID =@UserID ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);

        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE  Users WHERE UserID =@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
                Console.WriteLine("Error: " + ex.Message);
                EventLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool ChangeUserPassword(int UserID, string NewPassword)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET 
                          Password =@Password
                          WHERE UserID =@UserID ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", NewPassword);
            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
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
