using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;


public class MusicSelectionUI : MonoBehaviour
{
    private MusicSelectionBrain _musicSelectionBrain;
    
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
    [Space] 
    public GameObject CommencerObject;
    public GameObject VitesseObject;
    
    [Header("LevelSelectLowerTab")] 
    public TextMeshProUGUI LowerTitle;
    public TextMeshProUGUI LowerAuthor;
    public TextMeshProUGUI LowerDifficulty;
    public TextMeshProUGUI LowerBPM;
    public TextMeshProUGUI LowerTime;

    
    #endregion

    [Space]
    public TextMeshProUGUI SpeedValueDisplay;
    
    private void Awake()
    {
        _musicSelectionBrain = GetComponentInParent<MusicSelectionBrain>();
    }

    private void Update()
    {
        UpperDisplay();
        MiddleDisplay();
        LowerDisplay();

        SpeedValueDisplay.text = _musicSelectionBrain.Speed.ToString();
    }
    
    #region Level select Functions
    void UpperDisplay()
    {
        UpperTitle.text = _musicSelectionBrain.upperDisplayParameters.MusicTitle;
        UpperAuthor.text = _musicSelectionBrain.upperDisplayParameters.MusicAuthor;
        UpperTime.text =(_musicSelectionBrain.upperDisplayParameters.Minutes > 10 ? "" : "0") + _musicSelectionBrain.upperDisplayParameters.Minutes.ToString() +(_musicSelectionBrain.upperDisplayParameters.Seconds > 10 ? ":" : ":0")  + _musicSelectionBrain.upperDisplayParameters.Seconds;
        UpperBPM.text = _musicSelectionBrain.upperDisplayParameters.BPM.ToString();

        switch (_musicSelectionBrain.upperDisplayParameters.MusicDifficulty)
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
        MiddleTitle.text = _musicSelectionBrain.middleDisplayParameters.MusicTitle;
        MiddleAuthor.text = _musicSelectionBrain.middleDisplayParameters.MusicAuthor;
        MiddleTime.text = (_musicSelectionBrain.middleDisplayParameters.Minutes > 10 ? "" : "0") + _musicSelectionBrain.middleDisplayParameters.Minutes.ToString() + (_musicSelectionBrain.middleDisplayParameters.Seconds > 10 ? ":" : ":0") + _musicSelectionBrain.middleDisplayParameters.Seconds;
        MiddleBPM.text = _musicSelectionBrain.middleDisplayParameters.BPM.ToString();

        switch (_musicSelectionBrain.middleDisplayParameters.MusicDifficulty)
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

        if (_musicSelectionBrain.OnMiddleTab)
        {
            CommencerObject.SetActive(true);     
            VitesseObject.SetActive(true);
        }
        else
        {
            CommencerObject.SetActive(false);     
            VitesseObject.SetActive(false);
        }
        
    }

    void LowerDisplay()
    {
        LowerTitle.text = _musicSelectionBrain.lowerDisplayParameters.MusicTitle;
        LowerAuthor.text = _musicSelectionBrain.lowerDisplayParameters.MusicAuthor;
        LowerTime.text = (_musicSelectionBrain.middleDisplayParameters.Minutes > 10 ? "" : "0") + _musicSelectionBrain.lowerDisplayParameters.Minutes.ToString() + (_musicSelectionBrain.lowerDisplayParameters.Seconds > 10 ? ":" : ":0") + _musicSelectionBrain.lowerDisplayParameters.Seconds;
        LowerBPM.text = _musicSelectionBrain.lowerDisplayParameters.BPM.ToString();

        switch (_musicSelectionBrain.lowerDisplayParameters.MusicDifficulty)
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
