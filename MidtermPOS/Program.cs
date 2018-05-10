using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MidtermPOS
{
    class Program
    {
        static void Main(string[] args)
        {
			Menu();

        }



        private static List<Product> ReadFile(string filename)
        {
            List<Product> products = new List<Product>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] tokens = line.Split('\t');
                    string name = tokens[0];
                    string category = tokens[1];
                    string description = tokens[2];
                    double price = double.Parse(tokens[3]);

                    Product p = new Product(name, category, description, price);
                    products.Add(p);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading file.");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return products;
        }

        // menu
		public static void Menu()
        {

            // TAKEN FROM PROGRAM (MAIN ARG)
            Console.WriteLine("Welcome to the ***");
            bool RuningProgram = true;
            while (RuningProgram)
            {
                //prompts user to purchase a service or item.
                Console.WriteLine("Would you like to order a service or purchase an item?");
                Console.Write("Enter 1 for a service or 2 for an item:  ");

				//input validation on user input, converts to int, once validated.
				string userresponse = Console.ReadLine();
				int ServOrItResponse = Validator.ValidNum(userresponse);


				// if user does not choose 1 or 2, it will bounce back to 
				if (ServOrItResponse != 1 || ServOrItResponse != 2)
				{
					continue;
				}

                //display menu



                // TODO:  foreach
            }
        }

    }
}


