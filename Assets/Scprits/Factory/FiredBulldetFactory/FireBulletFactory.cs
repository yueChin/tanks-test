using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


class FireBulletFactory : IFiredBulletFactory
{
    public FiredBullet OpenFire(TurretType turretType,Transform transform,Bullet bullet)
    {
        FiredBullet firedBullet = null;        
        switch (turretType)
        {
            case TurretType.ShellTurret:
                firedBullet = new FireShell(transform,bullet);
                break;
            case TurretType.MissileLauncher:
                firedBullet = new FireMissile(transform,bullet);
                GameFacade.Instance.AddBullet(firedBullet);
                break;
            case TurretType.LaserBeamer:
                firedBullet = new FireLaser(transform,bullet);
                break;
            case TurretType.CanonTurret:
                firedBullet = new FireCanonBall(transform,bullet);
                break;
        }
        return firedBullet;
    }
}

