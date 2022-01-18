using Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository pour CRUD sur bdd : à besoin d'une instance de DBcontext.
/// </summary>
namespace Perstistance
{
    public class BeerRepository : IBeerRepository
    {
        private DbContext BeerContext { get; }

        //public BeerRepository()
        //{
        //}

        public BeerRepository(DbContext beerContext)
        {
            BeerContext = beerContext;
        }

        #region CRUD

        public BeerEntity CreateBeer(BeerEntity beerEntityToCreate)
        {
            BeerEntity beerEntity = BeerContext.Add(beerEntityToCreate).Entity;
            //WikiBeerSqlContext.SaveChanges(); // Enregistre les changements en base
            return beerEntity;
        }

        public IList<BeerEntity> GetAllBeers()
        {
            return BeerContext.Set<BeerEntity>().ToList();
        }

        /// <summary>
        /// Peut retourner un null si pas trouvé. TODO : implémenter un test sur ArgumentNUll Ou InvalidOperation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeerEntity? GetBeerById(Guid id)
        {
            return BeerContext.Set<BeerEntity>().SingleOrDefault(beer => beer.Id == id);
        } 

        public bool DeleteBeerById(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}