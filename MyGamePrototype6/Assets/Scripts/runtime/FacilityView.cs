using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using UnityEngine.Playables;
public class FacilityView : MonoBehaviour
{
    [Serializable]
    public struct SlaveView
    {
        public SlaveView(Slave slave)
        {
            id = slave.SlaveId.ToString();
            slaveState = slave.SlaveState;
        }
        public string id;
        public SlaveState slaveState;
    }
    [Serializable]
    public struct GuestView
    {
        public GuestView(Guest guest)
        {
            id = guest.GuestId.ToString();
            guestState = guest.GuestState;
        }
        public string id;
        public GuestState guestState;
    }
    [Serializable]
    public struct PlayingView
    {
        public PlayingView(PlayingStatus status)
        {
            slave = new SlaveView(status.Slave);
            guest = new GuestView(status.Guest);
            start = status.StartTime;
            end = status.EndTime;
        }

        public SlaveView slave;
        public GuestView guest;
        public ulong start;
        public ulong end;
    }
    public Facility Facility { get; set; }
    [SerializeField] ulong _time;
    [SerializeField] List<SlaveView> _slaveViews = null;
    [SerializeField] List<GuestView> _guestViews = null;
    [SerializeField] List<PlayingView> _playingViews = null;

    void Update()
    {
        _time = Facility?.TimeCount ?? 0;
        _slaveViews = Facility?.Slaves
            .Select(x => new SlaveView(x))
            .ToList();
        _guestViews = Facility?.Guests
            .Select(x => new GuestView(x))
            .ToList();
        _playingViews = Facility?.PlayingStatuses
            .Select(x => new PlayingView(x))
            .ToList();
    }
}
