using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public class SaveSytem
{

    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //string path1 = Application.persistentDataPath + "/FUN";
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/fun.rtf";
        
        Debug.Log(path);

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData();

        formatter.Serialize(stream, playerData);

        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/fun.rtf";

        if (File.Exists(path))
        {
            Debug.Log(true);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("SaveFilr not existant!!");
            return null;
        }
    }
}