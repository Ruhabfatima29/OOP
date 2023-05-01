using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3Challenge2.BL;

namespace week3Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            
            string choice;
            do
            {
                choice = menu();
                if(choice == "1")
                {
                    Product p = new Product();
                    p.addProduct();
                    products.Add(p);
                }
                if (choice == "2")
                {
                    Product p = new Product();
                    p.viewAllProduct(products);
                }
                if (choice == "3")
                {
                    Product p = new Product();
                    int highest = p.HighestPrice(products);
                    Console.WriteLine("The product with highest unit price" + products[highest].price +"  is " + products[highest].product);
                    Console.ReadKey();
                }
                if (choice == "4")
                {
                    Product p = new Product();
                    p.viewTaxes(products);
                }
                if (choice == "5")
                {
                    Product p = new Product();
                    p.productsToBeOrdered(products);
                } 
            }
            while (choice != "6");
            Console.ReadKey();
        }
        static string menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add product: ");
            Console.WriteLine("2. View All Product: ");
            Console.WriteLine("3. Find Product with the Highest Unit Price: ");
            Console.WriteLine("4. View Sales Tax of All Products: ");
            Console.WriteLine("5. Products to be Ordered: ");
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
