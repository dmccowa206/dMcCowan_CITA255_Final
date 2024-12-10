using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHolder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] Slider hpSlider;
    GameManagerScr gm;
    void Start()
    {
        gm = FindObjectOfType<GameManagerScr>();
    }
    
    void Update()
    {
        if (gm.GetMakeUI())
        {
            gm.SetHPSlider(hpSlider);
            gm.SetHighScoreText(highScoreText);
            gm.SetScoreText(scoreText);
        }
    }
}
