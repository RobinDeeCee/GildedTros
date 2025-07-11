namespace GildedTros.App.itemUpdater;

public class GoodWineUpdater : UpdateItem
{
    public override void UpdateQuality(Item item)
    {
        item.SellIn = item.SellIn - 1;
        item.Quality = item.Quality + 1;
    }
}
