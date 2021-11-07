using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveData
{
   #region High score saves & load
   public static void SaveHighScore(float highestScoreToSave)
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/High_Score.saves";
      FileStream stream = new FileStream(path, FileMode.Create);

      HighScoreData data = new HighScoreData(highestScoreToSave);
      
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

   #region MusicSpeed saves & load
   public static void SaveNextMusicSpeed(float nextMusicSpeed)
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/Music_Parameter.saves";
      FileStream stream = new FileStream(path, FileMode.Create);

      MusicSpeedData data = new MusicSpeedData(nextMusicSpeed);
      
      formatter.Serialize(stream, data);
      stream.Close();
   }

   public static MusicSpeedData LoadMusicSpeed()
   {
      string path = Application.persistentDataPath + "/Music_Parameter.saves";
      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         
         MusicSpeedData data = formatter.Deserialize(stream) as MusicSpeedData;
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
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/Game_Volume.saves";
      FileStream stream = new FileStream(path, FileMode.Create);

      GameVolumeData data = new GameVolumeData(audioVolume);
      
      formatter.Serialize(stream, data);
      stream.Close();
   }

   public static GameVolumeData LoadAudioParameters()
   {
      string path = Application.persistentDataPath + "/Game_Volume.saves";
      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         
         GameVolumeData data = formatter.Deserialize(stream) as GameVolumeData;
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
}
