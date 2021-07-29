using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IBookRL
    {
        bool AddBooks(Books user);
        IEnumerable<Books> GetAllBooks();
        bool DeleteBook(Books id);
        bool UpdateBook(Books book);
    }
}
