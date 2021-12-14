using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace UI
{
    public class MusicSelectionBrain : MonoBehaviour
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
        [Space] 
        public float AnimationTime = 0.3f;

        public AudioSource LaunchGameSound,ClickSound;

        [CanBeNull] public Animator LevelSelectorAnimator;
        
        [Header("Checks")] 
        public bool OnMiddleTab;
        private bool IsInAnimation;
        
        public enum MusicSelection{MusicOne,MusicTwo,MusicThree}
        public MusicSelection CurHighlightedMusic;

        public TransitonScreen transition;
        
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
                if (IsInAnimation == false)
                {
                    if (Input.GetButtonDown("Up")) StartCoroutine(nameof(ChangeMusicUp));
                
                    if (Input.GetButtonDown("Down")) StartCoroutine(nameof(ChangeMusicDown));
                }
                if (Input.GetButtonDown("Down Left")) ChangeSpeedDown();
                
                if (Input.GetButtonDown("Down Right")) ChangeSpeedUp();
            }
        }
        
        public void StartSelectedMusic()
        {
            if (IsInAnimation == false)
            {
                switch (CurHighlightedMusic)
                {
                    case MusicSelection.MusicOne:
                        transition.ButtonLoadScene(1);
                        break;
                    case MusicSelection.MusicTwo:
                        transition.ButtonLoadScene(2);
                        break;
                    case MusicSelection.MusicThree:
                        transition.ButtonLoadScene(3);
                        break;
                }
                PlayerPrefs.SetFloat("MusicSpeed",Speed);
                LaunchGameSound.Play();
            }
        }

        public IEnumerator ChangeMusicDown()
        {
            ClickSound.Play();
            if (LevelSelectorAnimator != null)LevelSelectorAnimator.SetBool("GoDown",true);
            IsInAnimation = true;
            yield return new WaitForSeconds(AnimationTime + .01f);
            if (LevelSelectorAnimator != null)LevelSelectorAnimator.SetBool("GoDown",false);
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

            IsInAnimation = false;
        }
        
        public IEnumerator ChangeMusicUp()
        {
            ClickSound.Play();
            if (LevelSelectorAnimator != null)LevelSelectorAnimator.SetBool("GoUp",true);
            IsInAnimation = true;
            yield return new WaitForSeconds(AnimationTime + .01f);
            if (LevelSelectorAnimator != null)LevelSelectorAnimator.SetBool("GoUp",false);
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

            IsInAnimation = false;
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
            PlayerPrefs.SetFloat("MusicSpeed",Speed);
        }

        void ChangeSpeedDown()
        {
            if (Speed > 1) Speed -= 0.25f;
            PlayerPrefs.SetFloat("MusicSpeed",Speed);
        }
    }
}
