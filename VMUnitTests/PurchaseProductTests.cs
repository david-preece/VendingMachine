using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VendingMachineApplication;

namespace VMUnitTests
{
    [TestFixture]
    public class PurchaseProductTests
    {

        private List<IVendingMachineProduct> _products;
        private VendingMachine _vendingMachine;

        [SetUp]
        public void SetupTests()
        {
            this._products = MachineProductsFactory.CreateProductsList();
            this._vendingMachine = new VendingMachine(MachinePartsFactory.CreatePartsList(), MachineProductsFactory.CreateProductsList());
            this._vendingMachine.CallPartActions("CoinHopperPart", new string[] {"add", "1.0"});
        }

        [Test]
        public void PurchaseShouldPassTest()
        {
            var expected = 5;
            var productCode = new string[] { "A1" };
            var actual = this._vendingMachine.CallPartActions("PurchaseProductPart", productCode);

            Assert.AreEqual(expected, actual, "Test failed, Expected 5");
        }

        [Test]
        public void PurchaseShouldFailTest()
        {
            var expected = 0;
            var productCode = new string[] { "JJ" };
            var actual = this._vendingMachine.CallPartActions("PurchaseProductPart", productCode);

            Assert.AreEqual(expected, actual, "Test failed, expected 0");
        }

        [Test]
        public void PurchaseShouldUpdateQuantityTest()
        {
            var machineProducts = this._vendingMachine.GetMachineProducts();

            var expected = 0;
            foreach (var product in machineProducts.Where(product => product.Code == "A1"))
                expected = product.Quantity - 1;

            var productCode = new string[] { "A1" };
            this._vendingMachine.CallPartActions("PurchaseProductPart", productCode);

            machineProducts = this._vendingMachine.GetMachineProducts();
            var actual = 0;
            foreach (var product in machineProducts.Where(product => product.Code == "A1"))
                actual = product.Quantity;

            Console.WriteLine((expected.ToString()) + (actual.ToString()));
            Assert.AreEqual(expected, actual, "Assert failed");
        }

        [Test]
        public void PurchaseShouldFailWithoutCorrectCoinsTest()
        {
            var expected = 0;
            var actual = this._vendingMachine.CallPartActions("PurchaseProductPart", new object[] {"A1"});
            Assert.AreEqual(expected, actual);
        }
    }
}
