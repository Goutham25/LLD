namespace Cache.Extentions
{
    internal class Node<K>
    {
        internal Node<K> Prev;
        internal Node<K> Next;
        internal K element;

        public Node (K key)
        {
            element = key;   
        }
    }
}
