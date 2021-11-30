using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public TextMeshProUGUI musicName;
    public TextMeshProUGUI author;

    public GetBadges BadgesScript;

    public TextMeshProUGUI result;
    public Image badges;
    public Sprite perfectBadge;
    public Sprite comboBadge;
    public Image perso;
    public Sprite happy;
    public Sprite sad;
    
    public TextMeshProUGUI score;
    public TextMeshProUGUI perfect;
    public TextMeshProUGUI nice;
    public TextMeshProUGUI ok;
    public TextMeshProUGUI bad;
    public TextMeshProUGUI combo;

    public Slider JaugeSlider;
    
    void Start()
    {
        musicName.text = Score.music.name;
        author.text = Score.music.author;

        switch (BadgesScript.badgesId[Score.music.songId])
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
        perso.sprite = Jauge.jauge >= 75 ? happy : sad;

        if (Score.score > SaveData.LoadHighScore().highscores[Score.music.songId])
        {
            int[] MusicHsData = new int[3] {0, 0, 0};
            if (!SaveData.HighScoresExist()) SaveData.SaveBadges(new[] {0, 0, 0});
            else MusicHsData = SaveData.LoadHighScore().highscores;
            MusicHsData[Score.music.songId] = Score.score;
            SaveData.SaveHighScore(MusicHsData);
        }
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
