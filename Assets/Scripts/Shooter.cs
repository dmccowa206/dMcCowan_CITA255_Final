using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{
    GameObject bInstance;
    [SerializeField] float bSpd = 2f;
    [SerializeField] float bLife = 2f;
    public void Shoot(GameObject bullet)
    {
        bInstance = Instantiate(bullet, gameObject.transform);
        bInstance.transform.up = WorldPosition.GetMouseWorldPos();
        Rigidbody2D rb = bInstance.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.velocity = transform.up * bSpd;
        }
        Destroy(bInstance, bLife);
    }
    public void PlayerShoot()
    {
        GameObject weapon = GetComponentInChildren<Turret>().GetCurrentWeapon();
        if (weapon != null)
        {
            Debug.Log("weapon exists");
        }
        Shoot(weapon);
    }
    public void ConstantFire(float fireRate)
    {
        InvokeRepeating("PlayerShoot", 0, fireRate);
    }
}