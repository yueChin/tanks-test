using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchState : MissileState, IMissileState
{
    private float mScanTime;
    private bool mIsScanOpen;
    public LaunchState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        mIsScanOpen = false;
        mScanTime = 0;
        mDropSpeed = 5f;
    }

    public void Act()
    {
        Launch();
        Scan();
        Reason();
    }

    public void Do()
    {
        //do no thing
    }

    public void Reason()
    {
        if (mIsScanOpen)
        {
            mMissileStateController.SetState(new ScanState(mMissileStateController,mFireMissile));
        }
    }

    private void Launch()
    {
        mRigidbody.velocity = GameObject.transform.forward * mFireMissile.Speed; // 设置子弹发射出的初速度
        Drag();
    }

    /// <summary>
    /// 扫描开启
    /// </summary>
    private void Scan()
    {
        mScanTime += Time.deltaTime;
        if (mScanTime > 0.5f)
        {
            mIsScanOpen = true;
        }
    }

}
