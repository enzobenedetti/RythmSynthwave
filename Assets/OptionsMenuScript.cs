using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject AudioTab, ControlsTab;
    public float HighlightedTabWidth, HighlightedTabHeight;

    private float normalTabWidth, normalTabHeight;

    public enum TabState { AudioTab, ControlsTab};
    public TabState CurOptionTabState;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == AudioTab)
        {
            HighlightTab(AudioTab);
        }

        if(EventSystem.current.currentSelectedGameObject == ControlsTab)
        {
            
        }
    }

    void HighlightTab(GameObject Tab)
    {
        
    }
}
