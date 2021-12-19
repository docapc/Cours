using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryExemple
{
    public abstract class InstrumentFactory
    {
        public abstract IInstrument CreateInstrument();

        public void UseInstrument()
        {
            var instrument = CreateInstrument(); // on crée un instruement
            instrument.MakeSound();    // on l'utilise
        }
    }


}
