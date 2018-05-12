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
                Console.WriteLine("Your Account and Routing number are already stored in our system.");
                Console.WriteLine("Please locate and enter the 3 digit check number being used for this order.");
                string _input = Console.ReadLine();
                Match match = Regex.Match(_input,"^[0-9]{3}$");
                bool validNum = int.TryParse(_input, out validnum);
                if (!match.Success || validNum != true)
                {
                    Console.WriteLine("Invalid check number!");
                }
                else
                {
                    Console.WriteLine("Valid Check Number!");
                    verifyingCheckNumn = false;
                }

            }
            return validnum;
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
                Console.WriteLine("Please enter a valid Visa/Mastercard credit card number. ");
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
