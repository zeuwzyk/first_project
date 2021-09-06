using System;

namespace example3
{
    class Program//sotrudniki!
    {
        enum Cars
        {
            BMW,
            Volkswagen,
            Skoda
        }
        static void Main(string[] args)
        {
            string selection = "";
            while (selection !="0")
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
        public static void EnterDataFunc()//cycle
        {
            int temp = 0;
            Console.WriteLine("\nEnter data:\n");
            do
            {
                Console.Write("Enter name: ");//check only string
                string name = Console.ReadLine();
                if (name == "")
                    Console.WriteLine("Not correct.");
                for (int i = 0; i < name.Length; i++)
                    if (char.IsLetter(name[i]))
                        continue;//temp++;
                    else
                    {
                        Console.WriteLine("Error.");//сделать обрыв
                        temp--;
                    }
                temp++;
                /////////////////////////////////////////////////////////////////////
                int age;
                Console.Write("Enter age: ");//check only int 18-99
                string ageString = Console.ReadLine();
                bool result = int.TryParse(ageString, out age);
                if (result == true && age <= 99 && age >= 18)
                {
                    temp++;
                }
                else
                    Console.WriteLine("Error.");

                /////////////////////////////////////////////////////////////////////
                Console.Write("Enter car (BMW, Volkswagen, Skoda): ");//enum
                string theCar = Console.ReadLine();
                string carCar = "";
                Cars car;
                if (Enum.TryParse(theCar, out car))
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
                Function();
            } while (temp != 3);
        }
        public static void ViewDataFunc()
        {

        }
        public static void FindDataFunc()
        {

        }
        public static void DeleteDataFunc()
        {

        }
        static void Function()
        {
            Console.WriteLine("\nEnter any button.\n");
            Console.ReadKey();
        }
    }
}
