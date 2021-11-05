using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public GameObject notesPrefab;

    public Track track;
    private int nextNote;

    public static List<GameObject> noteOnScreen = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Score.music = track;
        MoveNote.speed = track.bpm / 60;
        Timer.ResetTimer();
        Timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        while (nextNote < track.notes.Count && Timer.timer >= track.notes[nextNote].timeCode - (60/track.bpm) * 3)
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
    }

    public static void DestroyNote(Note note)
    {
        foreach (GameObject noteGameObject in noteOnScreen)
        {
            if (noteGameObject.GetComponent<MoveNote>().Note == note)
            {
                Destroy(noteGameObject);
                break;
            }
        }
    }
}