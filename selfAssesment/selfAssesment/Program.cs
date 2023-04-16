using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selfAssesment
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            float price, result;
            int toyPrice;
            int moneyGift, toyGift;
            int odd = 0, even = 0, sum = 0, n1 = 0;
            Console.Write( "Enter Lilly's Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter IPHONE price: ");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter the unit price of toys: ");
            toyPrice = int.Parse(Console.ReadLine());
            
            for (int count = 1; count <= age; count++)
            {
                if (count % 2 == 0)
                {
                    n1 = n1 + 1;
                    even = even + 10;
                    sum += even;
                }
                else
                {
                    odd = odd + 1;
                }
            }
            moneyGift = sum - n1;
            toyGift = odd * toyPrice;
            result = moneyGift + toyGift;

    
            if (result >= price)
            {
                Console.WriteLine( "YES!!" );
                Console.WriteLine(result - price);
            }
            else
            {
                Console.WriteLine("NO!");
                Console.WriteLine(price - result);
            }
            Console.Read();
        }

    }
}
