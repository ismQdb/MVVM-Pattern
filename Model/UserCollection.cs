using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class UserCollection : ObservableCollection <User>
    {
        public static int ID_Counter = GetAllUsers().Count;
        public static void AddNewUser(User user)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionPath"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT into [User](ID, UserName, UserPass, IsAdmin) VALUES(@Id, @UserName, @UserPassword, @IsAdmin", connection);

                SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                idParameter.Value = ID_Counter;
                ID_Counter++;

                SqlParameter userNameParameter = new SqlParameter("@UserName", System.Data.SqlDbType.NVarChar);
                userNameParameter.Value = user.UserName;

                SqlParameter userPasswordParameter = new SqlParameter("@UserPassword", System.Data.SqlDbType.NVarChar);
                userPasswordParameter.Value = user.UserPass;

                SqlParameter isAdminParameter = new SqlParameter("@IsAdmin", System.Data.SqlDbType.Int);
                isAdminParameter.Value = user.IsAdmin;

                command.Parameters.Add(idParameter);
                command.Parameters.Add(userNameParameter);
                command.Parameters.Add(userPasswordParameter);
                command.Parameters.Add(isAdminParameter);

                command.ExecuteNonQuery();
            }
        }

        public static bool DoesUserExist(User user) {
            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionPath"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserName=@userName AND UserPass=@userPassword", connection);

                SqlParameter userNameParameter = new SqlParameter("@userName", System.Data.SqlDbType.NVarChar);
                userNameParameter.Value = user.UserName;

                SqlParameter userPasswordParameter = new SqlParameter("@userPassword", System.Data.SqlDbType.NVarChar);
                userPasswordParameter.Value = user.UserPass;

                command.Parameters.Add(userNameParameter);
                command.Parameters.Add(userPasswordParameter);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read() == false)
                        return false;
                    else
                        return true;
                }
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            User user;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionPath"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("Select ID, UserName, UserPass, IsAdmin FROM [User]", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User((int)reader["ID"], (string)reader["UserName"], (string)reader["UserPass"], (int)reader["IsAdmin"]);
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public static void UpdateUser(User user) {
            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionPath"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE dbo.[User] SET userName=@userName, userPass=@userPass, isAdmin=@isAdmin WHERE ID=@id", connection);

                SqlParameter userNameParameter = new SqlParameter("@userName", System.Data.SqlDbType.NVarChar);
                userNameParameter.Value = user.UserName;

                SqlParameter userPasswordParameter = new SqlParameter("@userPass", System.Data.SqlDbType.NVarChar);
                userPasswordParameter.Value = user.UserPass;

                SqlParameter isAdminParameter = new SqlParameter("@isAdmin", System.Data.SqlDbType.Int);
                isAdminParameter.Value = user.IsAdmin;

                SqlParameter idParameter = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParameter.Value = user.Id;

                command.Parameters.Add(userNameParameter);
                command.Parameters.Add(userPasswordParameter);
                command.Parameters.Add(isAdminParameter);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
