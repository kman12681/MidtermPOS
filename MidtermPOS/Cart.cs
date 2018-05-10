using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{
    class Cart : Product
    {
        public Cart(string name, string category, string description, double price) :base(name, category, description, price)
        {

        }

        public override string ToString()
        {
            return base.ToString() + $"{Quantity}";
        }
    }
}
