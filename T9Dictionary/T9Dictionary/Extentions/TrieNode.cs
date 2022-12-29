using System.Collections.Generic;

namespace T9Dictionary.Extentions
{
    internal class TrieNode
    {
        public TrieNode Parent;
        public int Depth;

        public List<TrieNode> Children;
        public char value;

        public TrieNode(TrieNode parent, int depth,  char value)
        {
            Parent = parent;
            Children= new List<TrieNode>();
            Depth = depth;
            this.value = value;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public TrieNode FindChildrenNode(char c)
        {
            foreach(TrieNode child in Children)
            {
                if(child.value == c)
                {
                    return child;
                }
            }
            return null;
        }

        public void DeleteChildNode(char c)
        {
            for(int i=0; i< Children.Count; i++)
            {
                if (Children[i].value == c)
                {
                    Children.RemoveAt(i);
                }
            }
        }
    }
}
