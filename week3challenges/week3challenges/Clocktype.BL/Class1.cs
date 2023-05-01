using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3challenges.Clocktype.BL
{
    class ClockType
    {
        public int hours;
        public int mins;
        public int sec;
        public ClockType()
        {
            hours = 0;
            mins = 0;
            sec = 0;
        }
        public ClockType(int hours)
        {
            this.hours = hours;
        }
        public ClockType(int hours , int mins)
        {
            this.hours = hours;
            this.mins = mins;
        }
        public ClockType(int hours, int mins, int sec)
        {
            this.hours = hours;
            this.mins = mins;
            this.sec = sec;
        }
        public void incrementSeconds()
        {
            sec++;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void incrementMinutes()
        {
            mins++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + ":" + mins + ":" + sec);
        }
        public bool isEqual(int hours, int mins, int sec)
        {
            if (this.hours == hours && this.mins == mins && this.sec == sec)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(ClockType temp)
        {
            if(hours == temp.hours && mins == temp.mins && sec == temp.sec)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int elapsedTime()
        {
            int seconds = (hours * 3600) + (mins * 60) + (sec);
            return seconds;
        }
        public int remainingTime( ClockType current)
        {
            int curentTimesec = (current.hours * 3600) + (current.mins * 60) + (current.sec);
            Console.WriteLine(curentTimesec);
            int result = 86400 - curentTimesec;
            return result;
        }
        public ClockType farClock(ClockType s)
        {
            int seconds1 = (s.hours * 3600) + (s.mins * 60) + (s.sec);
            int seconds = (hours * 3600) + (mins * 60) + (sec);
            int result = 0;
            ClockType c = new ClockType();
            if(seconds1 > seconds)
            {
                result = seconds1 - seconds;
            }
            else
            {
                result = seconds - seconds1;
            }
             c.hours = result / 3600;
             c.mins = (result % 3600 ) / 60;
             c.sec= ((result % 3600) / 60) / 60;
            return c;
        }
        public void formattedOutput(ClockType n)
        {
            Console.WriteLine(n.hours + "hr : " + n.mins + "min : " + n.sec + "sec");
        }
    }
   
}
