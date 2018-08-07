using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanState : MissileState,IMissileState {
    private bool mIsScanTrue;
    private bool mHit;
    private Ray mRay;
    private RaycastHit mRaycastHit;
    private float mMinScanRange;
    private float mScanRange;

    public ScanState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        mIsScanTrue = false;
        mMinScanRange = 3f;
        mScanRange = 20f;
        mSelfRotateSpeed = 180f;
        mDropSpeed = 15f;
    }

    public void Act()
    {
        DragAndRotateSelf();
    }

    public void Do()
    {
        ScanTank();
    }

    public void Reason()
    {
        if (mIsScanTrue)
        {
            mMissileStateController.SetState(new DashState(mMissileStateController,mFireMissile));
        }
    }

    /// <summary>
    /// 子弹运动模拟
    /// </summary>
    private void DragAndRotateSelf()
    {
        RotateSelf();
        Drag();
    }

    /// <summary>
    /// 扫描坦克
    /// </summary>
    private void ScanTank()
    {
        //侧边发出射线，扫描目标
        mHit = Physics.Raycast(GameObject.transform.position, GameObject.transform.right, out mRaycastHit, mScanRange * mFireMissile.Size);
        if (mHit)
        {
            if (mRaycastHit.transform.tag == "Tank")
            {
                Debug.Log(mRaycastHit.GetType());
                if (Vector3.Distance(GameObject.transform.position, mRaycastHit.transform.position) > mMinScanRange) //如果目标太近，不进行瞄准动作
                {
                    mIsScanTrue = true;  //发现目标
                    mAimTankPos = mRaycastHit.transform.position; //保存发现目标的位置
                    mAimHashCode = mRaycastHit.transform.gameObject.GetHashCode();
                }
            }
        }
    }
}
