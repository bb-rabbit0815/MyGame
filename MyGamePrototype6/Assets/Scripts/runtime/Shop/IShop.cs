using System.Collections.Generic;

public interface IShop
{
    public string Name { get; }
    public IEnumerable<ItemStock> ItemStocks { get; }
}
