using System;
using System.Collections.Generic;
using System.Linq;
using poec.sql.dtos;
using poec.sql.repository;
using Xunit;

/// <summary>
/// Le GetPredicate Devrait être implémenté.
/// </summary>
namespace poec.fake.repository.tests;

/// <summary>
/// Classe de tests respectant le pattern AAA
/// </summary>
public class UserFakeRepositoryTest
{
    //private IUserRepository Repo { get; }= new UserFakeRepository(); // doit etre comme sa
    private UserFakeRepository Repo { get; } = new();// Mauvaise manière de faire car n'implémente pas l'interface 

    [Fact]
    public void GetTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = Repo.GetSingle(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.UserId, id);
    }

    [Fact]
    public void GetPredicateTest()
    {
        //Arrange
        const short count = 1;
        const string userName = "Alex";
        bool Predicate(UserSqlDto user) => user.Birthday.Year == 1990; // Déclaration de fonction locale via LinQ
        //équivalet à Func<UserSqlDto, bool> predicate = user => user.Birthday.Year == 1990;

        //Action
        IList<UserSqlDto> userSqlDto = Repo.GetPredicate(Predicate); // qu'il faut alors implémenter à cause de l'interface

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.Count, count);
        Assert.Equal(userSqlDto.First().UserName, userName);
    }

    [Fact]
    public void GetPredicateErrorTest()
    {
        //Arrange
        const string userName = "alex";
        bool Predicate(UserSqlDto user) => user.UserName == userName;

        //Action
        IList<UserSqlDto> userSqlDto = Repo.GetPredicate(Predicate);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Empty(userSqlDto);
    }
}