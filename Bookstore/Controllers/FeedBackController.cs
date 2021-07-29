using BusinessLayer.Interface;
using CommonLayer.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        IFeedBackBL feedBackBL;
        public FeedBackController(IFeedBackBL feedBackBL)
        {
            this.feedBackBL = feedBackBL;
        }
        [HttpPost]
        public ActionResult AddFeedBack(FeedBackModle modle)
        {
            try
            {
                this.feedBackBL.AddFeedBack(modle);
                return this.Ok(new { success = true, message = "FeedBack Added Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpDelete("DeleteFeedBack")]
        public IActionResult DeleteFeedBack(FeedBackModle id)
        {
            try
            {
                this.feedBackBL.DeleteFeedBack(id);
                return Ok(new { success = true, message = "FeedBack Deleted Table" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
        [HttpPut("UpdateFeedBack")]
        public ActionResult UpdateFeedBack(FeedBackModle modle)
        {
            try
            {
                this.feedBackBL.UpdateFeedBack(modle);
                return Ok(new { success = true, message = "FeedBack Updated Successfully " });

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Cart is Null" });
            }
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            IEnumerable<FeedBackModle> note = this.feedBackBL.Get();
            return Ok(note);
        }
    }
}
