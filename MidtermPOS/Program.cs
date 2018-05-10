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
            ShowInventory();
           
        }

        public static void ShowInventory()
        {
            
            foreach (Product p in Inventory.FileImport())
            {
                Console.WriteLine($"{p.Name}\t{p.Category}\t{p.Price}\t{p.Description}");
                
            }
        }


    }
}


