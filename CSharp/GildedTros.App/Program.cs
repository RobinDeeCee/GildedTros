﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new Item {Name = "Good Wine", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new Item {Name = "B-DAWG Keychain", SellIn = 0, Quality = 80},
                new Item {Name = "B-DAWG Keychain", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49},
                // these smelly items do not work properly yet
                new Item {Name = "Duplicate Code", SellIn = 3, Quality = 6},
                new Item {Name = "Long Methods", SellIn = 3, Quality = 6},
                new Item {Name = "Ugly Variable Names", SellIn = 3, Quality = 6}
            };

            var app = new GildedTros(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                Items.Select(item => {
                    Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
                    app.UpdateItem(item);
                    return item;
                }).ToList(); // to 'force immediate execution'
                Console.WriteLine("");
            }
        }
    }
}
