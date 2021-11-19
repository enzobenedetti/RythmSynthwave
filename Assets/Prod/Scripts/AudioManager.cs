using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioBase;

    [SerializeField] private AudioSource audioCombo;

    private float _comboVolume = 1f;
    public float comboVolume
    {
        get => _comboVolume;
        set
        {
            _comboVolume = value;
            if (_comboVolume >= 0.1f && _comboVolume <= 1f) return;
            if (_comboVolume < 0.1f) _comboVolume = 0.1f;
            if (_comboVolume > 1f) _comboVolume = 1f;
        }
    }
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

        if (MusicPlayer.OnPause)
        {
            audioBase.Pause();
            audioCombo.Pause();
        }
        if (Score.OnCombo) comboVolume += Time.deltaTime * 4;
        else comboVolume -= Time.deltaTime * 2;

        audioCombo.volume = comboVolume;
    }
}
