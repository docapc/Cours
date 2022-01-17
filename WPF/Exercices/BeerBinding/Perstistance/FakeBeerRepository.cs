using AutoFixture;

namespace Perstistance
{
    public class FakeBeerRepository<TBeer> : IBeerRepository<TBeer> where TBeer : class, new()
    {
        // Définitif
        private readonly List<TBeer> _beers;

        // Fixture
        private readonly Fixture _fixture = new Fixture();

        public FakeBeerRepository()
        {
            _beers = new List<TBeer>();
            _beers = _fixture.CreateMany<TBeer>(10).ToList();
        }

        public TBeer AddBeer(TBeer beer)
        {
            _beers.Add(beer);
            return beer;
        }

        public IEnumerable<TBeer> GetAllBeers()
        {
            return _beers;
        }
    }
}