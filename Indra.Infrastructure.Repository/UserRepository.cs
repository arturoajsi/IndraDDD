using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(string userName, string password)
        {
            var user = await context.User.FirstOrDefaultAsync(c => c.UserName == userName && c.Password == password);
            return user;
        }
    }
}
