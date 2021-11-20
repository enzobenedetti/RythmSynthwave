using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public float MusicOneHighScore,MusicTwoHighScore,MusicThreeHighScore;

    public HighScoreData(float highScore, int LevelToSave)
    {
        switch (LevelToSave)
        {
            case 1:
                MusicOneHighScore = highScore;
                break;
            case 2:
                MusicTwoHighScore = highScore;
                break;
            case 3:
                MusicThreeHighScore = highScore;
                break;
        }
    }
    
}
