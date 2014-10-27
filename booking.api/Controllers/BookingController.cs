using booking.api.Interfaces;
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
        [Route("criteria/{slug}")]
        public async Task<HttpResponseMessage> GetCriteria(string slug)
        {
            await Task.Delay(250);

            var criteria = CriteriaSingleton.Instance().GetCriteria(slug);
            
            if (criteria == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "bro it doesnt exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, criteria);
        }

        [HttpGet]
        [Route("criteria/{criteria}/{bookable}")]
        public async Task<HttpResponseMessage> GetBookable(string criteria, string bookable, int offset = 0)
        {
            await Task.Delay(200);

            Bookable book = CriteriaSingleton.Instance().GetBookable(bookable);

            var response = new Bookable
            {
                Bookings = book.Bookings
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }

    public class CriteriaSingleton
    {
        static CriteriaSingleton instance;

        List<Bookable> bookables = new List<Bookable>
                        {
                            new Bookable
                            {
                                Id = 1234,
                                Name = "Court 1",
                                Slug = "court-1",
                                CriteriaId = 1,
                                BookableTimePeriod = 30,
                                Bookings = new List<BookableBooking>
                                {
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddDays(7),
                                        Start = DateTime.Now.AddDays(-2),
                                        Type = BookingType.Restriction
                                    },
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddHours(2),
                                        Start = DateTime.Now,
                                        Type = BookingType.Booking
                                    }
                                }
                            },
                            new Bookable
                            {
                                Id = 122334,
                                Name = "Court 2",
                                Slug = "court-2",
                                CriteriaId = 1,
                                BookableTimePeriod = 45,
                                Bookings = new List<BookableBooking>
                                {
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddDays(7),
                                        Start = DateTime.Now.AddDays(-2),
                                        Type = BookingType.Restriction
                                    },
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddHours(2),
                                        Start = DateTime.Now,
                                        Type = BookingType.Booking
                                    }
                                }
                            },
                            new Bookable
                            {
                                Id = 2,
                                Name = "Court 69",
                                Slug = "court-69",
                                CriteriaId = 2,
                                BookableTimePeriod = 60,
                                Bookings = new List<BookableBooking>
                                {
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddDays(7),
                                        Start = DateTime.Now.AddDays(-2),
                                        Type = BookingType.Restriction
                                    },
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddHours(2),
                                        Start = DateTime.Now,
                                        Type = BookingType.Booking
                                    }
                                }
                            },
                            new Bookable
                            {
                                Id = 33,
                                Name = "Court 23",
                                Slug = "court-23",
                                CriteriaId = 2,
                                BookableTimePeriod = 15,
                                Bookings = new List<BookableBooking>
                                {
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddDays(7),
                                        Start = DateTime.Now.AddDays(-2),
                                        Type = BookingType.Restriction
                                    },
                                    new BookableBooking
                                    {
                                        ById = "123",
                                        ByName = "Michael",
                                        End = DateTime.Now.AddHours(2),
                                        Start = DateTime.Now,
                                        Type = BookingType.Booking
                                    }
                                }
                            }
                        };

        List<Criteria> criterias =

            new List<Criteria> 
                { 
                    new Criteria
                    {
                        Id = 1,
                        Description = "Awesome set of tennis courts location at winston hills",
                        DisplayImage = new ImageMetaData
                        {
                            Id = "2314"
                        },
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
                        Name = "Tennis courts at winston hills",
                        Slug = "tennis-at-winston-hills"
                    },
                    new Criteria
                    {
                        Id = 2,
                        Description = "Squash courts man",
                        DisplayImage = new ImageMetaData
                        {
                            Id = "2342"
                        },
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
                        Name = "Squash courts at mqu",
                        Slug = "squash-at-mqu"
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

        public Criteria GetCriteria(string slug)
        {
            var crit = criterias.Where(x => x.Slug == slug).First();

            crit.Bookables = bookables.Where(x => x.CriteriaId == crit.Id).ToList();

            return crit;
        }

        public Bookable GetBookable(string slug)
        {
            var bookable = bookables.Where(x => x.Slug == slug).FirstOrDefault();

            return bookable;
        }

        public List<Criteria> GetAllCriterias()
        {
            return criterias;
        }
    }
}
