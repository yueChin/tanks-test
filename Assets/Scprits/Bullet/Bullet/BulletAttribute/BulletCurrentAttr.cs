using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCurrentAttr :IBulletAttr {
    private float mDamage;
    private float mSize;
    private float mSpeed;
    private float mHoldTime;
    public float Damage { get { return mDamage; } }
    public float Size { get { return mSize; } }
    public float Speed { get { return mSpeed; } }

    public BulletCurrentAttr(float time)
    {
        mHoldTime = time;
        mDamage = GetBulletDamage();
        mSize = GetBulletSize();
        mSpeed = GetBulletSpeed();
    }

    public float GetBulletDamage()
    {
        return new BulletDamage(mHoldTime).Damage;
    }

    public float GetBulletSize()
    {
        return new BulletSize(mHoldTime).Size;
    }

    public float GetBulletSpeed()
    {
        return new BulletSpeed(mHoldTime).Speed;
    }
}
