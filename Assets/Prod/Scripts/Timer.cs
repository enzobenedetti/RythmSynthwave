using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public static float timer = -1f;

    private static bool _timerOn = true;
    
    // Update is called once per frame
    void Update()
    {
        if (_timerOn)
            timer += Time.deltaTime;
    }

    public static void StartTimer()
    {
        _timerOn = true;
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
}