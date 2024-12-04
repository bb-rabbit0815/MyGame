using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class PlayingStatus
{
    public Slave Slave { get; set; }
    public Guest Guest { get; set; }
    public ulong StartTime { get; set; }
    public ulong EndTime { get; set; }
}

public class FacilityCoord
{
    public int X { get; set; }
    public int Y { get; set; }
}

/// <summary>
/// 厳密にはPlayRoom
/// </summary>
public class Facility
{
    public ulong TimeCount { get; private set; }
    /// <summary>
    /// 新しいGuestを追加できるかどうか
    /// </summary>
    public bool CanNewGuest => true;
    /// <summary>
    /// 娼婦をアサインできるかどうか
    /// </summary>
    public bool CanAssgineSlave => true;
    public FacilityCoord Coord { get; set; } = new FacilityCoord();
    public IEnumerable<Slave> Slaves => _slaves;
    public IEnumerable<Guest> Guests => _guests;
    public IEnumerable<PlayingStatus> PlayingStatuses => _playingStatusList;
    private List<Slave> _slaves = new();
    private List<Guest> _guests = new();
    private List<Guest> _newGuests = new();
    private List<PlayingStatus> _playingStatusList = new();

    public void Update(ulong deltaCount)
    {
        TimeCount += deltaCount;

        // 新規のゲストの処理
        _UpdateNewGuest(deltaCount);

        // Palyの処理
        _UpdatePaly(deltaCount);
    }

    void _UpdateNewGuest(ulong deltaCount)
    {
        var assgined = new List<Guest>();
        // アサインされていないSlave新規のゲストにアサインする
        foreach (var guest in _newGuests)
        {
            var notAssignedSlave = _NotAssignedSlaves().FirstOrDefault();
            if (notAssignedSlave != null)
            {
                _playingStatusList.Add(new PlayingStatus()
                {
                    Slave = notAssignedSlave,
                    Guest = guest,
                    StartTime = TimeCount,
                    EndTime = TimeCount + 1000
                });
                guest.GuestState = GuestState.Playing;
                _guests.Add(guest);
                assgined.Add(guest);

                notAssignedSlave.SlaveState = SlaveState.Playing;
            }
            else
            {
                break;
            }
        }

        foreach (var x in assgined)
        {
            _newGuests.Remove(x);
        }
    }

    void _UpdatePaly(ulong deltaCount)
    {
        foreach (var paly in _playingStatusList.Where(x => x.EndTime <= TimeCount))
        {
            paly.Guest.GuestState = GuestState.Finishing;
            _guests.Remove(paly.Guest);

            // 売上追加(仮)
            Brothel.Funds += 100;

            // Slaveのステータス更新
            paly.Slave.SlaveState = SlaveState.Waiting;
        }

        // プレイリストの更新
        _playingStatusList = _playingStatusList
            .Where(x => x.EndTime > TimeCount)
            .ToList();
    }

    /// <summary>
    /// アサインされていないSlaveを取得する
    /// </summary>
    /// <returns></returns>
    IEnumerable<Slave> _NotAssignedSlaves()
    {
        foreach (var slave in _slaves)
        {
            if (_playingStatusList.All(x => x.Slave != slave))
            {
                yield return slave;
            }
        }

        yield break;
    }

    public void PushGuest(Guest guest)
    {
        _newGuests.Add(guest);
        guest.CurrentLocation = this;
        guest.GuestState = GuestState.Waiting;
    }

    public void AssgineSlave(Slave slave)
    {
        if (slave.CurrentLocation == this || _slaves.Contains(slave))
        {
            // アサイン済みなのでスキップ
            return;
        }

        if (slave.CurrentLocation != null)
        {
            slave.CurrentLocation.UnAssgineSlave(slave);
        }

        _slaves.Add(slave);
        slave.CurrentLocation = this;
        slave.SlaveState = SlaveState.Waiting;
    }

    public void UnAssgineSlave(Slave slave)
    {
        if (_slaves.Remove(slave))
        {
            slave.CurrentLocation = null;
        }
    }

}
