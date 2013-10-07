using System.Collections.Generic;
using NUnit.Framework;
using VendingMachineApplication;

namespace VMUnitTests
{
    [TestFixture]
    public class CoinHopperPartTests
    {
        private List<IVendingMachineProduct> _products;
        private VendingMachine _vendingMachine;
        private CoinHopperPart _hopperPart;

        [SetUp]
        public void SetupTests()
        {
            this._hopperPart = new CoinHopperPart();
            this._products = MachineProductsFactory.CreateProductsList();
            this._vendingMachine = new VendingMachine(MachinePartsFactory.CreatePartsList(), MachineProductsFactory.CreateProductsList());
        }

        [Test]
        public void ClassShouldExistTest()
        {
            Assert.IsNotNull(this._hopperPart);
        }

        [Test]
        public void ShouldBeAbleToRetrieveAvailableCoins()
        {
            var actual = this._hopperPart.GetAvailableCoins();
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ShouldBeAbleToAddCoinsToHopperTest()
        {
            var expected = 5;

            var actual = this._hopperPart.DoAction(new string[] {"add", ".50"});

            Assert.AreEqual(expected, actual, "Assert failed, expected: 5");
        }

        [Test]
        public void ShouldbeAbleToRemoveCoinsFromHopperTest()
        {
            var expected = 5;
            this._hopperPart.DoAction(new string[] { "add", ".66" });
            var actual = this._hopperPart.DoAction(new string[] {"remove", ".45"});

            Assert.AreEqual(expected, actual, "Assert failed, expected 5");
        }

        [Test]
        public void ShouldNotBeAbleToRemoveCoinsIntoNegativeTest()
        {
            var expected = 0;

            var actual = this._hopperPart.DoAction(new string[] {"remove", ".45"});
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldPrintAvailableCoinsToScreen()
        {
            this._hopperPart.DoAction(new string[] {"add", ".66"});
            var expected = 5;
            var actual = this._hopperPart.DoAction(new string[] {"amount"});
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldRefundAllCoins()
        {
            var expected = 5;
            this._hopperPart.DoAction(new string[] {"add", ".66"});
            var actual = this._hopperPart.DoAction(new string[] {"refund"});
            Assert.AreEqual(expected, actual);
        }
    }
}
