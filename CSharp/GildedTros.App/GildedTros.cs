using GildedTros.App.itemUpdater;
using GildedTros.App.updaters;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> _items;

        public GildedTros(IList<Item> _items)
        {
            this._items = _items;
        }

        public void UpdateItem(Item item)
        {
            if (item.Name == ItemNames.BDAWGKeychain)
            {
                new LegendaryItemUpdater().UpdateQuality(item);
                return;
            }
            if (item.Name == ItemNames.GoodWine)
            {
                new GoodWineUpdater().UpdateQuality(item);
                return;
            }
            if (item.Name.Contains(ItemNames.BackstagePasses)){
                new BackstagePassUpdater().UpdateQuality(item);
                return;
            }
            if (ItemNames.IsSmellyItem(item)){
                new SmellyItemUpdater().UpdateQuality(item);
                return;
            }

            new NormalItemUpdater().UpdateQuality(item);
        }
    }
}
