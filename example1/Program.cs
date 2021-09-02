using System;

namespace example1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows = 0;
            int numColumns = 0;

            Console.Write("Enter integer number of rows matrix: ");
            numRows = verification(numRows);

            Console.Write("Enter integer number of columns matrix: ");
            numColumns = verification(numColumns);

            int[,] matrix = new int[numRows, numColumns];

            Console.Write("\nMatrix:\n");
            Random rand = new Random();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    matrix[i, j] = rand.Next(10, 99);
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }
        }
        static int verification(int value)
        {
            while (!int.TryParse(Console.ReadLine(), out value) && value < 2147483647
                && value > -2147483648)
            {
                Console.WriteLine("You entered inavlid number or not number");
                Console.Write("\nEnter number of rows matrix: ");
            }
            return value;
        }
    }
}
