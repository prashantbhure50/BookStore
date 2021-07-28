﻿using BusinessLayer.Interface;
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
    public class WishListController : ControllerBase
    {
        IWishListBL wishListBl;
        public WishListController(IWishListBL wishListBl)
        {
            this.wishListBl = wishListBl;
        }
        [HttpPost]
        public ActionResult AddToWishList(WishListModle modle)
        {
            try
            {
                this.wishListBl.AddToWishList(modle);
                return this.Ok(new { success = true, message = "Books Added To WishList Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpDelete("RemoveWishList")]
        public IActionResult RemoveFromWishList(WishListModle id)
        {
            try
            {
                this.wishListBl.RemoveFromWishList(id);
                return Ok(new { success = true, message = "Books Deleted From Order Table" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Book Is Not In List" });
            }
        }
        [HttpPut("UpdateWishList")]
        public ActionResult UpdateWishList(WishListModle modle)
        {
            try
            {
                this.wishListBl.UpdateWishList(modle);
                return Ok(new { success = true, message = "WishList Updated Successfully " });

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Cart is Null" });
            }
        }
    }
}
