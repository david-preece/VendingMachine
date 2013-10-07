using System;

namespace VendingMachineApplication
{
    class MainMenuPart : IVendingMachinePart
    {
        public MainMenuPart()
        {
            Name = "MainMenuPart";
        }

        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            var menuInput = 0;

            while (menuInput < 1 || menuInput > 4)
            {
                Console.WriteLine("\nPlease select from the following options:");
                Console.WriteLine("1 - List Products\n" +
                                  "2 - Make Purchase\n" +
                                  "3 - Stock Up Products\n" +
                                  "4 - Exit Machine");

                try
                {
                    menuInput = int.Parse(UserInput.GetUserInput(""));
                    if (menuInput < 1 || menuInput > 4)
                    {
                        menuInput = 0;
                        continue;
                    }

                    menuInput = this.MenuAction(menuInput, obj);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return 0;
        }

        private int MenuAction(int menuInput, VendingMachine parentVendingMachine)
        {
            switch (menuInput)
            {
                case 1:
                    return (int)parentVendingMachine.CallPartActions("ListProductsPart");
                case 2:
                    return (int)parentVendingMachine.CallPartActions("PurchaseProductPart", new[]{UserInput.GetUserInput("Please enter the code of the product you wish to purchase:\n")});
                case 3:
                    var productCode = UserInput.GetUserInput("Please enter the code of the product you wish to stock:");
                    var quantityAmount = UserInput.GetUserInput("Please enter the amount to add to stock:");
                    return (int)parentVendingMachine.CallPartActions("StockProductMenuPart", new[]{productCode, quantityAmount});
                case 4:
                    Environment.Exit(0);
                    return 0;
                default:
                    return -1;
            }
        }
    }
}
