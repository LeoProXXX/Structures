using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node
    {
        public string value;
        public Node left = null;
        public Node right = null;

        public Node(string value)
        {
            this.value = value;
        }

        // dodaje lewe dziecko
        public void AddLeft(Node leftChild)
        {
            this.left = leftChild;
        }

        //dodaje prawe dziecko
        public void AddRight(Node rightChild)
        {
            this.right = rightChild;
        }

        // PRE-ORDER
        public void ShowPreOrder()
        {
            Console.Write("({0}", this.value);
            if (this.left != null)
            {
                this.left.ShowPreOrder();
            }
            if (this.right != null)
            {
                this.right.ShowPreOrder();
            }
            Console.Write(")");
        }

        // PRE-ORDER bez uzycia rekurencji (wsk. wykorzystaj stos)
        public void ShowPreOrderNotRecursion()
        {
            Stack<Node> stack = new Stack<Node>();
            if (this != null)
            {
                stack.Push(this);
            }
            while (stack.Count > 0)
            {
                Node tmp = stack.Pop();
                Console.WriteLine("{0} ", tmp.value);

                if (tmp.right != null)
                {
                    stack.Push(tmp.right);
                }
                if (tmp.left != null)
                {
                    stack.Push(tmp.left);
                }
            }
        }

        // POST-RDER
        public void ShowPostOrder()
        {
            if (this.left != null)
            {
                this.left.ShowPostOrder();
            }
            if (this.right != null)
            {
                this.right.ShowPostOrder();
            }
            Console.Write("{0} ", this.value);
        }

        // IN-ORDER
        public void ShowInOrder()
        {
            if (this.left != null)
            {
                this.left.ShowInOrder();
            }

            Console.WriteLine("{0} ", this.value);

            if (this.right != null)
            {
                this.right.ShowInOrder();
            }
        }

        // zwraca wysokosc
        public int GetHeight()
        {
            int height = 0;
            if (this.left != null)
            {
                height = Math.Max(height, this.left.GetHeight() + 1);
            }
            if (this.right != null)
            {
                height = Math.Max(height, this.right.GetHeight() + 1);
            }
            return height;
        }

        // przeszukuje drzewo
        public bool Search(string value)
        {
            if (this.value == value)
            {
                return true;
            }
            // przechodzimy przez odnogi drzewa najpierw lewe potem prawe
            bool left = false;
            bool right = false;

            if (this.left != null)
            {
                left = this.left.Search(value);
            }
            if (this.right != null)
            {
                right = this.right.Search(value);
            }
            return left || right;
        }

        // znajduje bezposredniego rodzica dla danego dziecka (po wartosciach)
        // metoda oparta na stosie i petli (tak jak PRE-ORDER bez uzycia rekurencji)
        public string FindParent(string childValue)
        {
            Stack<Node> stack = new Stack<Node>();
            if (this != null)
            {
                stack.Push(this);
            }
            while (stack.Count > 0)
            {
                Node tmp = stack.Pop();
                if ((tmp.left != null && tmp.left.value == childValue) || (tmp.right != null && tmp.right.value == childValue))
                {
                    return tmp.value;
                }

                if (tmp.right != null)
                {
                    stack.Push(tmp.right);
                }
                if (tmp.left != null)
                {
                    stack.Push(tmp.left);
                }
            }
            return "";
        }
    }

    class DrzewoBinarne
    {
        public Node root = null;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo binarne\n");

            DrzewoBinarne drzewo = new DrzewoBinarne();
            drzewo.root = new Node("F");

            Node wB = new Node("B");
            Node wA = new Node("A");
            Node wC = new Node("C");
            Node wD = new Node("D");
            Node wE = new Node("E");
            Node wG = new Node("G");
            Node wH = new Node("H");
            Node wI = new Node("I");

            wD.AddLeft(wC);
            wD.AddRight(wE);
            wB.AddLeft(wA);
            wB.AddRight(wD);
            wI.AddLeft(wH);
            wG.AddRight(wI);

            drzewo.root.AddLeft(wB);
            drzewo.root.AddRight(wG);

            Console.WriteLine("Pre-Order:");
            drzewo.root.ShowPreOrder();
            Console.WriteLine("\n");

            Console.WriteLine("Pre-Order bez rekurencji (na stosie)");
            drzewo.root.ShowPreOrderNotRecursion();
            Console.WriteLine("\n");

            Console.WriteLine("Post-Order:");
            drzewo.root.ShowPostOrder();
            Console.WriteLine("\n");

            Console.WriteLine("In-Order:");
            drzewo.root.ShowInOrder();
            Console.WriteLine("\n");

            Console.WriteLine("Wysokość: {0}", drzewo.root.GetHeight());
            Console.WriteLine();

            string valueToFind = "G";
            Console.WriteLine("Czy w drzewie jest wartość {0}? => {1}", valueToFind, drzewo.root.Search(valueToFind));

            valueToFind = "T";
            Console.WriteLine("Czy w drzewie jest wartość {0}? => {1}", valueToFind, drzewo.root.Search(valueToFind));
            Console.WriteLine();

            // bezpośredni rodzice danych elementów
            string arrayValuesToFind = "DBFIHZ";
            foreach (char item in arrayValuesToFind)
            {
                Console.WriteLine("Rodzicem elementu {0} jest {1}", item, drzewo.root.FindParent(item.ToString()));
            }

            Console.ReadKey();
        }
    }
}
