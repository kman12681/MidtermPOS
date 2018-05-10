﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS

{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the ***");

		}
		public static int ChooseProduct()
		{
			while (true)
			{
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

		public static void ViewFullMenu()
		{
			foreach (Product p in Product.products)
			{
				Console.WriteLine(p);
			}
		}

		public static void ShoppingCart()
		{
			List<Product> cart = new List<Product>();
			bool shopping = true;
			while (shopping)
			{
				int menuChoice = ChooseProduct();
				menuChoice--;

				Console.WriteLine("How many would you like?");
				//TODO: input validation on this
				int quantity = int.Parse(Console.ReadLine());
				for (int i = 0; i < quantity; i++)
				{
					cart.Add(Product.products[menuChoice - 1]);
				}
				Console.WriteLine("Keep shopping?");
				string response = Console.ReadLine();
				if (response == "y")
				{
					continue;
				}
				else
				{
					shopping = false;
				}
			}         
		}
	}
}
