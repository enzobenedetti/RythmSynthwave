using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LesTestDeThomas
{
    [System.Serializable]
    public class PlayerData
    {
        public string p_name;   
        public int p_life;
        public int p_highscore;
        
        public PlayerData(PlayerTest player)
        {
            p_life = player.life;
            p_highscore = player.highScore;
            p_name = player.playerName;
            
        } 
    }
}
