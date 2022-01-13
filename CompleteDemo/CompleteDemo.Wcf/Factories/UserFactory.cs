using CompleteDemo.Dtos;
using CompleteDemo.Entities;
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

        public static IEnumerable<UserDto> ToDto(this IEnumerable<UserEntity> users)
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

        public static UserDto ToDto(this UserEntity user)
        {
            return new UserDto { Name = user.Login };
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