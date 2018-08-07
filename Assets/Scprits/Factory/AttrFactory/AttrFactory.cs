using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory{


    private Dictionary<Type, TankAttr> mTankAttrDict;
    private Dictionary<TurretType, TurretAttr> mTurretDict;
    private Dictionary<TurretType, BulletFeature> mBulletDict;

    public AttrFactory()
    {
        InitTankAttr();
        InitTurretAttr();
        InitBulletFeature();
    }

    public TankAttr GetTankAttr(Type t)
    {
        if (mTankAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型:" + t + "得到坦克属性(GetTankAttr)"); return null;
        }
        return mTankAttrDict[t];
    }

    public TurretAttr GetTurretAttr(TurretType TurretType)
    {
        if (mTurretDict.ContainsKey(TurretType) == false)
        {
            Debug.LogError("无法根据类型:" + TurretType + "得到炮塔属性(GetTurretAttr)"); return null;
        }
        return mTurretDict[TurretType];
    }

    public BulletFeature GetBulletFeature(TurretType TurretType)
    {
        if (mBulletDict.ContainsKey(TurretType) == false)
        {
            Debug.LogError("无法根据类型:" + TurretType + "得到子弹特性(GetBulletFeature)"); return null;
        }
        return mBulletDict[TurretType];
    }

    private void InitTankAttr()
    {
        mTankAttrDict = new Dictionary<Type, TankAttr>();
        mTankAttrDict.Add(typeof(Tank1), new TankAttr(100, 10, 5, KeyCode.J,"Tank1",1));
        mTankAttrDict.Add(typeof(Tank2), new TankAttr(100, 10, 5, KeyCode.Keypad1, "Tank2", 2));
    }
    private void InitTurretAttr()
    {
        mTurretDict = new Dictionary<TurretType, TurretAttr>();
        mTurretDict.Add(TurretType.ShellTurret, new TurretAttr(TurretType.ShellTurret,AudioType.ShellFiring,5));
        mTurretDict.Add(TurretType.CanonTurret, new TurretAttr(TurretType.CanonTurret,AudioType.CanonFiring,3));
        mTurretDict.Add(TurretType.LaserBeamer, new TurretAttr(TurretType.LaserBeamer,AudioType.LaserCharging,30));
        mTurretDict.Add(TurretType.MissileLauncher, new TurretAttr(TurretType.MissileLauncher,AudioType.MissileFiring,8));
    }
    private void InitBulletFeature()
    {
        mBulletDict = new Dictionary<TurretType, BulletFeature>();
        mBulletDict.Add(TurretType.ShellTurret, new BulletFeature(BulletType.Shell, AudioType.ShellExplosionAduio, EffectType.ShellExplosionEffect));
        mBulletDict.Add(TurretType.CanonTurret, new BulletFeature(BulletType.CanonBall,AudioType.CanonExplosionAudio, EffectType.CanonExplosionEffect));
        mBulletDict.Add(TurretType.LaserBeamer, new BulletFeature(BulletType.Laser,AudioType.noting, EffectType.noting));
        mBulletDict.Add(TurretType.MissileLauncher, new BulletFeature(BulletType.Missile,AudioType.MissileExplosionAudio, EffectType.MissileExplosionEffect));
    }
}
