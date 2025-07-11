using System.Collections.Generic;

namespace GildedTros.App.itemUpdater;

public static class ItemNames
{
    public const string DuplicateCode = "Duplicate Code";
    public const string LongMethods = "Long Methods";
    public const string UglyVariableNames = "Ugly Variable Names";
    public const string BDAWGKeychain = "B-DAWG Keychain";
    public const string GoodWine = "Good Wine";
    public const string BackstagePasses = "Backstage passes";


    public static readonly HashSet<string> SmellyItems = new()
    {
        DuplicateCode,
        LongMethods,
        UglyVariableNames
    };

    //TODO place it in ItemExtensions or something
    public static bool IsSmellyItem(this Item item)
    {
        return SmellyItems.Contains(item.Name);
    }
}

