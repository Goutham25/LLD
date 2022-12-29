using Cache.Extentions;

namespace Cache.Policy
{
    internal class FIFOEvictionPolicy<K> : IEvictionPolicy<K>
    {
        Stack<K> _stack;
        static FIFOEvictionPolicy<K> _instance;


        public FIFOEvictionPolicy()
        {
            _stack = new Stack<K>();
        }
        public static FIFOEvictionPolicy<K> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FIFOEvictionPolicy<K>();
                }
                return _instance;
            }
        }
        public K GetEvictionKey()
        {
            K key = _stack.Pop();
            return key;
        }

        public void KeyAccessed(K key)
        {
            _stack.Push(key);
        }

        public void Reset()
        {
            _stack.DeleteAll();
        }
    }
}
