using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiredBullet {
    
    protected Transform mFireSpot;
    protected Bullet mBullet;

    public Bullet Bullet
    {
        set
        {
            mBullet = value;
            mBullet.Owner = this;
        }
        get { return mBullet; }
    }

    public GameObject GameObject { get { return mBullet.AnyBullet; } }     

    public FiredBullet(Transform _FireSpot,Bullet _Bullet)
    {
        mFireSpot = _FireSpot;
        Bullet = _Bullet;
    }
    public abstract GameObject Fire();    
    public virtual void InstAnyBulletSomeAttr() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
