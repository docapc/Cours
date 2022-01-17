using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// TODO : Rajouter le update pui scompléter dans BeerRepository et BddBeerManager
/// </summary>
namespace Perstistance
{
    public interface IBeerRepository
    {
        BeerEntity CreateBeer(BeerEntity beerEntityToCreate);

        IList<BeerEntity> GetAllBeers();

        BeerEntity? GetBeerById(Guid id);

        bool DeleteBeerById(Guid id);

    }
}
