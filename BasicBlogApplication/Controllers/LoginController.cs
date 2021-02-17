using BasicBlogApplication.Models;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicBlogApplication.Controllers
{
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Login(UserModel login)
        {
           
            IHttpActionResult response = Unauthorized();
            UserModel user = this._authentication.Login(login);
            if (user != null)
            {
                string token= TokenManager.GenerateToken(new UserModel()
                {
                    Email = user.Email,
                    Name = user.Name,
                });
                response = Ok(token);
            }
            else
            {
                response = BadRequest("Invalid Credential");
            }
            return response;
        }
    }
}
