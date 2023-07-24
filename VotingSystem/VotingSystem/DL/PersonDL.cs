using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.BL;
using System.IO;
using System.Windows.Forms;

namespace VotingSystem.DL
{
    class PersonDL
    {
        private static List<Person> users = new List<Person>();
        private static void addIntoList(Person p)
        {
            users.Add(p);
        }
        public static List<Person> returnUsers()
        {
            return users;
        }
        public static Person signIn(string name, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].getName() && password == users[i].getPassword())
                    return users[i];
            }
            return null;
        }
        public static void signUp(Person p)
        {
            addIntoList(p);
            storeToLoginFile(p);
        }
        //*************************** Load from and store to file related functions************
        public static string readDatafromlogin(string path)
        {
            string output = null;
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while (!myFile.EndOfStream)
                {
                    record = myFile.ReadLine();
                    string[] parseData = record.Split(',');
                    string name = parseData[0];
                    if (!isValidUserNameData(name))
                    {
                        output = " Name data is corrupted. ";
                    }
                    string gender = parseData[1];
                    if (!isValidGender(gender))
                    {
                        output = output + " Gender data is not valid. ";
                    }
                    string cnic = parseData[2];
                    if (!(isValidCnicFormat(cnic) || isValidCnic(cnic)))
                    {
                        output = output + " Cnic data is invalid. ";
                    }
                    string role = parseData[3];
                    if (role != "Admin" && role != "User" && role != "Employee")
                    {
                        output = output + "Not valid role.";
                    }
                    string password = parseData[4];
                    if (password.Length != 4)
                    {
                        output = output + " Length of password is not valid.";
                    }
                    Person p = new Person(name, gender, cnic, password, role);
                    addIntoList(p);
                }
                myFile.Close();
            }
            else
            {
                output = "Not Exists.";
            }
            return output;
        }

        private static void storeToLoginFile(Person p)
        {
            string path = "LoginFile.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine(p.getName() + ',' + p.getGender() + ',' + p.getCnic() + ',' + p.getRole() + ',' + p.getPassword());
            myFile.Flush();
            myFile.Close();
        }
        //**************************** Validation functions are below *************************
        public static bool isValidUserNameData(string name)
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
        public static bool isValidGender(string gender)
        {
            bool flag = false;
            if (gender == "male" || gender == "female" || gender == "other" || gender == "Employee")
            {
                flag = true;
            }
            return flag;
        }
        public static bool isValidCnic(string cnic)
        {
            bool flag = true;
            for (int idx = 0; idx < users.Count; idx++)
            {
                if (cnic == users[idx].getCnic())
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static bool isValidCnicFormat(string cnic)
        {
            int size = cnic.Length;
            int count = 0;
            bool flag = true;
            bool check = false;
            if (size == 15)
            {
                for (int idx = 0; idx < size; idx++)
                {
                    if ((cnic[idx] >= 48 && cnic[idx] <= 57) || (cnic[idx] == 45))
                    {
                        if (cnic[idx] == 45)
                        {
                            count++;
                        }
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (count == 2 && flag == true)
                {
                    check = true;
                }
            }
            return check;
        }
        public static bool isValidInputOption(string option)
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
        public static bool isValidPerson(string cnic)
        {
            bool check = true;

            for (int i = 0; i < users.Count; i++)
            {
                if (cnic == users[i].getCnic())
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        public static Person personExists(string cnic)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (cnic == users[i].getCnic())
                {
                    return users[i];
                }
            }
            return null;
        }
       

    }
}
