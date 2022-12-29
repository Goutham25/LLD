namespace Cache.Enum
{
    internal enum StorageType
    {
        Dictionary
    }

    internal enum EvictionType
    {
        LRU,
        LFU,
        DATETIME,
        FIFO
    }
}
