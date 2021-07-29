using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
   public class BookRL: IBookRL
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Bookstore;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddBooks(Books model)
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("Book", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@BookAurthor", model.BookAurthor);
                    command.Parameters.AddWithValue("@BookCategory", model.BookCategory);
                    command.Parameters.AddWithValue("@BookLanguage", model.BookLanguage);
                    command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
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
        public IEnumerable<Books> GetAllBooks()
        {
            List<Books> book = new List<Books>();
            try
            {
                using (this.connection)
                {
                    string query = @"Select * from Books;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            book.Add(new Books
                            {
                                BookID = (int)dr["BookID"],
                                BookName = (string)dr["bookName"],
                                BookAurthor = (string)dr["BookAurthor"],
                                BookCategory = (string)dr["BookCategory"],
                                BookLanguage = (string)dr["BookLanguage"],
                                BookQuantity = (int)dr["BookQuantity"]
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
            return book;

        }
        public bool DeleteBook(Books id)
        {
            try
            {
               
                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("Delete", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", id.BookID);
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
        public bool UpdateBook(Books modle)
        {
            try
            {

                this.connection.Open();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("Update", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", modle.BookID);
                    command.Parameters.AddWithValue("@BookName", modle.BookName);
                    command.Parameters.AddWithValue("@BookAurthor", modle.BookAurthor);
                    command.Parameters.AddWithValue("@BookCategory", modle.BookCategory);
                    command.Parameters.AddWithValue("@BookLanguage", modle.BookLanguage);
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
