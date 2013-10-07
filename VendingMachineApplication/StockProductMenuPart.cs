using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO include maximum stock quantity to stop unrealistic quantities of products in machine
namespace VendingMachineApplication
{
    class StockProductMenuPart : IVendingMachinePart
    {
        public StockProductMenuPart()
        {
            Name = "StockProductMenuPart";
        }
        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            var userInput = args[0];
            var stockToAdd = 0;

            if (!(obj.GetMachineProducts().Any(product => product.Code == (string)userInput)))
            {
                Console.WriteLine("No product found");
                return 0;
            }

            try
            {
                stockToAdd = int.Parse((string)args[1]) + obj.GetSingleProduct((string)args[0]).Quantity;
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a correct stock quantity...");
                return 0;
            }

            foreach (var outputProduct in obj.GetMachineProducts()
                .Where(product => product.Code == (string)userInput)
                .Select(product => "Product: " + product.Name + " has " + product.Quantity + " item(s) left"))
            {
                Console.WriteLine(outputProduct);
            }

            if ((int)obj.CallPartActions("StockProductPart", new object[] {userInput, stockToAdd}) == 0)
                return 0;

            foreach (var outputProduct in obj.GetMachineProducts()
                .Where(product => product.Code == (string)userInput)
                .Select(
                    product =>
                        product.Name + " has been updated with " + stockToAdd + " items.\n New quantity is " +
                        product.Quantity))
            {
                Console.WriteLine(outputProduct);
            }

            return 5;
        }
    }
}
