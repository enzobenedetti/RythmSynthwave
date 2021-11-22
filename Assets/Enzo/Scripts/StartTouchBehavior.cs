using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTouchBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform number in transform)
        {
            number.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timer >= -1f)
        {
            foreach (Transform number in transform)
            {
                number.gameObject.SetActive(false);
            }
        }
    }
}
