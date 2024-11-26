using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerS : MonoBehaviour
{
    public GameObject bulletS;
    [SerializeField] int damage = 1;
    [SerializeField] float fireRate = 1f;
    public virtual GameObject BulletType()
    {
        return bulletS;
    }
    public virtual int DamageDealt()
    {
        return damage;
    }
    public virtual void CollideDestroy()
    {
        Destroy(bulletS);
    }
    public virtual float GetFireRate()
    {
        return fireRate;
    }
}
