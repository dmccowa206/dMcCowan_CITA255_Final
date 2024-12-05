using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{
    GameObject bInstance, weapon;
    [SerializeField] float bSpd = 2f;
    [SerializeField] float bLife = 2f;
    Turret turret;
    Vector2 direction;
    GameManagerScr gm;
    void Awake()
    {
        gm = FindObjectOfType<GameManagerScr>();
        turret = FindObjectOfType<Turret>();
    }
    public void Shoot(GameObject bullet, Vector2 dir, Transform source)
    {
        bInstance = Instantiate(bullet, source);
        bInstance.transform.up = dir;
        Vector2 target = new Vector2(dir.x-source.position.x, dir.y-source.position.y);
        Rigidbody2D rb = bInstance.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.velocity = dir * bSpd;
        }
        Destroy(bInstance, bLife);
    }
    public void PlayerShoot()
    {
        weapon = turret.GetCurrentWeapon();
        direction = turret.transform.up;
        Shoot(weapon, direction, turret.transform);
    }
    public void ConstantFire(float fireRate)
    {
        InvokeRepeating("PlayerShoot", 0, fireRate);
    }
    public void EnemyShoot()
    {
        weapon = gm.bulletE;
        direction = gm.transform.position;
        Shoot(weapon, direction, gameObject.transform);
    }
}