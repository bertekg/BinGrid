using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevels(LevelsData levelsData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levels.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, levelsData);
        stream.Close();
    }

    public static LevelsData LoadLevels()
    {
        string path = Application.persistentDataPath + "/levels.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelsData data = formatter.Deserialize(stream) as LevelsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static bool ClearData()
    {
        string path = Application.persistentDataPath + "/levels.fun";
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return false;
        }
    }
    public static void SaveAwardInfo(AwardData singleAward)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/award.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, singleAward);
        stream.Close();
    }
    public static AwardData LoadAwardInfo()
    {
        string path = Application.persistentDataPath + "/award.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            AwardData data = formatter.Deserialize(stream) as AwardData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static bool ClearAwardData()
    {
        string path = Application.persistentDataPath + "/award.fun";
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return false;
        }
    }
}
