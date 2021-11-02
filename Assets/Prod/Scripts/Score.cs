using UnityEngine;
using UnityEngine.UI;

public class Score
{

    public static int score = 0;

    public static int Combo = 0;
    
    public static bool OnCombo;

    public static void AddCombo()
    {
        Combo++;
        OnCombo = true;
        if (Combo < 5) return;
        if (Combo < 15) score += 1;
        else if (Combo < 30) score += 5;
        else score += 10;
    }

    public static void GotPerfect()
    {
        score += 10;
        AddCombo();
        ScoreUI.UpdateUI();
    }
    public static void GotNice()
    {
        score += 5;
        AddCombo();
        ScoreUI.UpdateUI();
    }
    public static void GotOk()
    {
        score += 1;
        AddCombo();
        ScoreUI.UpdateUI();
    }

    public static void GotBad()
    {
        Combo = 0;
        ScoreUI.UpdateUI();
    }
}