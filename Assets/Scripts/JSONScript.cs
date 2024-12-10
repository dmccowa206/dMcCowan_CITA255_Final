using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONScript : MonoBehaviour
{
    const string FILE_DIR = "/Saves/";
    string FILE_NAME = "<name>.json";
    string FILE_PATH;
    int highScore;
    GameManagerScr gm;
    SerializableInt saveScore;
    void Start()
    {
        gm = FindObjectOfType<GameManagerScr>();
        FILE_NAME = FILE_NAME.Replace("<name>", "HighScore");
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        if(File.Exists(FILE_PATH))
        {
            string jsonString = File.ReadAllText(FILE_PATH);
            saveScore = JsonUtility.FromJson<SerializableInt>(jsonString);
            gm.SetHighScore(saveScore.value);
        }
    }
    private void OnApplicationQuit()
    {
        saveScore = new SerializableInt
        {
            value = gm.GetHighScore()
        };
        //translate highScore to json, pretty print so it's human readable
        string fileContent = JsonUtility.ToJson(saveScore, prettyPrint:true);
        Debug.Log(fileContent);
        if(!File.Exists(FILE_PATH))
        {
            if(!Directory.Exists(Application.dataPath + FILE_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + FILE_DIR);
            }
        }
        File.WriteAllText(FILE_PATH, fileContent);
    }
}
