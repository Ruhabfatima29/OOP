using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using BuisnessApplicationwithclasses.BL;

namespace Buisness_Application

{

    class Program
    {

        static void Main(string[] args)
        {
            List<LoginUser> users = new List<LoginUser>();
            List<ElectedParty> electedParties = new List<ElectedParty>();
            string path1 = "E:\\OOP\\Buisness APP\\loginFile.txt";
            readDatafromlogin(users, path1); // reads data from login file
            loadDatafromElectedPartiesfile(electedParties);
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
                        bool checker = isValidUserName(pass, name, users);
                        if (checker == true)
                        {
                            LoginUser user = new LoginUser(name, pass, role);
                            signUp(user, users);
                            storeToLoginFile(name, pass, role);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.WriteLine("<<< Remember that login name and password in order to sign in with that account >>>");
                            Console.WriteLine();
                            Console.WriteLine("SIGNED UP SUCCESSFULLY !!!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.WriteLine("User and password is already found. Kindly sign up with new ID (: ");
                        }
                    }
                    else if (option == "2")
                    {
                        Console.Clear();
                        printHeader();
                        // SIGN IN
                        LoginUser choice;
                        choice = signIn(users);
                        if (choice == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.WriteLine("NO User Found!!!! Sign up First...");
                        }
                        else if (choice.role == "Admin")
                        {

                            Console.Clear();
                            // Admin Menu
                            adminFunctions(electedParties);

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
                    Console.ReadLine();

                }
            }
        }



        static string parseData(string data, int field)
        {
            int commaCount = 1;
        string item = "";
            for (int x = 0; x<data.Length; x++)
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
        static void readDatafromlogin(List<LoginUser> users, string path)
        {

            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    LoginUser user = new LoginUser(name, password, role);
                    users.Add(user);

                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Not Exists.");
            }
        }

        static LoginUser signIn(List<LoginUser> users)
        {
            string name, password;
            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();

            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].name && password == users[i].password)
                return users[i];
            }
            return null;
        }
        static void storeToLoginFile(string name, string role, string password)
        {
            string path = "E:\\OOP\\Buisness APP\\loginFile.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine(name + ',' + password + ',' + role + '\n');
            myFile.Flush();
            myFile.Close();
        }
        static void signUp(LoginUser user, List<LoginUser> users)
        {
            users.Add(user);
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
        static bool isValidUserName(string pass, string name, List<LoginUser> users)
        {
            bool check = true;

            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].name && pass == users[i].password)
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
        static void adminFunctions(List<ElectedParty> electedParties)
        {

            string choice = "0";
            ElectedParty a = new ElectedParty();
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
                    // check valid party
                    for (int i = 0; i < electedParties.Count; i++)
                    {
                        if (partyName == electedParties[i].party )
                        {
                            flag = "true";
                            break;
                        }
                    }
                    if (flag == "true")
                    {
                        Console.WriteLine("PARTY ALREADY EXISTS!!! ");
                    }
                    else
                    {
                        
                        Console.WriteLine(" Enter the Symbol of your Elected Party: ");
                        partySymbol = Console.ReadLine();
                        // checks the validity of symbol's data
                        isvalidSymbol = a.validSymbol(partySymbol, electedParties);
                        while (isvalidSymbol == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid Symbol. This symbol is already allocated to another party..");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Enter the Symbol of your Elected Party: ");
                            partySymbol = Console.ReadLine();
                            isvalidSymbol = a.validSymbol(partySymbol, electedParties);
                        }
                        Console.WriteLine(" Enter the name of the founder of Elected Party:  ");
                        founder = Console.ReadLine();
                        checkFounderData = validUserNameData(founder);
                        // checks the validity of founder's data
                        isValidFounder = a.validFounder(founder, electedParties);
                        while (isValidFounder == false || checkFounderData == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            if (isValidFounder == false)
                            {
                                Console.WriteLine("Invalid Founder. For two different parties, there couldn't be a same founder.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid data entered. You can only enter alphabets and spaces.");
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Enter the name of the founder of Elected Party:  ");
                            founder = Console.ReadLine();
                            isValidFounder = a.validFounder(founder, electedParties);
                            checkFounderData = validUserNameData(founder);
                        }
                        ElectedParty party = new ElectedParty(partyName, founder, partySymbol);
                        party.addParty(party, electedParties);
                        storeToElectedPartiesFile(partyName, partySymbol, founder, 0);
                        Console.WriteLine();
                        Console.WriteLine("<<<Party added Successfully>>>");
                        Console.ReadKey();
                    }
                    
                }
                else if (choice == "2")
                {

                    // Deleting a party
                    Console.Clear();
                    string del_party;
                    bool flag;
                    ElectedParty c = new ElectedParty();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the party you want to delete: ");
                    del_party = Console.ReadLine();
                    flag = c.delParty(del_party,electedParties);
                    if(flag == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(del_party + " is deleted successfully. ");
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Party of this name is not Found..");
                    }
                }
                else if (choice == "3")
                {
                    // Search for an party
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    string search_party;
                    Console.WriteLine("Enter the name of the party you want to search: ");
                    search_party = Console.ReadLine();
                    ElectedParty flag = new ElectedParty();
                    flag = a.searchParty(search_party, electedParties);
                    if (flag != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" You searched for the party " + search_party);
                        Console.WriteLine(" The symbol of this party is " + flag.symbol);
                        Console.WriteLine(" The founder of this party is  " + flag.founder);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This party not found...");
                    }
                    Console.ReadKey();
                }
                else if (choice == "4")
                {
                    // View all the Parties
                    Console.Clear();
                    adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    a.viewParties(electedParties);
                }
                else if (choice == "5")
                {
                    // update elective party
                    Console.Clear();
                    // adminInterface();
                    Console.WriteLine("You Choosed: " + choice);
                    Console.WriteLine();
                    update_Party(electedParties);
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
       
       
       
        static void storeToElectedPartiesFile(string partyName, string symbol, string founder, int votes_counter)
        {
            string path = "E:\\OOP\\Buisness APP\\ElectedParties.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(partyName + "," + symbol + "," + founder + "," + votes_counter);
            file.Flush();
            file.Close();
        }
        static void loadDatafromElectedPartiesfile(List<ElectedParty> electedParties)
        {
            string path = "E:\\OOP\\Buisness APP\\ElectedParties.txt";
            string party, symbol, founder;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 4)
                    {
                        party = data[0];
                        symbol = data[1];
                        founder = data[2];
                        if (int.TryParse(data[3], out int counter))
                        {
                            ElectedParty p = new ElectedParty(party,founder,symbol);
                            p.partyCouter = counter;
                            electedParties.Add(p);
                        }
                     
                    }
                    
                }
            }
        }
        
        static void update_Party(List<ElectedParty> electedParties)
        {
            string party;
            bool flag = false;
            int place = 0;
            Console.WriteLine(" Enter the name of the elected party you want to update: ");
            party = Console.ReadLine();
            for (int i = 0; i < electedParties.Count; i++)
            {
                if (party == electedParties[i].party)
                {
                    flag = true;
                    place = i;
                    break;
                }
            }
            if (flag == true)
            {
                string updateParty, updateSymbol, updateFounder;
                //ElectedParty update = new ElectedParty();
                Console.WriteLine(" Enter the updated name of elected party: ");
                updateParty = Console.ReadLine();
                Console.WriteLine(" Enter the updated symbol of the elected party: ");
                updateSymbol = Console.ReadLine();
                Console.WriteLine(" Enter the updated founder of the elected party: ");
                updateFounder = Console.ReadLine();
                ElectedParty update = new ElectedParty(updateParty, updateFounder, updateSymbol);
                electedParties[place] = update;
                update.updatedElectedPartyFile(electedParties);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Updated Successfully !!!");
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

