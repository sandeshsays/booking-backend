using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using booking.dal.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace booking.api.Models
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}