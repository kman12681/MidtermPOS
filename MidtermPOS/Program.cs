using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ***");

            ChooseProduct();
            ViewFullMenu();
            //ShowInventory();
        }      
        
        public static void ChooseProduct()
        {
            int menuCount = 0;
            foreach (Product p in Product.products)
            {
                menuCount++;
                Console.WriteLine($"{menuCount}\t{p}");
            }

            bool RuningProgram = true;
            while (RuningProgram)
            {
                //prompts user to purchase a service or item.
                Console.WriteLine();
                Console.Write("Pick a menu item: ");                

                int userpick = Validator.ValidNumAndConvertToWholeNum();

                // if user does not choose 1 or 2, it will bounce back to

                if (userpick < 1 || userpick > Product.products.Count)
                {
                    Console.WriteLine($"Invalid entry. Enter a number between 1 and {Product.products.Count}");
                    continue;
                }
                else
                {
                    Console.WriteLine("It works!");
                    RuningProgram = false;
                }
            }
        }

        public static void ViewFullMenu()
        {
            foreach (Product p in Product.products)
            {
                Console.WriteLine(p);
            }
        }

        public static void ServiceMenu()
        {
            foreach (Product p in Product.products)
                if (p.Category.ToLower() == "service")
                {
                    Console.WriteLine(p);
                }
        }

        public static void ItemMenu()
        {
            foreach (Product p in Product.products)
                if (p.Category.ToLower() == "item")
                {
                    Console.WriteLine(p);
                }
        }

        public static void ShowInventory()
        {
            foreach (Product p in Product.products)
            {
                Console.WriteLine($"{p.Name}\t{p.Category}\t{p.Price}\t{p.Description}");
            }
        }
    }
}


