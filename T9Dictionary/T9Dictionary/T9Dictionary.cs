using System;
using System.Collections.Generic;
using T9Dictionary.Extentions;

namespace T9Dictionary
{
    internal class T9Dictionary
    {
        Trie _trie;

        public T9Dictionary()
        {
            _trie = new Trie();

            List<string> list = new List<string>();
            list.Add("acres");
            list.Add("ann");

            list.Add("anna");
            list.Add("apple");
            list.Add("basic");
            list.Add("book");
            list.Add("claustrophobic");
            list.Add("cool");
            list.Add("dog");
            list.Add("earnest");
            _trie.AddMany(list);

        }
        List<string> output;
        void FindCombinations(String[] keypad,
                                 int[] input, String result,
                                 int index, int n)
        {
            // If processed every digit of key, print result
            if (index == n)
            {
                output.Add(result);
                return;
            }

            // Stores current digit
            int digit = input[index];
            // Size of the list corresponding to current digit
            int len = keypad[digit].Length;
            // One by one replace the digit with each character
            // in the corresponding list and recur for next
            // digit
            for (int i = 0; i < len; i++)
            {
                FindCombinations(keypad, input,
                                 result + keypad[digit][i],
                                 index + 1, n);
            }
        }

        public List<string> Find(int[] input)
        {
            output = new List<string>();

            // Keypad word of number of (1 to 9)
            // 0 and 1 digit don't have any characters
            // associated

    //      2 ABC  3 DEF
    //      4 GHI  5 JKL 6 MNO
    //      7 PQRS 8 TUV 9 WXYZ


            String[] keypad
                = { "",    "",    "abc",  "def", "ghi",
                "jkl", "mno", "pqrs", "tuv", "wxyz" };
            String result = "";


            // Size of the array
            int n = input.Length;

            // Function call to find all combinations
            FindCombinations(keypad, input, result, 0, n);


            return _trie.SuggestHelperList(output);
        }


        private List<string> Find1(int[] input)
        {
              return _trie.SuggestHelper("an");

        }
    }
}
