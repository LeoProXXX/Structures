using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbiorHashtable
{
    /*
    * Zaimplementuj Zbiór wykorzystując klasę Hashtable z .NET. (lab 12 zad 5)
    * */

    class ZbiorHashtable
    {
        Hashtable hashtable = new Hashtable(1000);

        // Zwraca rozmiar naszej hashtable
        public int Count
        {
            get
            {
                return hashtable.Count;
            }
        }

        // Wartosci przechowywane przez nasze hashtable
        public ICollection Values
        {
            get
            {
                return hashtable.Keys;
            }
        }

        // Dodaje nowa wartosc
        public bool Insert(int value)
        {
            if (!this.hashtable.ContainsKey(value))
            {
                this.hashtable.Add(value, value);// wrtosc taka sama jak klucz
                return true;
            }
            return false;
        }

        // Czy zbior zawiera dana wartosc?
        public bool Contains(int value)
        {
            return this.hashtable.Contains(value);
        }

        // Usuwa element ze zbioru
        public bool Delete(int value)
        {
            if (this.hashtable.ContainsKey(value))
            {
                this.hashtable.Remove(value);
                return true;
            }
            return false;
        }

        // Union(s1, s2) - s1 U s2 - (suma zbiorów)
        public static ZbiorHashtable Union(ZbiorHashtable s1, ZbiorHashtable s2)
        {
            ZbiorHashtable result = new ZbiorHashtable();
            foreach (int k in s1.Values)
            {
                result.Insert(k);
            }
            foreach (int k in s2.Values)
            {
                result.Insert(k);
            }
            return result;
        }

        // Intersection(s1, s2) - s1 n s2 (iloczyn zbiorów, elementy wspólne)
        public static ZbiorHashtable Intersection(ZbiorHashtable s1, ZbiorHashtable s2)
        {
            ZbiorHashtable result = new ZbiorHashtable();
            foreach (int k in s1.Values)
            {
                if (s2.Contains(k))
                {
                    result.Insert(k);

                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var k in this.Values)
            {
                result += k + " ";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zbior wykorzystujacy Hashtable z .NET");

            ZbiorHashtable s1 = new ZbiorHashtable();
            ZbiorHashtable s2 = new ZbiorHashtable();

            s1.Insert(22);
            s1.Insert(522);
            s1.Insert(922);
            s1.Insert(677);
            s1.Insert(222);
            s1.Insert(377);

            s2.Insert(122);
            s2.Insert(522);
            s2.Insert(822);
            s2.Insert(677);

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            s1.Delete(377);
            Console.WriteLine(s1);

            ZbiorHashtable s3 = ZbiorHashtable.Union(s1, s2);
            Console.WriteLine(s3);

            ZbiorHashtable s4 = ZbiorHashtable.Intersection(s1, s2);
            Console.WriteLine(s4);

            Console.ReadKey();
        }
    }
}
