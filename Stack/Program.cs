using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A stack is an Abstract Data Type (ADT), commonly used in most programming languages. It is named stack as it behaves like a real-world stack, for example – a deck of cards or a pile of plates, etc.
/// This feature makes it LIFO data structure. LIFO stands for Last-in-first-out.
/// </summary>
namespace Stack
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack LIFO");

            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            Console.WriteLine(s.Peek());
            s.Pop();

            Console.WriteLine(s.Pop());

            Console.WriteLine(s.Pop());

            s.Push(123);

            Console.WriteLine(s.Pop());

            Console.ReadKey();
        }
    }
}
