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
            

            //ServiceOrItemMenu();
            //ItemMenu();
            ShowFullMenu();


        }

        public static void ShowInventory()
        {

            foreach (Product p in Product.products)
            {
                Console.WriteLine($"{p.Name}\t{p.Category}\t{p.Price}\t{p.Description}");
            }
        }
        // menu
        public static void ServiceOrItemMenu()
        {

            // TAKEN FROM PROGRAM (MAIN ARG)
            Console.WriteLine("Welcome to the ***");
            bool RuningProgram = true;
            while (RuningProgram)
            {
                //prompts user to purchase a service or item.
                Console.WriteLine("Would you like to order a service or purchase an item?");
                Console.Write("Enter 1 for a service or 2 for an item:  ");

                //input validation on user input, converts to int, once validated.
                int ServOrItResponse = Validator.ValidNum(Console.ReadLine());

                // if user does not choose 1 or 2, it will bounce back to 
                if (ServOrItResponse != 1 || ServOrItResponse != 2)
                {
                    continue;
                }
                else if (ServOrItResponse == 1)
                {
                    Console.WriteLine("valid");
                    ServiceMenu();
                }
                else
                {
                    ItemMenu();
                }

                // TODO:  foreach
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


