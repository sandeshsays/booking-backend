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
        [HttpPost]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(Login user)
        {
            await Task.Delay(750);

            var authenticatedUser = new AuthenticatedUser
            {
                user = new User
                {
                    name = "Michael Dougall",
                    email = "laheen@gmail.com",
                    role = UserRoles.admin.ToString(),
                    username = user.username
                },
 
                token = "213kujghaskdjhJKHSADKJHasd"
            };

            UserSingleton.Instance().User = authenticatedUser;

            return Request.CreateResponse(HttpStatusCode.OK, authenticatedUser);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<HttpResponseMessage> Logout()
        {
            await Task.Delay(500);

            UserSingleton.Instance().User = new AuthenticatedUser();

            return Request.CreateResponse(HttpStatusCode.OK, "Logged out");
        }

        [HttpGet]
        [Route]
        public async Task<HttpResponseMessage> UserDetails()
        {
            await Task.Delay(500);

            var sup = UserSingleton.Instance().User;
            sup.token = "";

            return Request.CreateResponse(HttpStatusCode.OK, UserSingleton.Instance().User);
        }
    }

    public class UserSingleton
    {
        static UserSingleton instance;

        public static UserSingleton Instance()
        {
            if (instance == null)
            {
                instance = new UserSingleton();
            }

            return instance;
        }

        AuthenticatedUser _user;
        public AuthenticatedUser User 
        { 
            get 
            {
                if (_user == null)
                {
                    _user = new AuthenticatedUser();
                }

                return _user;
            }
            set
            {
                _user = value;
            } 
        }
    }

    public enum UserRoles
    {
        user,
        admin
    }
}