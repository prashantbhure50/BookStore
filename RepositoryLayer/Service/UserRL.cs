using CommonLayer.Database;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        //public static string connectionString = ConfigurationManager.ConnectionStrings["Bookstore"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
       public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("HelloThisTokenIsGeneretedByMe");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim("Email",email),
                  // new Claim("UserID",result.UserId.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public bool AddUser(Users model)
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("Register", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhoneNo);
                    command.Parameters.AddWithValue("@role", "Customer");

                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public string Login(string email, string password)
        {
            var result = "";
            this.connection.Open();
            using (this.connection)
            {
                string query = @"Select * from RegisterUser;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result = dr.GetString(3);
                        string Pass = dr.GetString(4);

                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }


            }
            if (result == email)
            {
               return GenerateToken(email);
            }
            else
            {
                return null;
            }
            
        }

        public bool ForgotPassword(string email)
        {
            var result = "";
            this.connection.Open();
            using (this.connection)
            {
                string query = @"Select * from RegisterUser;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result = dr.GetString(3);
                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }


            }
            if (result == email)
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("Alokbhure7@gmail.com", "@lokbhurE123");

                    MailMessage msgObj = new MailMessage();
                    msgObj.To.Add(email);
                    msgObj.From = new MailAddress("Alokbhure7@gmail.com");
                    msgObj.Subject = "Password Reset Link";
                    msgObj.Body = GenerateToken(email);
                    client.Send(msgObj);
                }
            }
            return true;
        }

    }
}
