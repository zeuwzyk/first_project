using System;

namespace example1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows matrix: ");
            int numRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of columns matrix: ");
            int numColumns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[numRows, numColumns];

            Console.Write("\nMatrix:\n"); 
            Random rand = new Random();
            for (int i=0; i < numRows; i++)
            {
                for (int j=0; j<numColumns; j++) 
                { 
                    matrix[i, j] = rand.Next(10,99);
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }            
        }
    }
}
