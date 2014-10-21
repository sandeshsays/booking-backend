using booking.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace booking.api.Controllers
{
    [RoutePrefix("api/user")]
    [AllowAnonymous]
    [EnableCors( // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors
        "*", // change to specific sites after development
        "*", 
        "*"
    )]
    public class LoginController : ApiController
    {
        User userr;

        [HttpPost]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(Login user)
        {
            await Task.Delay(750);

            var authenticatedUser = new AuthenticatedUser
            {
                name = "Michael Dougall",
                email = "laheen@gmail.com",
                role = "admin",
                token = "213kujghaskdjhJKHSADKJHasd",
                username = user.username
            };

            this.userr = authenticatedUser as User;

            return Request.CreateResponse(HttpStatusCode.OK, authenticatedUser);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<HttpResponseMessage> Logout()
        {
            await Task.Delay(500);

            userr = new User();

            return Request.CreateResponse(HttpStatusCode.OK, "Logged out");
        }

        [HttpGet]
        [Route]
        public async Task<HttpResponseMessage> UserDetails()
        {
            await Task.Delay(500);

            return Request.CreateResponse(HttpStatusCode.OK, userr);
        }
    }
}