using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace MidtermPOS
{
    public class Validator
    {
        // converts string input to a whole num, loops until valid whole num is entered. returns a valid whole num.
        public static int ValidNumAndConvertToWholeNum()
        {
            int convertNum = 0;
            bool verifying = true;
            while (verifying)
            {
                string _input = Console.ReadLine();
                bool validNum = int.TryParse(_input, out convertNum);

                if (!validNum || convertNum < 0)
                {
                    Console.WriteLine("Invalid number entered, please enter a valid number.");
                    continue;
                }
                else
                { verifying = false; }

            }
            return convertNum;
        }

        //converts string input to a double num loops until valid double num is entered. returns a valid double num.
        public static double ValidDoubler()
        {
            double convertNum = 0;
            bool verifying = true;
            while (verifying)
            {
                string _input = Console.ReadLine();
                bool validNum = double.TryParse(_input, out convertNum);

                if (!validNum)
                {
                    Console.WriteLine("Invalid number entered, please enter a valid number.");
                    continue;
                }
                else
                { verifying = false; }

            }
            return convertNum;
        }

        // converts string input to an int, regex for 3 digit check number format.  returns a valid num.
        public static int ValidCheckNumber()
        {
            int validnum = 0;
            bool verifyingCheckNumn = true;
            while (verifyingCheckNumn)
            {
                
                Console.WriteLine("\nPlease locate and enter the 4 digit check number being used for this order.");
                string _input = Console.ReadLine();
                Match match = Regex.Match(_input,"^[0-9]{4}$");
                bool validNum = int.TryParse(_input, out validnum);
                if (!match.Success || validNum != true)
                {
                    Console.WriteLine("Invalid Check Number!");
                }
                else
                {
                    Console.WriteLine("Valid Check Number!");
                    verifyingCheckNumn = false;
                }

            }
            return validnum;
        }

        //Method for verifying a valid routing number for checking account
        //Converts string input to an int, regex for 9 digit routing number format.  Will return a valid routing number.
        public static int ValidRoutingNumber()
        {
            int validRouteNum = 0;
            bool verifyingRouteNum = true;
            while (verifyingRouteNum)
            {
                Console.WriteLine("\nPlease enter your 9 digit Routing Number.");
                string routenum = Console.ReadLine();
                Match matchroute = Regex.Match(routenum, "^[0-9]{9}$");
                bool validRouteNum1 = int.TryParse(routenum, out validRouteNum);
                if (!matchroute.Success || validRouteNum1 != true)
                {
                    Console.WriteLine("Invalid Routing Number!");
                }
                else
                {
                    Console.WriteLine("Valid Routing Number!");
                    verifyingRouteNum = false;
                }

            }
            return validRouteNum;
        }



        //Method for verifying a valid checking account number
        //Converts string input to an int, regex for 8 digit checking account number format.  Will return a valid checking account number.
        public static int ValidChkAcctNumber()
        {
            int validChkAcctNum = 0;
            bool verifyingChkAcctNum = true;
            while (verifyingChkAcctNum)
            {
                Console.WriteLine("\nChecking Account information is required inorder to process check payment.");
                Console.WriteLine("Please enter your 8 digit Checking Account Number.");
                string chkacctnum = Console.ReadLine();
                Match matchchkacct = Regex.Match(chkacctnum, "^[0-9]{8}$");
                bool validChkAcctNum1 = int.TryParse(chkacctnum, out validChkAcctNum);
                if (!matchchkacct.Success || validChkAcctNum1 != true)
                {
                    Console.WriteLine("Invalid Checking Account number!");
                }
                else
                {
                    Console.WriteLine("Valid Checking Account Number!");
                    verifyingChkAcctNum = false;
                }

            }
            return validChkAcctNum;
        }

        public static double cashpaid = 0;
        // converts a string input into cash and change. returns cash value in "double".
        public static double ValidCashAmount()
        {
            cashpaid = 0;
            bool verifying = true;
            while (verifying)
            {
                Console.WriteLine("Please enter a valid amount of cash that will be paid.");
                string _input = Console.ReadLine();
                bool validNum = double.TryParse(_input, out cashpaid);

                if (!validNum)
                {
                    Console.WriteLine("Invalid cash amount.");
                    continue;
                }

                if (Program.grandtotal > cashpaid)
                {
                    Console.WriteLine($"You entered ${cashpaid} while the grand total is ${Program.grandtotal}");
                    continue;
                }
                else
                {
                    verifying = false;
                }

            }
            return Math.Round(cashpaid, 2);
        }

        // takes userinput until a valid "y" or "n" answer is provided. returns "y" or "n"
        public static string GetAValidYorN()
        {
            bool askingYorN = true;
            string response="";
            while (askingYorN)
            {

                response = Console.ReadLine().ToLower();
                if (response != "y" && response != "n")
                {
                    Console.WriteLine("Invalid response.");
                    Console.WriteLine("Please enter (y/n).");
                    continue;
                }
                else { askingYorN = false; }
                
            }
            return response;
        }

        // takes user input, prampts for a valid payment method until one is chosen, returns payment method.
        public static string ValidPaymentMethod()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (!(input == "cash") && !(input == "credit") && !(input == "check") && !(input == "gift card"))
                {
                    Console.WriteLine("Invalid payment method entered. Please enter either cash, check or credit.");

                }
                else
                {
                    return input;
                }
            }
        }

        //takes user input, converts to int, checks for 16 digit format
        //does the same for an exp date in mm/YY format
        //does the same for a 3 digit CVV number
        public static void ValidateCreditCard()
        {

            bool askingforDaCC = true;
            while (askingforDaCC)
            {
                //user prompted to enter a CC num (comes in as string)
                Console.WriteLine("Please enter a valid 16 digit Visa/Mastercard credit card number. No spaces");
                string _input = Console.ReadLine();


                //converts to long, if _input is integers
                bool validNum = long.TryParse(_input, out long convertNum);
                if (!validNum)
                {
                    Console.WriteLine("Invalid number entered, please enter a valid number.");
                    continue;
                }

                else
                {
                    if (Regex.IsMatch(convertNum.ToString(), "^([0-9]){16}$"))

                    {

                        Console.WriteLine("Thank you for entering a credit card number!");
                        askingforDaCC = false;
                    }

                    // (valid doubles entered at input and valid CC format, per regex)
                    else
                    {
                        Console.WriteLine("You've entered an invalid credit card number");
                        continue;
                    }

                }
            }
            bool AskForExpDate = true;
            while (AskForExpDate)
            {
                Console.WriteLine("Please enter a valid Expiration Date for the card.\nFormat: mm/YY");
                string _i = Console.ReadLine();
                DateTime expDate;
                string format = "MM/yy";

                DateTime.TryParseExact(_i, format, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out expDate);

                int result = DateTime.Compare(expDate, DateTime.Today);
                if (result < 0)

                {
                    Console.WriteLine("You've entered an invalid expiration date");
                    continue;
                }
                else
                {
                    AskForExpDate = false;
                }
            }

            bool AskForCVV = true;
            while (AskForCVV)
            {
                Console.WriteLine("Please enter a valid 3 digit CVV");
                string _input = Console.ReadLine();

                //converts to int, if _input is integers
                bool validNum = int.TryParse(_input, out int convertNum);
                if (!validNum)
                {
                    Console.WriteLine("Invalid CVV number entered, please enter a valid 3 digit CVV.");
                    continue;
                }

                else
                {
                    if (Regex.IsMatch(convertNum.ToString(), "^([0-9]){3}$"))

                    {

                        Console.WriteLine("Thank you for entering a valid CVV number!");
                        AskForCVV = false;
                    }

                    // (valid doubles entered at input and valid CC format, per regex)
                    else
                    {
                        Console.WriteLine("You've entered an invalid CVV number");
                        continue;
                    }

                }
            }
        }      

       
    }
}
