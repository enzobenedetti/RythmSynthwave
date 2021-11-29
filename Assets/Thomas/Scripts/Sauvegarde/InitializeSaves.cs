using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class InitializeSaves : MonoBehaviour
{
    public float FirstAudioVolumeSave;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("GameVolume") != true)
        {
            PlayerPrefs.SetFloat("GameVolume", FirstAudioVolumeSave);
            Debug.LogWarning("Initialized Game volume at " + FirstAudioVolumeSave);
        }
        
        if (File.Exists(Application.persistentDataPath + "/Badges.saves") != true)
        {
            SaveData.SaveBadges(new[] {0, 0, 0});
        }
        
        if (File.Exists(Application.persistentDataPath + "/High_Score.saves") != true)
        {
            SaveData.SaveHighScore(new int[]{0,0,0});
            
            Debug.LogWarning("Initialized all musics HighScore at 0");
        }
    }
}
