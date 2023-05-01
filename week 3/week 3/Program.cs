using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_3.BL;
namespace week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            task5();
            Console.Read();
        }
        static void task1a()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
        }
        static void task1b()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Student s2= new Student();
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregate);
        }
        static void task2()
        {
            Student s1 = new Student("ALi");
            Console.WriteLine(s1.sname);
            Student s2 = new Student("Abdullah");
            Console.WriteLine(s2.sname);
        }
        static void task3()
        {
            Student s1 = new Student("Ali",130F,78F);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Student s2 = new Student("Rehman", 100F, 80F);
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregate);
        }
        static void task4()
        {
            Student s1 = new Student();
            s1.sname = "Bilal";
            Student s2 = new Student(s1);
            s1.sname = "Ahmad";
            Console.WriteLine(s1.sname);
            Console.WriteLine(s2.sname);
        }
        static void task5()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            foreach(int x in numbers)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }
    }
}
