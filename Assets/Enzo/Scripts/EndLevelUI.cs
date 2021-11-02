using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public Text score;
    public Text perfect;
    public Text nice;
    public Text ok;
    public Text bad;
    public Text combo;
    
    void Awake()
    {
        score.text = Score.score.ToString();
        perfect.text = "Perfect : " + Score.PerfectCount;
        nice.text = "Nice : " + Score.NiceCount;
        ok.text = "Ok : " + Score.OkCount;
        bad.text = "Bad : " + Score.BadCount;
        combo.text = Score.MaxCombo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
