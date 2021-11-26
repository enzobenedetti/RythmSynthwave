using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveData
{
   #region High score saves & load
   public static void SaveHighScore(int highestScoreToSave, int LevelToSave)
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/High_Score.saves";
      FileStream stream = new FileStream(path, FileMode.Create);

      HighScoreData data = new HighScoreData(highestScoreToSave, LevelToSave);
      
      formatter.Serialize(stream, data);
      stream.Close();
   }

   public static HighScoreData LoadHighScore()
   {
      string path = Application.persistentDataPath + "/High_Score.saves";
      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         
         HighScoreData data = formatter.Deserialize(stream) as HighScoreData;
         stream.Close();
         
         return data;
      }
      else
      {
         Debug.LogError("File not found in " + path);
         return null;
      }
   }
   #endregion
   
   #region Audio parameters saves & load
   public static void SaveAudioParameters(float audioVolume)
   {
      PlayerPrefs.SetFloat("GameVolume", audioVolume);
   }
   #endregion

   #region Badges saves & load
   public static void SaveBadges(int[] id)
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/Badges.saves";
      FileStream stream;
      using (stream = new FileStream(path, FileMode.Create))
      {
         BadgesData data = new BadgesData(id);
         formatter.Serialize(stream, data);
         Debug.Log("Badges saves with data : " + data.badgesId[0] + data.badgesId[1] + data.badgesId[2]);
      }
   }

   public static BadgesData LoadBadges()
   {
      string path = Application.persistentDataPath + "/Badges.saves";
      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         BadgesData data;
         using (FileStream stream = new FileStream(path, FileMode.Open))
         {
            data = (BadgesData) formatter.Deserialize(stream);
         }
         Debug.Log("Badges load with data : " + data.badgesId[0] + data.badgesId[1] + data.badgesId[2]);
         return data;
      }
      else
      {
         Debug.LogError("File not found in " + path);
         return null;
      }
   }
   
   public static bool BadgesExist() {
      string path = Application.persistentDataPath + "/Badges.saves";
      return File.Exists(path);
   }
   
   #endregion
}


