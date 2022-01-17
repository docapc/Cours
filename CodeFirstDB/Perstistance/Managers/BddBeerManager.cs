using Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perstistance.Managers
{
    public class BddBeerManager : IBeerRepository
    {
        private readonly IBeerRepository _beerRepository;
        //private readonly WikiBeerSqlContext _beerRepository;

        public BddBeerManager(string connectionString)
        {
            _beerRepository = new BeerRepository(new WikiBeerSqlContext(connectionString));
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
