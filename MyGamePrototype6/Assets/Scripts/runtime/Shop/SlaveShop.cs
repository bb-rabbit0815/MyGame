using System.Collections.Generic;

public class SlaveShop: IShop
{
    public string Name => "SlaveShop";
    public IEnumerable<ItemStock> ItemStocks => null;

}
