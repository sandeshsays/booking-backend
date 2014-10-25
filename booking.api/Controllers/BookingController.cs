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
    [RoutePrefix("api/booking")]
    [AllowAnonymous]
    [EnableCors( // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors
        "*", // change to specific sites after development
        "*",
        "*"
    )]
    public class BookingController : ApiController
    {
        [HttpPost]
        [Route]
        public async Task<HttpResponseMessage> CreateCriteria(Criteria criteria)
        {
            await Task.Delay(750);



            return Request.CreateResponse(HttpStatusCode.OK, criteria);
        }

        [HttpPost]
        [Route("image")]
        public async Task<HttpResponseMessage> UploadImage(object imageAsUrl)
        {
            await Task.Delay(2000);

            // test for failure as well

            return Request.CreateResponse(HttpStatusCode.OK, new ImageMetaData { Id = "1234" });
        }

        [HttpGet]
        [Route("criterias")]
        public async Task<HttpResponseMessage> GetCriterias()
        {
            await Task.Delay(500);

            return Request.CreateResponse(HttpStatusCode.OK, CriteriaSingleton.Instance().GetAllCriterias());
        }

        [HttpGet]
        [Route("criteria")]
        public async Task<HttpResponseMessage> GetCriteria(int id)
        {
            await Task.Delay(250);

            return Request.CreateResponse(HttpStatusCode.OK, CriteriaSingleton.Instance().GetCriteria(id));
        }
    }

    public class CriteriaSingleton
    {
        static CriteriaSingleton instance;

        List<Criteria> criterias =
            new List<Criteria> 
                { 
                    new Criteria
                    {
                        Id = 1,
                        Description = "Awesome set of tennis courts location at winston hills",
                        Images = new List<ImageMetaData>
                        {
                            new ImageMetaData
                            {
                                Id = "234"
                            },
                            new ImageMetaData
                            {
                                Id = "234"
                            }
                        },
                        Location = "Winston Hills",
                        Name = "Tennis courts at winston hills"
                    },
                    new Criteria
                    {
                        Id = 2,
                        Description = "Squash courts man",
                        Images = new List<ImageMetaData>
                        {
                            new ImageMetaData
                            {
                                Id = "222"
                            },
                            new ImageMetaData
                            {
                                Id = "111"
                            }
                        },
                        Location = "Macquarie University",
                        Name = "Squash courts at mqu"
                    }
                };

        public static CriteriaSingleton Instance()
        {
            if (instance == null)
            {
                instance = new CriteriaSingleton();
            }

            return instance;
        }

        public void SaveCriteria(int id, Criteria criteria)
        {
            var something = criterias.Where(x => x.Id == id).FirstOrDefault();

            something = criteria;
        }

        public Criteria GetCriteria(int id)
        {
            return criterias.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Criteria> GetAllCriterias()
        {
            return criterias;
        }
    }
}
