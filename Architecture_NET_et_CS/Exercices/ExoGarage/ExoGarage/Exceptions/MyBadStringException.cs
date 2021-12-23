using System.Runtime.Serialization;

namespace ExoGarage
{
    [Serializable]
    internal class MyBadStringException : ArgumentNullException
    {
        public MyBadStringException(string? message) : base(message)
        {
        }

        public MyBadStringException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}