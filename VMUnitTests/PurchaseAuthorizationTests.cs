using System;
using NUnit.Framework;
using VendingMachineApplication;

namespace VMUnitTests
{
    [TestFixture]
    public class PurchaseAuthorizationTests
    {
        [Test]
        public void ShouldAuthPurchase()
        {
            // Running tests with dependency injection
            var expected = true;
            var actual = PurchaseAuthorization.AuthPurchase(new VendingMachineProduct ("C", 0.8, 5, "A1"), 1.0);

            Assert.AreEqual(expected, actual, "Assert Failed, returned FALSE");
        }

        [Test]
        public void ShouldFailAuthPurchase()
        {
            var expected = false;
            var actual = PurchaseAuthorization.AuthPurchase(new VendingMachineProduct("C", 0.8, 5, "A1"), 0.2);

            Assert.AreEqual(expected, actual, "Asser failed, returned TRUE");
        }
    }
}
