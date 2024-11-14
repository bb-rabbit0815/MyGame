using System;

public interface IShopItem
{
    public string Name { get; }
}

[Serializable]
public class ItemStock
{
    public IShopItem shopItem;
    public int count;
}
