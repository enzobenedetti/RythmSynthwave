using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDisplayParameters")]
public class LevelSelectionDisplay : ScriptableObject
{
    public Track TrackMainInfo;

    public string SceneRelatedToTrack;
    
    public enum Difficulty{Easy,Medium,Hard}
    public Difficulty MusicDifficulty;
}
