using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed:BulletAttr {
    public BulletSpeed(float holdTime) : base(holdTime)
    {
        GetBulletSpeed();
    }

    private float mLv1SpeedRaiseSpeed = 10f;
    private float mLv2SpeedRaiseSpeed = 14f;
    private float mLv3SpeedRaiseSpeed = 20f;

    public float GetBulletSpeed()
    {
        if (mHoldTime <= mLv1Time)
        {
            mSpeed = GetLv1Speed(mHoldTime);
        }
        else if (mHoldTime <= mLv2Time)
        {
            mSpeed = GetLv2Speed(mHoldTime);
        }
        else if (mHoldTime <= mLv3Time)
        {
            mSpeed = GetLv3Speed(mHoldTime);
        }
        else
        {
            mSpeed = GetLv3Speed(mHoldTime);
        }
        return mSpeed;
    }
    private float GetLv1Speed(float time)
    {
        return (1+time) * mLv1SpeedRaiseSpeed;
    }
    private float GetLv2Speed(float time)
    {
        return (1+time) * mLv2SpeedRaiseSpeed;
    }
    private float GetLv3Speed(float time)
    {
        return (1+time) * mLv3SpeedRaiseSpeed;
    }

}
