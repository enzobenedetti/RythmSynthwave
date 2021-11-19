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

    private void Awake()
    {
        RelatedSlider.value = SaveData.LoadAudioParameters().GameVolume;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
             gameObject.GetComponent<TextMeshProUGUI>().color = Color.cyan;
             if (Input.GetButtonDown("Cancel"))
             {
                 ButtonsScript.SetSelectedObject(AudioTabButton);
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
            }
        }
        
        RelatedValueText.text = RelatedSlider.value.ToString("F1");
        
        AudioListener.volume = RelatedSlider.value;
    }

    public void SaveAudioVolume()
    {
        SaveData.SaveAudioParameters(AudioListener.volume);
        Debug.Log("Saved audio at " + RelatedSlider.value);
    }
}
