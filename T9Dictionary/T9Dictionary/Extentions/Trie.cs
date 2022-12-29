using System.Collections.Generic;

namespace T9Dictionary.Extentions
{
    internal class Trie
    {
        public TrieNode _root;

        public Trie()
        {
            _root = new TrieNode(null, 0, '^');
        }

        public TrieNode Prefix(string prefix)
        {
            TrieNode currentNode = _root;
            TrieNode result = currentNode;

            foreach (char c in prefix)
            {
                currentNode = currentNode.FindChildrenNode(c);
                if (currentNode == null)
                {
                    break;
                }
                result = currentNode;
            }
            return result;
        }

        public TrieNode PrefixMatch(string prefix)
        {
            TrieNode currentNode = _root;
            TrieNode result = currentNode;

            foreach (char c in prefix)
            {
                currentNode = currentNode.FindChildrenNode(c);
                if (currentNode == null)
                {
                    return null;
                }
                result = currentNode;
            }
            return result;
        }

        public bool Search(string s)
        {
            TrieNode currentNode = Prefix(s);

            return currentNode.IsLeaf() && currentNode.FindChildrenNode('$') != null;
        }
        public void AddMany(List<string> s)
        {
            foreach (string w in s)
            {
                Add(w);
            }
        }
        public void Add(string s)
        {
            TrieNode prefix = Prefix(s);
            TrieNode current = prefix;

            for (int i = prefix.Depth; i < s.Length; i++)
            {
                TrieNode newNode = new TrieNode(current, current.Depth + 1, s[i]);
                current.Children.Add(newNode);
                current = newNode;
            }
            current.Children.Add(new TrieNode(current, current.Depth + 1, '$'));
        }

        private List<string> Suggest(TrieNode prefix, List<string> list, string pre)
        {
            if (prefix == null)
            {
                return list;
            }

            if (prefix.FindChildrenNode('$') != null)
            {
                list.Add(pre);
            }

            foreach (TrieNode child in prefix.Children)
            {
                Suggest(child, list, pre + child.value);
            }
            return list;
        }
        public List<string> SuggestHelper(string pre)
        {
            TrieNode prefix = PrefixMatch(pre);

            return Suggest(prefix, new List<string>(), pre);

        }

        public List<string> SuggestHelperList(List<string> pre)
        {
            List<string> final = new List<string>();

            foreach (var item in pre)
            {
                var list = SuggestHelper(item);

                final.AddRange(list);
            }

            return final;
        }

        public void Remove(string s)
        {
            if (Search(s))
            {
                TrieNode currentNode = Prefix(s).FindChildrenNode('$');

                while (currentNode.IsLeaf())
                {

                    currentNode.DeleteChildNode(currentNode.value);
                    currentNode = currentNode.Parent;

                }
            }

        }
    }
}
