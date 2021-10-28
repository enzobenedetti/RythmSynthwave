using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("UpperTab")] 
    public TextMeshProUGUI UpperTitle;
    public TextMeshProUGUI UpperAuthor;
    public TextMeshProUGUI UpperDifficulty;
    public TextMeshProUGUI UpperBPM;
    public TextMeshProUGUI UpperTime;
    
    [Header("MiddleTab")] 
    public TextMeshProUGUI MiddleTitle;
    public TextMeshProUGUI MiddleAuthor;
    public TextMeshProUGUI MiddleDifficulty;
    public TextMeshProUGUI MiddleBPM;
    public TextMeshProUGUI MiddleTime;
    
    [Header("LowerTab")] 
    public TextMeshProUGUI LowerTitle;
    public TextMeshProUGUI LowerAuthor;
    public TextMeshProUGUI LowerDifficulty;
    public TextMeshProUGUI LowerBPM;
    public TextMeshProUGUI LowerTime;

    private LevelSelectionBrain LevelSelectionBrain;

    private void Awake()
    {
        LevelSelectionBrain = GetComponentInParent<LevelSelectionBrain>();
    }

    private void Update()
    {
        UpperDisplay();
        MiddleDisplay();
        LowerDisplay();
    }

    void UpperDisplay()
    {
        UpperTitle.text = LevelSelectionBrain.UpperDisplay.MusicTitle;
        UpperAuthor.text = LevelSelectionBrain.UpperDisplay.MusicAuthor;
        UpperTime.text =(LevelSelectionBrain.UpperDisplay.Minutes > 10 ? "" : "0") + LevelSelectionBrain.UpperDisplay.Minutes.ToString() +(LevelSelectionBrain.UpperDisplay.Seconds > 10 ? ":" : ":0")  + LevelSelectionBrain.UpperDisplay.Seconds;
        UpperBPM.text = LevelSelectionBrain.UpperDisplay.BPM.ToString();

        switch (LevelSelectionBrain.UpperDisplay.MusicDifficulty)
        {
            case LevelSelectionDisplay.Difficulty.Easy:
                UpperDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplay.Difficulty.Medium:
                UpperDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplay.Difficulty.Hard:
                UpperDifficulty.text = "Hard";
                break;
        }
    }

    void MiddleDisplay()
    {
        MiddleTitle.text = LevelSelectionBrain.MiddleDisplay.MusicTitle;
        MiddleAuthor.text = LevelSelectionBrain.MiddleDisplay.MusicAuthor;
        MiddleTime.text = (LevelSelectionBrain.MiddleDisplay.Minutes > 10 ? "" : "0") + LevelSelectionBrain.MiddleDisplay.Minutes.ToString() + (LevelSelectionBrain.MiddleDisplay.Seconds > 10 ? ":" : ":0") + LevelSelectionBrain.MiddleDisplay.Seconds;
        MiddleBPM.text = LevelSelectionBrain.MiddleDisplay.BPM.ToString();

        switch (LevelSelectionBrain.MiddleDisplay.MusicDifficulty)
        {
            case LevelSelectionDisplay.Difficulty.Easy:
                MiddleDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplay.Difficulty.Medium:
                MiddleDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplay.Difficulty.Hard:
                MiddleDifficulty.text = "Hard";
                break;
        }
    }

    void LowerDisplay()
    {
        LowerTitle.text = LevelSelectionBrain.LowerDisplay.MusicTitle;
        LowerAuthor.text = LevelSelectionBrain.LowerDisplay.MusicAuthor;
        LowerTime.text = (LevelSelectionBrain.MiddleDisplay.Minutes > 10 ? "" : "0") + LevelSelectionBrain.LowerDisplay.Minutes.ToString() + (LevelSelectionBrain.LowerDisplay.Seconds > 10 ? ":" : ":0") + LevelSelectionBrain.LowerDisplay.Seconds;
        LowerBPM.text = LevelSelectionBrain.LowerDisplay.BPM.ToString();

        switch (LevelSelectionBrain.LowerDisplay.MusicDifficulty)
        {
            case LevelSelectionDisplay.Difficulty.Easy:
                LowerDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplay.Difficulty.Medium:
                LowerDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplay.Difficulty.Hard:
                LowerDifficulty.text = "Hard";
                break;
        }
    }
}
