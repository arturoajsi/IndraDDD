using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userName, string password);
    }
}
