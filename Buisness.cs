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
        static string[] names = new string[100];
        static string[] passwords = new string[100];
        static string[] roles = new string[100];
        static int counter = 0;
        // Global arrays for adding polling station
        static string[] Ps_names = new string[200];
        static string[] Ps_codes = new string[200];
        static string[] areas = new string[200];
        static int Ps_counter = 0;
        static void Main(string[] args)
        {


            loadDatafromLoginFile();
            loadDatafromPSfile();
            /*loadFromVotersDetailsFile();
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

                    Console.WriteLine(" Invalid input ): ");
                }
                else
                {
                    if (option == "1")
                    {
                        Console.Clear();
                        printHeader();
                        //subMenu(" SignUp menu");
                        // SIGN Up
                        string name, pass, role;
                        bool isvalidName;

                        Console.WriteLine("Enter Name[informat i.e. Alyan]: ");
                        name = Console.ReadLine();
                        isvalidName = validUserNameData(name);
                        while (isvalidName == false)
                        {
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Invalid name ");
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Enter Name[informat i.e. Alyan]: ");
                            name = Console.ReadLine();
                            isvalidName = validUserNameData(name);
                        }
                        Console.WriteLine("<Your Password must be 4 character long>");
                        Console.WriteLine("Enter Password: ");
                        pass = Console.ReadLine();
                        int size = pass.Length;
                        while (size != 4)
                        {
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Invalid password ");
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Enter Password: ");
                            pass = Console.ReadLine();
                            size = pass.Length;
                        }
                        Console.WriteLine("Enter your Role[Admin,User]: ");
                        role = Console.ReadLine();
                        while (role != "Admin" && role != "User")
                        {
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine(" Invalid role entered");
                            /*                            SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            */
                            Console.WriteLine("Enter your Role[Admin,User]: ");
                            role = Console.ReadLine();
                        }
                        bool checker = isValidUserName(pass, name);
                        if (checker == true)
                        {
                            signUp(name, pass, role);
                            // storeToLoginFile(name, pass, role);
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine("<<< Remember that login name and password in order to sign in with that account >>>");
                            Console.WriteLine();
                            Console.WriteLine("SIGNED UP SUCCESSFULLY !!!");
                        }
                        else
                        {
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine("User and password is already found. Kindly sign up with new ID (: ");
                        }
                    }
                    else if (option == "2")
                    {
                        Console.Clear();
                        printHeader();
                        //subMenu(" SignIn menu");
                        // SIGN IN
                        string choice;
                        choice = signIn();
                        if (choice == "No")
                        {
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/
                            Console.WriteLine();
                            Console.WriteLine("NO User Found!!!! Sign up First...");
                        }
                        else if (choice == "Admin")
                        {

                            Console.Clear();
                            // Admin Menu
                            adminFunctions();
                        }
                        else
                        {
                            Console.Clear();
                            // User Menu
                            Console.WriteLine("userFunctions()");
                        }
                    }
                  /*  else if (option != "1" && option != "2" && option != "3")
                    {

                        Console.WriteLine(" Invalid input ): ");
                    }*/
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
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
        static void loadDatafromPSfile()
        {
            string path = "E:\\OOP\\Buisness Application\\PSfile.txt";
            StreamReader myFile = new StreamReader(path);
            string line;
            while ((line = myFile.ReadLine()) != null)
            {
                Ps_names[Ps_counter] = parseData(line, 1);
                Ps_codes[Ps_counter] = parseData(line, 2);
                areas[Ps_counter] = parseData(line, 3);
                Ps_counter++;
            }
            myFile.Close();
        }
        static void storeToPsFile(string Ps_name, string Ps_code, string area)
        {
            string path = "E:\\OOP\\Buisness Application\\PSfile.txt";
            StreamWriter file = new StreamWriter(path, true);

            file.Write(Ps_name + ",");
            file.Write(Ps_code + ",");
            file.WriteLine(area);
            file.Close();
        }
        static void updatedPsfile()
        {

            string path = "E:\\OOP\\Buisness Application\\PSfile.txt";
            /*FileStream file = File.Open(path, FileMode.Open, FileAccess.Write);*/
            StreamWriter file = new StreamWriter(path, true);
            for (int idx = 0; idx < Ps_counter; idx++)
            {
                file.Write(Encoding.ASCII.GetBytes(Ps_names[idx] + ","));
                file.Write(Ps_codes[idx] + ",");
                file.WriteLine(areas[idx]);
            }
            file.Close();
        }
        /*        static void updatedPsfile()
                {
                    string path = "E:\\OOP\\Buisness Application\\PSfile.txt";
                    FileStream file = File.Open(path, FileMode.Truncate, FileAccess.Write);

                    for (int idx = 0; idx < Ps_counter; idx++)
                    {
                        byte[] nameBytes = Encoding.ASCII.GetBytes(Ps_names[idx] + ",");
                        byte[] codeBytes = Encoding.ASCII.GetBytes(Ps_codes[idx] + ",");
                        byte[] areaBytes = Encoding.ASCII.GetBytes(areas[idx]);

                        file.Write(nameBytes, 0, nameBytes.Length);
                        file.Write(codeBytes, 0, codeBytes.Length);
                        file.Write(areaBytes, 0, areaBytes.Length);
                        file.Write(Environment.NewLine); // add a newline at the end of each record
                    }

                    file.Close();
                }*/
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
        /*void storeToLoginFile(string userName, string password, string role)
        {
            fstream file;
            file.open("loginFile.txt", ios::app);
            file << userName << ",";
            file << password << ",";
            file << role << endl;
            file.close();
        }*/
       
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
        static string loginMenu()
        {
            string option;
            Console.WriteLine("1. Sign up: ");
            Console.WriteLine("2. Sign in: ");
            Console.WriteLine("3. Exit: ");
            Console.WriteLine("Enter your option: ");
            option = Console.ReadLine();
            return option;
        }
        static bool validUserNameData(string name)
        {
            bool flag = false;
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
            bool flag = false;
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

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("||*************************************************************************************||");
            Console.WriteLine("||**************************ELECTION VOTING MANAGEMENT SYSTEM**************************||");
            Console.WriteLine("||*************************************************************************************||");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("<>        The Ignorance of one voter in a democracy impairs the security of all       <> ");
            Console.WriteLine("_________________________________________________________________________________________");

        }
        static void adminFunctions()
        {
            /*printAdminMenu();
            subMenu(" SignIn menu > Admin menu")*/
            ;
            string choice = "0";
            bool check;
            while (choice != "16")
            {
                Console.Clear();
                choice = AdminMenu();
                check = checkValidInputOption(choice);
                if (check == false)
                {
                    Console.WriteLine("Invalid Option");
                    Console.ReadKey();
                }
                else
                {
                    if (false) ;
                    else if (choice == "5")
                    {
                        // add polling stations
                        Console.Clear();
                        /*adminInterface();*/
                        //subMenu(" SignIn menu > Admin menu > Add polling station");
                        Console.WriteLine("You Choosed: " + choice);
                        string Ps_name, Ps_code, area;
                        string flag = "false";
                        bool validPsName, validArea;
                        Console.WriteLine("************* ADD POLLING STATIONS ************");

                        Console.WriteLine("Enter the polling station name : ");
                        Ps_name = Console.ReadLine();
                        validPsName = validUserNameData(Ps_name);
                        while (validPsName == false)
                        {

                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("Enter the polling station name : ");
                            Ps_name = Console.ReadLine();
                            validPsName = validUserNameData(Ps_name);
                        }
                        Console.WriteLine("Enter the code of the polling station: ");
                        Ps_code = Console.ReadLine();
                        Console.WriteLine("Enter the area of the polling station: ");
                        area = Console.ReadLine();
                        validArea = validUserNameData(area);
                        while (validArea == false)
                        {
                            //SetConsoleTextAttribute(h, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                            Console.WriteLine("Invalid Input");
                            //SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            Console.WriteLine("Enter the area of the polling station: ");
                            area = Console.ReadLine();
                            validArea = validUserNameData(area);
                        }
                        bool isValid = validPS(Ps_name, Ps_code);
                        if (isValid == true)
                        {
                            AddPs(Ps_name, Ps_code, area);
                            storeToPsFile(Ps_name, Ps_code, area);
                            /*SetConsoleTextAttribute(h, FOREGROUND_BLUE | FOREGROUND_INTENSITY);*/

                            Console.WriteLine("Polling station added Successfully !!! ");
                        }
                        else
                        {

                            Console.WriteLine("Polling Station ALREADY EXISTS!!! ");
                        }
                    }
                    else if (choice == "6")
                    {
                        // delete polling station
                        Console.Clear();
                        /*HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
                        adminInterface();
                        subMenu(" SignIn menu > Admin menu > Delete polling station");*/
                        Console.WriteLine("You Choosed: " + choice);
                        string delPs;
                        Console.WriteLine("Enter the name of the Polling station you want to delete: ");
                        delPs = Console.ReadLine();
                        int index = 0;
                        bool checkr = false;
                        for (int idx = 0; idx < Ps_counter; idx++)
                        {
                            if (Ps_names[idx] == delPs)
                            {
                                checkr = true;
                                index = idx;
                                break;
                            }
                        }
                        if (checkr == true)
                        {
                            del_Ps(index);
                            /*SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);*/
                            Console.WriteLine("Polling station " + delPs + " is deleted successfully. ");
                            updatedPsfile();
                        }
                        else
                        {
                            //SetConsoleTextAttribute(h, FOREGROUND_RED | FOREGROUND_INTENSITY);
                            Console.WriteLine("Polling station not found.");
                        }
                    }
                    else if (choice == "7")
                    {
                        // update polling stations
                        //subMenu(" SignIn menu > Admin menu > Update polling station");
                        Console.Clear();
                        //adminInterface();
                        Console.WriteLine("You Choosed: " + choice);
                        update_Ps();
                    }
                    else if (choice == "8")
                    {
                        // search polling stations
                        Console.Clear();
                        /*adminInterface();*/
                        //subMenu(" SignIn menu > Admin menu > Search polling station");
                        Console.WriteLine("You Choosed: " + choice);
                            Console.WriteLine();
                        search_Ps();
                    }
                    else if (choice == "9")
                    {
                        // View all polling stations
                         Console.Clear();
                        // adminInterface();
                         //subMenu(" SignIn menu > Admin menu > View all polling station");
                         Console.WriteLine( "You Choosed: " + choice );
                         Console.WriteLine();
                         view_Ps()
                        ;
                    }

/*                    else if (choice != "16")
                    {
                        Console.WriteLine("Invalid Input ");
                    }*/
                    Thread.Sleep(100);
                    Console.Read();
                }
            }
        }
        static string AdminMenu()
        {
            string option;
            printAdminMenu();
            option = Console.ReadLine();
            return option;
        }
        static void printAdminMenu()
        {

            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("&&                     ADMIN'S INTERFACE                      &&");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
           /* Console.WriteLine("1.  Add elective parties: ");
            Console.WriteLine("2.  Delete elective parties: ");
            Console.WriteLine("3.  Search for an elective party: ");
            Console.WriteLine("4.  View all the parties: ");*/
            Console.WriteLine("5.  Add polling stations: ");
            Console.WriteLine("6.  Delete polling stations: ");
            Console.WriteLine("7.  Update polling stations: ");
            Console.WriteLine("8.  Search for a polling station: ");
            Console.WriteLine("9.  View all polling stations: ");
            /*Console.WriteLine("10. Update elective party:  ");
            Console.WriteLine("11. View all details of the voters: ");
            Console.WriteLine("12. Search for the response of the voter: ");
            Console.WriteLine("13. Declare the election results: ");
            Console.WriteLine("14. View the feedback of the voters: ");
            Console.WriteLine("15. View all the Accounts details: ");*/
            Console.WriteLine("16. Exit ");
            Console.WriteLine();
            Console.WriteLine("Enter your response: ");
        }
        static void AddPs(string Ps_name, string Ps_code, string area)
        {
            // function of adding polling station

            Ps_names[Ps_counter] = Ps_name;
            Ps_codes[Ps_counter] = Ps_code;
            areas[Ps_counter] = area;
            Ps_counter++;
        }
        static bool validPS(string Ps_name, string Ps_code)
        {
            bool flag = true;
            for (int index = 0; index < Ps_counter; index++)
            {
                if (Ps_name == Ps_names[index] && Ps_code == Ps_codes[index])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static void view_Ps()
        {

            Console.WriteLine("\t PS_Names   " + " \t\t\t " + " PS_codes  " + " \t\t" + "   Areas ");
            Console.WriteLine();
            for (int i = 0; i < Ps_counter; i++)
            {
                if (Ps_names[i] == "")
                {
                    continue;
                }
                Console.WriteLine( Ps_names[i].PadRight(25) + Ps_codes[i].PadLeft(25) + areas[i].PadLeft(25) );
                Console.WriteLine();
            }
        }
        static void del_Ps(int index)
        {
            for (int idx = index; idx < Ps_counter; idx++)
            {
                Ps_names[idx] = Ps_names[idx + 1];
                Ps_codes[idx] = Ps_codes[idx + 1];
                areas[idx] = areas[idx + 1];
            }
            Ps_counter--;
        }
        static void update_Ps()
        {
            string update_Ps, updated_name, updated_code, updated_area;
            bool flag = false;
            int place = 0;

            Console.WriteLine(" Enter the code of the polling station you want to update: ");
            update_Ps = Console.ReadLine();
            for (int i = 0; i < Ps_counter; i++)
            {
                if (update_Ps == Ps_names[i])
                {
                    flag = true;
                    place = i;
                    break;
                }
            }
            if (flag == true)
            {
            
                Console.WriteLine(" Enter the updated name of polling station: ");
                updated_name = Console.ReadLine();
                Console.WriteLine(" Enter the updated code of the polling station: ");
                updated_code = Console.ReadLine();
                Console.WriteLine(" Enter the updated area of the polling station: ");
                updated_area = Console.ReadLine();
                Ps_names[place] = updated_name;
                Ps_codes[place] = updated_code;
                areas[place] = updated_area;
                updatedPsfile();
                Console.WriteLine("Updated Successfully !!!");
            }
            else
            {
                Console.WriteLine("Polling station not found ): ");
            }
        }
        static void search_Ps()
        {
            string srch_Ps;

            Console.WriteLine("Enter the name of the Polling station you want to search: ");
            srch_Ps = Console.ReadLine();
            bool flag = false;
            int place = 0;
            for (int index = 0; index < Ps_counter; index++)
            {
                if (srch_Ps == Ps_names[index])
                {
                    flag = true;
                    place = index;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine(" You searched for the polling station " + srch_Ps);
                Console.WriteLine(" The code of this polling station is " + Ps_codes[place]);
                Console.WriteLine(" The area of this polling station is  " + areas[place]);
            }
            else
            {
                Console.WriteLine("The polling station not found...");
            }
        }

    }
}

