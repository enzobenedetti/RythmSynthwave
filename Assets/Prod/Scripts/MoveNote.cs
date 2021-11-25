using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveNote : MonoBehaviour
{
    public static float speed = 2f;

    public Note Note;

    public SpriteRenderer SpriteRenderer;

    private float _noteTimer;

    private bool _destroyOutRun;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.sprite = Note.type.sprite;
        if (Note.type.direction == Vector3.zero)
            transform.localScale = new Vector3(4, 4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.TimerOn)
        {
            if (_destroyOutRun)
            {
                _noteTimer += Time.deltaTime;
                if (_noteTimer >= 0.25f) Destroy(gameObject);
            }
            else
            {
                Note.type.Movement(this.transform, speed);
            }
        }
    }

    public void OutRunDestroy()
    {
        _destroyOutRun = true;
        SpriteRenderer.DOColor(new Color(1f, 1f, 1f, 0f), 0.25f);
        transform.DOScale(3f, 0.25f);
    }

    private void OnDestroy()
    {
        MusicPlayer.noteOnScreen.Remove(gameObject);
    }
}
