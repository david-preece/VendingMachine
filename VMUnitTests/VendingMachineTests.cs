using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VendingMachineApplication;

namespace VMUnitTests
{
    [TestFixture]
    public class VendingMachineTests
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
        public void ShouldCreateProductListTest()
        {
            var products = this._products;
            
            Assert.IsNotEmpty(products, "Test Failed, list is empty");
        }

        [Test]
        public void B1ShouldBeFantaTest()
        {
            var expected = "Fanta";

            foreach (var tester in this._products.Where(product => product.Code == "B1"))
                Assert.AreEqual(expected, tester.Name, "Test Failed, expected Fanta");
        }
    }
}
