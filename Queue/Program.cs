using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Queue is a linear structure which follows a particular order in which the operations are performed. The order is First In First Out (FIFO).
/// </summary>
namespace Queue
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

    class Queue
    {
        Node head;
        Node rear;

        //add (store) an item to the queue.
        public void Enqueue(int x)
        {
            Node newNode = new Node(x);
            if (head == null)
            {
                head = newNode;
                rear = head;
                return;
            }

            rear.next = newNode;
            rear = newNode;
        }

        //Dequeue()	Removes and returns the object at the beginning of the Queue
        public int Dequeue()
        {
            int result;

            if (this.Empty())
            {
                throw new Exception("Dequeue is empty");
            }

            result = this.head.value;

            if (head == rear)
            {
                head = null;
                rear = null;
                return result;
            }

            head = head.next;
            return result;
        }

        //Checks if the queue is empty. True if Empty
        public bool Empty()
        {
            if (head == null || rear == null)
            {
                return true;
            }
            return false;
        }

        //Peek() Returns the object at the beginning of the Queue without removing it.
        public int Peek()
        {
            if (this.Empty())
            {
                throw new Exception("Dequeue is empty");
            }

            return this.head.value;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka FIFO");

            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Dequeue());

            Console.WriteLine(q.Dequeue());

            Console.WriteLine(q.Dequeue());

            Console.ReadKey();
        }
    }
}
