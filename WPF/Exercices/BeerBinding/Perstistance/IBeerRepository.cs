using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perstistance
{
    //public interface IBeerRepository<TBeer> where : TBeer ,class, new()
    public interface IBeerRepository<TBeer> where TBeer : class, new()
    {

    public TBeer AddBeer(TBeer beer);

    public IEnumerable<TBeer> GetAllBeers();
        
    }
}
