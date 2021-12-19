using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryExemple
{
    public class Piano : IInstrument
    {
        public void MakeSound()
        {
            Console.WriteLine("Piano play : Mozart");
        }
    }
}
