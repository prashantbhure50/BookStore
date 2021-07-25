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
    public class UserController : ControllerBase
    {
        IUserBL userBl;
        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;
        }
        [HttpPost]
        public ActionResult AddUser(Users user)
        {
            try
            {
                this.userBl.AddUser(user);
                return this.Ok(new { success = true, message = "Registration Successful " });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginModle loginModel)
        {
            try
            {
                var token = this.userBl.Login(loginModel.Email, loginModel.Password);
                if (token == null)
                    return Unauthorized();
                return this.Ok(new { token = token, success = true, message = "Token Generated Successfull" });
                
            }
            catch (Exception e)
            {
              
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }


        [HttpPost("forgotpassword")]
        public ActionResult ForgotPassword(LoginModle loginModel)
        {
            try
            {
                bool isExist = this.userBl.ForgotPassword(loginModel.Email);
                if (isExist)
                {
                    return Ok(new { success = true, message = $"Reset Link sent to {loginModel.Email}" });
                }
                else
                {
                    return BadRequest(new { success = false, message = $"No user Exist with {loginModel.Email}" });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
