using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerS : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] int damage = 1;
    [SerializeField] float fireRate = 1f;
    public virtual GameObject BulletType()
    {
        return bullet;
    }
    public virtual int DamageDealt()
    {
        return damage;
    }
    public virtual void CollideDestroy()
    {
        Destroy(bullet);
    }
    public virtual float GetFireRate()
    {
        return fireRate;
    }
    public virtual bool GetPlayerUsable()
    {
        return true;
    }
}
