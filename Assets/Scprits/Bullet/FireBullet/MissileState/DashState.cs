using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MissileState,IMissileState {
    private bool mIsDashComplete;
    private float mRef;
    private float mSmootTime;
    private float mDashMaxDistance;
    private float mDashMaxSpeed;
    private float mDashForce;
    private float mMinAccelerationAngle;

    public DashState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        mIsDashComplete = false;
        mSmootTime = 2.5f;
        mDashMaxDistance = 1500;
        mDashMaxSpeed = 150;
        mDashForce = 75;
        mMinAccelerationAngle = 1.5f;
        Debug.Log("dash");
    }

    public void Act()
    {
        //
    }

    public void Do()
    {
        Dash();
    }

    public void Reason()
    {
        if (mIsDashComplete)
        {
            mMissileStateController.SetState(new TransposeState(mMissileStateController, mFireMissile));
        }
    }

    /// <summary>
    /// 停止自转，冲刺，上升，预加速,
    /// </summary>
    private void Dash()
    {
        mX = Mathf.SmoothDamp(mX, -90, ref mRef, mSmootTime,30,1f); //弹头朝上
        GameObject.transform.rotation = Quaternion.Euler(mX, 0, 0);
        if (mRigidbody.velocity.magnitude < mDashMaxSpeed
            || Vector3.Distance(GameObject.transform.position, mAimTankPos) <= mDashMaxDistance
            || Vector3.Angle(GameObject.transform.forward.normalized, new Vector3(0, 1, 0)) > mMinAccelerationAngle) // 速度，高度，角度，任意条件都满足才进行瞄准
        {
            mRigidbody.AddForce(0, Mathf.Abs(Mathf.Sin(mX)) * mDashForce, 0, ForceMode.Force);
        }
        else //到达后冲刺结束，计算得到需要朝向的方向
        {
            mIsDashComplete = true;
            mMissileTargetDirection = (mAimTankPos - GameObject.transform.position).normalized;
            Debug.DrawLine(GameObject.transform.position, mAimTankPos, Color.blue, 100f);
        }
        ///拖尾效果
        if (!Trails.activeSelf)
        {
            Trails.SetActive(true);
        }

    }

}
