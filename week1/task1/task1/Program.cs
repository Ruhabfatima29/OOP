using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            task11(); 
        }
        static void task1()
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("Hello World");
            Console.Read();
        }
        static void task2()
            {
            float length, area;
            Console.Write("Enter length of the square: ");
            length = float.Parse(Console.ReadLine());
            area = length * length;
            Console.Write("Area of square is: " + area);
            Console.Read();

        } 
        static void task3()
        {
            int marks;
            Console.Write("Enter marks: ");
            marks = int.Parse(Console.ReadLine());
            if(marks>50)
            {
                Console.WriteLine("You are passed");

            }
            else
            {
                Console.WriteLine("You are Fail");

            }
            Console.ReadKey();
        }
        static void task4()
        {
            for(int i=0; i<5; i++)
            {
                Console.WriteLine("Welcome Jack");
            }
            Console.Read();
        }
        static void task5()
        {
            int num = 0;
            int sum = 0;
            do
            {
                sum = sum + num;
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
            }
            while (num != -1);
            Console.Write("The sum of numbers is " + sum);
            Console.Read();
        }
        static void task6()
        {
            int[] numbers = new int[5];
            for(int i=0; i<3; i++)
            {
                Console.Write("Enter number: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int largest = -1;
            for(int i=0; i<3; i++)
            {
                if(numbers[i]>largest)
                {
                    largest = numbers[i];
                }
            }
            Console.Write("The largest number is " + largest);
            Console.Read();
        }
        static void task7()
        {
            int age;
            float price, result;
            int toyPrice;
            int moneyGift, toyGift;
            int odd = 0, even = 0, sum = 0, n1 = 0;
            Console.Write("Enter Lilly's Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter IPHONE price: ");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter the unit price of toys: ");
            toyPrice = int.Parse(Console.ReadLine());

            for (int count = 1; count <= age; count++)
            {
                if (count % 2 == 0)
                {
                    n1 = n1 + 1;
                    even = even + 10;
                    sum += even;
                }
                else
                {
                    odd = odd + 1;
                }
            }
            moneyGift = sum - n1;
            toyGift = odd * toyPrice;
            result = moneyGift + toyGift;


            if (result >= price)
            {
                Console.WriteLine("YES!!");
                Console.WriteLine(result - price);
            }
            else
            {
                Console.WriteLine("NO!");
                Console.WriteLine(price - result);
            }
            Console.Read();
        }
        static void task8()
        {
            int num1, num2, sum;
            Console.Write("Enter number1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number2: ");
            num2 = int.Parse(Console.ReadLine());
            sum = addition(num1, num2);
            Console.Write("The sum of the numbers is " + sum);
            Console.Read();
        }
        static int addition(int number1, int number2)
        {
            int sum;
            sum = number1 + number2;
            return sum;
        }
        static void task9()
        {
            string path = "E:\\OOP\\week1\\text.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string line;
                while((line= myFile.ReadLine()) != null)
                    {
                    Console.WriteLine(line);
                }
                myFile.Close();
            }
            else 
            {
                Console.WriteLine(" The File does not exists");
            }
            Console.Read();
        }
        static void task10()
        {
            string path = "E:\\OOP\\week1\\text.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine("I am happy");
            myFile.Flush();
            Console.Read();
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. Sign in: ");
            Console.WriteLine("2. Sign up: ");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for(int i=0; i<record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData(string path, string[] names,string[] passwords)
        {
            int x = 0;
            if(File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    passwords[x] = parseData(record, 2);
                    x++;
                    if(x>=5)
                    {
                        break;
                    }
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Not Exists.");
            }
        }
        static void SignIn(string name, string password, string[] names, string[] passwords)
        {
            bool flag = false;
            for(int i=0; i<5; i++)
            {
                if(name == names[i] && password == passwords[i])
                {
                    Console.WriteLine("Valid Users");
                    flag = true;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.Read();

        }
        static void signUp(string path, string name, string password)
        {
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine(name + ',' + password);
            myFile.Flush();
            myFile.Close();
        }

        static void task11()
        {
            string path = "E:\\OOP\\week1\\signUp.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            int option;
            do
            {
                readData(path, names, passwords);
                Console.Clear();
                option = menu();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    SignIn(name, password, names, passwords);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    signUp(path, name, password);
                }
            }
            while (option < 3);
            Console.Read();
            }
        static string parseDataforCustomers(string record, int field)
        {
            int spaceCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    spaceCount++;
                }
                else if (spaceCount == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void task12()
        {

        }
    }
}
