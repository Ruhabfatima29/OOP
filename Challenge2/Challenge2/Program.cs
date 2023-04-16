using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge2.BL;

namespace Challenge2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Credential[] users = new Credential[10];
            int count = 0;
            string path = "E:\\OOP\\Challenge2\\login.txt";
            string option;
            readData(path, ref count, users);
            do
            {
                //Console.Clear();
                option = menu();
                if (option == "1")
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    SignIn(name, password,users,ref count);
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    signUp(path, name, password);
                    count++;
                }
            }
            while (option != "3");
            Console.ReadKey();
        }
        

        static string menu()
        {
            Console.WriteLine("1. Sign in: ");
            Console.WriteLine("2. Sign up: ");
            Console.WriteLine("Enter Option");
            string choice = Console.ReadLine();
            return choice;
        }
        static string parseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
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
        static void readData(string path, ref int count, Credential[] users)
        {
            
           // users = new Credential[10];
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    string record;
                    record = myFile.ReadLine();
                    Credential s1 = new Credential();
                    s1.name = parseData(record, 1);
                    s1.password = parseData(record, 2);
                    Console.WriteLine(s1.name);
                    Console.WriteLine(s1.password);
                    users[count++] = s1;
                    
                   
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Not Exists.");
            }
        }
        static void SignIn(string name, string password, Credential[] users, ref int count)
        {
            bool flag = false;
            for (int i = 0; i < count; i++)
            {
                if (name == users[i].name && password == users[i].password)
                {
                    Console.WriteLine("Valid Users");
                    flag = true;
                }
            }
            if (flag == false)
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
  
    }
}
