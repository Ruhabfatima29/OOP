using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Buisness_Application
   
{
    
    class Program
    {
      static  string[] names = new string[100];
      static  string[] passwords = new string[100];
      static  string[] roles = new string[100];
      static  int counter = 0;
        static void Main(string[] args)
        {
            

            loadDatafromLoginFile();

            /* loadDatafromPSfile();
             loadFromVotersDetailsFile();
             loadDatafromElectedPartiesfile(*//*);*/
            string option = "0";
            bool check;
            Console.Clear();
           /* printHeader();*/
           
            while (option != "3")
            {
                Console.Clear();
                /*printHeader();
                subMenu("");*/
                Console.WriteLine("Select an option from the given menu ");
                option = loginMenu();
                check = checkValidInputOption(option);
                if (check == false)
                {
                
                    Console.WriteLine( " Invalid input ): ");
                }
                else
                {
                    if (option == "1")
                    {
                        Console.Clear();
                       /* printHeader();
                        subMenu(" SignUp menu");*/
                        // SIGN Up
                        string name, pass, role;
                        bool isvalidName;
                        
                        Console.WriteLine ( "Enter Name[informat i.e. Alyan]: ");
                        name = Console.ReadLine();
                        isvalidName = validUserNameData(name);
                        while (isvalidName == false)
                        {
/*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
*/                            Console.WriteLine( "Invalid name ");
/*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
*/                            Console.WriteLine ("Enter Name[informat i.e. Alyan]: ");
                             name = Console.ReadLine();
                            isvalidName = validUserNameData(name);
                        }
                        Console.WriteLine( "<Your Password must be 4 character long>");
                        Console.WriteLine("Enter Password: ");
                        pass = Console.ReadLine();
                        int size = pass.Length;
                        while (size != 4)
                        {
/*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
*/                            Console.WriteLine( "Invalid password " );
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Enter Password: ");
                            pass = Console.ReadLine();
                            size = pass.Length;
                        }
                        Console.WriteLine("Enter your Role[Admin,User]: ");
                        role= Console.ReadLine();
                        while (role != "Admin" && role != "User")
                        {
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine(" Invalid role entered" );
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Enter your Role[Admin,User]: ");
                            role = Console.ReadLine();
                        }
                        bool checker = isValidUserName(pass, name);
                        if (checker == true)
                        {
                            signUp(name, pass, role);
                            /* storeToLoginFile(name, pass, role);*/
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine( "<<< Remember that login name and password in order to sign in with that account >>>") ;
                            Console.WriteLine();
                            Console.WriteLine("SIGNED UP SUCCESSFULLY !!!" );
                        }
                        else
                        {
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine("User and password is already found. Kindly sign up with new ID (: " );
                        }
                    }
                    else if (option == "2")
                    {
                        Console.Clear();
                        /*printHeader();*/
                        //subMenu(" SignIn menu");
                        // SIGN IN
                        string choice;
                        choice = signIn();
                        if (choice == "No")
                        {
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine("NO User Found!!!! Sign up First..." );
                        }
                        else if (choice == "Admin")
                        {

                            Console.Clear();
                            // Admin Menu
                            /*adminFunctions*//*()*/;
                        }
                        else
                        {
                            Console.Clear();
                            // User Menu
/*                            userFunctions();
*/                        }
                    }
                    else if (option != "1" && option != "2" && option != "3")
                    {

                        Console.WriteLine( " Invalid input ): ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue..." );
                    Thread.Sleep(100);
                    Console.ReadLine();

                }
            }
        }


        static void loadDatafromLoginFile()
        {
            string path = "E:\\OOP\\Buisness Application\\loginFile.txt";
            StreamReader myFile = new StreamReader(path);
            string line;

            while ((line = myFile.ReadLine()) != null)
            {
                names[counter] = parseData(line, 1);
                passwords[counter] = parseData(line, 2);
                roles[counter] = parseData(line, 3);
                counter++;
            }
            myFile.Close();
        }
        static string parseData(string data, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 1; x < data.Length - 1; x++)
            {
                if (data[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item = item + data[x];
                }
            }
           
            return item;
        }
        static void readData(string path, string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    passwords[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
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
        
        static string signIn()
        {
            string name, password;

            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();

            for (int i = 0; i < counter; i++)
            {
                if (name == names[i] && password == passwords[i])
                    return roles[i];
            }
            return "No";
        }
        static void signUp(string path, string name, string password)
        {
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine(name + ',' + password);
            myFile.Flush();
            myFile.Close();
        }
        static   string loginMenu()
        {
                    string option;
                    Console.WriteLine( "1. Sign up: " );
                    Console.WriteLine("2. Sign in: " );
                    Console.WriteLine("3. Exit: " );
                    Console.WriteLine("Enter your option: ");
                   option = Console.ReadLine();
                    return option;
        }
        static bool validUserNameData(string name)
        {
            bool flag= false;
            int size = name.Length;
            for (int idx = 0; idx < size; idx++)
            {
                if ((name[idx] >= 65 && name[idx] <= 90) || (name[idx] >= 97 && name[idx] <= 122) || name[idx] == 32)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static bool isValidUserName(string pass, string name)
        {
            bool check = true;

            for (int i = 0; i < counter; i++)
            {
                if (name == names[i] && pass == passwords[i])
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        static bool checkValidInputOption(string option)
        {
            bool flag=false;
            int size = option.Length;
            for (int idx = 0; idx < size; idx++)
            {
                if (option[idx] >= 48 && option[idx] <= 57)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static void printHeader()
        {
            
            Console.WriteLine( ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );
            Console.WriteLine("||*************************************************************************************||" );
            Console.WriteLine("||**************************ELECTION VOTING MANAGEMENT SYSTEM**************************||" );
            Console.WriteLine("||*************************************************************************************||" );
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );
            Console.WriteLine("<>        The Ignorance of one voter in a democracy impairs the security of all       <> " );
            Console.WriteLine("_________________________________________________________________________________________" );
         
        }
    }
}
