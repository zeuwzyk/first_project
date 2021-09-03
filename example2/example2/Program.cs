using System;
using System.Collections.Generic;
using System.IO;

namespace example2
{
    class Program
    {
        public static string text = "";
        static void Main(string[] args)
        {       
            string selection = "";
            while (selection != "0")
            {
                Console.Clear();
                Console.Write("Enter the path to *.txt file: \n");//убрать \n
                string path = "D:\\Projects\\example2\\File.txt"; //Console.ReadLine(path);
                text = File.ReadAllText(path);
                Console.WriteLine(text);

                Console.Write("\nEnter the word from text: ");
                string word = Console.ReadLine();

                text = text.ToLower();
                word = word.ToLower();

                Console.Write("\nMenu:\nCommands:\n f - find word\n r - replace word\n d - delete word\n 0 - exit" +
                    "\nEnter the command: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "f":
                        FindWord(word);
                        break;
                    case "r":
                        ReplaceWord(word);
                        break;
                    case "d":
                        DeleteWord(word);
                        break;
                    case "0":
                        Console.WriteLine("Exit.");
                        Function();
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Error. Entred not correct symbol");
                        Function();
                        break;
                }
            } 
        }
        static void FindWord(string word)
        {
            Console.WriteLine("\nf");
            string[] words = text.Split(' ', ',', '.');
            int temp = 0;

            for (int i = 0; i < words.Length; i++)
                if (words[i] == word && words[i].Length == word.Length)
                    temp++;

            if (temp >= 1)
            {
                Console.WriteLine("word find");
                Console.WriteLine($"the count of repetitions of the word '{word}' in the text: {temp}");
            }
            else
                Console.WriteLine("not find word");


            int index1 = text.IndexOf(word);
            Console.WriteLine($"First value Index of {word} is " + index1);
            Function();
        }
        static void ReplaceWord(string word)
        {
            Console.WriteLine("\nr");
            Console.Write("Enter the word for replace: ");
            string replaceWord = Console.ReadLine();

            if (word == null || replaceWord == null || word == "" || replaceWord == "")
            {
                Console.WriteLine("Please write correct word.");
            }
            else
                CheckFunction(word, replaceWord);
            Function();
        }
        static void DeleteWord(string word)
        {
            Console.WriteLine("\nd");

            if (word == null || word == "")
            {
                Console.WriteLine("Please write correct word.");
            }
            else
                CheckFunction(word, "");
            Function();
        }
        static void Function()
        {
            Console.WriteLine("\nEnter any button.");
            Console.ReadKey();
        }
        static void CheckFunction(string FirstWord, string SecondWord)
        {
            string[] words = text.Split(' ', ',', '.');
            int temp = 0;
            do
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == FirstWord && words[i].Length == FirstWord.Length)
                        text = text.Replace(FirstWord, SecondWord);
                    else if (words.Length - 1 == i)
                    {
                        Console.WriteLine("Entered not correct word.");
                        break;
                    }
                }
                Console.WriteLine(text);
                temp++;
            } while (temp < 1);

        }
    }
}

