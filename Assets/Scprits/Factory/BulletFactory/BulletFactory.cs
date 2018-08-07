using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletFactory : IBulletFactory
{
    public Bullet CreateBullet<T>(TurretType turretType, float holdTime) where T : Bullet, new()
    {
        Bullet bullet = new T();

        IBulletBuilder builder = new BulletBuilder(bullet,turretType, holdTime);

        return BuilderBuilderDirector.Construct(builder);
    }
}
