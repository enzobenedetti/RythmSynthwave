using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public Text musicName;
    public Text author;
    
    public Text score;
    public Text perfect;
    public Text nice;
    public Text ok;
    public Text bad;
    public Text combo;

    public Slider JaugeSlider;
    
    void Awake()
    {
        musicName.text = Score.music.name;
        author.text = Score.music.author;
        score.text = Score.score.ToString();
        perfect.text = "Perfect : " + Score.PerfectCount;
        nice.text = "Nice : " + Score.NiceCount;
        ok.text = "Ok : " + Score.OkCount;
        bad.text = "Bad : " + Score.BadCount;
        combo.text = Score.MaxCombo.ToString();
        JaugeSlider.value = Jauge.jauge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
