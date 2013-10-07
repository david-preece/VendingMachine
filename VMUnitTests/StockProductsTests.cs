using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VendingMachineApplication;

namespace VMUnitTests
{
    [TestFixture]
    public class StockProductsTests
    {
        private List<IVendingMachineProduct> _products;
        private VendingMachine _vendingMachine;

        [SetUp]
        public void SetupTests()
        {
            this._products = MachineProductsFactory.CreateProductsList();
            this._vendingMachine = new VendingMachine(MachinePartsFactory.CreatePartsList(), MachineProductsFactory.CreateProductsList());
        }

        [Test]
        public void ShouldUpdateStockQuantityTest()
        {
            var expected = 5;
            var args = new string[] {"A1", "4"};
            var actual = this._vendingMachine.CallPartActions("StockProductPart", args);

            Assert.AreEqual(expected, actual, "Assert Failed");
        }

        [Test]
        public void StockingShouldFailWithIncorrectCode()
        {
            var expected = 0;
            var args = new string[] {"JJ", "1"};
            var actual = this._vendingMachine.CallPartActions("StockProductMenuPart", args);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StockingShouldFailWithEmptyArgs()
        {
            var expected = 0;
            var args = new object[] {"", ""};
            var actual = this._vendingMachine.CallPartActions("StockProductMenuPart", args);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldBeAbleToUpdateStockThroughMenu()
        {
            var expected = 5;
            var code = "A1";
            var quantity = "1";

            var actual = this._vendingMachine.CallPartActions("StockProductMenuPart", new string[] {code, quantity});

            Assert.AreEqual(expected, actual);
        }
    }
}
