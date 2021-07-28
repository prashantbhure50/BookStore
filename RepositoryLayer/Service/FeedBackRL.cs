using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FeedBackRL: IFeedBackRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddFeedBack(FeedBackModle model)
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddFeedBack", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", model.UserID);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@Rating", model.Rating);
                    command.Parameters.AddWithValue("@Comments", model.Comments);
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
        public bool DeleteFeedBack(FeedBackModle id)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("DeleteFeedBack", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", id.UserID);
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
        public bool UpdateFeedBack(FeedBackModle modle)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("UpdateFeedback", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", modle.UserID);
                    command.Parameters.AddWithValue("@Rating", modle.Rating);
                    command.Parameters.AddWithValue("@Comments", modle.Comments);
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
    }
}
