using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    
    public static Text scoreText;
    public static TextMeshProUGUI comboText;
    public static TextMeshProUGUI maxText;
    public TextMeshProUGUI music;
    public TextMeshProUGUI author;
    public MusicPlayer playerMusic;
    public static Slider JaugeSlider;
    public Slider musicTime;
    
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<TextMeshProUGUI>();
        maxText = GameObject.Find("MaxCombo").GetComponent<TextMeshProUGUI>();
        JaugeSlider = GameObject.Find("Jauge").GetComponent<Slider>();
        
        music.text = playerMusic.track.name;
        author.text = playerMusic.track.author;
        scoreText.text = "Score : " + Score.score;
        comboText.text = "Combo : " + Score.Combo;
        maxText.text = "Combo Max : " + Score.MaxCombo;
        JaugeSlider.value = Jauge.jauge;
        musicTime.value = 0;
    }

    private void Update()
    {
        musicTime.value = Timer.timer / playerMusic.track.lenght;
    }

    // Update is called once per frame
    public static void UpdateUI()
    {
        scoreText.DOText(Score.score.ToString(), 0.3f, true, ScrambleMode.Numerals);
        comboText.text = "Combo : " + Score.Combo;
        maxText.text = "Combo Max : " + Score.MaxCombo;
        JaugeSlider.DOValue(Jauge.jauge, 0.25f, true).SetEase(Ease.InOutCirc);
    }
}
