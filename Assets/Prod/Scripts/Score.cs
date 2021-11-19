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

    public static int AddCombo()
    {
        Jauge.Add();
        Combo++;
        MaxCombo = Combo;
        OnCombo = true;
        if (Combo < 5) return 0;
        if (Combo < 15) return 1;
        if (Combo < 30) return 5;
        return 10;
    }

    public static void GotPerfect()
    {
        int scoreToAdd = 10 + AddCombo();
        if (Jauge.isOutRun) scoreToAdd *= 2;
        score += scoreToAdd;
        PerfectCount++;
        ScoreUI.UpdateUI();
    }
    public static void GotNice()
    {
        int scoreToAdd = 5 + AddCombo();
        if (Jauge.isOutRun) scoreToAdd *= 2;
        score += scoreToAdd;
        NiceCount++;
        ScoreUI.UpdateUI();
    }
    public static void GotOk()
    {
        int scoreToAdd = 1 + AddCombo();
        if (Jauge.isOutRun) scoreToAdd *= 2;
        score += scoreToAdd;
        OkCount++;
        ScoreUI.UpdateUI();
    }

    public static void GotBad()
    {
        Combo = 0;
        Jauge.Remove();
        OnCombo = false;
        BadCount++;
        ScoreUI.UpdateUI();
    }

    public static void ResetScore()
    {
        score = 0;
        OnCombo = true;
        Combo = 0;
        BadCount = 0;
        OkCount = 0;
        NiceCount = 0;
        PerfectCount = 0;
        _maxCombo = 0;
    }
}