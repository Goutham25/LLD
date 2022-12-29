using Cache.Exceptions;

namespace Cache.Extentions
{
    internal class DoublyLinkedList<K>
    {
        Node<K> head;
        readonly Node<K> tail;

        public DoublyLinkedList()
        {
            head = new Node<K>(default(K));
            tail = new Node<K>(default(K));

            head.Next = tail;
            tail.Prev = head;
        }

        public void AddNodeToLast(Node<K> node)
        {
            Node<K> prev = tail.Prev;
            tail.Prev = node;
            node.Next = tail;
            node.Prev = prev;
            if (prev != null)
            {
                prev.Next = node;
            }
        }

        public Node<K> AddElementToLast(K key)
        {
            var node = new Node<K>(key);
            AddNodeToLast(node);
            return node;
        }

        public void Detach(Node<K> node)
        {
            if (node == null)
            {
                var prev = node.Prev;
                var next = node.Next;

                prev.Next = next;
                next.Prev = prev;
            }
        }

        public Node<K> GetFirstNode()
        {
            if (head.Next != tail)
            {
                return head.Next;
            }
            else
            {
                throw new LinkedListException("List is Empty");
            }
        }

        public Node<K> GetLastNode()
        {
            if (tail.Prev != head)
            {
                return tail.Prev;
            }
            else
            {
                throw new LinkedListException("List is Empty");
            }
        }
        public void Clear()
        {
            head.Next = tail;
            tail.Prev = head;
        }
    }
}
