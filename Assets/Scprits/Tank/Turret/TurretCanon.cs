using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCanon :Turret {
    private bool mIsFiring;
    private bool mIsCanFire;
    private float mIntervalTime;
    private int mNowBall;
    private int mMaxBall = 3;
    private float mCanonTime;
    public TurretCanon(GameObject gameObject,TurretAttr turretAttr) : base(gameObject,turretAttr) {
        mFireSpot = UnityTool.FindOneOfActiveChild(gameObject, "FireSpot").transform;        
    }

    /// <summary>
    /// 按下开火键的时候
    /// </summary>
    public override void Fire()
    {
        if (mIsFiring == true) return;
        mAudioSource.Play();        
        mIsFiring = true;
        mCanonTime = mHoldTime;
    }

    public override void Update()
    {
        base.Update();
        if (mIsFiring == true)
        {
            if (mIsCanFire)
            {
                FireBall();
            }
            intervalSomeTimeToFire();
            NoBallToFire();
        }

    }

    /// <summary>
    /// 发射卡农炮？
    /// </summary>
    private void FireBall()
    {
        mBullet = FactoryManager.BulletFactory.CreateBullet<BulletShell>(TurretType, mCanonTime); //生成子弹: 子弹类型，预制件，数值属性
        FiredBullet canonball = FactoryManager.FiredBulletFactory.OpenFire(TurretType, mFireSpot, mBullet);
        canonball.Fire();
        mNowBall++;
        mIsCanFire = false;
    }

    /// <summary>
    /// 间隔时间计时
    /// </summary>
    private void intervalSomeTimeToFire()
    {
        if (mIntervalTime > 0.1f)
        {
            mIntervalTime = 0;
            mIsCanFire = true;
        }
        else
        {
            mIntervalTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// 射击一定数量的子弹
    /// </summary>
    private void NoBallToFire()
    {
        if (mNowBall >= mMaxBall)
        {
            mIsFiring = false;
            mNowBall = 0;
        }
    }
}
