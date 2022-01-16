using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perstistance
{
    public interface IBeerRepository
    {
        IEnumerable<BeerEntity> GetAllBeers();

        BeerEntity GetBeerById(Guid id);

        void CreateBeer(BeerEntity beerEntityToCreate);

        void DeleteBeerById(Guid id);

    }
}
