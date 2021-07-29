using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class OrderRL: IOrderRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddToOrder(OrderModle model)
        {
            try
            {
                int res = 0;
                bool final = false;
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddToOrder", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", model.UserID);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                    command.Parameters.AddWithValue("@BookPrice", model.BookPrice);
                  
                    string query = @"Select * from Books;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            res = dr.GetInt32(5);
                     
                            if (res <= model.BookQuantity)
                            {
                                return false;
                            }

                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
        
            
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
        public bool DeleteOrder(OrderModle id)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("DeleteOrder", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", id.OrderID);
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
        public bool UpdateOrder(OrderModle modle)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("UpdateOrder", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", modle.OrderID);
                    command.Parameters.AddWithValue("@BookQuantity", modle.BookQuantity);
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
        public IEnumerable<OrderModle> Get()
        {
            List<OrderModle> FeedBackModle = new List<OrderModle>();
            try
            {
                using (this.connection)
                {
                    string query = @"Select * from Orders;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            FeedBackModle.Add(new OrderModle
                            {
                                OrderID = (int)dr["OrderID"],
                                UserID = (int)dr["UserID"],
                                BookName = (string)dr["BookName"],
                                BookQuantity = (int)dr["BookQuantity"],
                                BookPrice = (string)dr["BookPrice"]
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
            return FeedBackModle;

        }
    }
}
