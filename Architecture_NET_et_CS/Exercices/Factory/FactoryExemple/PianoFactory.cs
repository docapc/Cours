using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryExemple
{
    class PianoFactory : InstrumentFactory
    {
        public override IInstrument CreateInstrument()
        {
            return new Piano(); // on pourrait donner les argument ici en les ``cachant'' dans la PianoFactory
                                // sans avoir à les donner dans l'appel de CreateInstrument
        }
    }
}
