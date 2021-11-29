using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisplayBehaviour : MonoBehaviour
{
    private float timerBalise;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBalise + 0.5f <= Timer.timer)
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
            
    }

    private void OnEnable()
    {
        timerBalise = Timer.timer;
        transform.DOKill();
        transform.DOPunchScale(Vector3.one, 0.45f, Jauge.isOutRun? 5 : 3);
    }

    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
