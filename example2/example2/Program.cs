using System;
using System.IO;

namespace example2
{
    class Program
    {
        public static string text = "";
        static void Main()
        {
            string selection = "";
            while (selection != "0")
            {
                Console.Clear();

                Console.Write("Open file? Enter 'y' or 'n' or '0' for exit: ");
                string change = Console.ReadLine();
                if (change == "y")
                {
                    FilePath();
                    if (text == "" || text == null)//D:\Projects\example2\text.txt //D:\Projects\example2\File.txt";
                        continue;
                }
                else if (change == "n")
                {
                    Console.WriteLine(text);
                    if (text == "" || text == null)
                        continue;
                }
                else if (change == "0")
                    break;
                else
                {
                    Console.WriteLine("Error. Not correct symbol was entered.");
                    Function();
                    continue;
                }

                Console.Write("\nMenu:\nCommands:\n f - find word\n r - replace word\n d - delete word\n 0 - exit\n");
                Console.Write("\nEnter the word from text for command: ");
                string word = Console.ReadLine();

                text = text.ToLower();
                word = word.ToLower();

                Console.Write("\nEnter the command: ");
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
                        Console.WriteLine("Error. Not correct symbol was entered.");
                        Function();
                        break;
                }
            }
        }
        static void FindWord(string word)
        {
            Console.WriteLine("\nFind word.");
            string[] words = text.Split(' ', ',', '.');
            int temp = 0;
            int index1 = text.IndexOf(word);

            for (int i = 0; i < words.Length; i++)
                if (words[i] == word && words[i].Length == word.Length)
                    temp++;

            if (temp >= 1)
            {
                Console.WriteLine("Word is find");
                Console.WriteLine($"The count of repetitions of the word '{word}' in the text: {temp}");
                Console.WriteLine($"First value Index of {word} is " + index1);
            }
            else
                Console.WriteLine("Word is not find.");

            Function();
        }
        static void ReplaceWord(string word)
        {
            Console.WriteLine("\nReplace word.");
            Console.Write("Enter the word for replace: ");
            string replaceWord = Console.ReadLine();

            if (word == null || replaceWord == null || word == "" || replaceWord == "")
                Console.WriteLine("Please write correct word.");
            else
                CheckFunction(word, replaceWord);
            Function();
        }
        static void DeleteWord(string word)
        {
            Console.WriteLine("\nDelete word.");

            if (word == null || word == "")
                Console.WriteLine("Please, write correct word.");
            else
                CheckFunction(word, "");
            Function();
        }
        static void Function()
        {
            Console.WriteLine("\nEnter any button.");
            Console.ReadKey();
        }
        static void CheckFunction(string firstWord, string secondWord)
        {
            string[] words = text.Split(' ', ',', '.');
            int temp = 0;
            do
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == firstWord && words[i].Length == firstWord.Length)
                    {
                        text = text.Replace(firstWord, secondWord);
                        Console.WriteLine(text);
                    }
                    else if (words.Length - 1 == i)
                    {
                        Console.WriteLine("Not correct start word was entered.");
                        break;
                    }
                }
                temp++;
            } while (temp < 1);
        }
        static void FilePath()
        {
            Console.Write("Enter the path to *.txt file (only english text): ");
            string path = Console.ReadLine(); 

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    text = reader.ReadToEnd();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.WriteLine(text);
        }
    }
}
