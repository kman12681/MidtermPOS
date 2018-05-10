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
            Menu();
            ShowFullMenu();
            //ShowInventory();
        }

        public static void ShowInventory()
        {
            foreach (Product p in Product.products)
            {
                Console.WriteLine($"{p.Name}\t{p.Category}\t{p.Price}\t{p.Description}");
            }
        }
        public static void Menu()
        {

            // TAKEN FROM PROGRAM (MAIN ARG)
            Console.WriteLine("Welcome to the ***");
            bool RuningProgram = true;
            while (RuningProgram)
            {
                //prompts user to purchase a service or item.
                Console.WriteLine("Would you like to order a service or purchase an item?");
                Console.Write("Enter 1 for a service or 2 for an item:  ");

                int userpick = Validator.ValidNumAndConvertToWholeNum();

                // if user does not choose 1 or 2, it will bounce back to

                if (userpick != 1 && userpick != 2)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("It works!");
                    RuningProgram = false;
                }
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

        public static void ShowFullMenu()
        {
            int menuCount = 0;
            foreach (Product p in Product.products)
            {
                menuCount++;
                Console.WriteLine($"{menuCount}\t{p}");

            }
        }
    }
}


