using System;

namespace Cache.Exceptions
{
    internal class KeyNotFoundInStoreException : Exception
    {
        public KeyNotFoundInStoreException(string message = "Key Not Found in Store") : base(message)
        {
        }
    }
}
