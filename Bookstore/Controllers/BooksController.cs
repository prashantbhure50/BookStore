using BusinessLayer.Interface;
using CommonLayer.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookBL BookBl;
        public BooksController(IBookBL BookBl)
        {
            this.BookBl = BookBl;
        }
        [HttpPost]
        //[Authorize(Roles = Role.Admin)]
        public ActionResult AddBooks(Books book)
        {
            try
            {
                this.BookBl.AddBooks(book);
                return this.Ok(new { success = true, message = "Books Added Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
          }
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Books> note = this.BookBl.GetAllBooks();
            return Ok(note);
        }
        [AllowAnonymous]
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(Books id)
        {
            try
            {
                this.BookBl.DeleteBook(id);
                return Ok(new { success = true, message = "Books Deleted " });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
        [HttpPut("UpdateBook")]
        public ActionResult UpdateBook(Books book)
        {
            try
            {
                this.BookBl.UpdateBook(book);
                return Ok(new { success = true, message = "Books Updates Successfully " });

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
    }
}
