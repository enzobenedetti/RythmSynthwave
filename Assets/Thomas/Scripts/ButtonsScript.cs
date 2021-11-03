using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonsScript : MonoBehaviour
{
    public GameObject FirstSelected;
    
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

    void CheckOutline()
    {
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("OutlinedButton");

        foreach (GameObject button in Buttons)
        {
            if (button == EventSystem.current.currentSelectedGameObject)
            {
                OutlineButton(button);
            }
            else
            {
                if (button.GetComponent<Outline>())
                {
                    button.GetComponent<Outline>().enabled = false;
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void OutlineButton(GameObject ToOutline)
    {
        if (ToOutline.GetComponent<Outline>())
        {
            ToOutline.GetComponent<Outline>().enabled = true;
        }
        else
        {
            Outline objOutline = ToOutline.AddComponent<Outline>();
            objOutline.effectColor = Color.cyan;
            objOutline.effectDistance = new Vector2(5, 5);
        }
    }

    public void SetSelectedObject(GameObject firstSelected)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
    
    
}
