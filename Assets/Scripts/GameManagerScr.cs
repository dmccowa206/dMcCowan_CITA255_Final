using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr instance;
    public float hp = 10;
    // public GameObject bulletS, bulletL, bulletE;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI highScoreText;
    int score = 0, highScore = 0;
    Slider hpSlider;
    public List<GameObject> weapons;
    bool makeUI = true;
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
    void Update()
    {
        UpdateScore();
        hpSlider.value = hp / 10;
        if (hp <= 0)
        {
            SetHighScore();
            score = 0;
            hp = 10;
            SceneManager.LoadScene("Main");
            makeUI = true;
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
        highScoreText.text = "High Score: " + highScore;
    }
    public void GainScore()
    {
        score += 100;
        UpdateScore();
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
    public void SetHighScore(int hs)
    {
        if (hs > highScore)
        {
            highScore = hs;
        }
    }
    public void SetHighScoreText(TextMeshProUGUI txt)
    {
        highScoreText = txt;
    }
    public void SetScoreText(TextMeshProUGUI txt)
    {
        scoreText = txt;
        makeUI = false;
    }
    public void SetHPSlider(Slider slider)
    {
        hpSlider = slider;
    }
    public bool GetMakeUI()
    {
        return makeUI;
    }
}
