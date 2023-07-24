using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.BL;
using System.IO;
namespace VotingSystem.DL
{
    class VoterDL
    {
        public static List<Voter> voters = new List<Voter>();
        public static void addVoter(Voter v)
        {
            voters.Add(v);
        }
        public static void castVote(Voter v)
        {
            addVoter(v);
            storeToVotersFile(v);
            ElectedPartyDL.updatedElectedPartyFile();
        }
        public static bool checkIsValidVoter(Person voter)
        {
            bool flag = true;
            for (int i = 0; i < voters.Count; i++)
            {
                if (voter.getName() == voters[i].getName() && voter.getCnic() == voters[i].getCnic())
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static void storeToVotersFile(Voter v)
        {

            string path = "VotersDetails.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(v.getCnic() + "," + v.getVotedParty() + "," + v.getFeedback());
            file.Flush();
            file.Close();
        }
        public static void updateVoterFile()
        {
            string path = "VotersDetails.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int i = 0; i < voters.Count; i++)
            {
                file.WriteLine(voters[i].getCnic() + "," + voters[i].getVotedParty() + "," + voters[i].getFeedback());
            }
            file.Flush();
            file.Close();
        }
        public static bool isVoterExists(string cnic)
        {
            bool flag = false;
            for (int i = 0; i < voters.Count; i++)
            {
                if (cnic == voters[i].getCnic())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static Voter voterExists(string cnic)
        {
            for (int i = 0; i < voters.Count; i++)
            {
                if (cnic == voters[i].getCnic())
                {
                    return voters[i];
                }
            }
            return null;
        }
        public static Voter voterExists(string cnic,string password)
        {
            for (int i = 0; i < voters.Count; i++)
            {
                if (cnic == voters[i].getCnic() && password == voters[i].getPassword())
                {
                    return voters[i];
                }
            }
            return null;
        }
        public static string readDataFromVotersFile()
        {
            string path = "VotersDetails.txt";
            string output = null;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 3)
                    {
                        string cnic = data[0];
                        if (!PersonDL.isValidCnicFormat(cnic))
                        {
                            output = "Cnic data is corrupted.";
                            return output;
                        }
                        string vote = data[1];
                        string feedback = data[2];
                        Person p = PersonDL.personExists(cnic);
                        if (p != null)
                        {
                            Voter v = new Voter(p.getName(), p.getGender(), p.getCnic(), p.getPassword(), vote);
                            v.setFeedback(feedback);
                            voters.Add(v);
                        }
                        else
                        {
                            output = "The person has not login id but still has voted a party!";
                        }
                    }
                }
            }
            return output;
        }
    }

}
