
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Brothel
{
    static List<Character> _slaves = new List<Character>();
    static List<Guest> _guests = new List<Guest>();
    static Queue<Guest> _newGuestQueue = new Queue<Guest>();
    static List<IShop> _shops = new List<IShop>();
    static List<Facility> _facilities = new List<Facility>();
    static ulong _gameCount;

    /// <summary>
    /// 資金
    /// </summary>
    public static float Funds { get; set; }
    public static IEnumerable<Character> Slaves => _slaves;
    public static IEnumerable<Guest> Gusets => _guests;
    public static IEnumerable<Facility> Facilities => _facilities;
    public static IEnumerable<IShop> Shops => _shops;
    public static ulong GameCount => _gameCount;

    public static void Update(ulong deltaCount)
    {
        _gameCount += deltaCount;

        // 新規ゲストのアップデート
        _NewGuestUpdate(deltaCount);
    }

    static void _NewGuestUpdate(ulong deltaCount)
    {
        // 新規のGuest
        if (GameCount % 500 == 0)
        {
            _newGuestQueue.Append(_CreateNewGuest());
        }

        while(_newGuestQueue.Count != 0)
        {
            var facility = Facilities.FirstOrDefault(x => x.CanNewGuest);
            if (facility == null)
            {
                // アサインできる施設がないのでループを出る
                break;
            }
            var newGuest = _newGuestQueue.Dequeue();
            facility.PushGuest(newGuest);
            _guests.Add(newGuest);
        }
    }

    static Guest _CreateNewGuest()
    {
        return new Guest();
    }


    public static bool Save(string path)
    {
        return true;
    }

    public static bool Load(string path)
    {
        return true;
    }
}
