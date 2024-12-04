using System;

public interface IShopItem
{
    public string Name { get; }
}

[Serializable]
public class ItemStock
{
    public IShopItem ShopItem { get; set; }
    public uint Stock { get; set; }
}
