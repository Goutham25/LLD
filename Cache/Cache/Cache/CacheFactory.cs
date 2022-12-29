using Cache.Enum;
using Cache.Policy;
using Cache.Store;

namespace Cache.Cache
{
    internal class CacheFactory<K, V>
    {
        IStore<K, V> _store;
        IEvictionPolicy<K> _evictionPolicy;
        public CacheFactory(StorageType storageType, EvictionType evictionType, int capacity)
        {

            switch (storageType)
            {
                case StorageType.Dictionary:
                    _store = new DictionaryStore<K, V>(capacity);
                    break;

            }
            switch (evictionType)
            {
                case EvictionType.LRU:
                    _evictionPolicy = new LRUEvictionPolicy<K>();
                    break;

            }

        }

        public Cache<K, V> GetCache()
        {
            return new Cache<K, V>(_evictionPolicy, _store);
        }
    }
}
