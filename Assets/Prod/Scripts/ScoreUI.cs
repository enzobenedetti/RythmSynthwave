using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    
    public static Text scoreText;
    public static Text comboText;
    public static Text maxText;
    public Text music;
    public Text author;
    public MusicPlayer playerMusic;
    
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<Text>();
        maxText = GameObject.Find("MaxCombo").GetComponent<Text>();
        music.text = playerMusic.track.name;
        author.text = playerMusic.track.author;
    }

    // Update is called once per frame
    public static void UpdateUI()
    {
        scoreText.text = "Score : " + Score.score;
        comboText.text = "Combo : " + Score.Combo;
        maxText.text = "Combo Max : " + Score.MaxCombo;
    }
}
