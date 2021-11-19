using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    static string scorePath = Application.persistentDataPath + "score.fun";

    public static void SaveScore()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(scorePath, FileMode.Create);

        ScoreData data = new ScoreData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        if (File.Exists(scorePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(scorePath, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;

            stream.Close();

            return data;
        }
        else
        {
            print("There is no saved data in " + scorePath);
            return null;
        }
    }
}
