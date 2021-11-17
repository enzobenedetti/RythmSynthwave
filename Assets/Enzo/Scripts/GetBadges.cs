using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBadges : MonoBehaviour
{
    public int badgeId;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SaveData.LoadBadges() == null) SaveData.SaveBadges(new int[3]);
        CheckForBadges();
    }

    void CheckForBadges()
    {
        if (Score.music.notes.Count == Score.PerfectCount)
            badgeId = 2;
        else if (Score.music.notes.Count == Score.MaxCombo)
            badgeId = 1;
        else badgeId = 0;
        
        int[] badgesId = SaveData.LoadBadges().badgesId;
        if (badgesId == null)
            badgesId = new int[3];
        if (badgesId[Score.music.songId] < badgeId)
            badgesId[Score.music.songId] = badgeId;
        SaveData.SaveBadges(badgesId);
    }
}
