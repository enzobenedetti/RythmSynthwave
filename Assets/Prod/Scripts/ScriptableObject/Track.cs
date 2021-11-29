﻿using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Track")]
public class Track : ScriptableObject
{
    public int songId;
    
    public string author;

    public Sprite album;
    
    public float bpm;

    public float lenght;

    public AudioClip completeTrack;

    public AudioClip baseTrack;

    public AudioClip onComboTrack;
    
    public List<Note> notes;
    
    public Track(List<Note> notes)
    {
        this.notes = notes;
    }
}