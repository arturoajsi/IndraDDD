using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> GetUser(string userName, string password);
    }
}
