using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Pr. dom. 8, zadanie 1
 * SortedList. This collection stores elements in an ordered way. This enables binary search.
 * We do not need to write custom code for the search.
 * 
 * Napisz klasę lista posortowana. Lista ta ma mieć tylko jedną metodę do wstawiania,
 * ma wstawiać element tak aby lista była stale posortowana
 * */

namespace SortedList
{
    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    class SortedList
    {
        Node head; //glowa

        public bool Add(int value)
        {
            Node newNode = new Node(value);
            //gdy lista jest pusta
            if (head == null)
            {
                head = newNode;
                return true;
            }

            // gdy jest jeden element
            if (head.next == null)
            {
                if (head.value <= newNode.value) // dodajemy na prawo
                {
                    head.next = newNode;
                }
                else // dodajemy na lewo
                {
                    newNode.next = head;
                    head = newNode;
                }
                return true;
            }

            // w innym wypadku, gdy elementow jest wiecej:
            // 1) sprawdzamy czy nie wstawic elementu przed wszystkimi elementami

            if (head.value >= newNode.value)
            {
                newNode.next = head;
                head = newNode;
                return true;
            }

            // 2) szukamy odpowiedniego miejsca na wstawianie elementu
            for (Node tmp = head; tmp != null; tmp = tmp.next)
            {
                Node current = tmp;
                Node next = tmp.next;

                if (next == null && current.value <= newNode.value) // gdy jest to ostatni element
                {
                    tmp.next = newNode;
                    break;
                }
                else if (next != null)
                {
                    if (current.value <= newNode.value && next.value >= newNode.value) // wstawianie pomiedzy
                    {
                        newNode.next = next;
                        current.next = newNode;
                        break;
                    }
                }
            }
            return true;
        }

        public void ShowList()
        {
            Console.WriteLine();
            for (Node tmp = head; tmp != null; tmp = tmp.next)
            {
                Console.Write("{0}, ", tmp.value);
            }
            Console.WriteLine("KONIEC");
            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SortedList lista = new SortedList();
            lista.Add(1);
            lista.Add(4);
            lista.Add(2);
            lista.Add(18);
            lista.Add(7);
            lista.Add(-5);
            lista.Add(7);
            lista.Add(12);
            lista.Add(5);
            lista.Add(1);
            lista.Add(4);

            lista.ShowList();
            Console.ReadKey();
        }
    }
}
