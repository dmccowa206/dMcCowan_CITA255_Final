using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : GunPlayerS
{
    public override GameObject BulletType()
    {
        return bulletS;
    }
    public override int DamageDealt()
    {
        return base.DamageDealt();
    }
}
