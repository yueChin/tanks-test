using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMissile :Turret {

    public TurretMissile(GameObject gameObject,TurretAttr turretAttr) : base(gameObject,turretAttr) {
        mFireSpot = UnityTool.FindOneOfActiveChild(gameObject, "FireSpot").transform;
    }

    public override void Fire()
    {
        mAudioSource.Play();
        mBullet = FactoryManager.BulletFactory.CreateBullet<BulletShell>(TurretType, mHoldTime); //生成子弹: 子弹类型，预制件，数值属性
        FiredBullet missile = FactoryManager.FiredBulletFactory.OpenFire(TurretType, mFireSpot, mBullet);
        missile.Fire();
    }
}
