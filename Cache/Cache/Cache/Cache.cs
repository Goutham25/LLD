using Cache.Exceptions;
using Cache.Policy;
using Cache.Store;

namespace Cache.Cache
{
    internal class Cache<K, V> : ICache<K, V>
    {
        IEvictionPolicy<K> _evictionPolicy;
        IStore<K, V> _store;
        public Cache(IEvictionPolicy<K> evictionPolicy, IStore<K,V> store) {
            _evictionPolicy = evictionPolicy;
            _store = store;
        }

        public void Add(K key, V val)
        {

            try
            {
                _evictionPolicy.KeyAccessed(key);
                _store.Put(key, val);
            }
            catch (StoreIsFullException ex)
            {
                K evicKey = _evictionPolicy.GetEvictionKey();
                _store.Delete(evicKey);

                Add(key, val);
            }
        }

        public V Get(K key)
        {
            _evictionPolicy.KeyAccessed(key);

            return _store.Get(key);
        }

        public void RemoveAll(K key)
        {
            _evictionPolicy.Reset();
            _store.DeleteAll();
        }
    }
}
