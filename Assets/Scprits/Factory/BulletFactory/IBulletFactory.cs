using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletFactory
{
    Bullet CreateBullet<T>(TurretType turretType,float holdTime) where T : Bullet, new();
}
