using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*In computer science, a priority queue is an abstract data type which is like a regular queue or stack data structure, but where additionally each element has a "priority" associated with it.
 * In a priority queue, an element with high priority is served before an element with low priority.
 * If two elements have the same priority, they are served according to their order in the queue.
 * */

namespace PriorityQueue
{

    /**
      * KOLEJKA PRIORYTETOWA - to struktura danych służąca do przechowywania
      *      zbioru S elementów, z których każdy ma przyporządkowaną wartość zwaną kluczem.
      *      Zbiór S jest podzbiorem zbioru liniowo uporządkowanego
      */
    /*
     * NOWE FUNKCJE
     *  - Insert - wstawia nowy element do kopca jako ostatni liść. Następnie naprawia ten kopiec
     *  - ExtractMax - usuwa element z kopca i go zwraca - tzn. zwraca największy, a na jego miejsce wstawia najmniejszy. Następnie wykonuje naprawę kopca
     *  - Maximum - zwraca (bez usuwania) największy element kopca
     *  
     *  INFO ODNOSNIE PLIKU:
     *  - są dwie klasy - Heap i KolejkaPriorytetowa
     *  - Heap wykonuje operacje na kopcu zapisanym w tablicy (wstawianie elementu, usuwanie elementu, budowa, wyświetlanie kopca)
     *  - KolejkaPriorytetowa - to tylko "obudowana" klasa Heap. Kolejka zawiera tablicę (kopiec) oraz licznik elementów
     **/

    class Heap
    {
        // wyswietla kopiec do elementu o indeksie length
        public static void Show(int[] heap, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }

        // funkcja naprawiajaca kopiec (incaczej downHeap)
        public static void Heapify(int[] heap, int node, int length)
        {
            int root = node; // korzen drzewa
            int left = 2 * node + 1;
            int right = 2 * node + 2;

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
                Heapify(heap, root, length);
            }
        }

        // budowanie kopca z nieuporzadkowanej tablicy elementow (uzywa funkcji Heapify())
        public static void Build(int[] heap, int length)
        {
            for (int i = (length / 2 - 1); i >= 0; i--)
            {
                Heapify(heap, i, length);
            }
        }


        // Wstawia elementy do kopca. int lenght - miejsce, gdzie wstawic. int element - element do wstawienia
        public static bool Insert(int[] heap, int lenght, int element)
        {
            if (lenght >= heap.Length)
            {
                return false;
            }
            heap[lenght] = element;

            // teraz naprawa (budowanie) kopca
            Build(heap, lenght + 1);
            //Heapify(heap, 0, lenght + 1);
            return true;
        }

        // Zwraca i usuwa najwiekszy element z kopca. Nastepnie wypelnia "luke" najmniejszym elementem i naprawia kopiec
        public static int ExtractMax(int[] heap, int length)
        {
            int max = heap[0];
            int min = heap[length - 1];
            heap[length - 1] = 0; // usuwanie najmniejszego elementu

            heap[0] = min; // wypelniamy luke najmniejszego elementu

            Heapify(heap, 0, length);
            return max;
        }

        // zwraca (ele nie usuwa!) najwiekszy element kopca
        public static int Maximum(int[] heap)
        {
            return heap[0];
        }
    }

    // Klasa kolejki priorytetowej, ktora operuje na kopcu (klasa Heap)
    class PriorityQueue
    {
        public int length = 0;
        public int[] heap = new int[100];

        // wstawia element do kolejki
        public void Insert(int element)
        {
            if (this.length >= 100)
            {
                Console.WriteLine("NIE MOZNA JUZ WIECEJ WSTAWIC!!!");
                return;
            }
            Heap.Insert(this.heap, this.length, element);
            this.length++;
        }

        // zwraca najwiekszy element w kolejce i go usuwa
        public int ExtractMax()
        {
            if (this.length <= 0)
            {
                Console.WriteLine("Nie ma juz elementow w kolejce!!!");
                return 0;
            }

            int result = Heap.ExtractMax(this.heap, this.length);
            this.length--;
            return result;
        }

        // zwraca najwiekszy element w kolejce (bez jego usuwania)
        public int Maximum()
        {
            if (this.length <= 0)
            {
                Console.WriteLine("Nie ma juz elementow w kolejce!!!");
                return 0;
            }

            return Heap.Maximum(this.heap);
        }

        // wyswietla kolejke
        public void Show()
        {
            Heap.Show(this.heap, this.length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka priorytetowa \n");

            PriorityQueue kolejka = new PriorityQueue();
            // wypełnaimy kolejkę 15 losowymi danymi z przedziału 1 - 50;
            Random rand = new Random();
            kolejka.Insert(1);
            kolejka.Insert(2);
            kolejka.Insert(4);
            kolejka.Insert(5);
            kolejka.Insert(6);
            kolejka.Insert(7);
            kolejka.Insert(8);
            kolejka.Insert(9);
            kolejka.Insert(10);

            Console.WriteLine();
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Dodaję 11 do kolejki");
            kolejka.Insert(11);

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Dodaję 3 do kolejki");

            kolejka.Insert(3);

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}