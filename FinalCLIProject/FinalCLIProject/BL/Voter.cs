using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCLIProject.BL
{
    class Voter: Person

    {
        public string votedParty;
        public string feedback;
        public Voter(string name, string gender, string cnic, string password,string votedParty):base(name,gender,cnic,password)
        {
            this.votedParty = votedParty;
            this.feedback = " Not feedbacked yet.";
        }
        
        public string getVotedParty()
        {
            return votedParty;
        }
        
        public void setFeedback(string feedback)
        {
            this.feedback = feedback;
        }
        public string getFeedback()
        {
            return feedback;
        }
    }
}
