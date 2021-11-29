using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenuDisplay : MonoBehaviour
{
    private int[] ScoreMusic = new int[3];
    private int[] BadgesId = new int[3];
    public Sprite BadgeCombo, BadgePerfect;
    public Image DisplayedBadgeMusicOne, DisplayedBadgeMusicTwo, DisplayedBadgeMusicThree;

    public TextMeshProUGUI MusicOneScoreText, MusicTwoScoreText, MusicThreeScoreText;
    
    private void Start()
    {
        LoadSaves();

        MusicOneScoreText.text = ScoreMusic[0].ToString();
        MusicTwoScoreText.text = ScoreMusic[1].ToString();
        MusicThreeScoreText.text = ScoreMusic[2].ToString();

        
        switch (BadgesId[0])
        {
            case 0:
                DisplayedBadgeMusicOne.sprite = null;
                DisplayedBadgeMusicOne.color = Color.clear;
                break;
            case 1:
                DisplayedBadgeMusicOne.sprite = BadgeCombo;
                DisplayedBadgeMusicOne.color = Color.white;
                break;
            case 2:
                DisplayedBadgeMusicOne.sprite = BadgePerfect;
                DisplayedBadgeMusicOne.color = Color.white;
                break;
        }
        switch (BadgesId[1])
        {
            case 0:
                DisplayedBadgeMusicTwo.sprite = null;
                DisplayedBadgeMusicTwo.color = Color.clear;
                break;
            case 1:
                DisplayedBadgeMusicTwo.sprite = BadgeCombo;
                DisplayedBadgeMusicTwo.color = Color.white;
                break;
            case 2:
                DisplayedBadgeMusicTwo.sprite = BadgePerfect;
                DisplayedBadgeMusicTwo.color = Color.white;
                break;
        }
        switch (BadgesId[2])
        {
            case 0:
                DisplayedBadgeMusicThree.sprite = null;
                DisplayedBadgeMusicThree.color = Color.clear;
                break;
            case 1:
                DisplayedBadgeMusicThree.sprite = BadgeCombo;
                DisplayedBadgeMusicThree.color = Color.white;
                break;
            case 2:
                DisplayedBadgeMusicThree.sprite = BadgePerfect;
                DisplayedBadgeMusicThree.color = Color.white;
                break;
        }
    }


    public void LoadSaves()
    {
        BadgesData badges = SaveData.LoadBadges();
        BadgesId = badges.badgesId;
        
        HighScoreData hSData = SaveData.LoadHighScore();
        ScoreMusic = hSData.highscores;
    }
}
