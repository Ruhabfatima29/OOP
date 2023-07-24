using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCLIProject.BL
{
    class ElectedParty
    {
        private string partyName;
        private string founder;
        private string symbol;
        private int votesCount;
        private List<Person> employees = new List<Person>();
        public ElectedParty(string partyName, string founder, string symbol)
        {
            this.partyName = partyName;
            this.founder = founder;
            this.symbol = symbol;
            this.votesCount = 0;
        }
        public ElectedParty(string partyName, string founder, string symbol, List<Person> employees)
        {
            this.partyName = partyName;
            this.founder = founder;
            this.symbol = symbol;
            this.votesCount = 0;
            this.employees = employees;
        }
        public string getPartyName()
        {
            return partyName;
        }
        public  void setVoteCount(int votesCount)
        {
            this.votesCount = votesCount;
        }
        public string getFounder()
        {
            return founder;
        }
        public string getSymbol()
        {
            return symbol;
        }
        public void setEmployees(List<Person> employees)
        {
            this.employees = employees;
        }
        public List<Person> getEmployees()
        {
            return employees;
        }
        public void addEmployee(Person p)
        {
            employees.Add(p);
        }
      
        public  void incrementVotesCount()
        {
            votesCount++;
        }
        public  int getVotesCount()
        {
            return votesCount;
        }
    }
}
