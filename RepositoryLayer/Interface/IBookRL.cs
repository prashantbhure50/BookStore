using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IBookRL
    {
        bool AddBooks(Books user);
        public void GetAllBooks();
        bool DeleteBook(Books id);
        bool UpdateBook(Books book);
    }
}
