using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace UI
{
    public class LevelSelection : MonoBehaviour
    {
        public enum MusicSelection{MusicOne,MusicTwo,MusicThree}
        public MusicSelection CurHighlightedMusic;
        
        private void Awake()
        {
            CurHighlightedMusic = MusicSelection.MusicOne;
        }

        private void Update()
        {
            CheckInputs();
        }

        void CheckInputs()
        {
            if (Input.GetButtonDown("Central")) { StartSelectedMusic(); }
            
            if (Input.GetButtonDown("Down")) { ChangeMusicDown(); }
            
            if (Input.GetButtonDown("Up")) { ChangeMusicUp(); }
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
    }
}
