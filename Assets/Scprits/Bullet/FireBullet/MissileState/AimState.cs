using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState :MissileState,IMissileState{
    private bool mIsScanTrue;
    private float mRelocateRange;

    public AimState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        mIsScanTrue = false;
        mSelfRotateSpeed = 90f;
        mRelocateRange = 2000f;
        Trails.SetActive(false);
        Debug.Log("Aim");
    }

    public void Act()
    {
        //
    }

    public void Do()
    {        
        Relacate();  //重定位  
    }

    public void Reason()
    {
        if (Vector3.Distance(GameObject.transform.forward, mMissileTargetDirection) < mAccuracyRange
            && Vector3.Distance(mAimTankPos, GameObject.transform.position ) < mDevasionRange)
        {
            mMissileStateController.SetState(new AttackState(mMissileStateController, mFireMissile));
        }
        if (mIsScanTrue)
        {
            mMissileStateController.SetState(new TransposeState(mMissileStateController, mFireMissile));
        }
    }

    /// <summary>
    /// 攻击阶段重定位校准
    /// </summary>
    private void Relacate()
    {
        //正面发射射线，扫描目标
        RotateSelf();
        GameObject gameObject = PhysicsTool.ConeHashCode(GameObject.transform.position, GameObject.transform.forward,90, mRelocateRange * mFireMissile.Size, 25, mAimHashCode);
        if (gameObject != null)
        {
            mMissileTargetDirection = (gameObject.transform.position - GameObject.transform.position).normalized; //得到导弹将要朝向的方向
            mAimTankPos = gameObject.transform.position;
            mIsScanTrue = true;
        }
    }
}
