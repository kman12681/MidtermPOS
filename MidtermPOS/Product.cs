using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{
    class Product
    {
        private string name;
        private string category;
        private string description;
        private double price;

        public Product(string name, string category, string description, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Price = price;
        }

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }

        public override string ToString()
        {
            return ($"{Name}\t\t\t{Category}\t\t${Price}\t\t{Description}");

        }

    }
}
