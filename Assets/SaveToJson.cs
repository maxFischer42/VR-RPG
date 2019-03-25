using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveToJson : MonoBehaviour
{
    public SaveData dataRef;
    string dataPath;

    private void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "svDTA");
    }


    static void SaveData(SaveData data, string path)
    {
        string jsonString = JsonUtility.ToJson(data);
        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    static SaveData LoadData (string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SaveData>(jsonString);
        }
    }
}
