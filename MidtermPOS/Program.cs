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
    }
}


