using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class BulletAttr
{
    protected float mDamage;
    protected float mSize;
    protected float mSpeed;
    protected float mHoldTime;
    protected float mLv1Time = 1f;
    protected float mLv2Time = 2f;
    protected float mLv3Time = 3f;

    public float Damage{get{ return mDamage; } }
    public float Size { get { return (mSize+0.8f); } }
    public float Speed { get { return mSpeed; } }

    public BulletAttr(float time)
    {
        mHoldTime = time;        
    }
}

