using System;
using System.Collections.Generic;
using System.IO;

namespace example2
{
    class Program
    {
        public static string line = "";
        static void Main(string[] args)
        {
            Console.Write("Enter the path to *.txt file: \n");//убрать \n
            string path = "D:\\Projects\\example2\\File.txt"; //Console.ReadLine(path);
            line = File.ReadAllText(path);
            Console.WriteLine(line);

            Console.Write("\nEnter the word from text: ");
            string word = Console.ReadLine();
            string startText = line;

            line = line.ToLower();
            word = word.ToLower();
            string[] words = line.Split(' ', ',', '.');
            int temp = 1;

            for (int i = 0; i < words.Length; i++)            
                if (words[i] == word && words[i].Length == word.Length)                
                    temp++;         
                            
            if (temp > 1)
            {
                Console.WriteLine("word find");
                Console.WriteLine($"the count of repetitions of the word '{word}' in the text: {temp}");
            }
            else
                Console.WriteLine("not find word");

            Function();
            string selection = "";
            while (selection != "0")
            {
                line = startText;
                Console.Clear();
                Console.WriteLine(line);
                Console.Write("\nMenu:\nCommands:\n f - find word\n r - replace word\n d - delete word\n 0 - exit" +
                    "\nEnter the command: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "f":
                        FindWord();
                        break;
                    case "r":
                        ReplaceWord();
                        break;
                    case "d":
                        DeleteWord();
                        break;
                    case "0":
                        Console.WriteLine("Exit.");
                        Function();
                        Environment.Exit(1);
                        break;
                    default://любой символ 
                        Console.WriteLine("Error. Entred not correct symbol");
                        Function();
                        break;
                }
            } 
        }
        static void FindWord()//учесть, что слово может быть не одно, какой должен быть поиск?
        {
            Console.WriteLine("f");
            Console.Write("Enter the word for find first and last index: ");
            string word = Console.ReadLine();
            int index1 = line.IndexOf(word);
            Console.WriteLine("First value Index of {word} is " + index1);
            Function();
        }
        static void ReplaceWord()//Любого регистра?
        {
            Console.WriteLine("r");
            Console.Write("Enter the word to be replaced: ");
            string word = Console.ReadLine();
            Console.Write("Enter the word for replace: ");
            string replaceWord = Console.ReadLine();

            string[] words = line.Split(' ', ',', '.');
            int temp = 0;
            do
            {
                for (int i = 0; i < words.Length; i++)
                    if (words[i] == word && words[i].Length == word.Length)
                    {
                        line = line.Replace(word, replaceWord);
                        Console.WriteLine(line);
                    }
                    else
                    {
                        Console.WriteLine("Enter not correct word.");
                        break;
                    }
                temp++;
            } while (temp < 1);

            Function();
        }
        static void DeleteWord()
        {
            Console.WriteLine("d");
            Console.Write("Enter the word for deleted: ");
            string word = Console.ReadLine();
            line = line.Replace($" {word}", "");
            Console.WriteLine(line);
            Function();
        }
        static void Function()
        {
            Console.WriteLine("\nEnter any button.");
            Console.ReadKey();
        }
    }
}

