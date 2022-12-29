namespace Cache.Policy
{
    internal interface IEvictionPolicy<K>
    {
        void KeyAccessed(K key);

        K GetEvictionKey();

        void Reset();
    }
}
