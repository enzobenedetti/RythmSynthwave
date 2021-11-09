using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBehaviour : MonoBehaviour
{
    private float timerBalise;
    
    // Start is called before the first frame update
    void Start()
    {
        timerBalise = Timer.timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBalise + 0.5f <= Timer.timer)
            Destroy(gameObject);
    }
}
