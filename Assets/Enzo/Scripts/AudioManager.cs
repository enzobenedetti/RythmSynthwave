using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioBase;

    [SerializeField] private AudioSource audioCombo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.timer >= 0f && !audioBase.isPlaying)
        {
            audioBase.Play();
            audioCombo.Play();
        }
    }
}
