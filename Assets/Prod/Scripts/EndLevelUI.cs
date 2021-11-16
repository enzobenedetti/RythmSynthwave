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

    public TextMeshProUGUI result;
    
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
        result.text = Jauge.jauge >= 75 ? "You win !" : "You lose...";
        Debug.Log("Level Ended");
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
