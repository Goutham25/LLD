using System;

namespace Cache.Exceptions
{
    internal class StoreIsFullException : Exception
    {
        public StoreIsFullException(string message = "Store Is Full") : base(message) {
        
        }

    }
}
