using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3Challenge2.BL
{
    class Product
    {
        public string product;
        public string category;
        public int price;
        public int stockQuantity;
        public int minQuantity;
        public void addProduct()
        {
            Console.Clear();
            Console.Write("Enter the name of product: ");
            product = Console.ReadLine();
            Console.Write("Enter the category of product: ");
            category = Console.ReadLine();
            Console.Write("Enter the price of product: ");
            price = int.Parse(Console.ReadLine());
            Console.Write("Enter the Stock Quantity: ");
            stockQuantity = int.Parse(Console.ReadLine());
            Console.Write("Enter the minimum Quantity: ");
            minQuantity = int.Parse(Console.ReadLine());
            Console.ReadKey();
        }
        public void viewAllProduct(List<Product> products)
        {
            Console.Clear();
            for(int i =0; i<products.Count; i++)
            {
                Console.WriteLine(products[i].product.PadRight(20) + products[i].category.PadLeft(15)+ "\t\t\t" + products[i].price + "\t\t" + products[i].stockQuantity + "\t\t" + products[i].minQuantity);
            }
            Console.ReadKey();
        }
        public int HighestPrice(List<Product> products)
        {
            int high = 0;
            for(int idx=0; idx < products.Count; idx++)
            {
                if(products[idx].price > high)
                {
                    high = idx;
                }
            }
            return high;
        }
        float SalesTax(int price, string category )
        {
            float tax = 0F;
            if(category == "grocery" || category == "Grocery")
            {
                tax = (price * 10) / 100;
            }
            if (category == "fruit" || category == "Fruit")
            {
                tax = (price * 5) / 100;
            }
            return tax ;
        }
        public void viewTaxes(List<Product> products)
        {
            Console.Clear();
            for (int idx=0; idx<products.Count; idx++)
            {
                float totalTax = SalesTax(products[idx].price, products[idx].category);
                Console.WriteLine("The tax on the product " + products[idx].product + " is " + totalTax + "%.");
            }
            Console.ReadKey();
        }
        public void productsToBeOrdered(List <Product> products)
        {
            Console.Clear();
            for (int idx = 0; idx < products.Count; idx++)
            {
                if (products[idx].stockQuantity < products[idx].minQuantity)
                {
                    Console.WriteLine(products[idx].product + " is needed to be ordered. ");
                }
            }
            Console.ReadKey();

        }
    }
}