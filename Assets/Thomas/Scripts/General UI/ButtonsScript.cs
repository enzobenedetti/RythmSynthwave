using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;



public class ButtonsScript : MonoBehaviour
{
    public GameObject FirstSelected;
    [CanBeNull]public GameObject TitleScreen;
    [CanBeNull]public GameObject MainMenu;
    
    [CanBeNull]public Sprite Background,BlurredBackground;
    
    public Color SelectedColor;

    [CanBeNull]public AudioSource AudioLaunch;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GameVolume");
        Debug.Log(PlayerPrefs.GetFloat("GameVolume"));

        if (PlayerPrefs.GetInt("HasSeenTitleScreen") != 1)
        {
            DisplayTitleScreen();
        }
        else
        {
            if (TitleScreen != null) TitleScreen.SetActive(false);    
            if(MainMenu != null)MainMenu.SetActive(true);
            SetSelectedObject(FirstSelected);
        }
    }
    
    public static void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        //Application.ExternalEval("document.location.reload(true)");
        //Application.OpenURL("https://forest-ier.itch.io/rythmwave");
        Application.Quit();
    }
    
    private void Update()
    {
        CheckOutline();

        if (TitleScreen != null)
        {
            if (TitleScreen.activeSelf)
            {
                if (Input.anyKeyDown)
                {
                    TitleScreen.SetActive(false);
                    if (MainMenu != null)MainMenu.SetActive(true);
                    SetSelectedObject(FirstSelected);
                    if(AudioLaunch != null)AudioLaunch.Play();
                }
            }
        }

        if (MainMenu != null)
        {
            if(MainMenu.activeSelf) gameObject.GetComponent<Image>().sprite = Background;
            else gameObject.GetComponent<Image>().sprite = BlurredBackground;
        }
    }
    void CheckOutline()
    {
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("OutlinedButton");

        foreach (GameObject button in Buttons)
        {
            if (button == EventSystem.current.currentSelectedGameObject)
            {
                //button.GetComponent<RectTransform>().DOShakePosition(0.75f, 20, 1, 80, false);
                button.GetComponent<Image>().color = SelectedColor;
            }
            else
            {
                button.transform.localScale = Vector3.one;
                button.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public static void SetSelectedObject(GameObject firstSelected)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


    void DisplayTitleScreen()
    {
        PlayerPrefs.SetInt("HasSeenTitleScreen", 1);
        TitleScreen.SetActive(true);
    }
}
