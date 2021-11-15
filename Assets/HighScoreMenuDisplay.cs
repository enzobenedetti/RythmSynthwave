using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreMenuDisplay : MonoBehaviour
{
    public float ScoreMusicOne, ScoreMusicTwo, ScoreMusicThree;

    private void Awake()
    {
        LoadHighScores();
        ScoreMusicOne = SaveData.LoadHighScore().MusicOneHighScore;
        ScoreMusicTwo = SaveData.LoadHighScore().MusicTwoHighScore;
        ScoreMusicThree = SaveData.LoadHighScore().MusicThreeHighScore;
    }


    public void LoadHighScores()
    {
        SaveData.LoadHighScore();
    }
}
