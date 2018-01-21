using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStacks
{
    /*
     * Lab 8 zad 4
     * Implement Queue using Stacks
     * A queue can be implemented using two stacks. 
     *
     *Zaprojektować implementację kolejki wykorzystującej dwa stosy.
     * Napisać metody obsługiwania takiej kolejki (wykorzystując metody stosu). Jaka jest złożoność metod takiej kolejki?
     * */

    class QueueBasedOnStacks
    {
        // pomocniczy stos
        Stack stackQueue = new Stack(); // główny stos, gdzie wierzchołek stosu to koniec kolejki

        // Dodawanie elementu (na koniec)
        public void Enqueue(int value)
        {
            // Przeniesienie danych z glownego stosu na stos pomocniczy (by byly odwrotnie)
            Stack tempStack = new Stack();

            while (!this.stackQueue.Empty())
            {
                int tempValue = this.stackQueue.Pop();
                tempStack.Push(tempValue);
            }

            // dodawanie elementu
            tempStack.Push(value);

            // przeniesienie danych ze stosu pomocniczego na stos glowny
            while (!tempStack.Empty())
            {
                int tempValue = tempStack.Pop();
                this.stackQueue.Push(tempValue);
            }
        }

        // Zdjecie elementu (z poczatku)
        public int Dequeue()
        {
            return this.stackQueue.Pop();
        }

        // Sprawdzenie czy pusty
        public bool Empty()
        {
            return stackQueue.Empty();
        }

        // odczyt poczatku kolejki
        public int Peek()
        {
            return this.stackQueue.Peek();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka na dwa stosy");

            QueueBasedOnStacks q = new QueueBasedOnStacks();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Dequeue());

            Console.WriteLine(q.Dequeue());

            q.Enqueue(100);
            q.Enqueue(200);

            Console.WriteLine(q.Dequeue());

            Console.WriteLine(q.Dequeue());

            q.Enqueue(300);

            Console.WriteLine(q.Dequeue());

            Console.ReadKey();
        }
    }

    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////
    //  //////////////////////////////////////////////////////////////////////

    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    class Stack
    {
        int counter = 0;
        Node top;

        //Pushing(storing) an element on the stack
        public void Push(int value)
        {
            this.counter++;

            Node newNode = new Node(value);
            newNode.next = top;
            top = newNode;
        }

        //Removing (accessing) an element from the stack.
        public int Pop()
        {
            if (this.Empty())
            {
                throw new Exception("Stack is empty");
            }
            this.counter--;
            int result = this.top.value;
            top = top.next;
            return result;
        }

        //Get the top data element of the stack, without removing it.
        public int Peek()
        {
            return this.top.value;
        }

        //Gets the number of elements contained in the Stack
        public int Size()
        {
            return this.counter;
        }

        //true if stack is empty
        public bool Empty()
        {
            return this.counter == 0;
        }
    }
}
