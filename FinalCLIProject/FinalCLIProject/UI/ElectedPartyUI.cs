using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCLIProject.BL;
using FinalCLIProject.DL;
namespace FinalCLIProject.UI
{
    class ElectedPartyUI
    {
        public static ElectedParty takeInputForElectedParty()
        {
            string name = inputPartyName();
            if(ElectedPartyDL.isPartyExists(name))
            {
                return null;
            }
            string founder = inputFounder();
            string symbol = inputSymbol();
            List<Person> employees = inputEmployees();
            ElectedParty p = new ElectedParty(name, founder, symbol, employees);
            return p;
        }
        public static string inputPartyName()
        {
            Console.WriteLine(" Enter the name of The Elected Party: ");
            string partyName = Console.ReadLine();
            // checks validity of Elected party's data
            bool flag = PersonDL.isValidUserNameData(partyName);
            while (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid data entered...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Enter the name of The Elected Party: ");
                partyName = Console.ReadLine();
                flag = PersonDL.isValidUserNameData(partyName);
            }
            return partyName;
        }
        public static string inputSymbol()
        {
            Console.WriteLine(" Enter the Symbol of your Elected Party: ");
            string partySymbol = Console.ReadLine();
            // checks the validity of symbol's data
            bool validSymbol = ElectedPartyDL.isValidSymbol(partySymbol);
            while (ElectedPartyDL.isValidSymbol(partySymbol) == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Symbol. This symbol is already allocated to another party..");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Enter the Symbol of your Elected Party: ");
                partySymbol = Console.ReadLine();
                validSymbol = ElectedPartyDL.isValidSymbol(partySymbol);
            }
            return partySymbol;
        }
        public static string inputFounder()
        {
            Console.WriteLine(" Enter the name of the founder of Elected Party:  ");
            string founder = Console.ReadLine();
            bool checkFounderData = PersonDL.isValidUserNameData(founder);
            // checks the validity of founder's data
            bool validFounder = ElectedPartyDL.isValidFounder(founder);
            while (validFounder == false || checkFounderData == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (validFounder == false)
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
                validFounder = ElectedPartyDL.isValidFounder(founder);
                checkFounderData = PersonDL.isValidUserNameData(founder);
            }
            return founder;
        }
        public static List<Person> inputEmployees()
        {
            List<Person> employees = new List<Person>();
            Console.WriteLine("How many Employees you want to enter? ");
            int size = int.Parse(Console.ReadLine());
            for(int idx=0; idx<size; idx++)
            {
                Console.WriteLine("**************** Enter details of " + idx + 1 + " employee ************** ");
                Person employee = PersonUI.takeInput();
                employee.setRole("Employee");
                employees.Add(employee);
            }
            return employees;
        }
        
        public static void viewParties(List<ElectedParty> electedParties)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t Elected Parties \t    Symbols\t\t   Founder \t\tEmployees");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < electedParties.Count; i++)
            {
                string employees = "";
                List<Person> p = electedParties[i].getEmployees();
                for (int idx = 0; idx < p.Count-1; idx++)
                {
                    employees = employees + p[idx].getName() + ",";
                }
                employees = employees + electedParties[i].getEmployees()[p.Count-1].getName();
                Console.WriteLine(electedParties[i].getPartyName().PadLeft(20) + electedParties[i].getSymbol().PadLeft(20) + electedParties[i].getFounder().PadLeft(25) + employees.PadLeft(30));
            }
            Console.ReadKey();
        }
        public static void displaySearchedParty(ElectedParty p)
        {
            Console.WriteLine(" You searched for the party " + p.getPartyName());
            Console.WriteLine(" The symbol of this party is " + p.getSymbol());
            Console.WriteLine(" The founder of this party is  " + p.getFounder());
        }
        public static string  inputForSearchParty()
        {
            Console.WriteLine("            *********** Search an elected party ***********");
            Console.WriteLine("Enter the name of the party you want to search: ");
            string name = Console.ReadLine();
            return name;
        }
        public static ElectedParty takeInputForUpdatingParty()
        {
            Console.WriteLine("Enter the name of the party you want to update: ");
            string name = Console.ReadLine();
            ElectedParty p = ElectedPartyDL.searchParty(name);
            if(p == null)
            {
                return null;
            }
            return takeInputForElectedParty();
        }
        public static void viewAllPartyVotes()
        {
            Console.WriteLine("ElectedParty\t\t   Party Votes Count");
            List<ElectedParty> p = ElectedPartyDL.returnList();
            for (int idx=0; idx<p.Count; idx++)
            {
                Console.WriteLine(p[idx].getPartyName().PadRight(25) + p[idx].getVotesCount());
            }
            Console.ReadLine();
        }
        public static void viewWinnerParty(List<ElectedParty> p)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("! * *************************ELECTION RESULTS DECLARATION * *********************!");
            if(p.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("The elected party  " + p[0].getPartyName() + " has got  " + p[0].getVotesCount() + "votes");

            }
            else if(p[0].getVotesCount() == p[1].getVotesCount())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\tNo winner team to be declared! There is a tie between parties...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The winner party  " + p[0].getPartyName() + " with " + p[0].getVotesCount() + " votes, has defeated all other parties.");
            }
            Console.ResetColor();
            ElectedPartyUI.viewAllPartyVotes();
            Console.ReadKey();
        }
    }
}
