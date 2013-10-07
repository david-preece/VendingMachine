using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VendingMachineApplication
{
    class StockProductPart : IVendingMachinePart
    {
        public StockProductPart()
        {
            Name = "StockProductPart";
        }

        public string Name { get; set; }
        public object DoAction(object[] args, VendingMachine obj = null)
        {
            try
            {
                var productsFile = XElement.Load(@".\Products.xml");

                var product = from pro in productsFile.Elements()
                              where pro.Element("code").Value == (string)args[0]
                              select pro.Element("quantity");

                foreach (var i in product)
                    i.SetValue(args[1].ToString());

                productsFile.Save(@".\Products.xml");

                // Reset the products list
                obj.ResetProducts();

                return 5;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
