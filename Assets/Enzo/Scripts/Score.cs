using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Text scoreText;
    public static Text comboText;
    
    private static int _score = 0;

    private static int combo = 0;
    
    public static bool OnCombo;
    
    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    static void UpdateUI()
    {
        scoreText.text = "Score : " + _score;
        comboText.text = "Combo : " + combo;
    }

    public static void AddCombo()
    {
        combo++;
        OnCombo = true;
        if (combo < 5) return;
        if (combo < 15) _score += 1;
        else if (combo < 30) _score += 5;
        else _score += 10;
    }

    public static void GotPerfect()
    {
        _score += 10;
        AddCombo();
        UpdateUI();
    }
    public static void GotNice()
    {
        _score += 5;
        AddCombo();
        UpdateUI();
    }
    public static void GotOk()
    {
        _score += 1;
        AddCombo();
        UpdateUI();
    }

    public static void GotBad()
    {
        combo = 0;
        UpdateUI();
    }
}