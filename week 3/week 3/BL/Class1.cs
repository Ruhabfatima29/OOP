using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3.BL
{


    class Student
    {
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
        public Student()
        {
            sname = "Jill";
            matricMarks = 100F;
            fscMarks = 100F;
            ecatMarks = 189F;
            aggregate = 3.4F;
            Console.WriteLine("Default Constructor is called");
        }
        public Student(string sname)
        {
            this.sname = sname;
        }
        public Student(string sname, float matricMarks, float ecatMarks)
        {
            this.sname = sname;
            this.matricMarks = matricMarks;
            this.ecatMarks = ecatMarks;
        }
        public Student(Student s)
        {
            sname = s.sname;
            matricMarks = s.matricMarks;
            ecatMarks = s.ecatMarks;
            fscMarks = s.fscMarks;
            aggregate = s.aggregate;
        }
    }
}