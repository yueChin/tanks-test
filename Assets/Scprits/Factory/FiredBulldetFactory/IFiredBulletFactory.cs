using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface IFiredBulletFactory
{
    FiredBullet OpenFire(TurretType turretType, Transform transform, Bullet bullet);
}

