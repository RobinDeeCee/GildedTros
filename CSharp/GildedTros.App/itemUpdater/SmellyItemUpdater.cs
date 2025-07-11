namespace GildedTros.App.itemUpdater;

public class SmellyItemUpdater : UpdateItem
{
    public override void UpdateQuality(Item item)
    {
        base.UpdateQuality(item);
        base.UpdateQuality(item);

        item.Quality = base.CheckMaxMinQuality(item.Quality);
        item.SellIn = base.DayIsOver(item.SellIn);
    }
}
