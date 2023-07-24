using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCLIProject.BL
{
    class Person
    {
        protected string name;
        protected string gender;
        protected string cnic;
        protected string password;
        protected string role;
        public Person(string name, string gender, string cnic, string password)
        {
            this.name = name;
            this.gender = gender;
            this.cnic = cnic;
            this.password = password;
            this.role = "User";
        }
        public Person(string name, string gender, string cnic, string password, string role)
        {
            this.name = name;
            this.gender = gender;
            this.cnic = cnic;
            this.password = password;
            this.role = role;
        }
       
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setGender(string gender)
        {
            this.gender = gender;
        }
        public string getGender()
        {
            return gender;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public string getPassword()
        {
            return password;
        }
        public void setRole(string role)
        {
            this.role = role;
        }
        public  string getRole()
        {
            return role;
        }
        public void setCnic(string cnic)
        {
            this.cnic = cnic;
        }
        public string getCnic()
        {
            return cnic;
        }

    }
}
