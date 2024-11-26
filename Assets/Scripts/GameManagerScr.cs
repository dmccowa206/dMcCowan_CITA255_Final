using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr instance;
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
}
