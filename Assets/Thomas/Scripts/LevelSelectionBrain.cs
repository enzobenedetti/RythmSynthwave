using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


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
        
        public enum MusicSelection{MusicOne,MusicTwo,MusicThree}
        public MusicSelection CurHighlightedMusic;

        private void Awake()
        {
            CurHighlightedMusic = MusicSelection.MusicOne;
        }

        private void Update()
        {
            CheckInputs();
            CheckHighlightedMusic();
        }
        
        void CheckInputs()
        {
            if (Input.GetButtonDown("Central")) { StartSelectedMusic(); }
            
            if (Input.GetButtonDown("Up")) { ChangeMusicDown(); }
            
            if (Input.GetButtonDown("Down")) { ChangeMusicUp(); }
        }
        
        void StartSelectedMusic()
        {
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne:
                    
                    break;
                case MusicSelection.MusicTwo:
                    
                    break;
                case MusicSelection.MusicThree:
                    
                    break;
            }
        }

        void ChangeMusicUp()
        {
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

        void ChangeMusicDown()
        {
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
    }
}
