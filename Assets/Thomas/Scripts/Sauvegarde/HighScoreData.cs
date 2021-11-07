using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public float ActualSavedHighScore;
    
    public HighScoreData(float highScore)
    {
        ActualSavedHighScore = highScore;
    }
    
}
