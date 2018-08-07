using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileState {

    protected MissileStateController mMissileStateController;
    protected FireMissile mFireMissile;

    //导弹物体
    protected GameObject GameObject { get { return mFireMissile.GameObject; } }

    // 拖尾特效
    protected GameObject Trails { get { return mFireMissile.Trails; } }

    //姿态调整需要用的参数   
    protected Rigidbody mRigidbody { get { return mFireMissile.Rigidbody; } }

    //扫描保存用的参数
    protected Vector3 mAimTankPos
    {
        get { return mFireMissile.AimTankPos; }
        set { mFireMissile.AimTankPos = value; }
    }
    protected int mAimHashCode
    {
        get { return mFireMissile.AimHashCode; }
        set { mFireMissile.AimHashCode = value; }
    }
    protected Vector3 mMissileTargetDirection
    {
        get { return mFireMissile.MissileTargetDirection; }
        set { mFireMissile.MissileTargetDirection = value; }
    }

    // 炮弹模拟需要用到的参数
    protected Vector3 mRotation;
    protected float mX;
    protected float mZ;
    protected float mDropSpeed;
    protected float mSelfRotateSpeed;

    //精度范围和偏差范围
    protected float mAccuracyRange;
    protected float mDevasionRange;

    public MissileState(MissileStateController missileStateController,FireMissile fireMissile)
    {
        mMissileStateController = missileStateController;
        mFireMissile = fireMissile;
        mAccuracyRange = 5f;
        mDevasionRange = 25f;
    }

    /// <summary>
    /// 子弹下坠
    /// </summary>
    protected void Drag()
    {
        mRotation = GameObject.transform.rotation.eulerAngles;
        mX = mRotation.x;
        mRotation.x = Mathf.SmoothDampAngle(mX, 90, ref mDropSpeed, 2.5f);
        GameObject.transform.localEulerAngles = mRotation;
    }

    /// <summary>
    /// 自转
    /// </summary>
    protected void RotateSelf()
    {
        mRotation = GameObject.transform.rotation.eulerAngles;
        mZ = mRotation.z;
        mZ += Time.deltaTime * mSelfRotateSpeed * mFireMissile.Speed;
        mRotation.z = mZ;
        GameObject.transform.localEulerAngles = mRotation;
    }
}
