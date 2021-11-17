using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNote : MonoBehaviour
{
    public bool allPerfectCheat;
    public bool noBadCheat;
    
    public float perfectBuffer = 0.05f;
    
    public float niceBuffer = 0.1f;

    public float okBuffer = 0.25f;

    public float badBuffer = 1f;

    public MusicPlayer MusicPlayer;

    public TimingDisplay TimingDisplay;

    public AnimatePerso AnimatePerso;

    private List<Note> notesLeft = new List<Note>();

    private bool input1, input2, input3, input4, input5, input6, input7, input8, input9 = false;

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
                else if (note.timeCode - badBuffer !<= Timer.timer) break;
            }

            if (Input.GetButtonDown("Down Left") && !input1)
            {
                input1 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 1)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input1 = false;

            if (Input.GetButtonDown("Down") && !input2)
            {
                input2 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 2)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input2 = false;

            if (Input.GetButtonDown("Down Right") && !input3)
            {
                input3 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 3)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input3 = false;

            if (Input.GetButtonDown("Left") && !input4)
            {
                input4 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 4)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input4 = false;

            if (Input.GetButtonDown("Central") && !input5)
            {
                input5 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 5)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input5 = false;

            if (Input.GetButtonDown("Right") && !input6)
            {
                input6 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 6)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input6 = false;

            if (Input.GetButtonDown("Up Left") && !input7)
            {
                input7 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 7)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input7 = false;
            
            if (Input.GetButton("Up Right") && !input9)
            {
                input9 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 9)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input9 = false;

            if (Input.GetButtonDown("Up") && !input8)
            {
                input8 = true;
                foreach (Note note in aviableNote)
                {
                    if (note.type.index == 8)
                    {
                        CheckTiming(note);
                        break;
                    }
                }
            }
            else input8 = false;

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
            ScoreOk(note);
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
