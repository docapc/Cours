using System;
// La Factory permet de séparer la Création de produit du produit

namespace FactoryExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            PianoFactory my_pfacto = new PianoFactory();
            IInstrument my_instrument = my_pfacto.CreateInstrument(); // pas nécessaire
            my_pfacto.UseInstrument(); // car la factory sait utiliser n'importe quelle instrument
        }
    }
}
