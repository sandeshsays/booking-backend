using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking.api.Models;
using booking.dal.Interfaces;
using booking.dal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace booking.dal.Repositories
{
    public class AuthRepository : IUserService
    {
        AuthContext context;
        UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            context = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public async Task<IdentityResult> RegisterUser(User user)
        {
            var newUser = new IdentityUser
            {
                UserName = user.Username
            };

            var result = await userManager.CreateAsync(newUser, user.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            var user = await userManager.FindAsync(username, password);
            return user;
        }

        public void Dispose()
        {
            context.Dispose();
            userManager.Dispose();
        }
    }
}
