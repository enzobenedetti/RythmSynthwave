using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioOptionsObject : MonoBehaviour
{
    public TextMeshProUGUI RelatedValueText;

    public Slider RelatedSlider;
    
    private void Start()
    {
        RelatedSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        AudioListener.volume = RelatedSlider.value;

        if (PlayerPrefs.GetFloat("GameVolume") != AudioListener.volume )
        {
            SaveAudioVolume();
        }
        RelatedValueText.text = RelatedSlider.value.ToString("F1");
    }

    public void SaveAudioVolume()
    {
        SaveData.SaveAudioParameters(AudioListener.volume);
        Debug.Log("Saved audio at " + RelatedSlider.value);
    }
}
