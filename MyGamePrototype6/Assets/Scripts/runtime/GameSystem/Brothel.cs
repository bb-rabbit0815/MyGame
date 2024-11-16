
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void FacilityEventHandler(Facility facility);
public delegate void GuestEventHandler(Guest guest);

public static class Brothel
{
    static List<Slave> _slaves = new List<Slave>();
    static List<Guest> _guests = new List<Guest>();
    static Queue<Guest> _newGuestQueue = new Queue<Guest>();
    static List<IShop> _shops = new List<IShop>();
    static List<Facility> _facilities = new List<Facility>();
    static ulong _gameCount;

    /// <summary>
    /// 資金
    /// </summary>
    public static float Funds { get; set; }
    public static IEnumerable<Slave> Slaves => _slaves;
    public static IEnumerable<Guest> Gusets => _guests;
    public static IEnumerable<Facility> Facilities => _facilities;
    public static IEnumerable<IShop> Shops => _shops;
    public static ulong GameCount => _gameCount;

    public static event FacilityEventHandler OnAddFacility;
    public static event GuestEventHandler OnAddNewGuest;

    public static void Update(ulong deltaCount)
    {
        _gameCount += deltaCount;

        // 新規ゲストのアップデート
        _NewGuestUpdate(deltaCount);

        // Guestの更新
        _GuestUpdate(deltaCount);

        // 施設の更新
        foreach(var facility in Facilities)
        {
            facility.Update(deltaCount);
        }
    }

    static void _NewGuestUpdate(ulong deltaCount)
    {
        // 新規のGuest
        if (GameCount % 500 == 0 && _newGuestQueue.Count < 10)
        {
            var newGuest = _CreateNewGuest();
            _newGuestQueue.Enqueue(newGuest);
            OnAddNewGuest?.Invoke(newGuest);
        }

        while(_newGuestQueue.Count > 0)
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

    static void _GuestUpdate(ulong deltaCount)
    {
        // Playが終了したGuestを削除
        _guests = _guests
            .Where(x => x.GuestState != GuestState.Finishing)
            .ToList();
    }

    static Guest _CreateNewGuest()
    {
        return new Guest() { GuestState = GuestState.Waiting };
    }

    public static void AddFacility(Facility facility)
    {
        _facilities.Add(facility);
        OnAddFacility?.Invoke(facility);
    }

    public static void AddSlave(Slave slave)
    {
        _slaves.Add(slave);
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
