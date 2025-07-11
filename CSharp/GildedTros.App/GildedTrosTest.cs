using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    // Write a test for every type of item, use these test to check if the logic is correct after the refactoring
    // TODO make private methode 'increaseByDays, what does loop X # amount over app.UpdateQuality(); to increase the days
    public class GildedTrosTest
    {
        //This is just a 'Default Item'
        [Fact]
        public void RingOfCleanseningCodeUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Ring of Cleansening Code", SellIn = 2, Quality = 5 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality); //day one  = Quality--
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality); // day 3 > Sellin = Quality--*2
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality); // test if negative
        }

        [Fact]
        public void GoodWineUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 2, Quality = 45 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(46, Items[0].Quality); //day one  = Quality--
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality); //Should be 50 for the first time
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality); // Should stay 50
        }

        //This is just a 'Default Item'
        [Fact]
        public void ElixirOfTheSOLIDUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the SOLID", SellIn = 2, Quality = 5 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality); //day one  = Quality--
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality); // day 3 > Sellin = Quality--*2
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality); // test if negative
        }

        [Fact]
        public void BDAWGKeychainUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 2, Quality = 5 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn); //Stays the same
            Assert.Equal(5, Items[0].Quality); //Stays the same
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn); //Stays the same
            Assert.Equal(5, Items[0].Quality); //Stays the same
        }

        [Fact]
        public void BackstagePassesForXUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 5 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(10, Items[0].SellIn); // at day 10 to go
            Assert.Equal(10, Items[0].Quality);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality); //will increase +2
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(5, Items[0].SellIn);
            Assert.Equal(20, Items[0].Quality); // at day 5 to go
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(23, Items[0].Quality); //will increase +3
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(35, Items[0].Quality); //last Quality before the end day
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality); //to late = Quality 0
        }

        //TODO fix code here - this is not working correctly
        [Fact]
        public void SmellyItemUpdateCorrectly()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Duplicate Code", SellIn = 2, Quality = 10 } };
            GildedTros app = new GildedTros(Items);

            //Act * Assert
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality); //should be 8 is 9
            app.UpdateQuality(); //6 is 8
            app.UpdateQuality(); //4 is 7
            Assert.Equal(2, Items[0].Quality); //2 is 6
            app.UpdateQuality(); // 0 is 4
            Assert.Equal(0, Items[0].Quality); // test if negative
            app.UpdateQuality(); // 0 is 2
            Assert.Equal(0, Items[0].Quality); // test if negative
        }
    }
}