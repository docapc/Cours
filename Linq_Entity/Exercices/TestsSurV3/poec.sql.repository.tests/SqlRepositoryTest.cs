using System;
using System.Collections.Generic;
using System.Linq;
using poec.sql.dtos;
using poec.sql.repository.Dtos;
using Xunit;

namespace poec.sql.repository.tests;

public class SqlRepositoryTest
{
    private UserSqlRepository UserSqlRepository { get; }

    public SqlRepositoryTest()
    {
        UserSqlRepository = new UserSqlRepository(new SqlDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityPoecV3;Integrated Security=True;"));
    }

    [Fact]
    public void AddTest()
    {
        //Arrange
        string userName = "Super user";
        string login = "User login";
        DateTime birthday = new DateTime(1956, 12, 31, 14, 36, 00);
        AddressSqlDto address = new AddressSqlDto(0, "Home", "La super adresse");
        UserSqlDto user = new UserSqlDto(default, userName, login, birthday, new List<AddressSqlDto> { address });

        //Action
        UserSqlDto userSqlDto = UserSqlRepository.Add(user);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.UserName, user.UserName);
        Assert.NotEqual(default, userSqlDto.UserId);
    }

    [Fact]
    public void GetTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = UserSqlRepository.Get(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.NotNull(userSqlDto?.Addresses);
        Assert.NotEmpty(userSqlDto?.Addresses);
        Assert.Equal(userSqlDto?.UserId, id);
    }

    [Fact]
    public void GetAllTest()
    {
        //Arrange

        //Action
        IList<UserSqlDto> userSqlDtos = UserSqlRepository.GetAll();

        //Assert
        Assert.NotNull(userSqlDtos);
        Assert.NotEmpty(userSqlDtos);
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
        UserSqlDto? userSqlDto = UserSqlRepository.Update(user);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserName, userName);
        Assert.Equal(userSqlDto?.UserId, id);
    }

    [Fact]
    public void DeleteTest()
    {
        //Arrange
        short id = UserSqlRepository.GetAll().Max(user => user.UserId); //utilisation du GetAll pour toujours un ID valide

        //Action
        bool isDeleted = UserSqlRepository.Delete(id);

        //Assert
        Assert.True(isDeleted);
    }

    [Fact]
    public void GetBestUsersTest()
    {
        //Arrange
        int count = 1;

        //Action
        IList<UserSqlDto> users = UserSqlRepository.GetBestUsers();

        //Assert
        Assert.NotNull(users);
        Assert.Equal(users.Count, count);
    }

    [Fact]
    public void GetOlderAgeTest()
    {
        //Arrange
        TimeSpan extected = DateTime.Now.Date - new DateTime(1990, 10, 30);

        //Action
        TimeSpan year = UserSqlRepository.GetOlderAge();

        //Assert
        Assert.Equal(extected, year);
    }

    [Fact]
    public void GetLongestNameTest()
    {
        //Arrange
        StringWrapperDto extected = new("Super Alex");

        //Action
        StringWrapperDto? longestName = UserSqlRepository.GetLongestName();

        //Assert
        Assert.NotNull(longestName);
        Assert.Equal(extected, longestName);
    }
}