﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{/* POS
includes a class, with name, category, description, massage - DONE
includes a minimum of 12 items, which are stored in a text files - DONE
include validation on if cart is empty - DONE
presents user with a menu, allows them to choose by a number - DONE
allows user to edit or checkout at menu - DONE
user is prompted to choose quantity while picking items - DONE
if the item exists in the cart, the quantity is updated without creating duplicate items - DONE
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
            Console.WriteLine("Welcome to Treat Yo'self by Drones");

            //runs the shoppingcart method
            ShoppingCart();

        }
        // shopping cart method
        public static void ShoppingCart()
        {

            bool shopping = true;
            //while loop for shopping, allowing multiple items to be added
            while (shopping)
            {
                //counter for items being added to the cart
                //iitemadded = Product.cartList.Count();
                double linetotal = 0;

                //while loop for placing an order
                bool placingorder = true;
                while (placingorder)
                {
                    //gets users requested quantity of menu item
                    int menuChoice = ChooseProduct();
                    if(menuChoice == 999)
                    {
                        placingorder = false;
                        shopping = false;
                    }

                    else if (menuChoice == 888)
                    {
                        placingorder = false;
                        shopping = CheckOut();
                    }
                    else
                    {

                        menuChoice--;
                        Console.WriteLine();
                        ViewSingleMenuItem(menuChoice);
                        Console.WriteLine();
                        Console.WriteLine(">> How many would you like?:");
                        Console.WriteLine();      
                        int quantity = Validator.ValidNumAndConvertToWholeNum();


                        // if the quantity to be added isn't 0 and the cart contains the item chosen:
                        if (quantity != 0 && Product.cartList.Contains(Product.products[menuChoice]))
                        {
                            Console.WriteLine();
                            Console.WriteLine("This item already exist in the shopping cart.");
                            int itemIndexInCart = Product.cartList.IndexOf(Product.products[menuChoice]);
                            Product.cartList[itemIndexInCart].Quantity += quantity;
                            ////prints a linetotal
                            linetotal = (Product.cartList[itemIndexInCart].Quantity * Product.cartList[itemIndexInCart].Price);
                            Console.WriteLine();
                            Console.WriteLine(Product.cartList[itemIndexInCart].Name + " | Quantity updated to: " + Product.cartList[itemIndexInCart].Quantity + " x $" + Product.cartList[itemIndexInCart].Price + " = $"+linetotal );
                        }

                        else if (quantity != 0 && !Product.cartList.Contains(Product.products[menuChoice]))
                        {
                            Product.cartList.Add(Product.products[menuChoice]);
                            int newItemIndex = Product.cartList.IndexOf(Product.products[menuChoice]);
                            Product.cartList[newItemIndex].Quantity = quantity;
                            ////prints a linetotal
                            linetotal = (Product.cartList[newItemIndex].Quantity * Product.cartList[newItemIndex].Price);
                            Console.WriteLine();
                            Console.WriteLine(Product.cartList[newItemIndex].Name + " | Quantity of " + quantity + " x $" + Product.cartList[newItemIndex].Price + " = $" + linetotal + "\t*ADDED TO CART*");

                            // increments the interaction with the shopping cart by 1.
                            //itemadded++;  -- may not be needed anymore?
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Nothing added to the cart.");
                        }
                        Console.WriteLine();
                        Console.WriteLine(">> Press any key to continue.");
                        Console.ReadKey();
                        continue;

                    }


                }
 
            }
        }

        public static bool CheckOut()
        {
            bool gobackorleave = CompleteOrder(); // this is now a bool, if order

            if (gobackorleave)
            {
                return AskToOrderAgainQ();
            }
            else
            {
                return true;
            }

        }

        public static bool CompleteOrder()
        {
            bool orderComplete = true;
            PrintCart();
            bool completingorder = true;
            while (completingorder)
            {
                Console.WriteLine();
                Console.WriteLine(">> Would you like to complete, return to the main menu, or cancel this order?\n\nType \"complete\" to complete, \"menu\" to return to the menu or \"cancel\" to cancel:");
                Console.WriteLine();
                string completePurchQ = Console.ReadLine();
                if (completePurchQ == "cancel")
                {
                    Console.WriteLine();
                    Console.WriteLine("Order cancelled.");
                    Product.cartList.Clear();
                    completingorder = false;
                    orderComplete = false;
                }

                else if (completePurchQ == "menu")
                {
                    completingorder = false;
                    orderComplete = false;
                }

                else if (completePurchQ == "complete")
                {
                    PaymentMenu();
                    Receipt();
                    Product.cartList.Clear();
                    completingorder = false;
                    orderComplete = true;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid response.");
                    continue;
                }
              
            }
            return orderComplete;
        }

        // prompts user for a response re placing another order, last method of main arg.
        public static bool AskToOrderAgainQ()
        {
            Console.WriteLine();
            Console.WriteLine(">> Would you like to place another order? (y/n):");
            string userresponse = Validator.GetAValidYorN();
            if (userresponse == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine();
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
                //prints menu
                PrintMenu();
                bool choosingFromMenu = true;
                while (choosingFromMenu)
                {
                    //prompts user to purchase a service or item.
                    Console.WriteLine();
                    Console.WriteLine(">> Type \"add\" to add to the cart, \"edit\" to view and edit items in the cart, \"checkout\" to checkout or \"exit\" to exit:");
                    Console.WriteLine();
                    string userresponse = Console.ReadLine().ToLower();

                    if (userresponse == "exit")
                    {
                        choosingFromMenu = false;
                        return 999;
                    }
                    else if (userresponse == "checkout" && Product.cartList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cannot checkout, the cart is empty!");
                        continue;
                    }
                    else if (userresponse == "checkout")
                    {
                        choosingFromMenu = false;
                        return 888;
                    }
                    else if (userresponse == "edit" && Product.cartList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cannot edit cart items, the cart is empty!");
                        continue;
                    }
                    else if (userresponse == "edit")
                    {
                        EditCart();
                    }
                    else if (userresponse == "add")
                    {
                        bool addingToCart = true;
                        while (addingToCart)
                        {
                            Console.WriteLine();                         
                            Console.WriteLine(">> Enter a menu item number to be added to the cart:");
                            Console.WriteLine();
                            int userpick = Validator.ValidNumAndConvertToWholeNum();
                            // if user does not choose a valid cart item
                            if (userpick < 1 || userpick > Product.products.Count)
                            {
                                Console.WriteLine();
                                Console.WriteLine($">> Invalid entry. Enter a number between 1 and {Product.products.Count}:");
                                continue;
                            }
                            else
                            {
                                return userpick;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                }
            }
        }

        private static void EditCart()
        {
            PrintCart();
            bool editingCart = true;
            while (editingCart)
            {
                int qtyPick;
                int userpick = 0;
                Console.WriteLine();
                Console.WriteLine($">> Enter a cart item number to be edited or type \"menu\" to return to the menu:");
                Console.WriteLine();
                string userresponse = Console.ReadLine().ToLower();
                int.TryParse(userresponse, out userpick);

                if (userresponse != "menu" && userpick > Product.cartList.Count && userpick < 1)
                {
                    continue;
                }

                else if (userresponse == "menu")
                {
                    PrintMenu();
                    editingCart = false;
                }
                else
                {
                    // if user does not choose a valid cart item
                    if (userpick < 1 || userpick > Product.cartList.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Invalid input.");                        
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();                     
                        Console.WriteLine(">> Enter a new quantity for this item:");
                        Console.WriteLine();
                        qtyPick = Validator.ValidNumAndConvertToWholeNum();
                        double linetotal = (Product.cartList[userpick-1].Quantity * Product.cartList[userpick-1].Price);
                        Console.WriteLine();
                        Console.WriteLine(Product.cartList[userpick-1].Name + " | Quantity updated to: " + qtyPick+ " x $" + Product.cartList[userpick-1].Price + " = $" + linetotal);
                        Console.WriteLine();                       
                        

                        userpick--;

                    }

                    if (qtyPick == 0)
                    {
                        Product.cartList.RemoveAt(userpick);
                        Console.WriteLine();
                        Console.WriteLine("Cart item removed!");
                        PrintMenu();
                        //itemadded--; may not be needed

                    }
                    else
                    {
                        Product.cartList[userpick].Quantity = qtyPick;
                        PrintMenu();
                    }
                    editingCart = false;
                }
            }
        }       

        // view a specific menu item
        public static void ViewSingleMenuItem(int choice)
        {
            Console.WriteLine(Product.products[choice]);
        }
        

        //  valudates menuchoice
        public static bool IsValidMenuChoice(int _input)
        {
            _input = Validator.ValidNumAndConvertToWholeNum();
            if (_input <= 0 && _input > Product.products.Count())
            {
                Console.WriteLine();
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
            Console.WriteLine($"\n{"CART ID",-8}{"NAME",-29} {"QTY",-17}  {"TOTAL",-7}");
            Console.WriteLine("======= ===========================   =============      ======\n");

            int cartCount = 0;
            foreach (Product c in Product.cartList)

            {
                cartCount++;
                double groupprice = (c.Quantity * c.Price);
                Console.WriteLine($"{cartCount,3} --- {c.Name,-25}     {c.Quantity, -3}( x ${c.Price, -4})      ${groupprice,-5}");
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
            Console.WriteLine();
            Console.WriteLine("----------------------------CHECKOUT----------------------------");
            Console.WriteLine();
            Console.WriteLine("Treat Yo'self by Drones accepts \"Cash\", \"Check\" or \"Credit\"");
            Console.WriteLine();
            Console.WriteLine(">> Which method of payment would you like to use for this order?:");
            Console.WriteLine();


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
            Console.WriteLine();
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


    }
}