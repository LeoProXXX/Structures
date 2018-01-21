using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * In computer science, a tree is a widely used abstract data type (ADT)—or data structure implementing this ADT—that simulates a hierarchical tree structure, with a root value and subtrees of children with a parent node, represented as a set of linked nodes.
 * */
namespace Tree
{
    class Node
    {
        public string value;
        public ArrayList children = new ArrayList();

        public Node(string value)
        {
            this.value = value;
            this.children = new ArrayList();
        }

        //inicjuje wezel danymi
        public void InitNode(string value)
        {
            this.value = value;
            this.children = new ArrayList();
        }

        //dodaje dziecko
        public void AddChild(Node child)
        {
            this.children.Add(child);
        }

        // PRE-ORDER
        public void ShowPreOrder()
        {
            //najpierw rodzic
            Console.Write("({0}", this.value);
            if (this.children.Count > 0)
            {
                for (int i = 0; i < this.children.Count; i++)
                {
                    Node child = (Node)this.children[i];
                    child.ShowPreOrder();
                }
            }
            Console.Write(")");
        }

        // POST-ORDER
        public void ShowPostOrder()
        {
            // najpierw potomkowie
            if (this.children.Count > 0)
            {
                for (int i = 0; i < this.children.Count; i++)
                {
                    Node child = (Node)this.children[i];
                    child.ShowPostOrder();
                }
            }
            Console.WriteLine(" {0},", this.value);
        }

        // Zwraca wysokosc
        public int GetHeight()
        {
            int height = 0;
            for (int i = 0; i < this.children.Count; i++)
            {
                Node child = (Node)this.children[i];
                height = Math.Max(height, child.GetHeight() + 1);
            }
            return height;
        }
    }

    class Drzewo
    {
        public Node root;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo\n");

            Drzewo drzewo = new Drzewo();
            drzewo.root = new Node("F");

            Node wB = new Node("B");
            Node wA = new Node("A");
            Node wC = new Node("C");
            Node wD = new Node("D");
            Node wE = new Node("E");
            Node wG = new Node("G");
            Node wH = new Node("H");
            Node wI = new Node("I");

            wD.AddChild(wC);
            wD.AddChild(wE);
            wB.AddChild(wA);
            wB.AddChild(wD);
            wI.AddChild(wH);
            wG.AddChild(wI);

            drzewo.root.AddChild(wB);
            drzewo.root.AddChild(wG);

            Console.WriteLine("Pre-order:");
            drzewo.root.ShowPreOrder();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Post-order:");
            drzewo.root.ShowPostOrder();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Wysokosc = {0}", drzewo.root.GetHeight());

            Console.ReadKey();
        }
    }
}
