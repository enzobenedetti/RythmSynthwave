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

    public Color SelectedColor;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GameVolume");
        Debug.Log(PlayerPrefs.GetFloat("GameVolume"));
    }

    private void Awake()
    {
        SetSelectedObject(FirstSelected);
    }
    
    public static void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }
    
    private void Update()
    {
        CheckOutline();
    }

    private GameObject LastButton;
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
                LastButton = null;
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
        SceneManager.LoadSceneAsync("MenuScene");
    }

}
