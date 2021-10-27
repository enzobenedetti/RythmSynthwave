using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace Ui
{
    public class LevelSelection : MonoBehaviour
    {
        public enum MusicSelection{MusicOne,MusicTwo,MusicThree}
        public MusicSelection CurHighlightedMusic;

        public string MusicOneName;
        public string MusicTwoName;
        public string MusicThreeName;

        private void Start()
        {
            CurHighlightedMusic = MusicSelection.MusicOne;
        }

        private void Update()
        {
            CheckInputs();
        }

        void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartSelectedMusic();
            }
        }

        void StartSelectedMusic()
        {
            switch (CurHighlightedMusic)
            {
                case MusicSelection.MusicOne: 
                    SceneManager.LoadScene(MusicOneName);
                    break;
                case MusicSelection.MusicTwo: 
                    SceneManager.LoadScene(MusicTwoName);
                    break;
                case MusicSelection.MusicThree:
                    SceneManager.LoadScene(MusicThreeName);
                    break;
            }
        }
    }
}
