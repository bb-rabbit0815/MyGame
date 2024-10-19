using System;
using Google.FlatBuffers;
using UnityEngine;

[Serializable]
public class CharctorParameters
{
    [field: SerializeField]
    public int Level { get; set; } = 0;
    [field: SerializeField]
    public int Helth { get; set; } = 0;
    [field: SerializeField]
    public int Appearance { get; set; } = 0;
    [field: SerializeField]
    public int Age { get; set; } = 0;
}