﻿using booking.api.Models;
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

        class ImageMetaData
        {
            public string Id { get; set; }
        }
    }

    public class CriteriaSingleton
    {
        static CriteriaSingleton instance;

        public static CriteriaSingleton Instance()
        {
            if (instance == null)
            {
                instance = new CriteriaSingleton();
            }

            return instance;
        }
    }
}
