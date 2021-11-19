using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor.Audio;

public class PauseUiScript : MonoBehaviour
{
    public GameObject VolumeObject;
    public GameObject FirstSelected;
    public GameObject VolumeSlider;
    public TextMeshProUGUI VolumeValueText;
    
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
        VolumeValueText.text = VolumeSlider.GetComponent<Slider>().value.ToString();
        AudioListener.volume = VolumeSlider.GetComponent<Slider>().value;
    }

    public void SaveVolume()
    {
        SaveData.SaveAudioParameters(VolumeSlider.GetComponent<Slider>().value);
    }
}
