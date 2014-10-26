using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class Criteria
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
        public List<ImageMetaData> Images { get; set; }
        public List<Bookable> Bookables { get; set; }

        public ImageMetaData DisplayImage { get; set; }
    }
}