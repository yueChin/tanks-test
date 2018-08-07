using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder : IBulletBuilder
{
    protected Bullet mBullet;
    protected TurretType mTurretType;
    protected float mHoldTime;
    protected BulletCollider mBulletCollider;

    public BulletBuilder(Bullet bullet, TurretType turretType, float holdTime)
    {
        mTurretType = turretType;
        mHoldTime = holdTime;
        mBullet = bullet;
    }

    public void AddBulletAttr()
    {
        mBullet.SetBulletAttr(mHoldTime);
    }

    public void AddBulletFeature()
    {
        BulletFeature bulletFeature = FactoryManager.attrFactory.GetBulletFeature(mTurretType); 
        mBullet.BulletFeature = bulletFeature;
    }

    public void AddGameObject()
    {
        GameObject BulletGO = ObjectsPoolManager.GetObject(mBullet.BulletType.ToString()); //从对象池中拿出物体
        if (BulletGO != null) //如果对象池里有物体，则设置该物体的子弹属性
        {
            mBullet.AnyBullet = BulletGO;
        }
        else //如果没有，就生成一个
        {
            GameObject gameObject = FactoryManager.assetFactory.LoadBullet(mBullet.BulletType.ToString());
            gameObject.AddComponent<BulletCollider>();
            ObjectsPoolManager.PushObject(mBullet.BulletType.ToString(), gameObject); //往对象池中添加物体
            mBullet.AnyBullet = gameObject;
        }                
    }

    public void AddMonoBehavior()
    {
        mBulletCollider = mBullet.AnyBullet.GetComponent<BulletCollider>();
        mBulletCollider.SetCollider(mBullet); //子弹伤害设置
        mBulletCollider.Init();
    }

    public Bullet GetResult()
    {
        return mBullet;
    }
}
