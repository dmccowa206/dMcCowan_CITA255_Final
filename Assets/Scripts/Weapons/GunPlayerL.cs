using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerL : GunPlayerS
{
    public override GameObject BulletType()
    {
        return bulletS;
    }
    public override int DamageDealt()
    {
        return base.DamageDealt() + 1;
    }
    public override void CollideDestroy()
    {
    }
}
