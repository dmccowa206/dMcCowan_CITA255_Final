using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerL : GunPlayerS
{
    [SerializeField] GameObject bulletL;
    public override GameObject BulletType()
    {
        return bulletL;
    }
    public override int DamageDealt()
    {
        return base.DamageDealt() + 1;
    }
    public override void CollideDestroy()
    {
    }
}
