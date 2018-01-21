using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_ParenthesisChecker
{
    /// <summary>
    /// (Lab 8 zad 5)
    /// Use the stack to check for balanced parentheses in an expression.
    /// Given an expression string exp, write a program to examine whether the pairs and the orders of “{“,”}”,”(“,”)”,”[“,”]” are correct in exp.
    /// Examples:
    ///     "a=)x]i[+5(*y;" -  Error
    ///     "a=(x[i]+5)*y;" -  OK
    ///     "a=(x[i)+5]*y;" -  Error
    ///     "a=(x(i]+5]*y;" -  Error
    /// </summary>
    class Program
    {
        public static bool CheckBrackets(string expression)
        {
            char[] openBrackets = new char[] { '(', '[', '{' };
            char[] closeBrackets = new char[] { ')', ']', '}' };
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char charracter = expression[i];
                if (openBrackets.Contains(charracter)) // czy dany znak to znak z tablicy openBrackets
                {
                    // jeśli tak, to na stos wrzucamy odpowiadający mu znak z closeBrackets
                    int index = Array.IndexOf(openBrackets, charracter);
                    char closeBrack = closeBrackets[index];
                    stack.Push(closeBrack);
                    continue;
                }

                if (closeBrackets.Contains(charracter))// czy dany znak to znak z tablicy closeBrackets
                {
                    if (stack.Count == 0) // jesli stos pusty, to koniec
                    {
                        return false;
                    }

                    char bracketFromStack = stack.Pop();
                    if (charracter != bracketFromStack)
                    {
                        return false;
                    }
                }
            }

            // na koniec trzeba sprawdzic, ze stos jest pusty (tzn. że zamknięto wszystkie otwarte nawiasy)
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            bool wynik;
            string wyrazenie;

            Console.WriteLine("Sprawdzanie poprawności nawiastów w wyrażeniu");
            Console.WriteLine();

            wyrazenie = "a=)x]i[+5(*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x[i]+5)*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x[i)+5]*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x(i]+5]*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            Console.ReadKey();
        }
    }
}
