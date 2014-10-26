using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class ImageMetaData
    {
        public string Id { get; set; }
        public string Uri { get { return "http://cool-cdn.com/" + Id; } }
    }
}