using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;

namespace Indra.Domain.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public Guid guid { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public static UserEntity MaptoUserEntity(User user)
        {
            return new UserEntity
            {
                UserName = user.UserName,
                guid = user.guid,
                EmailId = user.EmailId,
                Password = user.Password
            };
        }

        public static User MaptoUser(UserEntity userEntity)
        {
            return new User
            {
                UserName = userEntity.UserName,
                guid = userEntity.guid,
                EmailId = userEntity.EmailId,
                Password = userEntity.Password
            };
        }

        public static List<UserEntity> MaptoUserEntityList(IEnumerable<User> users)
        {
            List<UserEntity> usersList = new List<UserEntity>();
            foreach (User user in users)
            {
                usersList.Add(MaptoUserEntity(user));
            }
            return usersList;

        }

        public static List<User> MaptoUserList(IEnumerable<UserEntity> usersEntity)
        {
            List<User> usersList = new List<User>();
            foreach (UserEntity user in usersEntity)
            {
                usersList.Add(MaptoUser(user));
            }
            return usersList;

        }
    }
}
