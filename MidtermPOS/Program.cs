using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{/* POS
includes a class, with name, category, description, massage - DONE
includes a minimum of 12 items, which are stored in a text files - DONE
include validation on if cart is empty - DONE
presents user with a menu, allows them to choose by a number - DONE
user is then prompted to choose a quantity - DONE
line total (price * quantity =) is provided - DONE
keep shopping or checkout? (y/n) - DONE
if checkout, give subtotal, tax and grandtotal of all items - DONE
ask for payment type - DONE
if cash, validate amount tendered - DONE
if check, check the check number - DONE
if credit, validate the expiration and CVV - DONE
display a receipt with all items ordered, subtotal, tax, grand total - DONE
if cash, show change - DONE
if check, show check accepted - DONE
if credit, show credit card accepted - DONE
asks for another order - DONE */

    public static class Program
    {
        static void Main(string[] args)
        {
            // welcomes the user
            Console.WriteLine("Welcome to Treat Ya'self by Drones");
           //AddToProductList();
            //runs the shoppingcart method
            ShoppingCart();            

        }

        //private static void AddToProductList()
        //{
        //    string name = "shampoo";
        //    string category = "item";
        //    string description = "cleans your hair";
        //    int price = 10;

        //    using (FileStream fs = new FileStream("Product List.txt", FileMode.Append, FileAccess.Write))
        //    using (StreamWriter sw = new StreamWriter(fs))
        //    {

        //        sw.WriteLine($"\n{name}\t{category}\t{description}\t{price}\t");
        //    }
        //}

        // shopping cart method (1)
        public static void ShoppingCart()
        {

            bool shopping = true;
            //while loop for shopping, allowing multiple items to be added
            while (shopping)
            {           
                //counter for items being added to the cart
                int itemadded = 0;
                double linetotal = 0;

                //while loop for placing an order
                bool placingorder = true;
                while (placingorder)
                {
                    PrintMenu();
                    int menuChoice = ChooseProduct();
                    menuChoice--;

                    //gets users requested quantity of menu item
                    Console.WriteLine("How many would you like?");
                    int quantity = Validator.ValidNumAndConvertToWholeNum();

                    //foreach (Product product in Product.cartList)
                    //{
                    //    if (!Product.cartList.Contains(str))
                    //        lines2.Add(str);
                    //}

                    if (quantity != 0)
                    {
                        //adds item to the cartList and updates the quantity from 0.
                        Product.cartList.Add(Product.products[menuChoice]);
                        Product.cartList[itemadded].Quantity = quantity;

                        ////prints a linetotal
                        linetotal = (Product.cartList[itemadded].Quantity * Product.cartList[itemadded].Price);
                        Console.WriteLine(Product.cartList[itemadded].Name + " | Quantity of " + quantity + " x $" + Product.cartList[itemadded].Price + " = $" + linetotal + "\t*ADDED TO CART*");

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
                    // if no to keep shopping
                    else
                    {
                        CompleteOrder();
                        itemadded = 0;
                    }
                    placingorder = false;

                    shopping = AskToOrderAgainQ();
                }
 
            }
        }

        public static void CompleteOrder()
        {
            PrintCart();
            bool completingorder = true;
            while (completingorder)
            {
                Console.WriteLine("Would you like to complete your order (y/n)");
                string completePurchQ = Validator.GetAValidYorN().ToLower();

                if (completePurchQ == "n")
                {
                    Console.WriteLine("Order cancelled.");
                    Product.cartList.Clear();
                    completingorder = false;
                }
                else
                {
                    PaymentMenu();
                    Receipt();
                    Product.cartList.Clear();
                    completingorder = false;
                }
            }
        }

        // prompts user for a response re placing another order, last method of main arg.
        public static bool AskToOrderAgainQ()
        {
            Console.WriteLine("Would you like to place another order?");
            string userresponse = Validator.GetAValidYorN();
            if (userresponse == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Thank you for ordering from Treat Yo'self!");
                Console.ReadKey();
                return false;
            }
        }
        public static void PrintMenu()
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
        }

        // method for choosing product from menu
        public static int ChooseProduct()
        {
            while (true)
            {
                bool RuningProgram = true;
                while (RuningProgram)
                {
                    //prompts user to purchase a service or item.
                    Console.WriteLine();
                    Console.WriteLine("Pick a menu item to add to the cart.");
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

        //prints the shopping cart contents
        public static double grandtotal = 0;

        //prints the shopping cart contents
        public static void PrintCart()
        {
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\nSHOPPING CART:");

            //Headers for Shopping Cart
            Console.WriteLine($"\n{"NAME",-28}{"QTY",-19}{"TOTAL",-7}");
            Console.WriteLine("=========================   =============      ======\n");

            foreach (Product c in Product.cartList)

            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name,-25}   {c.Quantity,-4}   x  ${c.Price,-4} =  ${groupprice,-4}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }


            grandtotal = (cartTotalPrice * .06) + cartTotalPrice;
            Console.WriteLine($"\n\n{"SUBTOTAL",-15} $ {cartTotalPrice,10:F2}");
            Console.WriteLine($"{"TAX",-15} $ {(cartTotalPrice * .06),10:F2}");
            Console.WriteLine($"{"GRAND TOTAL",-15} $ {grandtotal,10:F2}");

        }

        public static string userPaymentChoice = "";

        //requests desired payment method from user
        public static void PaymentMenu()
        {
            Console.WriteLine("Treat Ya'self by Drones accepts Cash, Check or Credit");
            Console.WriteLine("Which method of payment would you like to use for this order?");


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
            Console.WriteLine("ORDER COMPLETED!\n");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*******************************************************");
            //declares and initializes cart's total price to 0.
            double cartTotalPrice = 0;
            Console.WriteLine("\n\nRECEIPT\n");
            Console.WriteLine($"{"NAME",-28}{"QTY",-19}{"TOTAL",-7}");
            Console.WriteLine("=========================   =============      ======\n");
            foreach (Product c in Product.cartList)
            {
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{c.Name,-25}   {c.Quantity,-4}   x  ${c.Price,-4} =  ${groupprice,-4}");
                cartTotalPrice = cartTotalPrice + groupprice;
            }
            double changeGiven = (Validator.cashpaid - Program.grandtotal);
            grandtotal = (cartTotalPrice * .06) + cartTotalPrice;
            Console.WriteLine($"\n\n{"SUBTOTAL",-20} $ {cartTotalPrice,10:F2}");
            Console.WriteLine($"{"TAX",-20} $ {(cartTotalPrice * .06),10:F2}");
            Console.WriteLine($"{"GRAND TOTAL",-20} $ {grandtotal,10:F2}");
            Console.WriteLine($"{"METHOD OF PAYMENT",-20}   {userPaymentChoice,10:F2}");
<<<<<<< HEAD
            Console.WriteLine($"{"YOUR PAYMENT",-20} $ {Validator.cashpaid,10:F2}");
            Console.WriteLine($"{"YOUR CHANGE",-20} $ {changeGiven,10:F2}");
        } 
        
        //private static void AddToProductList()
        //{
        //    string name = "shampoo";
        //    string category = "item";
        //    string description = "cleans your hair";
        //    int price = 10;

        //    using (FileStream fs = new FileStream("Product List.txt", FileMode.Append, FileAccess.Write))
        //    using (StreamWriter sw = new StreamWriter(fs))            {            

        //        sw.WriteLine($"\n{name}\t{category}\t{description}\t{price}\t");
        //    }
        //}
=======
            if (userPaymentChoice == "cash")
            {
                Console.WriteLine($"{"YOUR PAYMENT",-20} $ {Validator.cashpaid,10:F2}");
                Console.WriteLine($"{"YOUR CHANGE",-20} $ {changeGiven,10:F2}");
            }
            else
            {
                Console.WriteLine($"{"PAYMENT SUBMITTED FOR APPROVAL",-20}");
            }


        }

>>>>>>> 715e9dedf6a2f2ec26fe9359c9932e71aef001bd

    }
}