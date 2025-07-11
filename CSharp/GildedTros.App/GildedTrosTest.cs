using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    // TODO Write test for Quality > 50 when Item in init state has 50, should return the same 50 (do the same for 0)
    // TODO make private methode 'increaseByDays, what does loop X # amount over app.UpdateQuality(); to increase the days
    public class GildedTrosTest
    {
        [Fact]
        public void GoodWineUpdateCorrectly()
        {
            //Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Good Wine", SellIn = 2, Quality = 45 } };
            GildedTros app = new GildedTros(items);

            //Act * Assert
            app.UpdateItem(items[0]);
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(46, items[0].Quality); //day one  = Quality--
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(50, items[0].Quality); //Should be 50 for the first time
            app.UpdateItem(items[0]);
            Assert.Equal(50, items[0].Quality); // Should stay 50
        }

        [Fact]
        public void DefaultItemUpdateCorrectly()
        {
            //Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Elixir of the SOLID", SellIn = 2, Quality = 5 } };
            GildedTros app = new GildedTros(items);

            //Act * Assert
            app.UpdateItem(items[0]);
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(4, items[0].Quality); //day one  = Quality--
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(1, items[0].Quality); // day 3 > Sellin = Quality--*2
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(0, items[0].Quality); // test if negative
        }

        [Fact]
        public void BDAWGKeychainUpdateCorrectly()
        {
            //Arrange
            IList<Item> items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 2, Quality = 5 } };
            GildedTros app = new GildedTros(items);

            //Act * Assert
            app.UpdateItem(items[0]);
            Assert.Equal(2, items[0].SellIn); //Stays the same
            Assert.Equal(5, items[0].Quality); //Stays the same
            app.UpdateItem(items[0]);
            Assert.Equal(2, items[0].SellIn); //Stays the same
            Assert.Equal(5, items[0].Quality); //Stays the same
        }

        [Fact]
        public void BackstagePassesForXUpdateCorrectly()
        {
            //Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes for OTHER TEST", SellIn = 15, Quality = 5 } };
            GildedTros app = new GildedTros(items);

            //Act * Assert
            app.UpdateItem(items[0]);
            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(10, items[0].SellIn); // at day 10 to go
            Assert.Equal(10, items[0].Quality);
            app.UpdateItem(items[0]);
            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(12, items[0].Quality); //will increase +2
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(5, items[0].SellIn);
            Assert.Equal(20, items[0].Quality); // at day 5 to go
            app.UpdateItem(items[0]);
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(23, items[0].Quality); //will increase +3
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(35, items[0].Quality); //last Quality before the end day
            app.UpdateItem(items[0]);
            Assert.Equal(0, items[0].Quality); //to late = Quality 0
        }

        [Fact]
        public void SmellyItemUpdateCorrectly()
        {
            //Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Duplicate Code", SellIn = 2, Quality = 10 } };
            GildedTros app = new GildedTros(items);

            //Act * Assert
            app.UpdateItem(items[0]);
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(8, items[0].Quality);
            app.UpdateItem(items[0]);
            app.UpdateItem(items[0]);
            Assert.Equal(2, items[0].Quality);
            app.UpdateItem(items[0]);
            Assert.Equal(0, items[0].Quality);
            app.UpdateItem(items[0]);
            Assert.Equal(0, items[0].Quality);
        }
    }
}