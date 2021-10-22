using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LesTestDeThomas{
public class PlayerTest : MonoBehaviour
{
    public string playerName = "Player";
    public int life = 5;
    public int highScore;

    public Text nameText;
    public Text lifeText;
    public Text highScoreText;
    
    

    private void FixedUpdate()
    {
        lifeText.text = life.ToString();
        highScoreText.text = highScore.ToString();
        nameText.text = playerName;
    }

    public void SavePlayer()
    {
        SaveTestScript.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveTestScript.LoadPlayer();

        life = data.p_life;
        highScore = data.p_highscore;
        playerName = data.p_name;
    }

    public void PlusStats()
    {
        life++;
        highScore += 100;
    }
}
}