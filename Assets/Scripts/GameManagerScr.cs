using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr instance;
    public float hp = 10;
    // public GameObject bulletS, bulletL, bulletE;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0, highScore;
    [SerializeField] Slider hpSlider;
    const string FILE_DIR = "/Saves/";
    string FILE_NAME = "<name>.json";
    string FILE_PATH;
    public List<GameObject> weapons;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateScore();
        FILE_NAME = FILE_NAME.Replace("<name>", name);
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        if(File.Exists(FILE_PATH))
        {
            string jsonString = File.ReadAllText(FILE_PATH);
            highScore = JsonUtility.FromJson<int>(jsonString);
        }
    }
    void Update()
    {
        hpSlider.value = hp / 10;
        if (hp <= 0)
        {
            SetHighScore();
            score = 0;
            hp = 10;
            SceneManager.LoadScene("Main");
        }
    }
    public GameObject GetEnemyWeapon()
    {
        foreach (GameObject bullet in weapons)
        {
            if (bullet.name == "BulletEnemy")
            {
                return bullet;
            }
        }
        return null;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GainScore()
    {
        score += 100;
        UpdateScore();
    }
    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
    private void OnApplicationQuit()
    {
        //translate highScore to json, pretty print so it's human readable
        string fileContent = JsonUtility.ToJson(highScore, prettyPrint:true);
        //Debug.Log(fileContent);
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
