using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A binary heap is a heap data structure that takes the form of a binary tree. Binary heaps are a common way of implementing priority queues.
namespace BinaryHeap
{
    /*
     * TABLICOWA IMPLEMENTACJA KOPCA BINARNEGO  - LAB 10
     * 
     * Spis metod
     * - IsHeap - sprawdza, czy podana tablica jest kopcem
     * - GetHeight - zwraca wysokość kopca dla podanej tablicy
     * - MaxHeapElements - liczy największą liczbę elementów w kopcu o wysokości h
     * - MinHeapElements - liczy najmniejszą liczbę elementów w kopcu o wysokości h
     * - CountLeafNodes - liczy, ile jest liści w kopcu o liczbie węzłów n
     * - CountInnerNodes - liczy, ile jest węzłów wewnętrznych w kopcu o liczbie węzłów n
     * 
     * - ShowHeap - wyświetla kopiec
     * - Heapify - naprawia kopiec, czyli. przywraca mu własności kopca (tzn rodzic ma zawsze mniejszych potomków)
     * - Build - budowanie kopca z nieuporządkowanej tablicy elementów (używa funkcji Heapify())
     * */

    class BinaryHeap
    {
        // sprawdzamy, czy podana tablica to kopiec
        public static bool IsHeap(int[] tab)
        {
            for (int i = 0; i < tab.Length / 2; i++)
            {
                // badamy czy nie kopiec
                // czy lewe dziecko jest wieksze
                if (2 * i + 1 < tab.Length && tab[i] < tab[2 * i + 1])
                    return false;
                // czy prawe dziecko wieksze
                if (2 * i + 2 < tab.Length && tab[i] < tab[2 * i + 2])
                    return false;
            }
            return true;
        }

        // UWAGA
        // Jeżeli uwzglednimy zadanie 1c to zauważymy, że (t.Length / 2) -1 jest indeksem
        // ostatniego węzła węwnętrznego czyli mozemy uprościć sprawdzanie
        static bool IsHeap2(int[] t)
        {
            for (int i = 0; i < t.Length / 2; i++)
            {
                // badamy czy NIE kopiec
                if (t[i] < t[2 * i + 1] || (2 * i + 2 < t.Length && t[i] < t[2 * i + 2]))
                    return false;
            }
            return true;
        }

        // zwraca wysokosc podanego kopca
        public static int GetHeight(int[] heap)
        {
            int height = 0;

            int i = 1;
            while (i < heap.Length)
            {
                height++;
                i = 2 * i + 1; // pierwszy wierzcholek nastepnego poziomu
            }
            return height;
        }

        // mozemy zauwazyc, ze wyokosc kopca to czesc calkowita logarytmu przy podstawie 2 z liczby wezlow
        public static int GetHeight2(int[] heap)
        {
            return (int)Math.Floor(Math.Log(heap.Length, 2));
        }

        // Najwieksza liczba wezlow w kopcu o wysokosci height
        public static int MaxHeapElements(int height)
        {
            int result = 0;
            int value = 1;
            // pelne h poziomow
            for (int i = 0; i <= height; i++)
            {
                result += value;
                value = value * 2;
            }
            return result;
        }

        // podejscie matematyczne
        public static int MaxHeapElements2(int height)
        {
            return (int)Math.Pow(2, height + 1) - 1;
        }

        // Najmniejsza liczba wezlow w kopcu o wysokosci height
        public static int MinHeapElements(int height)
        {
            int result = 0;
            int value = 1;
            // pelne h-1 poziomow
            for (int i = 0; i < height; i++)
            {
                result += value;
                value = value * 2;
            }
            return result + 1; // jeden na ostatnim poziomie
        }

        // podejscie matematyczne
        public static int MinHeapElements2(int height)
        {
            return (int)Math.Pow(2, height);
        }

        // liczy, ile jest lisci w kopcu o n wierzcholkach
        public static int CountLeafNodes(int n)
        {
            return n - (n / 2);
        }

        // liczy, ile jest wezlow wewnetrznych w kopcu o n wierzcholkach
        public static int CountInnerNodes(int n)
        {
            return n / 2;
        }

        // wyswietla kopiec (tablice)
        public static void ShowHeap(int[] heap)
        {
            for (int i = 0; i < heap.Length; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }

        // funkcja naprawiajaca kopiec (inaczej downHeap)
        public static void Heapify(int[] heap, int node)
        {
            ShowHeap(heap); //Wyswietlamy stan kopca w kazdym kroku
            int length = heap.Length;
            int root = node; // korzen drzewa
            int left = 2 * node + 1;
            int right = 2 * node + 2;

            // dopóki są dzieci
            if (left < length && heap[left] > heap[root])
            {
                root = left;
            }
            if (right < left && heap[right] > heap[root])
            {
                root = right;
            }

            // robimy zamiane
            if (root != node)
            {
                int tmp = heap[node];
                heap[node] = heap[root];
                heap[root] = tmp;
                Heapify(heap, root);
            }
        }

        // budowanie kopca z nieuporzadkowanej tablicy elementow (uzywa fukcji Heapify())
        public static void Build(int[] heap)
        {
            int length = heap.Length;
            for (int i = (length / 2 - 1); i >= 0; i--)
            {
                Heapify(heap, i);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kopiec Binarny");
            int[] kopiec0 = { 23, 17, 14, 7, 13, 10, 1, 5, 6, 12 };
            int[] kopiec1 = { 23, 17, 14, 7, 13, 10, 1, 5, 6, 12, 0 };
            int[] kopiec2 = { 23, 17, 14, 7, 13, 10, 1 };
            int[] nieKopiec = { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };

            Console.WriteLine("Czy array jest kopcem?");
            Console.WriteLine(BinaryHeap.IsHeap(kopiec0));
            Console.WriteLine(BinaryHeap.IsHeap(kopiec1));
            Console.WriteLine(BinaryHeap.IsHeap(kopiec2));
            Console.WriteLine(BinaryHeap.IsHeap(nieKopiec));
            Console.WriteLine();

            Console.WriteLine("Wysokość kopca");
            Console.WriteLine(BinaryHeap.GetHeight(kopiec0));
            Console.WriteLine(BinaryHeap.GetHeight(kopiec1));
            Console.WriteLine(BinaryHeap.GetHeight(kopiec2));
            Console.WriteLine(BinaryHeap.GetHeight2(kopiec0));
            Console.WriteLine(BinaryHeap.GetHeight2(kopiec1));
            Console.WriteLine(BinaryHeap.GetHeight2(kopiec2));
            Console.WriteLine();

            Console.WriteLine("Max i min liczba elementów w kopcu");
            Console.WriteLine(BinaryHeap.MaxHeapElements(3));
            Console.WriteLine(BinaryHeap.MinHeapElements(3));
            Console.WriteLine(BinaryHeap.MaxHeapElements2(3));
            Console.WriteLine(BinaryHeap.MinHeapElements2(3));
            Console.WriteLine();

            Console.WriteLine("Liście i węzły wewnętrzne");
            Console.WriteLine(BinaryHeap.CountInnerNodes(15));
            Console.WriteLine(BinaryHeap.CountLeafNodes(15));
            Console.WriteLine(BinaryHeap.CountInnerNodes(8));
            Console.WriteLine(BinaryHeap.CountLeafNodes(8));
            Console.WriteLine();

            Console.WriteLine("Budowanie kopca");
            int[] t = { 5, 3, 17, 10, 84, 19, 6, 22, 9 };
            BinaryHeap.Build(t);
            Console.WriteLine(BinaryHeap.IsHeap(t));

            Console.ReadKey();
        }
    }
}
