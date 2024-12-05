using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr instance;
    public float hp = 10;
    public GameObject bulletS, bulletL, bulletE;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    [SerializeField] Slider hpSlider;
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
    }
    void Update()
    {
        hpSlider.value = hp / 10;
    }
    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GainScore()
    {
        score += 100;
        UpdateScore();
    }
}
