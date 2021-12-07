using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNote : MonoBehaviour
{
    public bool allPerfectCheat;
    public bool noBadCheat;
    
    public float perfectBuffer = 0.08f;
    
    public float niceBuffer = 0.15f;

    public float okBuffer = 0.3f;

    public float badBuffer = 1f;

    public MusicPlayer MusicPlayer;

    public TimingDisplay TimingDisplay;

    public AnimatePerso AnimatePerso;

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
        if (Input.anyKeyDown && notesLeft[0].timeCode - badBuffer <= Timer.timer && Timer.TimerOn)
        {
            List<Note> aviableNote = new List<Note>();
            
            foreach (Note note in notesLeft)
            {
                if (note.timeCode - badBuffer <= Timer.timer && note.timeCode + okBuffer >= Timer.timer &&
                    Timer.timer >= note.timeCode - (60/MusicPlayer.track.bpm) * 3 * (1/MusicPlayer.Speed))
                {
                    aviableNote.Add(note);
                }
                else if (note.timeCode - badBuffer !<= Timer.timer) break;
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

            if (Input.GetButtonDown("Up Right"))
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
            if (!allPerfectCheat && !noBadCheat)
            {
                ScoreBad(notesLeft[0]);
            }
            else if (allPerfectCheat) ScorePerfect(notesLeft[0]);
            else ScoreOk(notesLeft[0]);
        }
    }

    void CheckTiming(Note note)
    {
        if (allPerfectCheat) ScorePerfect(note);
        else if (Timer.timer <= note.timeCode + perfectBuffer &&
            Timer.timer >= note.timeCode - perfectBuffer)
        {
            ScorePerfect(note);
        }
        else if (Timer.timer <= note.timeCode + niceBuffer &&
                 Timer.timer >= note.timeCode - niceBuffer)
        {
            ScoreNice(note);
        }
        else if (Timer.timer <= note.timeCode + okBuffer &&
                 Timer.timer >= note.timeCode - okBuffer)
        {
            ScoreOk(note);
        }
        else
        {
            if (!noBadCheat) ScoreBad(note);
            else ScoreOk(note);
        }
        
    }
    private void ScorePerfect(Note note)
    {
        TimingDisplay.DisplayResult(note.type.index, 4);
        Score.GotPerfect();
        notesLeft.Remove(note);
        MusicPlayer.DestroyNote(note);
    }

    void ScoreNice(Note note)
    {
        TimingDisplay.DisplayResult(note.type.index, 3);
        Score.GotNice();
        notesLeft.Remove(note);
        MusicPlayer.DestroyNote(note);
    }
    private void ScoreOk(Note note)
    {
        TimingDisplay.DisplayResult(note.type.index, 2);
        Score.GotOk();
        notesLeft.Remove(note);
        MusicPlayer.DestroyNote(note);
    }
    void ScoreBad(Note note)
    {
        TimingDisplay.DisplayResult(note.type.index, 1);
        MusicPlayer.DestroyNote(note);
        notesLeft.Remove(note);
        AnimatePerso.BadAnimation();
        Score.GotBad();
    }
}
