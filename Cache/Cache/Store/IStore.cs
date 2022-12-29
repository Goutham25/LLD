namespace Cache.Store
{
    internal interface IStore<K,V>
    {
        void Put(K key, V value);

        void Delete(K key);

        void DeleteAll();
        V Get(K key);
    }
}
