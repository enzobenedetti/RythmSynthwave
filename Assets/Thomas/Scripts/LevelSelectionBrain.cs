using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace UI
{
    public class LevelSelectionBrain : MonoBehaviour
    {
        [Header("Tracks")]
        public LevelSelectionDisplayParameters MusicOne;
        public LevelSelectionDisplayParameters MusicTwo;
        public LevelSelectionDisplayParameters MusicThree;
        
        [HideInInspector]public LevelSelectionDisplayParameters upperDisplayParameters;
        [HideInInspector]public LevelSelectionDisplayParameters middleDisplayParameters;
        [HideInInspector]public LevelSelectionDisplayParameters lowerDisplayParameters;

        [Space] public GameObject MiddleSelectionTab;
        
        [Space]
        public float Speed;
        public float MusicOneMaxSpeed;
        public float MusicTwoMaxSpeed;
        public float MusicThreeMaxSpeed;
        
        [Header("Checks")] 
        public bool OnMiddleTab;
        
        public enum MusicSelection{MusicOne,MusicTwo,MusicThree}
        public MusicSelection CurHighlightedMusic;
        
         
        
        private void Awake()
        {
            CurHighlightedMusic = MusicSelection.MusicOne;
            Speed = 1;
        }

        private void Update()
        {
            CheckState();
            CheckInputs();
            CheckHighlightedMusic();
        }

        void CheckState()
        {
            if ( MiddleSelectionTab == EventSystem.current.currentSelectedGameObject)
            {
                OnMiddleTab = true;
            }
            else
            {
                OnMiddleTab = false;
            }
        }
        
        void CheckInputs()
        {
            if (OnMiddleTab)
            {
                if (Input.GetButtonDown("Up")) ChangeMusicDown();
                
                if (Input.GetButtonDown("Down")) ChangeMusicUp();

                if (Input.GetButtonDown("Down Left")) ChangeSpeedDown();
                
                if (Input.GetButtonDown("Down Right")) ChangeSpeedUp();
            }
        }
        
        public void StartSelectedMusic()
        {
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne:
                    SceneManager.LoadScene("LevelOne");
                    break;
                case MusicSelection.MusicTwo:
                    SceneManager.LoadScene("LevelTwo");
                    break;
                case MusicSelection.MusicThree:
                    SceneManager.LoadScene("LevelThree");
                    break;
            }
        }

        public void ChangeMusicDown()
        {
            Speed = 1;
            
            switch (CurHighlightedMusic)
               { 
                   case MusicSelection.MusicOne:
                       CurHighlightedMusic = MusicSelection.MusicTwo;
                       break;
                   case MusicSelection.MusicTwo: 
                       CurHighlightedMusic = MusicSelection.MusicThree; 
                       break;
                   case MusicSelection.MusicThree: 
                       CurHighlightedMusic = MusicSelection.MusicOne; 
                       break;
            }
        }
        
        void ChangeMusicUp()
        {
            Speed = 1;
            
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne:
                    CurHighlightedMusic = MusicSelection.MusicThree;
                    break;
                case MusicSelection.MusicTwo:
                    CurHighlightedMusic = MusicSelection.MusicOne;
                    break;
                case MusicSelection.MusicThree:
                    CurHighlightedMusic = MusicSelection.MusicTwo;
                    break;
            }
        }

        void CheckHighlightedMusic()
        {
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne:
                    upperDisplayParameters = MusicThree;
                    middleDisplayParameters = MusicOne;
                    lowerDisplayParameters = MusicTwo;
                    break;
                case MusicSelection.MusicTwo:
                    upperDisplayParameters = MusicOne;
                    middleDisplayParameters = MusicTwo;
                    lowerDisplayParameters = MusicThree;
                    break;
                case MusicSelection.MusicThree:
                    middleDisplayParameters = MusicThree;
                    upperDisplayParameters = MusicTwo;
                    lowerDisplayParameters = MusicOne;
                    break;
            }
        }

        void ChangeSpeedUp()
        {
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne:
                    if (Speed < MusicOneMaxSpeed) Speed += 0.25f;
                    break;
                case MusicSelection.MusicTwo:
                    if (Speed < MusicTwoMaxSpeed) Speed += 0.25f;
                    break;
                case MusicSelection.MusicThree:
                    if (Speed < MusicThreeMaxSpeed) Speed += 0.25f;
                    break;
            }
        }

        void ChangeSpeedDown()
        {
            if (Speed > 1) Speed -= 0.25f;
        }

        public void SaveMusicSpeed()
        {
            SaveData.SaveNextMusicSpeed(Speed);
        }
    }
}
