
using GildedTros.App.itemUpdater;

namespace GildedTros.App.updaters;

public class LegendaryItemUpdater : UpdateItem
{
    public override void UpdateQuality(Item item)
    {
        item.SellIn = item.SellIn;
        item.Quality = item.Quality;
    }

}
