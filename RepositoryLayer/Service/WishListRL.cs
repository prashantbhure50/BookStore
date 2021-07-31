using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
   public class WishListRL: IWishListRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddToWishList(WishListModle model)
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddToWishList", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;     
                    command.Parameters.AddWithValue("@UserID", model.UserID);              
                    command.Parameters.AddWithValue("@BookID", model.BookID);
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
        public bool RemoveFromWishList(WishListModle id)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("RemoveWishList", this.connection);
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
        public bool UpdateWishList(WishListModle modle)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("UpdateWishList", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartID", modle.CartID);
                    command.Parameters.AddWithValue("@BookName", modle.BookName);
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
        public IEnumerable<WishListModle> Get(int id)
        {
            List<WishListModle> wish = new List<WishListModle>();
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("GetWishList", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", id);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            wish.Add(new WishListModle
                            {
                                BookName = (string)dr["BookName"],
                                BookAurthor = (string)dr["BookAurthor"],
                                BookCategory = (string)dr["BookCategory"],
                                BookLanguage = (string)dr["BookLanguage"]
                            });
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return wish;

        }
    }
}
