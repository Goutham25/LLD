using System;

namespace Cache.Policy
{
    internal class LFUEvictionPolicy<K> : IEvictionPolicy<K>
    {
        public K GetEvictionKey()
        {
            throw new NotImplementedException();
        }

        public void KeyAccessed(K key)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
