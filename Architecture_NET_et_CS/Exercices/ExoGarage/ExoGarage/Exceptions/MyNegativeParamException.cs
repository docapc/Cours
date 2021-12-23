using System.Runtime.Serialization;

namespace ExoGarage
{
    [Serializable]
    internal class MyNegativeParamException : ArgumentException
    {
        public MyNegativeParamException(string? message) : base(message)
        {
        }

        public MyNegativeParamException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}