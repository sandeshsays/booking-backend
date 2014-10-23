using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace booking.api.Models
{
    public class AuthenticatedUser
    {
        public AuthenticatedUser()
        {
            token = "";
            user = new User();
        }

        public User user { get; set; }
        public string token { get; set; }
    }
}