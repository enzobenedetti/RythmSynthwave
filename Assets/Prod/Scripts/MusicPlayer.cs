using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public GameObject notesPrefab;

    public Track track;
    private int nextNote;

    public float Speed = 1f;

    public static List<GameObject> noteOnScreen = new List<GameObject>();

    public static bool OnPause;

    // Start is called before the first frame update
    void Start()
    {
        Speed = SaveData.LoadMusicSpeed().SavedSpeedForNextMusic;
        Score.music = track;
        Score.ResetScore();
        Jauge.Reset();
        MoveNote.speed = track.bpm / 60 * Speed;
        Timer.ResetTimer();
        Timer.StartTimer();
        ScoreUI.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        while (nextNote < track.notes.Count && Timer.timer >= track.notes[nextNote].timeCode - (60/track.bpm) * 3 * (1/Speed))
        {
            GameObject currentNote = Instantiate(notesPrefab, Vector3.zero, Quaternion.identity);
            currentNote.GetComponent<MoveNote>().Note = track.notes[nextNote];
            noteOnScreen.Add(currentNote);
            nextNote++;
        }
        if (track.lenght <= Timer.timer)
        {
            Timer.StopTimer();
            SceneManager.LoadScene(4);
        }

        if (Input.GetButtonDown("Cancel") && !OnPause)
        {
            //SetPause();
        }
    }

    public static void DestroyNote(Note note)
    {
        foreach (GameObject noteGameObject in noteOnScreen)
        {
            if (noteGameObject.GetComponent<MoveNote>().Note == note)
            {
                noteOnScreen.Remove(noteGameObject);
                Destroy(noteGameObject);
                break;
            }
        }
    }

    void SetPause()
    {
        OnPause = true;
        Timer.StopTimer();
    }

    public void QuitPause()
    {
        OnPause = false;
        Timer.StartTimer();
    }
}