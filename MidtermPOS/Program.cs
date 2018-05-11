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
            // welcomes the user
			Console.WriteLine("Welcome to the ***");

            ShoppingCart();
            Console.WriteLine($"The Subtotal is {Cart.SubTotaler()} ");
            Console.ReadKey();
            
		}

        public static void ViewFullMenu()
        {
            foreach (Product p in Product.products)
            {
                Console.WriteLine(p);
            }
        }

        public static int ChooseProduct()
		{
			while (true)
			{
                //lists the products on the menu, starting at 1 
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
						return userpick;
					}
				}
			}
		}
        
        // shopping cart method (1)
		public static void ShoppingCart()
		{
            //counter for items being added to the cart
            int itemadded = 0;

            //while loop for shopping, allowing multiple items to be added
            bool shopping = true;
			while (shopping)
			{
				int menuChoice = ChooseProduct();
				menuChoice--;

                //gets quantity of menu item
				Console.WriteLine("How many would you like?");
                int quantity = Validator.ValidNumAndConvertToWholeNum();

                Cart.cartList.Add(Product.products[menuChoice]);
                
                Cart.cartList[itemadded].Quantity = quantity;

                Console.WriteLine(Cart.cartList[itemadded].ToStringWithQuantity());
                itemadded++;

                Console.WriteLine("Keep shopping? (y/n)");
                string response = Validator.GetAValidYorN();
				if (response == "y")
				{
					continue;
				}
				else
				{
					shopping = false;
				}
			}         
		}

        //calculates salestax
		public static double SalesTaxCalculator(double input)         {             double aftertax = (input * .06) + input;             return aftertax;         }

        public static bool IsValidMenuChoice(int _input)
        {
            _input = Validator.ValidNumAndConvertToWholeNum();
            if (_input <= 0 && _input > Product.products.Count())
            {
                Console.WriteLine("That item does not exist");
                return false;
            }
            else
            {
                return true;
            }
        }
	}
}
