using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class PurchaseAuthorization
    {
        public static bool AuthPurchase(IVendingMachineProduct selectedProduct, double moneyAvaiable)
        {
            return selectedProduct.Price <= moneyAvaiable;
        }
    }
}
