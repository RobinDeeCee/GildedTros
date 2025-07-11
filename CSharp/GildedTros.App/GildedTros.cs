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
            if (item.Name == "B-DAWG Keychain"){
                new LegendaryItemUpdater().UpdateQuality(item);
                return;
            }
            if (item.Name == "Good Wine"){
                new GoodWineUpdater().UpdateQuality(item);
                return;
            }
            if (item.Name.Contains("Backstage passes")){
                new BackstagePassUpdater().UpdateQuality(item);
                return;
            }
            if (item.Name == "Duplicate Code" || item.Name == "Long Methods" || item.Name == "Ugly Variable Names"){ // TODO add to vars and make methode to check
                new SmellyItemUpdater().UpdateQuality(item);
                return;
            }

            new NormalItemUpdater().UpdateQuality(item);
        }
    }
}
