using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCLIProject.BL;
using FinalCLIProject.DL;
namespace FinalCLIProject.UI
{
    class PollingStationUI
    {
        
        public static PollingStation takeInputInPs()
        {
            string Psname = inputName();
            Console.WriteLine(" Enter the code of the polling station: ");
            string Pscode = Console.ReadLine();
            string area = inputArea();
            PollingStation p1 = new PollingStation(Psname, Pscode, area);
            return p1;
        }
        public static string inputArea()
        {
            Console.WriteLine(" Enter the area of the polling station: ");
            string area = Console.ReadLine();
            bool validArea = PersonDL.isValidUserNameData(area);
            while (validArea == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Invalid Input");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter the area of the polling station: ");
                area = Console.ReadLine();
                validArea = PersonDL.isValidUserNameData(area);
            }
            return area;
        }
        public static string inputName()
        {
            Console.WriteLine("Enter the polling station name : ");
            string Psname = Console.ReadLine();
            bool validPsName = PersonDL.isValidUserNameData(Psname);
            while (validPsName == false)
            {

                Console.WriteLine(" Invalid Input");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Enter the polling station name : ");
                Psname = Console.ReadLine();
                validPsName = PersonDL.isValidUserNameData(Psname);
            }
            return Psname;
        }
        public static void viewSearchParty(PollingStation p)
        {
            if (p != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" You searched for the polling station " + p.getName());
                Console.WriteLine(" The code of this polling station is " + p.getCode());
                Console.WriteLine(" The area of this polling station is " + p.getArea());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The polling station not found...");
            }
        }
        public static void viewPs(List<PollingStation> pollingStations)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t Polling Stations \t      PS Code\t\t\t\t Area ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (PollingStation p in pollingStations)
            {
                Console.WriteLine(p.getName().PadLeft(30) + p.getCode().PadLeft(20) + p.getArea().PadLeft(30));
            }
            Console.ReadKey();
        }
    }
}
