using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplayScript : MonoBehaviour
{ 
    [Header("Text")]
   public TextMeshProUGUI SweetEidolonText, CatchUpText, HowlingText;
   
   [SerializeField]private float SweetEidolonScore, CatchUpScore, HowlingScore;
   
      
   void Awake()
   {
       InitiateScores();
       DisplayScores();
   }

   private void Update()
   {
       
   }

   private void InitiateScores()
   {
       //Load High Scores from saves and change the value
   }

   private void DisplayScores()
   {
       
   }
}
