using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDisplayParameters")]
public class LevelSelectionDisplay : ScriptableObject
{
    public string MusicTitle;
    public string MusicAuthor;
    public int BPM;
    
    [Header("Music length")]
    [Range(0, 60)] public int Minutes;
    [Range(0, 60)] public int Seconds;
    
    public enum Difficulty{Easy,Medium,Hard}
    public Difficulty MusicDifficulty;
}
