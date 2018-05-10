using System;
namespace MidtermPOS
{
	public class Validator
	{

		// validate number of services or items chosen, will be used for menu selection as well

		public static int ValidNum(string input)
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
		public double ValidCashInput(string input)
		{
			double ValidCash = 0;
			bool verifying = true;
			while (verifying)
			{
				string _input = Console.ReadLine();
				bool validNum = double.TryParse(_input, out ValidCash);

				if (!validNum)
				{
					Console.WriteLine("Invalid number entered, please enter a valid number.");
					continue;
				}
				else
				{ verifying = false; }

			}
			return ValidCash;
		}
	}
}

