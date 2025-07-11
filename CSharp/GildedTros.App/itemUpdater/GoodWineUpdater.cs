namespace GildedTros.App.itemUpdater;

public class GoodWineUpdater : UpdateItem
{
    public override void UpdateQuality(Item item)
    {
        item.Quality += (item.SellIn <= 0) ? 2 : 1;
        item.Quality = CheckMaxMinQuality(item.Quality);
        item.SellIn = base.DayIsOver(item.SellIn);
    }
}
