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

                if (quantity != 0) // can I edit?
                {
                    //adds item to the cartList and updates the quantity from 0.
                    Product.cartList.Add(Product.products[menuChoice]);
                    Product.cartList[itemadded].Quantity = quantity;

                    ////prints a linetotal
                    double linetotal = (Product.cartList[itemadded].Quantity * Product.cartList[itemadded].Price);
                    Console.WriteLine(Product.cartList[itemadded].Name + " | Quantity of " + quantity + " x $" + Product.cartList[itemadded].Price + " = $" + linetotal);

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
                    Console.WriteLine("Would you like to complete your purchase? (y/n)");
                    string completePurchQ = Validator.GetAValidYorN();

                    if (completePurchQ != "y")
                    {
                        Console.WriteLine("Order cancelled.");
                        continue;
                    }


                    //TODO:  Payment menu, then a display receipt method

                    PaymentMenu();

                    Console.WriteLine("Thank you for your order!");
                    shopping = false;
                }
            }
        }

        //  valudates menuchoice
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
        public static double grandtotal = 0;
        //prints the shopping cart contents
        public static void PrintCart()
        {
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\nSHOPPING CART");
            foreach (Product c in Product.cartList)
            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name}  Qty:{c.Quantity} x ${c.Price} = ${groupprice}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }

            grandtotal = (cartTotalPrice * .06) + cartTotalPrice;
            Console.WriteLine($"SUBTOTAL: ${cartTotalPrice}");
            Console.WriteLine($"TAX: ${cartTotalPrice*.06}");
            Console.WriteLine($"GRAND TOTAL: ${grandtotal}");
        }

        //requests desired payment method from user
        public static void PaymentMenu()
        {
            Console.WriteLine("Treat Ya'self by Drones accepts Cash, Check or Credit");
            Console.WriteLine("Which method of payment would you like to use for this order?");

            string userPaymentChoice = Validator.ValidPaymentMethod();

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
       




    }
}