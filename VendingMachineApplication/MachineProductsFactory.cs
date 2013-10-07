using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class MachineProductsFactory
    {
        private MachineProductsFactory()
        {
            // Singleton Factory
        }

        public static List<IVendingMachineProduct> CreateProductsList()
        {
            // Using LINQ to load the make shift products file
            // No Need for LINQ to return just a single value to make the list
            XElement productsFile = XElement.Load(@".\Products.xml");

            return (from element in productsFile.Elements() let name = element.Element("name").Value
                    let price = double.Parse(element.Element("price").Value)
                    let quantity = int.Parse(element.Element("quantity").Value)
                    let code = element.Element("code").Value
                    select new VendingMachineProduct(name, price, quantity, code)).Cast<IVendingMachineProduct>().ToList();

            /*
            // TODO populate list with products when available
            return new List<IVendingMachineProduct>()
            {
                new ProductCoke("A1"), new ProductWalkersSalted("A1"), new ProductWalkersVin("A2"),
                new ProductWalkersCheese("A4")
            };*/
        }
    }
}
