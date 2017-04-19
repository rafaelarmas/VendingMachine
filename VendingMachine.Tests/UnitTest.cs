using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Products;

namespace VendingMachine.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SelectAnyProductShouldReturnInsertCoin()
        {
            var vendingMachine = new VendingMachine();
            Assert.AreEqual(vendingMachine.SelectProduct(new Cola()), "INSERT COIN");
            Assert.AreEqual(vendingMachine.SelectProduct(new Chips()), "INSERT COIN");
            Assert.AreEqual(vendingMachine.SelectProduct(new Candy()), "INSERT COIN");
        }

        [TestMethod]
        public void InsertFiftyPenceCoinForColaShouldDisplayFiftyPenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Cola());
            Assert.AreEqual(vendingMachine.InsertCoin(0.5), "PRICE £0.50");
        }

        [TestMethod]
        public void InsertTwentyPenceCoinForColaShouldDisplayEightyPenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Cola());
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.80");
        }

        [TestMethod]
        public void InsertPoundCoinForColaShouldDisplayThankYou()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Cola());
            Assert.AreEqual(vendingMachine.InsertCoin(1), "THANK YOU");
        }

        [TestMethod]
        public void InsertMultipleCoinsForColaShouldDisplayThankYou()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Cola());
            Assert.AreEqual(vendingMachine.InsertCoin(0.5), "PRICE £0.50");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.30");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.10");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "THANK YOU");
        }

        [TestMethod]
        public void InsertTenPenceCoinForChipsShouldDisplayFortyPenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Chips());
            Assert.AreEqual(vendingMachine.InsertCoin(0.1), "PRICE £0.40");
        }

        [TestMethod]
        public void InsertTwentyPenceChipsForChipsShouldDisplayThirtyPenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Chips());
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.30");
        }

        [TestMethod]
        public void InsertFiftyPenceCoinForChipsShouldDisplayThankYou()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Chips());
            Assert.AreEqual(vendingMachine.InsertCoin(1), "THANK YOU");
        }

        [TestMethod]
        public void InsertMultipleCoinsForChipsShouldDisplayThankYou()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Chips());
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.30");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.10");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "THANK YOU");
        }

        [TestMethod]
        public void InsertFiftyPenceCoinForCandyShouldDisplayFifteenPenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Candy());
            Assert.AreEqual(vendingMachine.InsertCoin(0.5), "PRICE £0.15");
        }

        [TestMethod]
        public void InsertTwentyPenceCoinForCandyShouldDisplayFortyFivePenceRemainingCost()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Candy());
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "PRICE £0.45");
        }

        [TestMethod]
        public void InsertMultipleCoinsForCandyShouldDisplayThankYou()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct(new Candy());
            Assert.AreEqual(vendingMachine.InsertCoin(0.5), "PRICE £0.15");
            Assert.AreEqual(vendingMachine.InsertCoin(0.2), "THANK YOU");
        }

        [TestMethod]
        public void InsertTenPenceCoinThenCancelShouldDisplayInsertCoin()
        {
            var vendingMachine = new VendingMachine();
            Assert.AreEqual(vendingMachine.InsertCoin(0.1), "SELECT PRODUCT");
            Assert.AreEqual(vendingMachine.Cancel(), "INSERT COIN");
        }
    }
}
