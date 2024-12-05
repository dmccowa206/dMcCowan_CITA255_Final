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
        bInstance = Instantiate(bullet, source.position, source.rotation);
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
        direction = gm.transform.position - gameObject.transform.position;
        Shoot(weapon, direction, gameObject.transform);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "Player")//Player is getting hit
        {
            PlayerHit(other);
        }
        else if (gameObject.tag == "Enemy")//Enemy is getting hit
        {
            EnemyHit(other);
        }
    }
    void PlayerHit(Collider2D o)
    {
        if (o.tag == "Enemy")// if bullet is from enemy
        {
            //damage pc
            GunEnemy oGun = o.GetComponent<GunEnemy>();
            gm.hp -= oGun.DamageDealt();
            oGun.CollideDestroy();
        }
    }
    void EnemyHit(Collider2D o)
    {
        if (o.tag == "Player")//if bullet is from player
        {
            //damage pc
            GunPlayerS oGun = o.GetComponent<GunPlayerS>();
            gameObject.GetComponent<EnemyMove>().HitHp(oGun.DamageDealt());
            oGun.CollideDestroy();
            if (gameObject.GetComponent<EnemyMove>().GetHp() <= 0)
            {
                Destroy(gameObject);
                gm.GainScore();
            }
        }
    }
}