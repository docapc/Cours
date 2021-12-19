using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    public class ExStagiaire : ExDeveloppeur
    {
        public override void Coder() //  
        {
            base.Coder();
            Console.WriteLine($"mais mal!");
        }

        public void FaireCafe()
        {
            Console.WriteLine($"{Name} fait le café");
        }
    }

 
}
