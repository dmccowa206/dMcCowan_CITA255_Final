using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : GunPlayerS
{
    public override GameObject BulletType()
    {
        return bullet;
    }
    public override int DamageDealt()
    {
        return base.DamageDealt();
    }
    public override bool GetPlayerUsable()
    {
        return false;
    }
}
