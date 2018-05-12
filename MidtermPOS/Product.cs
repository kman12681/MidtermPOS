using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidtermPOS
{


    class Product
    {

        public static List<Product> cartList = new List<Product>();

        private string name;
        private string category;
        private string description;
        private double price;
        private int quantity;

        public Product(string name, string category, string description, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public static List<Product> products = FileImport();

        public static List<Product> FileImport()

        {
            List<Product> products = ReadFile("Product List.txt");
            return products;

            List<Product> ReadFile(string filename)
            {
                products = new List<Product>();
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



        public override string ToString()
        {

            return ($"{Name,-25}    ${Price,3}");
        }
        public string ToStringWithQuantity()
        {
            return ($"{Name,-25}    #{Quantity,3}");

        }


    }
}