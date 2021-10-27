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
                
                if (Input.GetButton("Down Left"))
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
                if (Input.GetButton("Down"))
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
                if (Input.GetButton("Down Right"))
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
                if (Input.GetButton("Left"))
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
                if (Input.GetButton("Central"))
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
                if (Input.GetButton("Right"))
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
                if (Input.GetButton("Up Left"))
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
                if (Input.GetButton("Up"))
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
                
            }
            else if (Timer.timer >= notesLeft[0].timeCode + okBuffer)
            {
                Debug.Log("Bad !");
                notesLeft.Remove(notesLeft[0]);
                //Score.GotBad();
            }
        }
    
        void CheckTiming(Note note)
        {
            if (Timer.timer <= note.timeCode + perfectBuffer &&
                Timer.timer >= note.timeCode - perfectBuffer)
            {
                Debug.Log("Perfect !");
                //Score.GotPerfect();
            }
            else if (Timer.timer <= note.timeCode + niceBuffer &&
                     Timer.timer >= note.timeCode - niceBuffer)
            {
                Debug.Log("Nice !");
                //Score.GotNice();
            }
            else if (Timer.timer <= note.timeCode + okBuffer &&
                     Timer.timer >= note.timeCode - okBuffer)
            {
                Debug.Log("OK");
                //Score.GotOk();
            }
            else
            {
                Debug.Log("Bad");
                //Score.GotBad();
            }
            notesLeft.Remove(note);
        }
}
