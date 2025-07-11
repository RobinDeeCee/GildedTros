namespace GildedTros.App.itemUpdater;
interface IUpdateItem
{
    public void UpdateQuality(Item item);
    public int CheckMaxMinQuality(int quality);
}
