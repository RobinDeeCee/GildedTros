namespace GildedTros.App.itemUpdater;

public class SmellyItemUpdater : UpdateItem
{
    //TODO should be *2 the normal so this is maybe not that correct
    public override void UpdateQuality(Item item)
    {
        item.Quality = item.Quality - 2;
        if (item.SellIn <= 0)
        {
            item.Quality = item.Quality - 2;
        }
        item.SellIn = item.SellIn - 1;
    }
}
