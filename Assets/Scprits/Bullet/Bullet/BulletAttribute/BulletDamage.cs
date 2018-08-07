using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletDamage:BulletAttr{

    public BulletDamage(float holdTime) : base(holdTime)
    {
        GetBulletDamage();
    }

    private float mLv1DamageRaiseSpeed = 4f;
    private float mLv2DamageRaiseSpeed = 9f;
    private float mLv3DamageRaiseSpeed = 15f;

    public float GetBulletDamage() { 
        if (mHoldTime <= mLv1Time)
        {
            mDamage = GetLv1Damage(mHoldTime);
        }
        else if (mHoldTime <= mLv2Time)
        {
            mDamage = GetLv2Damage(mHoldTime);
        }
        else if (mHoldTime <= mLv3Time)
        {
            mDamage = GetLv3Damage(mHoldTime);
        }
        else
        {
            mDamage = 50;
        }
        return mDamage;
    }

    private float GetLv1Damage(float time)
    {
        return time * mLv1DamageRaiseSpeed + UnityEngine.Random.Range(1,3);
    }

    private float GetLv2Damage(float time)
    {
        return time * mLv2DamageRaiseSpeed + UnityEngine.Random.Range(4,8);
    }

    private float GetLv3Damage(float time)
    {
        return time * mLv3DamageRaiseSpeed ;
    }

}
