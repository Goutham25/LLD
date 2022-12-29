using Cache.Extentions;
using System;
using System.Collections.Generic;

namespace Cache.Policy
{
    internal class LRUEvictionPolicy<K> : IEvictionPolicy<K>
    {
        DoublyLinkedList<K> _dll;
        Dictionary<K, Node<K>> _dic;
        static LRUEvictionPolicy<K> _instance;

        public LRUEvictionPolicy()
        {
            _dll = new DoublyLinkedList<K>();
            _dic = new Dictionary<K, Node<K>>();
        }

        public static LRUEvictionPolicy<K> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LRUEvictionPolicy<K>();
                }
                return _instance;
            }
        }

        public K GetEvictionKey()
        {
            var node = _dll.GetFirstNode();

            if (node != null)
            {
                _dll.Detach(node);
                _dic.Remove(node.element);
                return node.element;
            }
            else
            {
                return default(K);
            }
        }

        public void KeyAccessed(K key)
        {
            if (!_dic.ContainsKey(key))
            {
                var node = _dll.AddElementToLast(key);
                _dic.Add(key, node);
            }
            else
            {
                Node<K> node = _dic[key];
                _dll.Detach(node);
                _dll.AddNodeToLast(node);
            }
        }

        public void Reset()
        {
            _dll.Clear();
            _dic.Clear();
        }
    }
}
