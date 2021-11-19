using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public static float timer = -1f;

    public static float outOfPauseTimer = 0f;
    public float unPauseTime = 3f;
    private static bool _isOutOfPause;
    
    private static bool _timerOn = true;
    
    // Update is called once per frame
    void Update()
    {
        if (_timerOn)
            timer += Time.deltaTime;
        if (_isOutOfPause)
            outOfPauseTimer += Time.deltaTime;
        if (outOfPauseTimer >= unPauseTime)
            StartTimer();
    }

    public static void StartTimer()
    {
        _timerOn = true;
        _isOutOfPause = false;
        outOfPauseTimer = 0f;
    }

    public static void StopTimer()
    {
        _timerOn = false;
    }

    public static void ResetTimer()
    {
        _timerOn = false;
        timer = -1f;
    }

    public static void UnPauseTimer()
    {
        _isOutOfPause = true;
    }
}