using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public int[] highscores = new int[3];

    public HighScoreData(int[] newHS)
    {
        highscores[0] = newHS[0];
        highscores[1] = newHS[1];
        highscores[2] = newHS[2];
    }
    
}
