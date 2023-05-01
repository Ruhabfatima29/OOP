using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3challenges.Clocktype.BL;

namespace week3challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockType emptyTime = new ClockType();
            Console.Write("EmptyTime");
            emptyTime.printTime();

            ClockType hourTime = new ClockType(8);
            Console.Write("HourTime");
            hourTime.printTime();

            ClockType minuteTime = new ClockType(8,10);
            Console.Write("MinuteTime");
            minuteTime.printTime();

            ClockType fullTime = new ClockType(8,10,10);
            Console.Write("FullTime");
            fullTime.printTime();

            fullTime.incrementSeconds();
            Console.Write("Full time after increment in seconds :");
            fullTime.printTime();

            fullTime.incrementHours();
            Console.Write("Full time after increment in hours :");
            fullTime.printTime();

            fullTime.incrementMinutes();
            Console.Write("Full time after increment  in minutes :");
            fullTime.printTime();

            bool flag = fullTime.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            ClockType c = new ClockType(10,12,1);
            bool check = fullTime.isEqual(c);
            Console.Write("Object flag: " + check);

            int seconds = c.elapsedTime();
            ClockType time = new ClockType(9,10,10);
            int result = c.remainingTime(time);
            Console.WriteLine(result);
            Console.Read();
        }
        
    }
}
