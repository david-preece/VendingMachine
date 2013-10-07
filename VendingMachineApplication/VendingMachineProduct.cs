using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class VendingMachineProduct : IVendingMachineProduct
    {
        public VendingMachineProduct(string name, double price, int quantity, string code)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Code = code;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
    }
}
