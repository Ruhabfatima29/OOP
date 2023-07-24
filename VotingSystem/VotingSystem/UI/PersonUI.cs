using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.DL;
using VotingSystem.BL;
namespace VotingSystem.UI
{
    class PersonUI
    {
        public static Person takeInput()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string name = inputName();
            string gender = inputGender();
            string cnic = inputCnic();
            string password = inputPassword();
            Person p = new Person(name, gender, cnic, password);
            Console.ResetColor();
            return p;
        }
        public static Person takeInputWithRole()
        {
            Person admin = takeInput();
            admin.setRole(inputRole());
            return admin;
        }
        public static string inputName()
        {
            string name = Console.ReadLine();
            bool isvalidName = PersonDL.isValidUserNameData(name);
            while (isvalidName == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter Name[informat i.e. Alyan]: ");
                name = Console.ReadLine();
                isvalidName = PersonDL.isValidUserNameData(name);
            }
            return name;
        }
        public static string inputPassword()
        {
            Console.WriteLine("<Your Password must be 4 character long>");
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
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
            return pass;
        }
        public static string inputGender()
        {
            Console.Write("Enter gender [male,female,other]: ");
            string gender = Console.ReadLine();
            bool isvalidGender = PersonDL.isValidGender(gender);
            while (!isvalidGender)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter gender [male,female,other]: ");
                gender = Console.ReadLine();
                isvalidGender = PersonDL.isValidGender(gender);
            }
            return gender;
        }
        public static string inputCnic()
        {
            Console.WriteLine(" Enter your CNIC number in proper format i.e. XXXXX-XXXXXXX-X");
            string cnic = Console.ReadLine();
            bool isValidCnic = PersonDL.isValidCnicFormat(cnic);
            while (!(isValidCnic || PersonDL.isValidCnic(cnic)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Enter your CNIC number in proper format i.e. XXXXX-XXXXXXX-X");
                Console.Write(" Enter your CNIC number: ");
                cnic = Console.ReadLine();
                isValidCnic = PersonDL.isValidCnicFormat(cnic);
            }
            return cnic;
        }
        public static string inputRole()
        {
            Console.WriteLine("Enter your Role[Admin,User]: ");
            string role = Console.ReadLine();
            while (role != "Admin" && role != "User" && role != "Employee")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid role entered");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter your Role[Admin,User,Employee]: ");
                role = Console.ReadLine();
            }
            return role;
        }
    }
}
