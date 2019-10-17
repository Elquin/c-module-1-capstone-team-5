using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using Capstone.Views;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Chip_Consume_Messages()
        {
            //Arrange
            Chip c = new Chip("A1", "Potato Crisps", "3.05");

            //Act
            string returnedResult = c.Consume();

            //Assert
            Assert.AreEqual("Crunch Crunch, Yum!", returnedResult);

        }
        [TestMethod]
        public void Gum_Consume_Messages()
        {
            //Arrange
            Gum g = new Gum("D1", "U-Chews", "0.85");

            //Act
            string returnedResult = g.Consume();

            //Assert
            Assert.AreEqual("Chew Chew, Yum!", returnedResult);
        }
        [TestMethod]
        public void Drink_Consume_Messages()
        {
            //Arrange
            Drink d = new Drink("C4", "Heavy", "1.50");

            //Act
            string returnedResult = d.Consume();

            //Assert
            Assert.AreEqual("Glug Glug, Yum!", returnedResult);
        }
        [TestMethod]
        public void Candy_Consume_Messages()
        {
            //Arrange
            Candy c = new Candy("B4", "Crunchie", "1.75");

            //Act
            string returnedResult = c.Consume();

            //Assert
            Assert.AreEqual("Munch Munch, Yum!", returnedResult);
        }

        [TestMethod]
         public void DictionaryTestContainsKey()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            bool actualResult = ex.inventory.ContainsKey("A3");

            // Assert
            Assert.AreEqual(true, actualResult);
        }
        [TestMethod]
        public void DictionaryTestDoesNotContainKey()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            bool actualResult = ex.inventory.ContainsKey("A7");

            // Assert
            Assert.AreEqual(false, actualResult);
        }
        [TestMethod]
        public void ItemName()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            string actualResult = ex.inventory["C2"].Item.Name;

            // Assert
            Assert.AreEqual("Dr. Salt", actualResult);
        }
        [TestMethod]
        public void ItemPrice()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            string actualResult = ex.inventory["C2"].Item.Price;

            // Assert
            Assert.AreEqual("1.50", actualResult);
        }
        [TestMethod]
        public void ItemType()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            string actualResult = ex.inventory["D1"].Item.Type;

            // Assert
            Assert.AreEqual("Gum", actualResult);
        }
        [TestMethod]
        public void ItemCount()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            ex.Loader();

            //Act
            int actualResult = ex.inventory["B4"].Count;

            // Assert
            Assert.AreEqual(5, actualResult);
        }
        [TestMethod]

        public void MakeChangeTest1()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();
            decimal beginningBalance = 5.95M;
            decimal expected = 0.00M;

            //Act
            decimal actual = ex.MakeChange(beginningBalance);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MakeChangeTest2()
        {
            //Arrange
            VendingMachine ex = new VendingMachine();

            //Act
            ex.MakeChange(1.90M);
            decimal quarter = ex.quarterCount;
            decimal dime = ex.dimeCount;
            decimal nickel = ex.nickelCount;

            // Assert
            Assert.AreEqual(7, quarter);
            Assert.AreEqual(1, dime);
            Assert.AreEqual(1, nickel);
        }

        [DataTestMethod]
        [DataRow("5", 5, DisplayName = "Feed Positive Int")]
        //Made it mpossible to enter negative number or non-integer into system

        public void FeedMoneyTest(string n, int expectedResult)
        {
            //Arrange
            VendingMachine ex = new VendingMachine();

            //Act
            int en = int.Parse(n);
            ex.FeedMoney(en);
            decimal actualResult = ex.currentMoneyProvided;

            //Assert
            Assert.AreEqual(actualResult, (decimal)expectedResult);
        }
    }
}
