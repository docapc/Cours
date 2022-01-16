using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perstistance.Managers
{
    internal class BddBeerManager : IBeerRepository
    {
        private readonly IBeerRepository _beerRepository;

        public BddBeerManager()
        {
            _beerRepository = new BeerRepository();
        }

        public void CreateBeer(BeerEntity beerEntityToCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BeerEntity> GetAllBeers()
        {
            throw new NotImplementedException();
        }

        public BeerEntity GetBeerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
