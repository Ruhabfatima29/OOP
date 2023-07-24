using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.BL
{
    class PollingStation
    {
        private string PsName;
        private string code;
        private string area;

        public string PsName1 { get => PsName; set => PsName = value; }
        public string Code { get => code; set => code = value; }
        public string Area { get => area; set => area = value; }

        public PollingStation(string PsName, string area, string code)
        {
            this.PsName1 = PsName;
            this.Area = area;
            this.Code = code;
        }
        public void setName(string PsName)
        {
            this.PsName1 = PsName;
        }
        public void setCode(string code)
        {
            this.Code = code;
        }
        public void setArea(string area)
        {
            this.Area = area;
        }
        public string getArea()
        {
            return Area;
        }
        // Ps stands for polling station
        public string getName()
        {
            return PsName1;
        }
        public string getCode()
        {
            return Code;
        }
    }
}
