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
    public class OrderController : ControllerBase
    {
        IOrderBL orderBl;
        public OrderController(IOrderBL orderBl)
        {
            this.orderBl = orderBl;
        }

        [HttpPost]
        public ActionResult AddToOrder(OrderModle order)
        {
            try
            {
                this.orderBl.AddToOrder(order);
                return this.Ok(new { success = true, message = "Books Added To Order Table Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(OrderModle id)
        {
            try
            {
                this.orderBl.DeleteOrder(id);
                return Ok(new { success = true, message = "Books Deleted From Order Table" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
        [HttpPut("UpdateOrder")]
        public ActionResult UpdateOrder(OrderModle order)
        {
            try
            {
                this.orderBl.UpdateOrder(order);
                return Ok(new { success = true, message = "Order Updated Successfully " });

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Cart is Null" });
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            IEnumerable<OrderModle> note = this.orderBl.Get(id);
            return Ok(note);
        }
    }
}
