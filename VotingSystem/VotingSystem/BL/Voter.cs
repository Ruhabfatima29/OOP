using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.BL
{
    class Voter : Person

    {
        private string votedParty;
        private string feedback;

        public string VotedParty { get => votedParty; set => votedParty = value; }
        public string Feedback { get => feedback; set => feedback = value; }

        public Voter(string name, string gender, string cnic, string password, string votedParty) : base(name, gender, cnic, password)
        {
            this.VotedParty = votedParty;
            this.Feedback = " Not feedbacked yet.";
        }

        public string getVotedParty()
        {
            return VotedParty;
        }

        public void setFeedback(string feedback)
        {
            this.Feedback = feedback;
        }
        public string getFeedback()
        {
            return Feedback;
        }
    }
}
