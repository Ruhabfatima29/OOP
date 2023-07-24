using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCLIProject.BL;
using FinalCLIProject.DL;
namespace FinalCLIProject.UI
{
    class PersonUI
    {
        public  static  Person takeInput()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string name = inputName();
            string gender = inputGender();
            string cnic = inputCnic();
            string password = inputPassword();
            Person p = new Person(name, gender,cnic,password);
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
            Console.Write("Enter your name: ");
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
            while (!(PersonDL.isValidCnicFormat(cnic)) || !(PersonDL.isValidCnic(cnic)))
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
        public static void viewAllUsers()
        {
            List<Person> p = PersonDL.returnUsers();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Name ID\t\t gender \t\t CNIC Numbers\t\t\t Password ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < p.Count; i++)
            {
                string name = p[i].getName().PadRight(15);
                string cnicNumber = p[i].getCnic().PadRight(25);
                string pass = p[i].getPassword().PadRight(30);
                string gender = p[i].getGender().PadRight(20);
                string role = p[i].getRole().PadRight(20);
                Console.WriteLine("{0}{1}{2}{3}{4}", name, cnicNumber, gender, role, pass);
            }
            Console.ResetColor();
            Console.ReadKey();
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
        public static string AdminMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string option;
            
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
            Console.WriteLine("4.  View all parties");
            Console.WriteLine("5.  Update elective party: ");
            Console.WriteLine("6.  Add polling stations");
            Console.WriteLine("7.  Delete polling stations");
            Console.WriteLine("8.  Update polling stations");
            Console.WriteLine("9.  Search for a polling station");
            Console.WriteLine("10. View all polling stations");
            Console.WriteLine("11. View all details of the voters");//
            Console.WriteLine("12. Search for the response of the voter");//
            Console.WriteLine("13. Declare the election results");//
            Console.WriteLine("14. View the feedback of the voters");//
            Console.WriteLine("15. View all the Accounts details");
            Console.WriteLine("17. Add an admin member: ");
            Console.WriteLine("16. Exit");
            Console.WriteLine("  Enter your response:  ");
            Console.WriteLine();
            option = Console.ReadLine();
            return option;
        }
        public static void adminInterface()
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
    }
}
