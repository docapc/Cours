using Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Instancie et gère un BeerRepository(WikiBeerSqlServer(connectionString)) (comme un IBeerRepository)
/// Tentative : surement à supprimer plus tard
/// </summary>
namespace Perstistance.Managers
{
    public class BddToApiManager : IBeerRepository 
    {
        private readonly IBeerRepository _beerRepository;

        //public BddToApiManager() : this(DefaultConnectionString.DEFAULT_MIGRATION_STRING)
        //{
        //}

        public BddToApiManager(string connectionString)
        {
            _beerRepository = new BeerRepository(new WikiBeerSqlContext(connectionString));
        }

        public BddToApiManager(DbContext dbContext)
        {
            _beerRepository = new BeerRepository(dbContext);
        }
        #region CRUD
        //C:\Users\armel\git\Formation_IPME_dot_net\Cours\CodeFirstDB\Perstistance\Contexts\WikiBeerSqlContext.cs
        public BeerEntity CreateBeer(BeerEntity beerEntityToCreate)
        {
            return _beerRepository.CreateBeer(beerEntityToCreate);
        }

        public IList<BeerEntity> GetAllBeers()
        {
            return _beerRepository.GetAllBeers();
        }

        public BeerEntity? GetBeerById(Guid id)
        {
            return _beerRepository.GetBeerById(id);
        }

        public bool DeleteBeerById(Guid id)
        {
            return _beerRepository.DeleteBeerById(id);
        }
        #endregion
    }
}
