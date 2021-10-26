using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public static float timer = -1f;

    private bool _timerOn = false;

    // Update is called once per frame
    void Update()
    {
        if (_timerOn)
            timer += Time.deltaTime;
    }

    public void StartTimer()
    {
        _timerOn = true;
    }

    public void StopTimer()
    {
        _timerOn = false;
    }

    public void ResetTimer()
    {
        _timerOn = false;
        timer = -1f;
    }
}