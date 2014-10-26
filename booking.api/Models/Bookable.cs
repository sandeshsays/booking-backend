using booking.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class Bookable: IBookableMetaData, IBookableData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}