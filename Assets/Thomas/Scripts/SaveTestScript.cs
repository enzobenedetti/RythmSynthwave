using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace LesTestDeThomas
{
    public static class SaveTestScript
    {
        public static void SavePlayer(PlayerTest playerTest)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.test";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(playerTest);
            
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.test";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

               PlayerData data = formatter.Deserialize(stream) as PlayerData;
               stream.Close();

               return data;
            }
            else
            {
                Debug.LogError("file not found in " + path);
                return null;
            }
        }
    }    
}

