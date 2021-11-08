using UnityEngine;
using UnityEngine.UI;

public static class Score
{

    public static int score = 0;

    public static int Combo = 0;

    private static int _maxCombo = 0;
    public static int MaxCombo
    {
        get => _maxCombo;
        set
        {
            if (value < _maxCombo) return;
            _maxCombo = value;
            
        }
    }

    public static int PerfectCount = 0;
    public static int NiceCount = 0;
    public static int OkCount = 0;
    public static int BadCount = 0;
    
    public static bool OnCombo = true;

    public static Track music;

    public static void AddCombo()
    {
        Combo++;
        MaxCombo = Combo;
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
        PerfectCount++;
        ScoreUI.UpdateUI();
    }
    public static void GotNice()
    {
        score += 5;
        AddCombo();
        NiceCount++;
        ScoreUI.UpdateUI();
    }
    public static void GotOk()
    {
        score += 1;
        AddCombo();
        OkCount++;
        ScoreUI.UpdateUI();
    }

    public static void GotBad()
    {
        Combo = 0;
        OnCombo = false;
        BadCount++;
        ScoreUI.UpdateUI();
    }

    public static void ResetScore()
    {
        OnCombo = true;
        Combo = 0;
        BadCount = 0;
        OkCount = 0;
        NiceCount = 0;
        PerfectCount = 0;
        _maxCombo = 0;
    }
}