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
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddToOrder", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", model.UserID);
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
        public IEnumerable<OrderModle> Get(int UserID)
        {
            List<OrderModle> FeedBackModle = new List<OrderModle>();
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("GetOrder", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            FeedBackModle.Add(new OrderModle
                            {
                                OrderID = (int)dr["OrderID"],
                                BookID = (int)dr["BookID"],
                                BookName = (string)dr["BookName"],
                                BookAurthor = (string)dr["BookAurthor"],
                                BookCategory = (string)dr["BookCategory"],
                                BookLanguage = (string)dr["BookLanguage"],
                                BookQuantity = (int)dr["BookQuantity"],
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                City = (string)dr["City"],
                                Address = (string)dr["Address"],
                                Pincode = (string)dr["Pincode"],
                                PhoneNo = (string)dr["PhoneNo"],
                                Email = (string)dr["Email"]
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
