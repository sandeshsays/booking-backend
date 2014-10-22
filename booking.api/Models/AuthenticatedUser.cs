using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class AuthenticatedUser : User
    {
        public AuthenticatedUser()
        {
            token = "";
        }

        public string token { get; set; }
    }
}