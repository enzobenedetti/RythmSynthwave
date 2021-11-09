using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNote : MonoBehaviour
{
    public float perfectBuffer = 0.05f;
    
    public float niceBuffer = 0.1f;

    public float okBuffer = 0.25f;

    public float badBuffer = 1f;

    public MusicPlayer MusicPlayer;

    public TimingDisplay TimingDisplay;

    private List<Note> notesLeft = new List<Note>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var t in MusicPlayer.track.notes)
        {
            notesLeft.Add(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (notesLeft.Count <= 0) return;
        if (Input.anyKeyDown && notesLeft[0].timeCode - badBuffer <= Timer.timer)
        {
            List<Note> aviableNote = new List<Note>();
            
            foreach (Note note in notesLeft)
            {
                if (note.timeCode - badBuffer <= Timer.timer && note.timeCode + okBuffer >= Timer.timer)
                {
                    aviableNote.Add(note);
                }
                else break;
            }
            
            if (Input.GetButtonDown("Down Left"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 1)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Down"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 2)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Down Right"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 3)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Left"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 4)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Central"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 5)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Right"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 6)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Up Left"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 7)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButton("Up Right"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 9)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            if (Input.GetButtonDown("Up"))
            {
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 8)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }

        }
        else if (Timer.timer >= notesLeft[0].timeCode + okBuffer)
        {
            TimingDisplay.DisplayResult(notesLeft[0].type.index, 1);
            MusicPlayer.DestroyNote(notesLeft[0]);
            notesLeft.Remove(notesLeft[0]);
            Score.GotBad();
        }
    }

    void CheckTiming(Note note)
    {
        if (Timer.timer <= note.timeCode + perfectBuffer &&
            Timer.timer >= note.timeCode - perfectBuffer)
        {
            TimingDisplay.DisplayResult(note.type.index, 4);
            Score.GotPerfect();
        }
        else if (Timer.timer <= note.timeCode + niceBuffer &&
                 Timer.timer >= note.timeCode - niceBuffer)
        {
            TimingDisplay.DisplayResult(note.type.index, 3);
            Score.GotNice();
        }
        else if (Timer.timer <= note.timeCode + okBuffer &&
                 Timer.timer >= note.timeCode - okBuffer)
        {
            TimingDisplay.DisplayResult(note.type.index, 2);
            Score.GotOk();
        }
        else
        {
            TimingDisplay.DisplayResult(note.type.index, 1);
            Score.GotBad();
        }
        notesLeft.Remove(note);
        MusicPlayer.DestroyNote(note);
    }
}
