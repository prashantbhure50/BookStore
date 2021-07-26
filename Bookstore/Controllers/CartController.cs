using BusinessLayer.Interface;
using CommonLayer.Database;
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
    public class CartController : ControllerBase
    {
        ICartBL cartBl;
        public CartController(ICartBL cartBl)
        {
            this.cartBl = cartBl;
        }
        [HttpPost]
        public ActionResult AddToCart(CartModle cart)
        {
            try
            {
                this.cartBl.AddToCart(cart);
                return this.Ok(new { success = true, message = "Books Added To Cart Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
       
        [HttpDelete("Deletecart")]
        public IActionResult DeleteFromCart(CartModle id)
        {
            try
            {
                this.cartBl.DeleteFromCart(id);
                return Ok(new { success = true, message = "Books Deleted From Cart" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
        [HttpPut("UpdateCart")]
        public ActionResult UpdateCart(CartModle cart)
        {
            try
            {
                this.cartBl.UpdateCart(cart);
                return Ok(new { success = true, message = "Cart Updates Successfully " });

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Cart is Null" });
            }
        }
    }
}