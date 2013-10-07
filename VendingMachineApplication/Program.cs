using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new VendingMachine(MachinePartsFactory.CreatePartsList(),
                MachineProductsFactory.CreateProductsList());

            vm.StartTransaction();
            Console.ReadKey();
        }
    }
}
