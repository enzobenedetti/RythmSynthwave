using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBadges : MonoBehaviour
{
    private int badgeId;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckForBadges()
    {
        if (Score.music.notes.Count == Score.PerfectCount)
            badgeId = 2;
        else if (Score.music.notes.Count == Score.MaxCombo)
            badgeId = 1;
        if (SaveData.LoadBadges() != null)
            if (SaveData.LoadBadges().badgeId < badgeId)
                SaveData.SaveBadges(badgeId);
    }
}
