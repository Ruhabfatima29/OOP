using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;
namespace task1
{
    class Program
    {
        class Student
        {
            public string name;
            public float roll_no;
            public float cgpa;
            public char isHostellite;
        }
        static void Main(string[] args)
        {
          UAMS();
          Console.Read();
        }

        static void tasks()
        {
            Student s1 = new Student();
            Console.Write("Enter your name:");
            s1.name = Console.ReadLine();
            Console.Write("Enter your roll no:");
            s1.roll_no = int.Parse(Console.ReadLine());
            s1.isHostellite = 'y';
            Console.WriteLine("Name: {0}. Roll no: {1}.  ", s1.name, s1.roll_no);
            Student s2 = new Student();
            s2.name = "John";
            s2.roll_no = 90F;
            s2.cgpa = 3.63F;
            s2.isHostellite = 'n';
            Console.WriteLine("Name: {0}. Roll no: {1}. Hostellite: {2}. CGPA {3} ", s2.name, s2.roll_no, s2.isHostellite, s2.cgpa);

        }
        static string menu()
        {
            Console.Clear();
            Console.WriteLine("1.Add Student:");
            Console.WriteLine("2.View Students:");
            Console.WriteLine("3.Top 3 students:");
            Console.Write("Enter your option: ");
            string option = Console.ReadLine();
            return option;
        }
        static Students addStudent()
        {
            Console.Clear();
            Students s1 = new Students();
            Console.Write("Enter  name:  ");
            s1.name = Console.ReadLine();
            Console.Write("Enter  Roll no:  ");
            s1.roll_no =int.Parse( Console.ReadLine());
            Console.Write("Enter  cgpa:  ");
            s1.cgpa =float.Parse( Console.ReadLine());
            Console.Write("Enter  Department name:  ");
            s1.department = Console.ReadLine();
            Console.Write("Enter Hostellide(y or n):  ");
            s1.isHostellide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void viewAll(Students[] s, int count)
        {
            Console.Clear();
            for(int i=0; i<count; i++)
            {
                Console.WriteLine("Name: {0}    Roll NO: {1}     CGPA: {2}    Department: {3}    Hostelide: {4} ", s[i].name, s[i].roll_no, s[i].cgpa, s[i].department, s[i].isHostellide);
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
        static void topStudents(Students[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("NO record found..");
            }
            else if(count == 1)
            {
                viewAll(s, 1);
            }
            else if(count == 2)
            {
                for(int x=0; x<2; x++)
                {
                    int index = largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewAll(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewAll(s, 3);
            }
        }
        static int largest(Students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int i= start; i<end; i++)
            {
                if(large < s[i].cgpa)
                {
                    large = s[i].cgpa;
                    index = i;
                }
            }
            return index;
        }
        static void UAMS()
        {
            Students[] students = new Students[10];
            string option;
            int count = 0;
            do
            {
                option = menu();
                if (option == "1")
                {
                    students[count] = addStudent();
                    count++;
                }
                else if (option == "2")
                {
                    viewAll(students, count);
                }
                else if (option == "3")
                {
                    topStudents(students, count);
                }
                else if (option == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option.");
                }

            }
            while (option != "4");
            Console.WriteLine("Press any key to continue...");
        }
    }
}
