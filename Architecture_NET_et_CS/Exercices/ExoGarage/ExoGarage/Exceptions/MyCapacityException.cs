using System.Runtime.Serialization;

namespace ExoGarage
{
    [Serializable]
    internal class MyCapacityException : ArgumentException
    {
        public MyCapacityException(string? message) : base(message)
        {
        }

        public MyCapacityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}