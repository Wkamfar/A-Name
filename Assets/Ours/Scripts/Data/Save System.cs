using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.gitgud";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fileStream, data); // do coinCount later
        fileStream.Close();
        //add  level counter later on
    }
    public static PlayerData playerLoad()
    {
        string path = Application.persistentDataPath + "/player.gitgud";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            Debug.Log("SaveSystem.playerLoad:" + data);
            return data;
        }
        else
        {
            Debug.Log("SaveSystem.playerLoad: Didn't load" + path);
            return null;
        }
    }
}
