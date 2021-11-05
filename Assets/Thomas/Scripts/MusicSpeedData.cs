using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MusicSpeedData
{
    public float SavedSpeedForNextMusic;

    public MusicSpeedData(float speed)
    {
        SavedSpeedForNextMusic = speed;
    }
}
