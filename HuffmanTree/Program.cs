using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    // Drzewo Huffmana to rodzaj drzew binarnego
    // TODO

    class Node
    {
        public char character; // znak
        public int occurrences; // liczba wystapien
        public Node left;
        public Node right;
    }

    class HuffmanTree
    {
        // funkcja która liczy wystapienia danych znaków
        public static void ClculateOccurrences(string text)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo Huffmana \n");

            Console.ReadKey();
        }
    }
}
