using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBadges : MonoBehaviour
{
    private bool allPerfectBadge;
    private bool fullCombo;
    
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
            allPerfectBadge = true;
        else if (Score.music.notes.Count == Score.MaxCombo)
            fullCombo = true;
    }
}
