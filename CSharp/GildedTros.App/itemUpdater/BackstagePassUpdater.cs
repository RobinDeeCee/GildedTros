namespace GildedTros.App.itemUpdater;
public class BackstagePassUpdater : UpdateItem
    {
        public override void UpdateQuality(Item item)
        {
            item.Quality = item.Quality + 1;
            if(item.SellIn <= 10)
            {
                item.Quality = item.Quality + 1;
            }
            if (item.SellIn <= 5)
            {
                item.Quality = item.Quality + 1;
            }
            if (item.SellIn == 0)
            {
                item.Quality = 0;
            }
            item.SellIn = item.SellIn - 1;
        }
    }
