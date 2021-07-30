using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
   public class AddressRL: IAddressRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddAddress(AddressModle model)
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddAddress", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", model.UserID);
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Pincode", model.Pincode);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhoneNo);
                    command.Parameters.AddWithValue("@Email", model.Email);
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
        public IEnumerable<AddressModle> Get()
        {
            List<AddressModle> modle = new List<AddressModle>();
            try
            {
                using (this.connection)
                {
                    string query = @"Select * from AddressTable;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            modle.Add(new AddressModle
                            {
                                UserID = (int)dr["UserID"],
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                City = (string)dr["City"],
                                State = (string)dr["State"],
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
            return modle;

        }
        public bool DeleteAddress(AddressModle id)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("DeleteAddress", this.connection);
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
        public bool UpdateAddress(AddressModle modle)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("UpdateAddress", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", modle.UserID);
                    command.Parameters.AddWithValue("@FirstName", modle.FirstName); 
                    command.Parameters.AddWithValue("@LastName", modle.LastName);
                    command.Parameters.AddWithValue("@City", modle.City);
                    command.Parameters.AddWithValue("@State", modle.State);
                    command.Parameters.AddWithValue("@Address", modle.Address);
                    command.Parameters.AddWithValue("@Pincode", modle.Pincode);
                    command.Parameters.AddWithValue("@PhoneNo", modle.PhoneNo);
                    command.Parameters.AddWithValue("@Email", modle.Email);
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
