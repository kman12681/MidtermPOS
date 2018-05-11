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
            
            //runs the shoppingcart method
            ShoppingCart();

            // press any key to exit
            Console.ReadKey();
            
		}

        // ShoppingCart method uses this to choose a product number.
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

                //gets users requested quantity of menu item
				Console.WriteLine("How many would you like?");
                int quantity = Validator.ValidNumAndConvertToWholeNum();

                if (quantity != 0)
                {
                    //adds item to the cartList and updates the quantity from 0.
                    Cart.cartList.Add(Product.products[menuChoice]);
                    Cart.cartList[itemadded].Quantity = quantity;

                    ////prints a linetotal
                    double linetotal = (Cart.cartList[itemadded].Quantity * Cart.cartList[itemadded].Price);
                    Console.WriteLine(Cart.cartList[itemadded].Name + " | Quantity of " + quantity + " x $" + Cart.cartList[itemadded].Price + " = $" + linetotal);

                    // increments the interaction with the shopping cart by 1.
                    itemadded++;
                }
                else
                {
                    Console.WriteLine("Nothing added to the cart");
                }
                //keep shopping yey or ney
                Console.WriteLine("Keep shopping? (y/n)");
                string response = Validator.GetAValidYorN();
				if (response == "y")
				{
					continue;
				}
				else
				{
                    PrintCart();
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

        //prints the shopping cart contents
        public static void PrintCart()
        {
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\nSHOPPING CART");
            foreach (Product c in Cart.cartList)
            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name}  Qty:{c.Quantity} x ${c.Price} = ${groupprice}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }
            Console.WriteLine($"TOTAL: ${cartTotalPrice}");
        }
    }
}
