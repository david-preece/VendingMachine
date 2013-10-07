using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    class CoinHopperPart : IVendingMachinePart
    {
        public CoinHopperPart()
        {
            Name = "CoinHopperPart";
        }

        // Hopper only fields
        private double _coinsAvaiable = 0.0;

        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            switch ((string)args[0])
            {
                case "add":
                    return this.AddCoinsToHopper(args[1]);
                case "remove":
                    return this.RemoveCoinsFromHopper(args[1]);
                case "refund":
                    return this.RefundAllCoinsFromHopper();
                case "amount":
                    return this.PrintAmountOfCoinsInHopper();
                default:
                    return 0;
            }
        }

        private int PrintAmountOfCoinsInHopper()
        {
            Console.Write(this._coinsAvaiable);
            return 5;
        }

        private int RefundAllCoinsFromHopper()
        {
            this._coinsAvaiable = 0.0;
            return this._coinsAvaiable.Equals(0.0) ? 5 : 0;
        }

        private int RemoveCoinsFromHopper(object coins)
        {
            try
            {
                var amountToRemove = double.Parse((string)coins);
                this._coinsAvaiable -= amountToRemove;
                return this._coinsAvaiable > 0.0 ? 5 : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int AddCoinsToHopper(object coins)
        {
            try
            {
                var amountToAdd = double.Parse((string)coins);
                this._coinsAvaiable += amountToAdd;
            }
            catch (Exception)
            {
                return 0;
            }
            return 5;
        }

        public double GetAvailableCoins()
        {
            return this._coinsAvaiable;
        }
    }
}
