using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selfAssesment2
{
    class Program3
    {
        static void Main(string[] args)
        {
            int order, price;
            Console.Write("Enter minimum number of orders: ");
            order =int.Parse( Console.ReadLine());
            Console.Write("Enter minimum order price:  ");
            price = int.Parse(Console.ReadLine());
            pizza_points(order,price);
            Console.ReadKey();
        }
        static void pizza_points(int order, int minPrice)
        {
            string record;
            string name;
            int ordersNo;
            string data;
            string path = "E:\\OOP\\Customers.txt";
            StreamReader myFile = new StreamReader(path);
            while((record=myFile.ReadLine())!=null)
            {
                name = parseData(record, 1);
                ordersNo = int.Parse(parseData(record, 2));
                if(ordersNo>=order)
                {
                    data = parseData(record, 3);
                    int count = 0;
                    for(int x=1; x<ordersNo; x++)
                    {
                        int price = commaParsing(data, x);
                        if(price>=minPrice)
                        {
                            count++;
                        }
                    }
                    if(count>=order)
                    {
                        Console.WriteLine(name);
                    }
                }
                /*Console.Read();*/
            }
           
        }
        static string parseData(string record, int field)
        {
            int space = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    space++;
                }
                else if (space == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static int commaParsing(string data, int field)
        {
            int commaCount = 1;
            string item="";
            int number;
            for(int x=1; x < data.Length-1; x++ )
            {
                if(data[x] == ',')
                {
                    commaCount++;
                }
                else if(commaCount == field)
                {
                    item = item + data[x];
                }
            }
            number = int.Parse(item);
            return number;
        }
    }
}
