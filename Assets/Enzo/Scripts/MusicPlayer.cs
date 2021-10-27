using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject notesPrefab;

    public Track track;
    private int nextNote;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveNote.speed = track.bpm / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextNote < track.notes.Count)
            if (Timer.timer >= track.notes[nextNote].timeCode - (60/track.bpm) * 3)
            {
                GameObject currentNote = Instantiate(notesPrefab, Vector3.zero, Quaternion.identity);
                currentNote.GetComponent<MoveNote>().NoteType = track.notes[nextNote].type;
                nextNote++;
            }
        if (track.lenght <= Timer.timer) Timer.StopTimer();
    }
    
}