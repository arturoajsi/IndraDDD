using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Web.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public Guid guid { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public static UserEntity MaptoUserEntity(UserDto userDto)
        {
            return new UserEntity
            {
                UserName = userDto.UserName,
                guid = userDto.guid,
                EmailId = userDto.EmailId,
                Password = userDto.Password
            };
        }

        public static UserDto MaptoUserDto(UserEntity userEntity)
        {
            return new UserDto
            {
                UserName = userEntity.UserName,
                guid = userEntity.guid,
                EmailId = userEntity.EmailId,
                Password = userEntity.Password
            };
        }
    }
}
