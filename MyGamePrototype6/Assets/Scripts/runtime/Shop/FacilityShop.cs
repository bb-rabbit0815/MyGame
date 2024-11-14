using System.Collections.Generic;

public class FacilityShop: IShop
{
    public string Name => "FacilityShop";
    public IEnumerable<ItemStock> ItemStocks => null;
}
