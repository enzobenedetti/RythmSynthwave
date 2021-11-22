using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action GameResumed;
    
    public static float timer = -6f;

    public static float outOfPauseTimer = 0f;
    public float unPauseTime = 3f;
    private static bool _isOutOfPause;
    
    public static bool TimerOn = true;
    
    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
            timer += Time.deltaTime;
        if (_isOutOfPause)
            outOfPauseTimer += Time.deltaTime;
        if (outOfPauseTimer >= unPauseTime)
        {
            StartTimer();
            GameResumed?.Invoke();
        }
    }

    public static void StartTimer()
    {
        TimerOn = true;
        _isOutOfPause = false;
        outOfPauseTimer = 0f;
    }

    public static void StopTimer()
    {
        TimerOn = false;
    }

    public static void ResetTimer()
    {
        TimerOn = false;
        timer = -6f;
    }

    public static void UnPauseTimer()
    {
        _isOutOfPause = true;
        outOfPauseTimer = 0f;
    }
}