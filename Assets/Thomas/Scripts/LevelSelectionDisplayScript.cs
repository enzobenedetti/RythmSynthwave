using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;


public class LevelSelectionDisplayScript : MonoBehaviour
{
    #region Level select Variables
    [Header("LevelSelectUpperTab")] 
    public TextMeshProUGUI UpperTitle;
    public TextMeshProUGUI UpperAuthor;
    public TextMeshProUGUI UpperDifficulty;
    public TextMeshProUGUI UpperBPM;
    public TextMeshProUGUI UpperTime;
    
    [Header("LevelSelectMiddleTab")] 
    public TextMeshProUGUI MiddleTitle;
    public TextMeshProUGUI MiddleAuthor;
    public TextMeshProUGUI MiddleDifficulty;
    public TextMeshProUGUI MiddleBPM;
    public TextMeshProUGUI MiddleTime;
    
    [Header("LevelSelectLowerTab")] 
    public TextMeshProUGUI LowerTitle;
    public TextMeshProUGUI LowerAuthor;
    public TextMeshProUGUI LowerDifficulty;
    public TextMeshProUGUI LowerBPM;
    public TextMeshProUGUI LowerTime;

    private LevelSelectionBrain LevelSelectionBrain;
    #endregion
    
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
    
    #region Level select Functions
    void UpperDisplay()
    {
        UpperTitle.text = LevelSelectionBrain.upperDisplayParameters.MusicTitle;
        UpperAuthor.text = LevelSelectionBrain.upperDisplayParameters.MusicAuthor;
        UpperTime.text =(LevelSelectionBrain.upperDisplayParameters.Minutes > 10 ? "" : "0") + LevelSelectionBrain.upperDisplayParameters.Minutes.ToString() +(LevelSelectionBrain.upperDisplayParameters.Seconds > 10 ? ":" : ":0")  + LevelSelectionBrain.upperDisplayParameters.Seconds;
        UpperBPM.text = LevelSelectionBrain.upperDisplayParameters.BPM.ToString();

        switch (LevelSelectionBrain.upperDisplayParameters.MusicDifficulty)
        {
            case LevelSelectionDisplayParameters.Difficulty.Easy:
                UpperDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Medium:
                UpperDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Hard:
                UpperDifficulty.text = "Hard";
                break;
        }
    }

    void MiddleDisplay()
    {
        MiddleTitle.text = LevelSelectionBrain.middleDisplayParameters.MusicTitle;
        MiddleAuthor.text = LevelSelectionBrain.middleDisplayParameters.MusicAuthor;
        MiddleTime.text = (LevelSelectionBrain.middleDisplayParameters.Minutes > 10 ? "" : "0") + LevelSelectionBrain.middleDisplayParameters.Minutes.ToString() + (LevelSelectionBrain.middleDisplayParameters.Seconds > 10 ? ":" : ":0") + LevelSelectionBrain.middleDisplayParameters.Seconds;
        MiddleBPM.text = LevelSelectionBrain.middleDisplayParameters.BPM.ToString();

        switch (LevelSelectionBrain.middleDisplayParameters.MusicDifficulty)
        {
            case LevelSelectionDisplayParameters.Difficulty.Easy:
                MiddleDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Medium:
                MiddleDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Hard:
                MiddleDifficulty.text = "Hard";
                break;
        }
    }

    void LowerDisplay()
    {
        LowerTitle.text = LevelSelectionBrain.lowerDisplayParameters.MusicTitle;
        LowerAuthor.text = LevelSelectionBrain.lowerDisplayParameters.MusicAuthor;
        LowerTime.text = (LevelSelectionBrain.middleDisplayParameters.Minutes > 10 ? "" : "0") + LevelSelectionBrain.lowerDisplayParameters.Minutes.ToString() + (LevelSelectionBrain.lowerDisplayParameters.Seconds > 10 ? ":" : ":0") + LevelSelectionBrain.lowerDisplayParameters.Seconds;
        LowerBPM.text = LevelSelectionBrain.lowerDisplayParameters.BPM.ToString();

        switch (LevelSelectionBrain.lowerDisplayParameters.MusicDifficulty)
        {
            case LevelSelectionDisplayParameters.Difficulty.Easy:
                LowerDifficulty.text = "Easy";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Medium:
                LowerDifficulty.text = "Medium";
                break;
            case LevelSelectionDisplayParameters.Difficulty.Hard:
                LowerDifficulty.text = "Hard";
                break;
        }
    }
    #endregion
}
