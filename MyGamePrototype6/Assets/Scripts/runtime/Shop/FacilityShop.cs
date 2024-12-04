using System.Collections.Generic;
using System.Linq;
public delegate void OnBoughtDelegate(IShopItem shopItem, uint stocks);

public class FacilityShopItem : IShopItem
{
    public string Name { get; set; }
    public Facility Facility { get; set; }
}
public class FacilityShop : IShop
{
    public string Name => "FacilityShop";
    public IEnumerable<ItemStock> ItemStocks => _itemStocks;
    public ItemStock CurrentItemStock => ItemStocks.ElementAt(_current);
    public int CurrentItemIndex
    {
        get => _current;
        set => _current = value < ItemStocks.Count() ? value : _current;
    }
    public event OnBoughtDelegate OnBought;
    List<ItemStock> _itemStocks = new();
    int _current;
    public void BuyCurrentItem(uint stocks)
    {
        var itemStock = _itemStocks[CurrentItemIndex];

        if (itemStock.Stock >= stocks)
        {
            OnBought(_itemStocks[CurrentItemIndex].ShopItem, stocks);
            _itemStocks[CurrentItemIndex].Stock -= stocks;
        }
    }

    public void AddItemStock(ItemStock stock)
    {
        _itemStocks.Add(stock);
    }

}
