using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameSystemMain : MonoBehaviour
{
    [SerializeField]
    ulong _time;
    [SerializeField]
    float _fund;
    [SerializeField]
    int _facilityCount;
    [SerializeField]
    Tilemap _tilemap;
    [SerializeField]
    List<Tile> _tiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 初期化
        var slave = new Slave();
        var facility = new Facility();
        facility.AssgineSlave(slave);
        facility.Coord = new FacilityCoord { X = 0, Y = 0 };
        var facility2 = new Facility();
        facility.AssgineSlave(slave);
        facility.Coord = new FacilityCoord { X = 0, Y = 1 };
        
        // Shop
        var faciiltyShop = new FacilityShop();
        faciiltyShop.AddItemStock(new ItemStock(){
            ShopItem = new FacilityShopItem() {Name = "GroyHole", Facility = new Facility()},
            Stock = 1});
        faciiltyShop.AddItemStock(new ItemStock(){
            ShopItem = new FacilityShopItem() {Name = "GroyHoleW", Facility = new Facility()},
            Stock = 1});
        faciiltyShop.AddItemStock(new ItemStock(){
            ShopItem = new FacilityShopItem() {Name = "GroyHoleH", Facility = new Facility()},
            Stock = 1});
        faciiltyShop.OnBought += _OnFacilityBought;

        Brothel.OnAddNewGuest += _OnAddNewGuest;
        Brothel.OnAddFacility += _OnAddFacility;
        Brothel.Funds = 1000;
        Brothel.AddFacility(facility);
        Brothel.AddFacility(facility2);
        Brothel.AddSlave(slave);
        Brothel.AddShop(faciiltyShop);

        var facilityView = GetComponent<FacilityView>();
        if (facilityView)
        {
            facilityView.Facility = facility;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Brothel.Update(1);
        _time = Brothel.GameCount;
        _fund = Brothel.Funds;
        _facilityCount = Brothel.Facilities.Count();
    }

    void OnDestroy()
    {
        Brothel.OnAddNewGuest -= _OnAddNewGuest;
        Brothel.OnAddFacility -= _OnAddFacility;
    }

    void _OnAddNewGuest(Guest guest)
    {
        Debug.Log(guest.GuestId.ToString());
    }

    void _OnAddFacility(Facility facility)
    {
        _tilemap.SetTile(new Vector3Int(facility.Coord.X, facility.Coord.Y, 0), _tiles[0]);
    }

    void _OnFacilityBought(IShopItem shopItem, uint stock)
    {
        if (shopItem is FacilityShopItem facilityShopItem)
        {
            Brothel.AddFacility(facilityShopItem.Facility);
        }
    }
}
