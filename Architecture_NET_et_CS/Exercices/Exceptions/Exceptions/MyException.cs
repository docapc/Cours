using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
// pour les exception custom
namespace Exceptions
{
    public class MyException : Exception
    {
        //public MyException() // en l'enlevant on force le user à passer un messsage
        //{
        //}
        public int A { get; set; }

        public int B { get; set; }
        public MyException(string message, int a, int b) : base(message)
        {
            A = a;
            B = b;
        }

        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // Customisation du Message
        public override string Message => $"{base.Message}, Arg1: {A}, Arg2 : {B}"; 

    }
}
