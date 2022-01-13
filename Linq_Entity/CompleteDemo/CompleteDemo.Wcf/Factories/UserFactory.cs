using CompleteDemo.Dtos;
using CompleteDemo.Models;
using System.Collections;
using System.Collections.Generic;

namespace CompleteDemo.Wcf.Factories
{
    public static class UserFactory
    {
        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return user.ToDto(); 
            }
        }


        public static UserDto ToDto(this User user)
        {
            return new UserDto { Name = user.Name };
        }


        public static IEnumerable<User> ToModel(this IEnumerable<UserDto> users)
        {
            foreach (var user in users)
            {
                yield return user.ToModel();
            }
        }


        public static User ToModel(this UserDto user)
        {
            return new User { Name = user.Name };
        }

    }
}