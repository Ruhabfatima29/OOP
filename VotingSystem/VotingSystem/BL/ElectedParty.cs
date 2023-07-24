using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.BL
{
     class ElectedParty
    {
        private string partyName;
        private string founder;
        private string symbol;
        private int votesCount;
        private Person employees;

        public string PartyName { get => partyName; set => partyName = value; }
        public string Founder { get => founder; set => founder = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int VotesCount { get => votesCount; set => votesCount = value; }
        public string EmployeeName { get => employees.getName(); }  
        public string EmployeeCnic { get => employees.getCnic(); }
        public string EmployeeGender { get => employees.getGender(); }
        public string EmployeePassword { get => employees.getPassword(); }


        public ElectedParty(string partyName, string founder, string symbol)
        {
            this.PartyName = partyName;
            this.Founder = founder;
            this.Symbol = symbol;
            this.VotesCount = 0;
        }
        public ElectedParty(string partyName, string founder, string symbol, Person employees)
        {
            this.PartyName = partyName;
            this.Founder = founder;
            this.Symbol = symbol;
            this.VotesCount = 0;
            this.employees = employees;
        }
        public string getPartyName()
        {
            return PartyName;
        }
        public  void setVoteCount(int votesCount)
        {
            this.VotesCount = votesCount;
        }
        public string getFounder()
        {
            return Founder;
        }
        public string getSymbol()
        {
            return Symbol;
        }
        public void setEmployee(Person employees)
        {
            this.employees = employees;
        }
        public Person getEmployee()
        {
            return employees;
        }
      
        public  void incrementVotesCount()
        {
            VotesCount++;
        }
        public  int getVotesCount()
        {
            return VotesCount;
        }
    }
}
