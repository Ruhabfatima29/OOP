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
        // For Elected parties
        static string[] parties = new string[20];
        static string[] symbols = new string[20];
        static string[] founders = new string[20];
        static int[] parties_counter = new int[20];
        static int adminCount = 0;
        static void Main(string[] args)
        {


            loadDatafromLoginFile();
            loadDatafromElectedPartiesfile();
            string option = "0";
            bool check;
            Console.Clear();
            printHeader();
            while (option != "3")
            {
                Console.Clear();
                printHeader();
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
                        // SIGN Up
                        string name, pass, role;
                        bool isvalidName;

                        Console.WriteLine("Enter Name[informat i.e. Alyan]: ");
                        name = Console.ReadLine();
                        isvalidName = validUserNameData(name);
                        while (isvalidName == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name ");
                            Console.ForegroundColor = ConsoleColor.Green;
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid password ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter Password: ");
                            pass = Console.ReadLine();
                            size = pass.Length;
                        }
                        Console.WriteLine("Enter your Role[Admin,User]: ");
                        role = Console.ReadLine();
                        while (role != "Admin" && role != "User")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Invalid role entered");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter your Role[Admin,User]: ");
                            role = Console.ReadLine();
                        }
                        bool checker = isValidUserName(pass, name);
                        if (checker == true)
                        {
                            signUp(name, pass, role);
                            /* storeToLoginFile(name, pass, role);*/
                            Console.ForegroundColor = ConsoleColor.Blue;
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
                            /*                            userFunctions();
                            */
                        }
                    }
                    else if (option != "1" && option != "2" && option != "3")
                    {

                        Console.WriteLine(" Invalid input ): ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Thread.Sleep(100);
                    Console.ReadKey();

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
            for (int x = 0; x < data.Length; x++)
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

            string choice = "0";
            while (choice != "6")
            {
                printAdminMenu();
                Console.Clear();
                choice = AdminMenu();
                if (choice == "1")
                {
                    // Adding a party
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    addParty();
                }
                else if (choice == "2")
                {

                    // Deleting a party
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    delParty();
                }
                else if (choice == "3")
                {
                    // Search for an party
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    searchParty();
                }
                else if (choice == "4")
                {
                    // View all the Parties
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    viewParties();
                }
                else if (choice == "5")
                {
                    // update elective party

                    Console.Clear();
                    // adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    update_Party();
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("&&                     ADMIN'S INTERFACE                      &&");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1.  Add elective parties: ");
            Console.WriteLine("2.  Delete elective parties: ");
            Console.WriteLine("3.  Search for an elective party: ");
            Console.WriteLine("4.  View all the parties: ");
            Console.WriteLine("5.  Update elective party: ");
            Console.WriteLine("  Enter your response:  ");
            Console.WriteLine();
        }
        static void adminInterface()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("&&                                 ADMIN'S INTERFACE                                        &&");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("&&  Democracy is not just a right to vote but it is a right to select to live with Dignity &&");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
        }
        static void addParty()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string partyName, partySymbol, founder;
            string flag = "false";
            bool isvalidSymbol, isValidFounder, checkFounderData, checkPartyData;
            Console.WriteLine("########### ADD ELECTIVE Parties ##########");
            Console.WriteLine(" Enter the name of The Elected Party: ");
            partyName = Console.ReadLine();
            // checks validity of Elected party's data
            checkPartyData = validUserNameData(partyName);
            while (checkPartyData == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid data entered...");
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine(" Enter the name of The Elected Party: ");
                partyName = Console.ReadLine();
                checkPartyData = validUserNameData(partyName);
            }
            Console.WriteLine(" Enter the Symbol of your Elected Party: ");
            partySymbol = Console.ReadLine();
            // checks the validity of symbol's data
            isvalidSymbol = validSymbol(partySymbol);
            while (isvalidSymbol == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Symbol. This symbol is already allocated to another party..");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Enter the Symbol of your Elected Party: ");
                partySymbol = Console.ReadLine();
                isvalidSymbol = validSymbol(partySymbol);
            }
            Console.WriteLine(" Enter the name of the founder of Elected Party:  ");
            founder = Console.ReadLine();
            checkFounderData = validUserNameData(founder);
            // checks the validity of founder's data
            isValidFounder = validFounder(founder);
            while (isValidFounder == false || checkFounderData == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (isValidFounder == false)
                {
                    Console.WriteLine("Invalid Founder. For two different parties, there couldn't be a same founder." );
                }
                else
                {
                    Console.WriteLine("Invalid data entered. You can only enter alphabets and spaces.");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Enter the name of the founder of Elected Party:  ");
                founder = Console.ReadLine();
                isValidFounder = validFounder(founder);
                checkFounderData = validUserNameData(founder);
            }
            for (int i = 0; i < adminCount; i++)
            {
                if (partyName == parties[i] || founder == founders[i])
                {
                    flag = "true";
                    break;
                }
            }
            if (flag == "true")
            {
                Console.WriteLine("PARTY ALREADY EXISTS!!! " );
            }
            else
            {
                int party_votes;
                parties[adminCount] = partyName;
                founders[adminCount] = founder;
                symbols[adminCount] = partySymbol;
                party_votes = parties_counter[adminCount];
                adminCount++;
                Console.WriteLine();
                Console.WriteLine("<<<Party added Successfully>>>" );
                storeToElectedPartiesFile(partyName, partySymbol, founder, party_votes);
            }
            Console.ReadKey();
        }
        static bool validSymbol(string symbol)
        {
            bool flag = true;
            for (int i = 0; i < adminCount; i++)
            {
                if (symbol == symbols[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static bool validFounder(string founder)
        {
            bool check = true;
            for (int index = 0; index < adminCount; index++)
            {
                if (founder == founders[index])
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        static void storeToElectedPartiesFile(string partyName, string symbol, string founder, int votes_counter)
        {
            string path = "E:\\OOP\\Business app ver1\\ElectedParties.txt";
            StreamWriter file = new StreamWriter(path,true);
            file.WriteLine(partyName + "," + symbol + "," + founder + "," + votes_counter);
            file.Flush();
            file.Close();
        }
        static void loadDatafromElectedPartiesfile()
        {
            string path = "E:\\OOP\\Business app ver1\\ElectedParties.txt";
            using (StreamReader file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 4)
                    {
                        parties[adminCount] = data[0];
                        symbols[adminCount] = data[1];
                        founders[adminCount] = data[2];
                        if (int.TryParse(data[3], out int counter))
                        {
                            parties_counter[adminCount] = counter;
                            adminCount++;
                        }
                        else
                        {
                            Console.WriteLine("Error: could not parse counter on line {0}", adminCount + 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: invalid data on line {0}", adminCount + 1);
                    }
                }
            }
        }

        static void delParty()
        {
            string del_party;
            int place = 0 ;
            bool flag = false;
            Console.WriteLine("Enter the name of the party you want to delete: ");
            del_party = Console.ReadLine();
            for (int index = 0; index < adminCount; index++)
            {
                if (del_party == parties[index])
                {
                    flag = true;
                    place = index;
                    break;
                }
            }
            if (flag == true)
            {
                for (int index = place; index < adminCount; index++)
                {
                    parties[index] = parties[index + 1];
                    founders[index] = founders[index + 1];
                    symbols[index] = symbols[index + 1];
                    parties_counter[index] = parties_counter[index + 1];
                }
                adminCount--;
                updatedElectedPartyFile();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(del_party + " is deleted successfully. " );
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Party of this name is not Found.." );
            }
            Console.ReadKey();
        }
        static void updatedElectedPartyFile()
        {
            string path = "E:\\OOP\\Business app ver1\\ElectedParties.txt";
            StreamWriter file = new StreamWriter(path, true);
            for (int idx = 0; idx < adminCount; idx++)
            {
                file.WriteLine(parties[idx] + "," + symbols[idx] + "," + founders[idx] + "," + parties_counter[idx]);
            }
            file.Flush();
            file.Close();
        }
        static void searchParty()
        {
            string srch_party;
            Console.WriteLine("Enter the name of the party you want to search: ");
            srch_party= Console.ReadLine();
            bool flag = false;
            int place = 0 ;
            for (int index = 0; index < adminCount; index++)
            {
                if (srch_party == parties[index])
                {
                    flag = true;
                    place = index;
                    break;
                }
            }
            if (flag == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" YOU searched for the party " + srch_party );
                Console.WriteLine(" The symbol of this party is " + symbols[place] );
                Console.WriteLine(" The founder of this party is  " + founders[place] );
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This party not found...");
            }
            Console.ReadKey();
        }
        static void viewParties()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t Elected Parties \t      Symbols\t\t\tFounder ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < adminCount; i++)
            {
                Console.WriteLine(parties[i].PadLeft(20) +  symbols[i].PadLeft(25) + founders[i].PadLeft(30));
            }
            Console.ReadKey();
        }
        static void update_Party()
        {
            string party, updated_name, updated_symbol, updated_founder;
            bool flag = false;
            int place = 0;
            Console.WriteLine(" Enter the name of the elected party you want to update: ");
            party = Console.ReadLine();
            for (int i = 0; i < adminCount; i++)
            {
                if (party == parties[i])
                {
                    flag = true;
                    place = i;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine(" Enter the updated name of elected party: ");
                updated_name = Console.ReadLine();
                Console.WriteLine(" Enter the updated symbol of the elected party: ");
                updated_symbol = Console.ReadLine();
                Console.WriteLine(" Enter the updated founder of the elected party: ");
                updated_founder = Console.ReadLine();
                parties[place] = updated_name;
                symbols[place] = updated_symbol;
                founders[place] = updated_founder;
                updatedElectedPartyFile();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Updated Successfully !!!" );
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Elected Party not found ): ");
            }
               Console.ReadKey();
        }
    }
}
