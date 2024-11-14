using System;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public enum GuestState
{
    None, /// 不明
    Waiting, /// 待機中
    Moving, /// 移動中
    Playing, /// プレイ中
    Finishing, /// プレイ終了
}

public class Guest
{
    /// <summary>
    /// ゲストのID
    /// </summary>
    public Guid GuestId { get; private set; } = Guid.NewGuid();
    /// <summary>
    /// TimeCount
    /// </summary>
    public ulong TimeCount { get; private set; }
    /// <summary>
    /// Guestの現在地
    /// </summary>
    public GuestState GuestState { get; set; }
    /// <summary>
    /// 現在地
    /// </summary>
    public Facility CurrentLocation { get; set; }

    public void Update(ulong deltaCount)
    {
        TimeCount += deltaCount;
    }


}
