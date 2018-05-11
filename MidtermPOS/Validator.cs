using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace MidtermPOS
{
    public class Validator
    {
        // validate number of services or items chosen, will be used for menu selection as well
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

        //validate amount of cash given.
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

        public static int ValidCheckNumber()
        {
            int validnum = 0;
            bool verifyingCheckNumn = true;
            while (verifyingCheckNumn)
            {
                Console.WriteLine("Your Account and Routing number are already stored in our system.");
                Console.WriteLine("Please locate and enter the check number being used for this order.");
                string _input = Console.ReadLine();
                Match match = Regex.Match(_input, "([0-9]){3}");
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

        public static double ValidCashAmount()
        {
            int convertNum = 0;
            bool verifying = true;
            while (verifying)
            {
                Console.WriteLine("Please enter a valid amount of cash that will be paid.  (Dollars only, change is not accepted)");
                string _input = Console.ReadLine();
                bool validNum = int.TryParse(_input, out convertNum);

                if (!validNum)
                {
                    Console.WriteLine("Invalid cash amount.");
                    continue;
                }

                if (Program.grandtotal > convertNum)
                {
                    Console.WriteLine($"You entered ${convertNum}.  The grand total is {Program.grandtotal}");
                    continue;
                }
                else
                {
                    double changeGiven = (Program.grandtotal - convertNum);
                    Console.WriteLine($"Your change is {convertNum}");
                    verifying = false;
                }

            }
            return convertNum;
        }

        public static string GetAValidYorN()
        {
            bool askingYorN = true;
            string response="";
            while (askingYorN)
            {

                response = Console.ReadLine();
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

        public static string ValidPaymentMethod()
        {
            //bool AskingForPaymentMethod = true;
            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (!(input.ToLower() == "cash") && !(input.ToLower() == "credit") && !(input.ToLower() == "check") && !(input.ToLower() == "gift card"))
                {
                    Console.WriteLine("Invalid payment method entered. Please enter either cash, check or credit.");


                    // AskingForPaymentMethod = true;

                }
                else
                {
                    return input;
                }
            }
        }

        // checks for valid long number
        public static long ValidNumAndConvertToWholeLong()
        {
            long convertNum = 0;
            bool verifying = true;
            while (verifying)
            {
                string _input = Console.ReadLine();
                bool validNum = long.TryParse(_input, out convertNum);

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

        //checks for valid credit card number
        public static void ValidateCreditCard()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "MM/yy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

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
                Console.WriteLine("Please enter a valid Expiration Date for the card.\n Format: mm/YY");
                string _input = Console.ReadLine();

                DateTime expDate = DateTime.Parse(_input);

                if (expDate > DateTime.Now)

                {

                    Console.WriteLine("Thank you for entering a validexpiration date!");
                    AskForExpDate = false;
                }

                // (valid doubles entered at input and valid CC format, per regex)
                else
                {
                    Console.WriteLine("You've entered an invalid expiration date");
                    continue;
                }
            }


            bool AskForCVV = true;
            while(AskForCVV)
            {
                Console.WriteLine("Please enter a valid CVV");
                string _input = Console.ReadLine();

                //converts to int, if _input is integers
                bool validNum = int.TryParse(_input, out int convertNum);
                if (!validNum)
                {
                    Console.WriteLine("Invalid CVV number entered, please enter a valid  CVV number.");
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
