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



    }
}

