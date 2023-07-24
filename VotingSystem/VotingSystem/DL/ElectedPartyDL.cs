using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.BL;
using VotingSystem;
using System.IO;
namespace VotingSystem.DL
{
    class ElectedPartyDL
    {
        private static List<ElectedParty> electedParties = new List<ElectedParty>();
        public static void addIntoPartiesList(ElectedParty p)
        {
            electedParties.Add(p);
        }
        public static List<ElectedParty> returnList()
        {
            return electedParties;
        }
        public static void sortElectedParties()
        {
            electedParties = electedParties.OrderByDescending(ElectedParty => ElectedParty.getVotesCount()).ToList();
        }
        public static bool delParty(string delParty)
        {

            int flag = getIndexOfSpecificParty(delParty);
            if (flag >= 0)
            {
                electedParties.RemoveAt(flag);
                updatedElectedPartyFile();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeToElectedPartiesFile(ElectedParty p)
        {
            string path = "ElectedParty.txt";
            StreamWriter file = new StreamWriter(path, true);
            string employee = "";
            employee = p.getEmployee().getName() + ";" + p.getEmployee().getGender() + ";" + p.getEmployee().getCnic() + ";" + p.getEmployee().getRole()+";" + p.getEmployee().getPassword();
            file.WriteLine(p.getPartyName() + "," + p.getSymbol() + "," + p.getFounder() + "," + p.getVotesCount() + "," + employee);
            file.Flush();
            file.Close();
        }
        public static void updatedElectedPartyFile()
        {
            string path = "ElectedParty.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int idx = 0; idx < electedParties.Count; idx++)
            {
                ElectedParty p = electedParties[idx];
                string employee = "";
                employee = p.getEmployee().getName() + ";" + p.getEmployee().getGender() + ";" + p.getEmployee().getCnic() + ";" + p.getEmployee().getRole() +";"+ p.getEmployee().getPassword();
                file.WriteLine(electedParties[idx].getPartyName() + "," + electedParties[idx].getSymbol() + "," + electedParties[idx].getFounder() + "," + electedParties[idx].getVotesCount() + "," + employee);
            }
            file.Flush();
            file.Close();
        }
        public static void loadDatafromElectedPartiesfile()
        {
            string path = "ElectedParty.txt";
            string party, symbol, founder;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 5)
                    {
                        party = data[0];
                        symbol = data[1];
                        founder = data[2];
                        string[] employee = data[4].Split(';');
                        if (int.TryParse(data[3], out int counter))
                        {
                            ElectedParty p = new ElectedParty(party, founder, symbol);
                            p.setVoteCount(counter);
                            string name = employee[0];
                            string gender = employee[1];
                            string cnic = employee[2];
                            string role = employee[3];
                            string pass = employee[4];
                            Person p1 = new Person(name, gender, cnic, pass, role);
                            p.setEmployee(p1);
                            electedParties.Add(p);
                        }

                    }

                }
            }
        }
        public static ElectedParty searchParty(string search)
        {
            int place = 0;
            for (int index = 0; index < electedParties.Count; index++)
            {
                if (search == electedParties[index].getPartyName())
                {
                    place = index;
                    return electedParties[place];
                }
            }
            return null;
        }
        public static void updateParty(ElectedParty p, int index)
        {
            electedParties[index] = p;
            updatedElectedPartyFile();
        }

        public static bool isPartyExists(string partyName)
        {
            bool flag = false;
            for (int i = 0; i < electedParties.Count; i++)
            {
                if (partyName == electedParties[i].getPartyName())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static int getIndexOfSpecificParty(string name)
        {
            int place = -1;
            for (int i = 0; i < electedParties.Count; i++)
            {
                if (name == electedParties[i].getPartyName())
                {
                    place = i;
                    break;
                }
            }
            return place;
        }
        public static bool isValidSymbol(string symbol)
        {
            bool flag = true;
            for (int i = 0; i < electedParties.Count; i++)
            {
                if (symbol == electedParties[i].getSymbol())
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static bool isValidFounder(string founder)
        {
            bool check = true;
            for (int index = 0; index < electedParties.Count; index++)
            {
                if (founder == electedParties[index].getFounder())
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
    }
}
