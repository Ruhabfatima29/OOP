using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCLIProject.DL;
using FinalCLIProject.BL;
namespace FinalCLIProject.UI
{
    class VoterUI
    {
        public static Voter takeInputForVoteCasting()
        {
            string cnic = PersonUI.inputCnic();
            Person p = PersonDL.personExists(cnic);
            if(p == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Alert!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("<> You entered an unregistered ID. To cast your vote, you must be registered. \n Make sure that you are entering your own correct Cnic number <>");
                Console.ResetColor();
            }
            else
            {
                if(!VoterDL.checkIsValidVoter(p))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The person with this ID has already voted!!!");
                }
                else
                {
                    string party = ElectedPartyUI.inputPartyName();
                    bool flag = ElectedPartyDL.isPartyExists(party);
                    if (flag == true)
                    {
                        Voter v = new Voter(p.getName(), p.getGender(), p.getCnic(), p.getPassword(), party);
                        return v;
                    }
                    else
                    {
                        Console.WriteLine("You selected an undefined party.Please vote from the given elected parties.\nTo view the list of all elective parties,select option 3... ");
                    }
                }
                Console.ReadLine();
            }
            return null;
        }
        public static string takeFeedback()
        {
            string feedback = "";
            Console.WriteLine("****************** Your Feedback must be one line long only. ***************");
            Console.WriteLine("Enter your feedback: ");
            feedback = Console.ReadLine();
            return feedback;
        }

        public static void printUserMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("<>                               USER'S INTERFACE                                 <>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("<>           BAD OFFICIALS ARE ELECTED BY GOOD CITIZENS WHO DON'T VOTE            <>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. View all polling stations: ");
            Console.WriteLine("2. Search your polling station: ");
            Console.WriteLine("3. View all the Elected Parties: ");
            Console.WriteLine("4. Search an elected party: ");
            Console.WriteLine("5. Cast your vote: ");
            Console.WriteLine("6. View your response: ");
            Console.WriteLine("7. Update your profile data: ");
            Console.WriteLine("8. Give your feedback: ");
            Console.WriteLine("9. Check your (vote) status:");
            Console.WriteLine("10. Exit: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter your response: ");
        }
        public static void viewVotersDetails()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tVoters Names\t\t gender \t\t CNIC_Numbers\t\t\t VOTES ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < VoterDL.voters.Count; i++)
            {
                string voterName = VoterDL.voters[i].getName().PadRight(15);
                string cnicNumber = VoterDL.voters[i].getCnic().PadRight(25);
                string vote = VoterDL.voters[i].getVotedParty().PadRight(30);
                string gender = VoterDL.voters[i].getGender().PadRight(20);
                Console.WriteLine("{0}{1}{2}", voterName,gender, cnicNumber, vote);
            }
            Console.ResetColor();
            Console.ReadKey();
        }
        public static string userMenu()
        {
            string option;
            printUserMenu();
            option = Console.ReadLine();
            return option;
        }
        public static void viewVoter(Voter v)
        {
            if(v!= null)
            {
                Console.WriteLine("Name is " + v.getName());
                Console.WriteLine("Cnic is " + v.getCnic());
                Console.WriteLine("This person has voted for " + v.getVotedParty());
            }
            else
            {
                Console.WriteLine("this person has not voted yet..");
            }
        }
        public static void viewFeddbacks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tVoters Names\t\t Feedback ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < VoterDL.voters.Count; i++)
            {
                string voterName = VoterDL.voters[i].getName().PadRight(25);
                string feedback = VoterDL.voters[i].getFeedback().PadRight(40);
                Console.WriteLine("{0}{1}", voterName, feedback);
            }
            Console.ResetColor();
            Console.ReadKey();

        }
        public static void userInterface()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("<>                                 USER'S INTERFACE                                        <>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("<>               BAD OFFICIALS ARE ELECTED BY GOOD CITIZENS WHO DON'T VOTE                 <>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

