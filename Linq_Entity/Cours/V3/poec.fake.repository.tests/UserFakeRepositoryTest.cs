using System;
using System.Collections.Generic;
using System.Linq;
using poec.sql.dtos;
using Xunit;

namespace poec.fake.repository.tests;

/// <summary>
/// Classe de tests respectant le pattern AAA
/// </summary>
public class UserFakeRepositoryTest
{
    private UserFakeRepository UserFakeRepository { get; } = new();

    [Fact]
    public void AddTest()
    {
        //Arrange
        string userName = "Super user";
        string login = "User login";
        DateTime birthday = new DateTime(1956, 12, 31, 14, 36, 00);
        UserSqlDto user = new UserSqlDto(default, userName, login, birthday, new List<AddressSqlDto>());

        //Action
        UserSqlDto? userSqlDto = UserFakeRepository.Add(user);

        //Action
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserName, user.UserName);
        Assert.NotEqual(default, userSqlDto?.UserId);
    }

    [Fact]
    public void GetFirstTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = UserFakeRepository.GetFirst(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserId, id);
    }

    [Fact]
    public void GetTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = UserFakeRepository.Get(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserId, id);
    }

    [Fact]
    public void GetAllTest()
    {
        //Arrange

        //Action
        IList<UserSqlDto> userSqlDtos = UserFakeRepository.GetAll();

        //Assert
        Assert.NotNull(userSqlDtos);
        Assert.NotEmpty(userSqlDtos);
    }

    [Fact]
    public void GetPredicateTest()
    {
        //Arrange
        const short count = 1;
        const string userName = "Alex";
        bool Predicate(UserSqlDto user) => user.Birthday.Year == 1990;
        //équivalet à Func<UserSqlDto, bool> predicate = user => user.Birthday.Year == 1990;

        //Action
        IList<UserSqlDto> userSqlDto = UserFakeRepository.GetPredicate(Predicate);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.Count, count);
        Assert.Equal(userSqlDto.First().UserName, userName);
    }

    [Fact]
    public void UpdateTest()
    {
        //Arrange
        string userName = "Super Alex";
        string login = "Super Lelexxx";
        short id = 1;
        UserSqlDto user = new UserSqlDto(id, userName, login, new DateTime(1990, 12, 31, 14, 36, 00), new List<AddressSqlDto>());

        //Action
        UserSqlDto? userSqlDto = UserFakeRepository.Update(user);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserName, userName);
        Assert.Equal(userSqlDto?.UserId, id);
    }

    [Fact]
    public void DeleteTest()
    {
        //Arrange
        const short id = 4;

        //Action
        bool isDeleted = UserFakeRepository.Delete(id);

        //Assert
        Assert.True(isDeleted);
    }

    [Fact]
    public void GetPredicateErrorTest()
    {
        //Arrange
        const string userName = "alex";
        bool Predicate(UserSqlDto user) => user.UserName == userName;

        //Action
        IList<UserSqlDto> userSqlDto = UserFakeRepository.GetPredicate(Predicate);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Empty(userSqlDto);
    }

    [Fact]
    public void GetBestUsersTest()
    {
        //Arrange
        int count = 1;

        //Action
        IList<UserSqlDto> users = UserFakeRepository.GetBestUsers();

        //Assert
        Assert.NotNull(users);
        Assert.Equal(users.Count, count);
    }

    [Fact]
    public void GetOlderAgeTest()
    {
        //Arrange
        TimeSpan extected = DateTime.Now.Date - new DateTime(1990, 10, 30, 2, 55, 0);

        //Action
        TimeSpan timeSpan = UserFakeRepository.GetOlderAge();

        //Assert
        Assert.Equal(extected, timeSpan);
    }
}