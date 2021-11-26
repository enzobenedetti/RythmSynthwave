using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

    public GameObject PauseTab,PauseAnimationTab;

    private float UnPauseAnimationTime;
    
    
    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GameVolume");
        VolumeSlider.GetComponent<Slider>().value = AudioListener.volume;
    }
    private void Awake()
    {
        ButtonsScript.SetSelectedObject(FirstSelected);
        UnPauseAnimationTime = FindObjectOfType<Timer>().unPauseTime;
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
        
        AudioListener.volume = VolumeSlider.GetComponent<Slider>().value;
        
        if (PlayerPrefs.GetFloat("GameVolume") != AudioListener.volume )
        {
            SaveVolume();
        }
    }
    
    public void Pause()
    {
        if (PauseAnimationTab.activeSelf != true)
        {
            switch (PauseTab.activeSelf)
            {
                case true:
                    StartCoroutine("ExitPause");
                    break;
                case false:
                    MusicPlayer.SetPause();
                    PauseTab.SetActive(true);
                    if (PauseAnimationTab.activeSelf)
                    {
                        PauseAnimationTab.SetActive(false);
                    }
                    break;
            }
        }
    }

     IEnumerator ExitPause()
    {
        
        MusicPlayer.QuitPause();
        PauseTab.SetActive(false);
        PauseAnimationTab.SetActive(true);
        yield return new WaitForSeconds(UnPauseAnimationTime);
        PauseAnimationTab.SetActive(false);
    }

    public void SaveVolume()
    {
        SaveData.SaveAudioParameters(AudioListener.volume);
        Debug.Log("Saved audio at " + VolumeSlider.GetComponent<Slider>().value);
    }
}
