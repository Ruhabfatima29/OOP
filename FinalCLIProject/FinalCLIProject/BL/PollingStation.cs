using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCLIProject.BL
{
    class PollingStation
    {
        private string PsName;
        private string code;
        private string area;
        public PollingStation(string PsName, string area, string code)
        {
            this.PsName = PsName;
            this.area = area;
            this.code = code;
        }
        public void setName(string PsName)
        {
            this.PsName = PsName;
        }
        public void setCode(string code)
        {
            this.code = code;
        }
        public void setArea(string area)
        {
            this.area = area;
        }
        public string getArea()
        {
            return area;
        }
        // Ps stands for polling station
        public string getName()
        {
            return PsName;
        }
        public string getCode()
        {
            return code;
        }
    }
}
