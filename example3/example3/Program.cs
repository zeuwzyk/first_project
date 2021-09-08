using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
//using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace example3
{    class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Car { get; set; }
    }
    class Program//sotrudniki!
    {
        public static int check = 0;
        enum Cars
        {
            BMW,
            Volkswagen,
            Skoda
        }
       
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            string selection = "";
            while (selection != "0")
            {
                Console.Write("\nMenu:\nCommands:\n e - enter data\n v - view data\n f - find data\n d - delete data\n 0 - exit\n");
                Console.Write("\nEnter the command: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "e":
                        EnterDataFunc();
                        break;
                    case "v":
                        ViewDataFunc();
                        break;
                    case "f":
                        FindDataFunc();
                        break;
                    case "d":
                        DeleteDataFunc();
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
        public static void EnterDataFunc()
        {
            int temp = 0;
            string name;
            int age;
            string carCar = "";
            Console.WriteLine("\nEnter data:\n");
            do
            {
                temp = 0;
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                if (name == "")
                    Console.WriteLine("Not correct.");
                for (int i = 0; i < name.Length; i++)
                    if (char.IsLetter(name[i]))
                        continue;
                    else
                    {
                        Console.WriteLine("Error.");
                        temp--;
                        continue;
                    }
                temp++;

                Console.Write("Enter age: ");//check only int 18-99
                string ageString = Console.ReadLine();
                bool result = int.TryParse(ageString, out age);
                if (result == true && age <= 99 && age >= 18)
                    temp++;
                else
                    Console.WriteLine("Error.");

                Console.Write("Enter car (BMW, Volkswagen, Skoda): ");//enum
                string theCar = Console.ReadLine();
                Cars car;
                if (Enum.TryParse(theCar, out car))// шрифты
                {
                    switch (car)
                    {
                        case Cars.BMW:
                            Console.WriteLine("Your car is BMW.");
                            carCar = theCar;
                            break;
                        case Cars.Volkswagen:
                            Console.WriteLine("Your car is Volkswagen.");
                            carCar = theCar;
                            break;
                        case Cars.Skoda:
                            Console.WriteLine("Your car is Skoda.");
                            carCar = theCar;
                            break;
                    }
                    temp++;
                }
                else
                    Console.WriteLine("Error.");

                Console.Write($"\nname: {name}; age: {age}; car: {carCar}");
                //запись в файл                
            } while (temp != 3);

            if (temp == 3)
                pathFuncAsync(name, age, carCar);
        }
        public static async Task ViewDataFunc()
        {
            string fileName = "user.json";
            string jsonString = File.ReadAllText(fileName);
            var restoredData = JsonSerializer.Deserialize<List<Data>>(jsonString);
            foreach (var data in restoredData)
            {
                Console.WriteLine(JsonSerializer.Serialize(data));
            }
        }
        public static void FindDataFunc()
        {
            Console.WriteLine("Find employee (enter name or age or car (BMW, Volkswagen, Skoda)):");
            string information = Console.ReadLine();
            int age = 0;

            CheckFunc(information);
            if (check != 0)
                age = int.Parse(information);

            string fileName = "user.json";
            string jsonString = File.ReadAllText(fileName);
            var restoredData = JsonSerializer.Deserialize<List<Data>>(jsonString);

            string name = "", car = "";
            int ages = 0;
            foreach (var data in restoredData)
            {
                ages = int.Parse(data.Age.ToString());             
                name = data.Name.ToString();
                car = data.Car.ToString();
                if (information == name)
                {
                    Console.WriteLine(JsonSerializer.Serialize(data));
                    break;
                }
                else if (information == car)
                {
                    Console.WriteLine(JsonSerializer.Serialize(data));
                    break;
                }
                else if (age == ages)
                {
                    Console.WriteLine(JsonSerializer.Serialize(data));
                    break;
                }
                //else// сделать проверку на отсутствие имен, машин, возрастов
                //    Console.WriteLine("error.");
            }
        }
        public static void DeleteDataFunc()
        {
            //удаление по имени
        }
        public static void Function()
        {
            Console.WriteLine("\nEnter any button.\n");
            Console.ReadKey();
        }
        public static async Task pathFuncAsync(string name, int age, string car)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            };
            int id = 1;//сделать счетчик//последний ид вытащить

            string fileName = "user.json";
            string jsonString = File.ReadAllText(fileName);
            var restoredData = JsonSerializer.Deserialize<List<Data>>(jsonString);
            foreach (var data in restoredData)
            {
                //Console.WriteLine(JsonSerializer.Serialize(data, options));
                id = int.Parse(data.Id.ToString());
            }
            id += 1;
            
            restoredData.Add(new Data()
            {
                Id = id,
                Name = name,
                Age = age,
                Car = car
            }
            );

            using (StreamWriter file = File.CreateText(fileName))
            {
                string data = JsonSerializer.Serialize<List<Data>>(restoredData, options);
                file.Write(data);
            }
        }
    public static void CheckFunc(string information)
        {
            if (information == "")
                Console.WriteLine("Not correct.");
            for (int i = 0; i < information.Length; i++)
                if (char.IsLetter(information[i]))
                {
                    Console.WriteLine("symbol");
                   // continue;
                }
                else if ((char)(information[i]) < '9' || (char)(information[i]) > '0')
                {
                    Console.WriteLine("number");
                    check = 1;
                    //continue;
                }
                else
                {
                    Console.WriteLine("Error.");
                    //continue;
                }
        }
    }
}
