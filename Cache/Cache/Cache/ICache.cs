namespace Cache.Cache
{
    internal interface ICache<K, V>
    {
        void Add(K key, V val);
        V Get(K key);
        void RemoveAll(K key);
    }
}
