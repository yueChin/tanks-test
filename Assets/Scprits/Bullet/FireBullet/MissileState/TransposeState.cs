using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransposeState : MissileState, IMissileState
{
    private bool mIsTransposeDone;
    private bool mIsAdjustmentDone;
    private float mCounterForece;
    private float mAdjustmentForce;
    private float mScanTime;
    private float mTransposeSpeed;
    private float mMinAccelerationAngle;
    private float mMaxSpeed;
    public TransposeState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        mIsTransposeDone = false;
        mIsAdjustmentDone = false;
        mScanTime = 0;
        mAdjustmentForce = 250f;
        mCounterForece = 500f;
        mMaxSpeed = 100;
        mTransposeSpeed = 1f;
        mMinAccelerationAngle = 2.5f;
        Trails.SetActive(true);
        Debug.Log("Transpose");
    }

    public void Act()
    {
        Transpose(); //调整姿态
    }

    public void Do()
    {
        if (!mIsTransposeDone) return;
        TrajectoryAdjustment(); //弹道调整
    }

    public void Reason()
    {
        if (Vector3.Distance(mAimTankPos, mMissileTargetDirection) < mAccuracyRange
            && Vector3.Distance(mAimTankPos, GameObject.transform.position) < mDevasionRange)
        {
            mMissileStateController.SetState(new AttackState(mMissileStateController, mFireMissile));
        }
        if (mIsAdjustmentDone)
        {
            mMissileStateController.SetState(new AimState(mMissileStateController, mFireMissile));
        }
    }

    /// <summary>
    /// 攻击阶段姿态调整
    /// </summary>
    private void Transpose()
    {
        mScanTime += Time.deltaTime * mTransposeSpeed;
        if (Vector3.Angle(GameObject.transform.forward, mMissileTargetDirection) > mMinAccelerationAngle)
        {
            GameObject.transform.forward = Vector3.Slerp(GameObject.transform.forward, mMissileTargetDirection, mScanTime); //姿态调整
            Debug.DrawRay(GameObject.transform.position, GameObject.transform.forward * 10, Color.red, 50f); //姿态绘制
        }
        else
        {
            mIsTransposeDone = true;            
        }
    }

    /// <summary>
    /// 弹道调整
    /// </summary>
    private void TrajectoryAdjustment()
    {
        if (Vector3.Angle(GameObject.transform.forward, mRigidbody.velocity.normalized) > 90) //如果大于90度
        {
            mRigidbody.AddForce(GameObject.transform.forward * mCounterForece, ForceMode.Force); //反推
            Debug.DrawRay(GameObject.transform.position, GameObject.transform.forward * 10, Color.white, 50f); //反推绘制
        }
        else if (mRigidbody.velocity.magnitude < mMaxSpeed)
        {
            mRigidbody.AddForce(GameObject.transform.forward * mAdjustmentForce, ForceMode.Force);//接近
            Debug.DrawRay(GameObject.transform.position, GameObject.transform.forward * 10, Color.blue, 50f); //加速绘制
        }
        else if (Vector3.Angle(GameObject.transform.forward, mRigidbody.velocity.normalized) > mMinAccelerationAngle)
        {
            mRigidbody.AddForce((GameObject.transform.forward - mRigidbody.velocity.normalized) * mAdjustmentForce, ForceMode.Force); //调整            
            Debug.DrawRay(GameObject.transform.position, GameObject.transform.forward * 10, Color.black, 50f); //调整绘制
        }
        else
        {
            mIsAdjustmentDone = true;
        }
    }
}
