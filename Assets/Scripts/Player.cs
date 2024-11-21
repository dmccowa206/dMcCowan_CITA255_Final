using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damage;
    public float hp;
    public event Action OnPlayerClick;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void PlayerClick()
    {
        OnPlayerClick?.Invoke();
    }
    void Shoot()
    {
    }
    void Damage()
    {
    }
}
