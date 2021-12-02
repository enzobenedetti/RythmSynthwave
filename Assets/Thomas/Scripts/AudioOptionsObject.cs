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

    public GameObject AudioTabButton;

    public Slider RelatedSlider;

    public AudioSource UiReturnSound;
    
    private void Start()
    {
        RelatedSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
             gameObject.GetComponent<TextMeshProUGUI>().color = Color.cyan;
             if (Input.GetButtonDown("Cancel"))
             {
                 ButtonsScript.SetSelectedObject(AudioTabButton);
                 UiReturnSound.Play();
             }
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        
        if (EventSystem.current.currentSelectedGameObject == RelatedSlider.gameObject)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                ButtonsScript.SetSelectedObject(gameObject);
                UiReturnSound.Play();
            }
        }
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
