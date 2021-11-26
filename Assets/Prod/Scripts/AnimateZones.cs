using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateZones : MonoBehaviour
{
    public Transform zone1;
    public Transform zone2;
    public Transform zone3;
    public Transform zone4;
    public Transform zone5;
    public Transform zone6;
    public Transform zone7;
    public Transform zone8;
    public Transform zone9;

    // Update is called once per frame
    void Update()
    {
        if (Timer.TimerOn)
        {
            if (Input.GetButtonDown("Down Left"))
            {
                ShakeZone(zone1);
            }
            if (Input.GetButtonDown("Down"))
            {
                ShakeZone(zone2);
            }
            if (Input.GetButtonDown("Down Right"))
            {
                ShakeZone(zone3);
            }
            if (Input.GetButtonDown("Left"))
            {
                ShakeZone(zone4);
            }
            if (Input.GetButtonDown("Central"))
            {
                ShakeZone(zone5);
            }
            if (Input.GetButtonDown("Right"))
            {
                ShakeZone(zone6);
            }
            if (Input.GetButtonDown("Up Left"))
            {
                ShakeZone(zone7);
            }
            if (Input.GetButtonDown("Up Right"))
            {
                ShakeZone(zone9);
            }
            if (Input.GetButtonDown("Up"))
            {
                ShakeZone(zone8);
            }
        }
    }

    void ShakeZone(Transform zone)
    {
        zone.DOShakeScale(0.05f, Jauge.isOutRun? 2.2f : 0.8f, Jauge.isOutRun? 30 : 10, 0f, true).SetEase(Ease.OutElastic);
    }
}
