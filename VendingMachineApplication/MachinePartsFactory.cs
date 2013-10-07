using System.Collections.Generic;

namespace VendingMachineApplication
{
    public class MachinePartsFactory
    {
        private MachinePartsFactory()
        {
            // Singleton Fatory
        }

        public static List<IVendingMachinePart> CreatePartsList()
        {
            return new List<IVendingMachinePart>
            {
                new ListProductsPart(),
                new MainMenuPart(),
                new PurchaseProductPart(),
                new StockProductPart(),
                new StockProductMenuPart(),
                new CoinHopperPart()
            };
        }
    }
}
