using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPOS
{
    class Cart : Product
    { 
        public Cart(string name, string category, string description, double price, int _quantity) : base(name, category, description, price)
        {
            Quantity = _quantity;
        }
        // converts the Cart item to a string
        public override string ToString()
        {
            return base.ToString() + "{Description}";

        }

        //public string ToStringWithQuantity()
        //{
        //    return ($"{Name}\t\t\t\t{Quantity}");

        //}



        // calculates subtotal immediatelty after delcaring quantity in cart.
        public static double SubTotaler()
        {
            double subTotal = 0;
            foreach (Product item in cartList)
            {
                subTotal += item.Price;
            }
            return subTotal;
        }
    }
}