using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineApplication
{
    public class VendingMachine
    {

        private List<IVendingMachinePart> _machineParts { get; set; }
        private List<IVendingMachineProduct> _machineProducts { get; set; }

        internal List<IVendingMachineProduct> GetMachineProducts()
        {
            return this._machineProducts;
        }

        internal IVendingMachineProduct GetSingleProduct(string code)
        {
            return this._machineProducts.FirstOrDefault(product => product.Code == code);
        }

        public VendingMachine(List<IVendingMachinePart> parts, List<IVendingMachineProduct> products)
        {
            this._machineParts = parts;
            this._machineProducts = products;
            this.DisplayWelcome();
        }

        public void ResetProducts()
        {
            this._machineProducts = MachineProductsFactory.CreateProductsList();
        }

        public object CallPartActions(string partName, object[] args = null)
        {
            return _machineParts.Where(product => product.Name == partName).Select(partToCall => partToCall.DoAction(args, this)).FirstOrDefault();
        }

        public void DisplayWelcome()
        {
            Console.WriteLine("Hello and welcome to VENDOR 1.0\n");
        }

        public void StartTransaction()
        {
            CallPartActions("MainMenuPart", new object[]{});
        }

        public void EndTransaction()
        {
            // TODO add code to "finish" the transaction
        }
    }
}
