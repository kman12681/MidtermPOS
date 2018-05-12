using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // welcomes the user
            Console.WriteLine("Welcome to Treat Ya'self by Drones");

            //runs the shoppingcart method
            ShoppingCart();

        }

        // method for choosing product from menu
        public static int ChooseProduct()
        {
            while (true)
            {
                Console.WriteLine($"\n{"ITEM",-8}{"NAME",-29}PRICE");
                Console.WriteLine("======= ===========================  =====\n");
                //lists the products on the menu, starting at 1 
                int menuCount = 0;
                foreach (Product p in Product.products)
                {
                    menuCount++;
                    //Tabs would result in unaligned items because the tab would begin based on the length of the characters within it
                    //Using commas & a num to determine the width of each column will produce the best alignment for columns
                    //A negative num will align to the left, positive num will align to the right 
                    Console.WriteLine($"{menuCount,3} --- {p}");
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

        // view entire products menu
        public static void ViewFullMenu()
        {
            foreach (Product p in Product.products)
            {
                Console.WriteLine(p);
            }

        }

        // view a specific menu item

        public static void ViewSingleMenuItem()
        {
            Console.WriteLine(Product.products[0]);
        }
        public static int itemadded = 0;
        // shopping cart method (1)
        public static void ShoppingCart()
        {
            //counter for items being added to the cart
            itemadded = 0;
            double linetotal = 0;
            //while loop for shopping, allowing multiple items to be added
            bool shopping = true;
            while (shopping)
            {
                int menuChoice = ChooseProduct();
                menuChoice--;

                //gets users requested quantity of menu item
                Console.WriteLine("How many would you like?");
                int quantity = Validator.ValidNumAndConvertToWholeNum();

                if (quantity != 0) // can I edit?
                {
                    //adds item to the cartList and updates the quantity from 0.
                    Product.cartList.Add(Product.products[menuChoice]);
                    Product.cartList[itemadded].Quantity = quantity;

                    ////prints a linetotal
                    linetotal = (Product.cartList[itemadded].Quantity * Product.cartList[itemadded].Price);
                    Console.WriteLine(Product.cartList[itemadded].Name + " | Quantity of " + quantity + " x $" + Product.cartList[itemadded].Price + " = $" + linetotal);

                    // increments the interaction with the shopping cart by 1.
                    itemadded++;
                }
                else
                {
                    Console.WriteLine("Nothing added to the cart");
                }
                //keep shopping yey or ney
                Console.WriteLine("Add another item? (y/n)");
                string response = Validator.GetAValidYorN();
                if (response == "y")
                {
                    continue;
                }
                else
                {
                    PrintCart();
                    Console.WriteLine("\nWould you like to complete your purchase? (y/n)");
                    string completePurchQ = Validator.GetAValidYorN();

                    if (completePurchQ != "y")
                    {
                        Console.WriteLine("Order cancelled.");
                        continue;
                    }


                    //TODO:  Payment menu, then a display receipt method

                    PaymentMenu();

                    //Console.WriteLine(Product.cartList[itemadded].Name + " | Quantity of " + quantity + " x $" + Product.cartList[itemadded].Price + " = $" + linetotal);

                    Receipt();
                    Console.WriteLine("Would you like to place another order?");
                    string userresponse = Validator.GetAValidYorN();
                    if (userresponse == "y")
                    {
                        continue;
                    }
                    else
                    {
                        shopping = false;
                        Console.WriteLine("Thank you!");
                        Console.ReadKey();
                    }

                }
            }
        }

        //  valudates menuchoice
        public static bool IsValidMenuChoice(int _input)
        {
            _input = Validator.ValidNumAndConvertToWholeNum();
            if (_input <= 0 && _input > Product.products.Count())
            {
                Console.WriteLine("That item does not exist.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static double grandtotal = 0;
        //prints the shopping cart contents
        public static void PrintCart()
        {
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\nSHOPPING CART");

            //Headers for Shopping Cart
            Console.WriteLine($"\n{"ITEM NAME",-29}{"QTY",-13}TOTAL");
            Console.WriteLine("============================ ========     =====\n");

            foreach (Product c in Product.cartList)

            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name,-25}   {c.Quantity,2} x  ${c.Price,-3} =  ${groupprice,-3}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }


            grandtotal = (cartTotalPrice * .06) + cartTotalPrice;
            Console.WriteLine($"\n\n{"SUBTOTAL",-15} $ {cartTotalPrice,5:F2}");
            Console.WriteLine($"{"TAX",-15} $ {(cartTotalPrice * .06),5:F2}");
            Console.WriteLine($"{"GRAND TOTAL",-15} $ {grandtotal,5:F2}");

        }

        public static string userPaymentChoice = "";

        //requests desired payment method from user
        public static void PaymentMenu()
        {
            Console.WriteLine("Which method of payment would you like to use for this order?");
            Console.WriteLine("Treat Ya'self by Drones accepts Cash, Check or Credit");

            userPaymentChoice = Validator.ValidPaymentMethod();

            if (userPaymentChoice == "cash")
            {
                Validator.ValidCashAmount();
            }
            else if (userPaymentChoice == "check")
            {
                Validator.ValidCheckNumber();
            }
            else if (userPaymentChoice == "credit")
            {
                Validator.ValidateCreditCard();
            }

        }

        public static void Receipt()
        {
            Console.WriteLine("Order Completed!");
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\nItems Ordered:");
            foreach (Product c in Product.cartList)
            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name}  Qty:{c.Quantity} x ${c.Price} = ${groupprice}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }

            grandtotal = (cartTotalPrice * .06) + cartTotalPrice;
            Console.WriteLine($"SUBTOTAL: ${cartTotalPrice}");
            Console.WriteLine($"TAX: ${cartTotalPrice * .06}");
            Console.WriteLine($"GRAND TOTAL: ${grandtotal}");
            Console.WriteLine($"Method of payment used: {userPaymentChoice}");

        }





    }
}