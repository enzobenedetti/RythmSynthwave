using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBadges : MonoBehaviour
{
    public int[] badgesId = new int[3]{0,0,0};
    
    // Start is called before the first frame update
    void Awake()
    {
        CheckForBadges();
    }

    void CheckForBadges()
    {
        if (Score.music.notes.Count == Score.PerfectCount)
            badgesId[Score.music.songId] = 2;
        else if (Score.music.notes.Count == Score.MaxCombo)
            badgesId[Score.music.songId] = 1;
        else badgesId[Score.music.songId] = 0;
        
        int[] BadgesIdData = new int[3]{0,0,0};
        if (!SaveData.BadgesExist()) SaveData.SaveBadges(new []{0,0,0});
        else BadgesIdData = SaveData.LoadBadges().badgesId;
        if (BadgesIdData[Score.music.songId] < badgesId[Score.music.songId])
        {
            BadgesIdData[Score.music.songId] = badgesId[Score.music.songId];
            SaveData.SaveBadges(BadgesIdData);
        }
    }
}
