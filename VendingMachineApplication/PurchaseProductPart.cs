using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    class PurchaseProductPart : IVendingMachinePart
    {
        public PurchaseProductPart()
        {
            Name = "PurchaseProductPart";
        }

        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            try
            {
                var userInput = args[0];
                foreach (var product in obj.GetMachineProducts().Where(product => product.Code == (string)userInput))
                {
                    if (product.Quantity < 1) throw new Exception();
                   // if(obj.GetSingleProduct("CoinHopperPart"))

                    var inputCode = new object[] {userInput, (product.Quantity - 1)};
                    obj.CallPartActions("StockProductPart", inputCode);
                }

                Console.WriteLine("You have successfully brought: " +
                                  obj.GetSingleProduct((string)args[0]).Name + "\nThere are " +
                                  obj.GetSingleProduct((string)args[0]).Quantity + " left.\n");
                return 5;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
