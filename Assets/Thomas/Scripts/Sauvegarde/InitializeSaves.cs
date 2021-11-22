using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class InitializeSaves : MonoBehaviour
{
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Badges.saves") != true)
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/Badges.saves", FileMode.Create);
        }
        
        if (File.Exists(Application.persistentDataPath + "/High_Score.saves") != true)
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/High_Score.saves", FileMode.Create);
        }
    }
}
