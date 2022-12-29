using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using T9Dictionary.Extentions;

namespace T9Dictionary
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Trie trie = new Trie();
            T9Dictionary t9Dictionary = new T9Dictionary();

            //      2 ABC  3 DEF
            //      4 GHI  5 JKL 6 MNO
            //      7 PQRS 8 TUV 9 WXYZ

            int[] input = { 2, 2 };
            var a = t9Dictionary.Find(input);
        }
    }
}
