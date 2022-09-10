using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArrV1Próba
{
    class Program
    {

        //Napisz metody(nie program) o sygnaturach:

        static char[][] ReadJaggedArrayFromStdInput()
        {
            //- z pierwszej linii standardowego wejścia wczytuje liczbę wierszy(<10), następnie wczytuje kolejne wiersze składające się ze znaków oddzielonych pojedynczą spacją.Jako wynik swojego działania zwraca wczytane dane w formie tablicy postrzępionej(patrz sygnatura),
            int numbrow = Convert.ToInt32(Console.ReadLine());
            char[][] jagged_arr = new char[numbrow][];
            for (var i = 0; i < numbrow; i++)
            {
                jagged_arr[i] = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
            }
            return jagged_arr;

        }
        static char[][] TransposeJaggedArray(char[][] tab)
        {
            ///*- transponuje tablicę, zwracając nową, w której kolumny stają się wierszami, zaś wiersze kolumnami,*/
            ///

            var numRows = tab.Max(x => x.Length);
            var numCols = tab.Length;

            var target = new char[numRows, numCols];
            for (int row = 0; row < tab.Length; ++row)
            {
                for (int col = 0; col < tab[row].Length; ++col)
                    target[col, row] = tab[row][col];
            };
            char[,] ob = target;
            char[] objSP = ((char[,])ob).Cast<char>().ToArray();

            int j = 0;
            char[][] jagged = objSP.GroupBy(x => j++ / ob.GetLength(1)).Select(y => y.ToArray()).ToArray();

            return jagged;
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for (int n = 0; n < tab.Length; n++)
            {

                for (int k = 0; k < tab[n].Length; k++)
                {
                    Console.Write("{0} ", tab[n][k]);

                }
                Console.Write("\n");
                //Console.ReadLine();
                //- wypisuje na standardowe wyjście tablicę wierszami w kolejnych liniach.
            }
        }
        static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }
    }
}

