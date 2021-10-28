using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    public static float speed = 2f;

    public Note Note;

    public SpriteRenderer SpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.sprite = Note.type.sprite;
        if (Note.type.direction == Vector3.zero)
            transform.localScale = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Note.type.Movement(this.transform, speed);
    }

    private void OnDestroy()
    {
        MusicPlayer.noteOnScreen.Remove(gameObject);
    }
}
