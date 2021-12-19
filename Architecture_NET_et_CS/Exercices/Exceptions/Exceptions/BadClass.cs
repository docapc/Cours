using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class BadClass
    {
        public int DivPar0(int a)
        {
            return a / 0;
        }
        public Exception BadReturn(Exception e)
        {
            try
            {
                throw e;
            }
            catch(DivideByZeroException dbz)
            {
                Console.WriteLine($"BadClass à attrapé : {dbz.Message}");
                throw dbz; // interessant sa
            }

        }

    }
}
