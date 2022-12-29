using System.Collections.Generic;

namespace Cache.Extentions
{
    internal class Stack<K>
    {
        List<K> _list;
        public Stack() {
            _list = new List<K>();
        } 

        public void Push(K item)
        {
            _list.Add(item);
        }

        public K Pop()
        {
            K key = _list[0];
            _list.RemoveAt(0);
            return key;
        }

        public bool Contains(K item)
        {
            return _list.Contains(item);
        }

        public void DeleteAll()
        {
            _list.Clear();
        }

    }
}
