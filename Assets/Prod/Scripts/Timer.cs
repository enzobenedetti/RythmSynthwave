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
    public static bool IsOutOfPause;
    
    public static bool TimerOn = true;
    
    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
            timer += Time.deltaTime;
        if (IsOutOfPause)
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
        IsOutOfPause = false;
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
        IsOutOfPause = true;
        outOfPauseTimer = 0f;
    }
}