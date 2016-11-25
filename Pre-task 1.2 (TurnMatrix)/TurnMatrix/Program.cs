using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnMatrix
{
    class Program
    {
        static void Main(string[] args)

        {
            
            int[,] table1 = new int[3, 3];
            fillMatrix(table1);
            int[,] table2 = new int[3, 3];
            Boolean loop = false;

            do
            {
                Console.WriteLine("Press enter to fill in random matrix");
                Console.ReadLine();
                displayMatrix(table1);
                Console.ReadLine();
                Console.WriteLine("Press enter to turn matrix clockwise");
                Console.ReadLine();
                turnMatrixCloclwise(table1, table2);
                displayMatrix(table2);
                Console.WriteLine("Try again!");
            } while (loop == false);


        }

        public static void turnMatrixCloclwise(int[,] turnTable1, int[,] turnTable2)
        {
            for (int x = 0; x < turnTable1.GetLength(1); x++)

            {
                for (int z = 0, y = turnTable1.GetLength(0) - 1; y >= 0; y--, z++)

                {
                    turnTable2[x, z] = turnTable1[y, x];
                }
                
            }

        }




        public static void displayMatrix(int[,] array)

        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(" " + array[i, j] + " ");
                }

                Console.WriteLine();

            }
        }



        public static void fillMatrix(int[,] matrix)

        {
            Random rand = new Random(10);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(10);
                }
            }
        }

    }
}
