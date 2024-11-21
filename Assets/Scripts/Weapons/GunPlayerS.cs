using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerS : MonoBehaviour
{
    [SerializeField] GameObject bulletS;
    [SerializeField] int damage = 1;
    bool destroyOnCollide = true;
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
}
