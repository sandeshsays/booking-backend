using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using booking.dal.Interfaces;
using booking.dal.Models;
using booking.dal.Repositories;

namespace booking.api.Controllers
{
    [Authorize, RoutePrefix("api/user")]
    public class LoginController : BaseController<IUserService>
    {
        public LoginController()
            : base(new AuthRepository())
        {

        }

        [HttpPost, Route("login")]
        public async Task<IHttpActionResult> Login(Login user)
        {
            return null;
        }

        [HttpGet,Route("logout")]
        public async Task<IHttpActionResult> Logout()
        {
            return null;
        }

        [HttpPost, Route, AllowAnonymous]
        public async Task<IHttpActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.RegisterUser(user);

            var errorResult = BuildErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
     
        [HttpGet, Route]
        public async Task<IHttpActionResult> UserDetails()
        {
            return Ok(string.Format("Hello {0}", User.Identity.Name));
        }
    }


    public enum UserRoles
    {
        user,
        admin
    }
}