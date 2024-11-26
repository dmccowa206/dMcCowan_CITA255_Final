using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damage;
    public float hp;
    public float fireRate;
    public event Action<float> OnPlayerClick;
    public event Action OnPlayerRelease;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerClick();
        }
        if(Input.GetMouseButtonUp(0))
        {
            PlayerRelease();
        }
    }
    void PlayerClick()
    {
        OnPlayerClick?.Invoke(fireRate);
    }
    void PlayerRelease()
    {
        OnPlayerRelease?.Invoke();
    }
}
