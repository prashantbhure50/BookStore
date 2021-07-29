using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL: IBookBL
    {
        IBookRL bookRl;
        public BookBL(IBookRL bookRl)
        {
            this.bookRl = bookRl;
        }
        public bool AddBooks(Books book)
        {
            return this.bookRl.AddBooks(book);
        }
        public IEnumerable<Books> GetAllBooks()
        {
            return this.bookRl.GetAllBooks();
        }
        public bool DeleteBook(Books id)
        {
            return this.bookRl.DeleteBook(id);
        }
        public bool UpdateBook(Books book)
        {
            return this.bookRl.UpdateBook(book);
        }
    }
}
