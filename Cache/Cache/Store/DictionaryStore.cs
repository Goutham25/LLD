using Cache.Exceptions;
using System.Collections.Generic;

namespace Cache.Store
{
    internal class DictionaryStore<K, V> : IStore<K, V>
    {
        Dictionary<K, V> _dictstore;
        int _capacity = 0;

        public DictionaryStore(int capacity)
        {
            _dictstore = new Dictionary<K, V>();
            _capacity = capacity;
        }

        public void Delete(K key)
        {
            if (_dictstore.ContainsKey(key))
            {
                _dictstore.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void DeleteAll()
        {
            _dictstore.Clear();
        }

        public V Get(K key)
        {
            if (_dictstore.ContainsKey(key))
            {
                return _dictstore[key];
            }
            else
            {
                return default(V);
            }
        }

        public void Put(K key, V value)
        {
            if (_dictstore.ContainsKey(key))
            {
                _dictstore[key] = value;
            }
            else
            {
                if (_dictstore.Count < _capacity)
                {
                    _dictstore.Add(key, value);
                }
                else
                {
                    throw new StoreIsFullException();
                }
            }
        }
    }
}
