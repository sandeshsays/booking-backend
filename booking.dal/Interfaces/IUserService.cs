using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking.dal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace booking.dal.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IdentityResult> RegisterUser(User user);
        Task<IdentityUser> FindUser(string username, string password);
    }
}
