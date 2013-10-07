using System;
using System.Linq;

namespace VendingMachineApplication
{
    class ListProductsPart : IVendingMachinePart
    {
        public ListProductsPart()
        {
            Name = "ListProductsPart";
        }

        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            foreach (var displayMessage in obj.GetMachineProducts().Select(product => "Product Name: " +
                                                                                      product.Name +
                                                                                      "\nCode: " +
                                                                                      product.Code +
                                                                                      "\nPrice: " +
                                                                                      product.Price +
                                                                                      "\nQuantity: " +
                                                                                      product.Quantity + "\n"))
            {
                Console.WriteLine(displayMessage);
            }


            Console.WriteLine("Please press any button to go back to the menu...");
            Console.ReadKey();
            return 0;
        }
    }
}
