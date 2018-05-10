using System;
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
<<<<<<< HEAD
            ShowInventory();
           
        }
=======
			List<Product> products = ReadFile("Product List.txt");

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
>>>>>>> e1895dcf6f00ef4d8550b061f56791a4022deffa

        public static void ShowInventory()
        {
            
            foreach (Product p in Inventory.FileImport())
            {
                Console.WriteLine($"{p.Name}\t{p.Category}\t{p.Price}\t{p.Description}");
                
            }
        }

<<<<<<< HEAD
=======
        // menu
		public void Menu()
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
                int ServOrItResponse = Validator.ValidNum(Console.ReadLine());


                // if user does not choose 1 or 2, it will bounce back to 
                if (ServOrItResponse != 1 || ServOrItResponse != 2)
                {
                    continue;
                }


                // TODO:  foreach
            }
        }
>>>>>>> e1895dcf6f00ef4d8550b061f56791a4022deffa

    }
}


