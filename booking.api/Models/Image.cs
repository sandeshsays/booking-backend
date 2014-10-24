using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class Image
    {
        public string FileName { get; set; }
        public List<Byte> Bytes { get; set; }
    }
}