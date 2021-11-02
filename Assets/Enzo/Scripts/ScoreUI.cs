using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    
    public static Text scoreText;
    public static Text comboText;
    public static Text maxText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<Text>();
        maxText = GameObject.Find("MaxCombo").GetComponent<Text>();
    }

    // Update is called once per frame
    public static void UpdateUI()
    {
        scoreText.text = "Score : " + Score.score;
        comboText.text = "Combo : " + Score.Combo;
        maxText.text = "Combo Max : " + Score.MaxCombo;
    }
}
