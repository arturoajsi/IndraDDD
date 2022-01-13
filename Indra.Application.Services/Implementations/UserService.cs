using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        IUserRepository _iUserRepository;

        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<UserEntity> GetUser(string userName, string password)
        {
            User usersGet = await _iUserRepository.GetUser(userName, password);
            return UserEntity.MaptoUserEntity(usersGet);
        }
    }
}
