using System;
using Google.FlatBuffers;
using UnityEngine;

[Serializable]
public class CharctorParameters
{
    [field: SerializeField]
    public int Level { get; set; }
    [field: SerializeField]
    public int Helth { get; set; }
    [field: SerializeField]
    public int Appearance { get; set; }
    [field: SerializeField]
    public int Age { get; set; }
    [field: SerializeField]
    public float InfectionResistance { get; set; }
    [field: SerializeField]
    public int HealthRecoverySpeed { get; set; }
}