using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenges.BL;
namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[10];
            int count = 0;
            string option;
            do
            {
                option = menu();
                if (option == "1")
                {
                    products[count] = addProducts();
                    count++;
                }
                else if (option == "2")
                {
                    viewProducts(products, count);
                }
                else if (option == "3")
                {
                    totalStoreWorth(products,count);
       
                }
                else if (option == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
            while (option != "4");
            Console.Read();
        }
        static string menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Product: ");
            Console.WriteLine("2. Show Product: ");
            Console.WriteLine("3. Total Store Worth: ");
            Console.WriteLine(" Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        static Product addProducts()
        {
            Console.Clear();
            Product p = new Product();
            Console.WriteLine("Enter product ID: ");
            p.id = Console.ReadLine();
            Console.WriteLine("Enter product name: ");
            p.name = Console.ReadLine();
            Console.WriteLine("Enter product Price: ");
            p.price =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter product category: ");
            p.category = Console.ReadLine();
            Console.WriteLine("Enter product BrandName: ");
            p.brandName = Console.ReadLine();
            Console.WriteLine("Enter product Country: ");
            p.country = Console.ReadLine();
            return p;
        }
       static void viewProducts(Product[] p, int count)
        {
            Console.Clear();
            for(int x=0; x < count; x++)
            {
                Console.WriteLine("Product ID: {0} Product Name: {1} Price: {2} Category: {3} BrandName: {4} Country: {5}", p[x].id, p[x].name, p[x].price, p[x].category, p[x].brandName, p[x].country);
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
        static void totalStoreWorth(Product[] products, int count)
        {
            Console.Clear();
            int sum = 0;
            for(int i=0; i < count; i++)
            {
                sum = sum + products[i].price;
            }
            Console.WriteLine("The total worth of the store is "+ sum);
            Console.ReadKey();
        }
    }
}
