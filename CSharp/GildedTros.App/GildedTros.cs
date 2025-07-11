using GildedTros.App.itemUpdater;
using GildedTros.App.updaters;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items; // no cap

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Good Wine" 
                    && Items[i].Name != "Backstage passes for Re:factor"
                    && Items[i].Name != "Backstage passes for HAXX")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "B-DAWG Keychain")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                        if (Items[i].Name == "Duplicate Code" || Items[i].Name == "Long Methods" || Items[i].Name == "Ugly Variable Names")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes for Re:factor"
                        || Items[i].Name == "Backstage passes for HAXX")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "B-DAWG Keychain")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Good Wine")
                    {
                        if (Items[i].Name != "Backstage passes for Re:factor"
                            && Items[i].Name != "Backstage passes for HAXX")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "B-DAWG Keychain")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                                if (Items[i].Name == "Duplicate Code" || Items[i].Name == "Long Methods" || Items[i].Name == "Ugly Variable Names")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
