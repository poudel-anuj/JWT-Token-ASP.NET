using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Token.JWTHelper;
using Token.Library;
using Token.Models;
using Token.Repository;
using Token.Result;

namespace Token.Controllers
{
    public class AccountController : ApiController
    {
        AccountRepository repo = new AccountRepository();

      
        //public class user
        //{
        //    public string username { get; set; }
        //    //public byte[] Password { get; set; }
        //    public string Password { get; set; }

        //    public string Email { get; set; }
        //}
        [Route("api/Account/login")]
        [HttpGet]
        public IHttpActionResult ValidLogin([FromBody] User us )
        {
            var dbUser = repo.GetUser(us.Email,us.Password);
            User user = new User();
            user = dbUser.MapObject<User>();

            //string password = Encoding.UTF8.GetString(dbUser.Password);
            if (user.code != "0")
            {
                return new HttpResult(HttpStatusCode.BadRequest, new { message = "The user with the given email was not found" }, Request);
            }

            Admin ad = new Admin();
            ad = dbUser.MapObject<Admin>();
            string token = TokenManager.GenerateToken(ad);
            return new HttpResult(HttpStatusCode.OK, new { user = dbUser, token = token }, Request);

        }


    }
}
