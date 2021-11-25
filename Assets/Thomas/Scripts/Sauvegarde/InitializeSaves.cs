using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class InitializeSaves : MonoBehaviour
{
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Game_Volume.saves") != true)
        {
            SaveData.SaveAudioParameters(0.8f);
        }
        
        if (File.Exists(Application.persistentDataPath + "/Badges.saves") != true)
        {
            SaveData.SaveBadges(new[] {0, 0, 0});
        }
        
        if (File.Exists(Application.persistentDataPath + "/High_Score.saves") != true)
        {
            SaveData.SaveHighScore(0, 1);
            SaveData.SaveHighScore(0, 2);
            SaveData.SaveHighScore(0, 3);
        }
    }
}
