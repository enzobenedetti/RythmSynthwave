using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public Text musicName;
    public Text author;

    public GetBadges BadgesScript;

    public TextMeshProUGUI result;
    public Image badges;
    public Sprite perfectBadge;
    public Sprite comboBadge;
    
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

        switch (BadgesScript.badgeId)
        {
            case 0:
                badges.sprite = null;
                badges.color = Color.clear;
                break;
            case 1:
                badges.sprite = comboBadge;
                break;
            case 2:
                badges.sprite = perfectBadge;
                break;
        }
        
        score.text = Score.score.ToString();
        perfect.text = "Perfect : " + Score.PerfectCount;
        nice.text = "Nice : " + Score.NiceCount;
        ok.text = "Ok : " + Score.OkCount;
        bad.text = "Bad : " + Score.BadCount;
        combo.text = Score.MaxCombo.ToString();
        JaugeSlider.value = Jauge.jauge;
        result.text = Jauge.jauge >= 75 ? "You win !" : "You lose...";
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene(0);
    }
}
