using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayingStatus
{
    public Character Slave { get; set; }
    public Guest Guest { get; set; }
    public ulong StartTime { get; set; }
    public ulong EndTime { get; set; }
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
    private string _name = "";
    private List<Character> _slaves = new();
    private List<Guest> _guests = new();
    private List<Guest> _newGuests = new();
    private List<PlayingStatus> _playingStatusList = new();

    void Update(ulong deltaCount)
    {
        TimeCount += deltaCount;

        // 新規のゲストの処理
        _UpdateNewGuest(deltaCount);

        // Palyの処理
        _UpdatePaly(deltaCount);
    }

    void _UpdateNewGuest(ulong deltaCount)
    {
        // アサインされていないSlave新規のゲストにアサインする
        foreach (var guest in _newGuests)
        {
            var notAssignedSlave = _NotAssignedSlaves().FirstOrDefault(null);
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
                _newGuests.Remove(guest);
            }
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

            // TODO:Slaveのステータス更新
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
    IEnumerable<Character> _NotAssignedSlaves()
    {
        yield return null;
    }

    public void PushGuest(Guest guest)
    {
        _newGuests.Add(guest);
        guest.CurrentLocation = this;
        guest.GuestState = GuestState.Waiting;
    }

}
