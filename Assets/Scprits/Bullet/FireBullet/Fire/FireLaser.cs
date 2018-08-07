using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FireLaser : FiredBullet,IFire
{
    //private LineRenderer mLineRenderer;
    //new private BulletType mBulletType = BulletType.Laser;
    public FireLaser(Transform _FireSpot, Bullet _Bullet) : base(_FireSpot, _Bullet) { }

    public override GameObject Fire()
    {
        throw new NotImplementedException();
    }
}


