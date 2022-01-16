using Entities;

namespace Perstistance
{
    public class BeerRepository : IBeerRepository
    {
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