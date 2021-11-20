using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseUiScript : MonoBehaviour
{
    public GameObject VolumeObject;
    public GameObject FirstSelected;
    public GameObject VolumeSlider;
    public TextMeshProUGUI VolumeValueText;

    public GameObject PauseTab;
    
    private void Awake()
    {
        VolumeSlider.GetComponent<Slider>().value = SaveData.LoadAudioParameters().GameVolume;
        ButtonsScript.SetSelectedObject(FirstSelected);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == VolumeObject)
        {
            if (Input.GetButtonDown("Central"))
            {
                ButtonsScript.SetSelectedObject(VolumeSlider);
            }
        }
        VolumeValueText.text = VolumeSlider.GetComponent<Slider>().value.ToString("F1");
        
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }
    
    public void Pause()
    {
        switch (PauseTab.activeSelf)
        {
        case true:
            PauseTab.SetActive(false);
            break;
        case false:
            PauseTab.SetActive(true);
            break;
        }
    }

    public void SaveVolume()
    {
        AudioListener.volume = VolumeSlider.GetComponent<Slider>().value;
        SaveData.SaveAudioParameters(AudioListener.volume);
        Debug.Log("Saved audio at " + VolumeSlider.GetComponent<Slider>().value);
    }
}