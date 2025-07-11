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
            if (item.Name == "B-DAWG Keychain")
                new LegendaryItemUpdater().UpdateQuality(item);
            if (item.Name == "Good Wine")
                new GoodWineUpdater().UpdateQuality(item);
            if (item.Name.Contains("Backstage passes"))
                new BackstagePassUpdater().UpdateQuality(item);
            if (item.Name == "Duplicate Code" || item.Name == "Long Methods" || item.Name == "Ugly Variable Names") // TODO add to vars and make methode to check
                new SmellyItemUpdater().UpdateQuality(item);

            new NormalItemUpdater().UpdateQuality(item);
        }

        // TODO need yo have: separation of concerns => each Item should be responsible for its own quality update logic
        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name != "Good Wine" 
                    && _items[i].Name != "Backstage passes for Re:factor"
                    && _items[i].Name != "Backstage passes for HAXX")
                {
                    if (_items[i].Quality > 0)
                    {
                        if (_items[i].Name != "B-DAWG Keychain")
                        {
                            _items[i].Quality = _items[i].Quality - 1;
                        }
                        if (_items[i].Name == "Duplicate Code" || _items[i].Name == "Long Methods" || _items[i].Name == "Ugly Variable Names")
                        {
                            _items[i].Quality = _items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;

                        if (_items[i].Name == "Backstage passes for Re:factor"
                        || _items[i].Name == "Backstage passes for HAXX")
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_items[i].Name != "B-DAWG Keychain")
                {
                    _items[i].SellIn = _items[i].SellIn - 1;
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != "Good Wine")
                    {
                        if (_items[i].Name != "Backstage passes for Re:factor"
                            && _items[i].Name != "Backstage passes for HAXX")
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (_items[i].Name != "B-DAWG Keychain")
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                                if (_items[i].Name == "Duplicate Code" || _items[i].Name == "Long Methods" || _items[i].Name == "Ugly Variable Names")
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = _items[i].Quality - _items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality = _items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
