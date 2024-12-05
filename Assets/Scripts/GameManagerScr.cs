using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr instance;
    public GameObject bulletS, bulletL, bulletE;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
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
    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
