using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace booking.api.Controllers
{
    [Route]
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var message = Request.CreateResponse(HttpStatusCode.OK, ":)");

            return message;
        }
    }
}
