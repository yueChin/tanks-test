using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSize:BulletAttr{
    public BulletSize(float holdTime) : base(holdTime)
    {
        GetBulletSize();
    }

    private float mLv1SizeRaiseSpeed = 1.1f;
    private float mLv2SizeRaiseSpeed = 1.2f;
    private float mLv3SizeRaiseSpeed = 1.4f;

    public float GetBulletSize()
    {
        if (mHoldTime <= mLv1Time)
        {
            mSize = GetLv1Size(mHoldTime);
        }
        else if (mHoldTime <= mLv2Time)
        {
            mSize = GetLv2Size(mHoldTime);
        }
        else if (mHoldTime <= mLv3Time)
        {
            mSize = GetLv3Size(mHoldTime);
        }
        else
        {
            mSize = GetLv3Size(mHoldTime);
        }
        return mSize;
    }

    private float GetLv1Size(float time)
    {
        return time * mLv1SizeRaiseSpeed;
    }

    private float GetLv2Size(float time)
    {
        return time * mLv2SizeRaiseSpeed;
    }

    private float GetLv3Size(float time)
    {
        return time * mLv3SizeRaiseSpeed;
    }

}
