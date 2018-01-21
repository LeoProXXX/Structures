using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
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

    class SinglyLinkedList
    {
        Node head;
        Node rear;

        // dodaje element na koncu (po wszystkich elementach)
        public void AddEnd(int value)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(value);
                return;
            }

            Node newNode = new Node(value);
            rear.next = newNode;
            rear.next = newNode;
        }

        // dodaje element na poczatku (przed wszystkimi innymi)
        public void AddFront(int value)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(value);
                return;
            }

            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
        }

        // funkcja prywatna, potrzebna tylko do uzytku wewnetrznego - dodaje pierwszy element (tzn. gdy lista byla wczesniej pusta)
        private void AddFirstElement(int value)
        {
            Node newNode = new Node(value);
            this.head = newNode;
            this.rear = newNode;
        }

        //usuwa pierwszy wezel
        public void DeleteFirstNode()
        {
            head = head.next;
        }

        // usuwa ostatni wezel
        public void DeleteLastNode()
        {
            if (head == null)
            {
                return;
            }

            for (Node temp = head; temp != null; temp = temp.next)
            {
                if (temp.next == rear)
                {
                    temp.next = null;
                    rear = temp;
                    return;
                }
            }
        }

        // usuwa pierwszy wezel z wartoscia rowna
        public void DeleteFirstOccurrenceOf(int value)
        {
            if (head.value == value)
            {
                this.DeleteFirstNode();
                return;
            }
            if (rear.value == value)
            {
                this.DeleteLastNode();
                return;
            }

            for (Node tmp = head; tmp != null; tmp = tmp.next)
            {
                // to moze nie zadzialac
                if (tmp.next.value == value)
                {
                    tmp.next = tmp.next.next;
                    return;
                }
            }
        }

        //zamienia wszystkie wartosci oldValue na newValue
        public void Change(int oldValue, int newValue)
        {
            for (Node tmp = head; tmp != null; tmp = tmp.next)
            {
                if (tmp.value == oldValue)
                {
                    tmp.value = newValue;
                }
            }
        }

        //zwraca rozmiar listy (ilosc elementow)
        public int GetSize()
        {
            int counter = 0;
            Node tmp = head;
            while (tmp != null)
            {
                tmp = tmp.next;
                counter++;
            }

            return counter;
        }

        // wyswietla wszystkie elementy listy
        public void ShowList()
        {
            Console.WriteLine();
            if (head == null)
            {
                Console.WriteLine("PUSTO");
            }

            Node tmp = head;
            while (tmp != null)
            {
                Console.Write("{0}, ", tmp.value);
                tmp = tmp.next;
            }

            Console.WriteLine();
        }

        // zwraca wartosc w head
        public int? GetHeadValue()
        {
            if (head == null)
            {
                return null;
            }
            return head.value;
        }

        // zwraca wartosc rear
        public int? GetRearValue()
        {
            if (rear == null)
            {
                return null;
            }
            return rear.value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList lista = new SinglyLinkedList();
            lista.AddFront(3);
            lista.AddFront(1);
            lista.AddFront(14);
            lista.AddFront(23);
            lista.AddFront(1);
            lista.AddFront(7);
            lista.ShowList();

            Console.WriteLine("Rozmiar: {0}", lista.GetSize());

            Console.ReadKey();
        }
    }
}
