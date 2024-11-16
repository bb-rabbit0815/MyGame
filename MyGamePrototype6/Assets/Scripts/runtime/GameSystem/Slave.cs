
using System;

public enum SlaveState
{
    None, /// 不明
    Waiting, /// 待機中
    Moving, /// 移動中
    Playing, /// プレイ中
}
public class Slave
{
    public Guid SlaveId { get; private set; } = Guid.NewGuid();
    public SlaveState SlaveState { get; set; }
    public Facility CurrentLocation { get; set; }
}
