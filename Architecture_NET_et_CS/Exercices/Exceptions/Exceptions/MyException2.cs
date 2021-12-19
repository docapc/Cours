using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class MyException2 : Exception
    {
        //public MyException() // en l'enlevant on force le user à passer un messsage
        //{
        //}
 
        public MyException2(string message) : base(message)
        {
        }

        public MyException2(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => $" CouCou de l'excéption custom {base.Message}";

    }
}
