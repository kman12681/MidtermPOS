using System;
using System.Text.RegularExpressions;

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
                Console.WriteLine("Enter a valid check number:");
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
                Console.WriteLine("Please enter a valid amount of cash.  (Dollars only, change is not accepted)");
                string _input = Console.ReadLine();
                bool validNum = int.TryParse(_input, out convertNum);

                if (!validNum)
                {
                    Console.WriteLine("Invalid cash amount.");
                    continue;
                }
                else
                    Console.WriteLine("Valid amount of cash accepted!");
                { verifying = false; }

            }
            return convertNum;
        }

        public static string GetAValidYorN()
        {
            bool askingYorN = true;
            string response = "";
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
        public static double ValidateCreditCard(string paymentMethod)
        {

            while (true)
            {
                Console.WriteLine("Please enter credit card number");
                //string payment = Console.ReadLine();
                long paymentDouble = ValidNumAndConvertToWholeLong();

                if (paymentMethod == "credit" && Regex.IsMatch(paymentDouble.ToString(), @"\b(?:3[47]\d|(?:4\d|5[1-5]|65)\d{2}|6011)\d{12}\b"))
                {
                    Console.WriteLine("Thank you for entering a credit card number!");
                    return paymentDouble;


                }
                else
                {
                    Console.WriteLine("That was not a valid credit card number");
                }
            }
        }

        //public static double VerifyAmountPaid()
        //{


        //}
    }
}
