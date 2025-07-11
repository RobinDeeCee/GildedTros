namespace GildedTros.App.itemUpdater;

public abstract class UpdateItem : IUpdateItem
{
    public virtual void UpdateQuality(Item item)
    {
        item.Quality = item.Quality - 1;
        if(item.SellIn <= 0)
        {
            item.Quality = item.Quality - 1;
        }
        item.SellIn = item.SellIn - 1;
    }
}
