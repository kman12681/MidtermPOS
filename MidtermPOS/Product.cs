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
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
        }
    }
}
