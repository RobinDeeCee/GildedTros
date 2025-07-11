namespace GildedTros.App.itemUpdater;

public abstract class UpdateItem : IUpdateItem
{
    public int CheckMaxMinQuality(int quality)
    {
        if (quality < 0) return 0;
        if (quality > 50) return 50;
        return quality;
    }

    public int DayIsOver(int amountOfDays)
    {
        return --amountOfDays;
    }

    public virtual void UpdateQuality(Item item)
    {
        item.Quality = item.Quality - 1;
        if(item.SellIn <= 0)
        {
            item.Quality = item.Quality - 1;
        }
        item.Quality = CheckMaxMinQuality(item.Quality);
    }
}
