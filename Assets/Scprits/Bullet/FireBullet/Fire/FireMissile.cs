using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FireMissile : FiredBullet, IFire
{
    public float Size { get { return mBullet.Size; } }
    public float Speed { get { return mBullet.Speed; } }
    public Rigidbody Rigidbody { get { return mRigidbody; } }
    public GameObject Trails { get { return mTrails; } }
    public Vector3 AimTankPos { get { return mAimTankPos; }set { mAimTankPos = value; } }
    public Vector3 MissileTargetDirection { get { return mMissileTargetV3; } set { mMissileTargetV3 = value; } }
    public int AimHashCode { get { return mAimHashCode; }set { mAimHashCode = value; } }

    private Vector3 mAimTankPos;
    private Vector3 mMissileTargetV3;
    private int mAimHashCode;
    // 拖尾特效
    private GameObject mTrails;
    //姿态调整需要用的参数   
    private Rigidbody mRigidbody;
    private MissileStateController MSC = new MissileStateController();
    private bool mIsFire;
    public FireMissile(Transform _FireSpot,Bullet _Bullet) : base(_FireSpot,_Bullet) { }
    
    public override GameObject Fire()
    {              
        GameObject.transform.position = mFireSpot.position; //发射子弹的初始位置和角度
        GameObject.transform.rotation = mFireSpot.rotation;
        mRigidbody = GameObject.GetComponent<Rigidbody>();
        mRigidbody.velocity = GameObject.transform.forward * mBullet.Speed; // 设置子弹发射出的初速度
        mTrails = UnityTool.FindOneOfAllChild(GameObject, "Trails");
        mTrails.SetActive(false);
        MSC.SetState(new LaunchState(MSC,this));
        mIsFire = true;
        return GameObject;
    }

    public override void FixedUpdate()
    {
        if (!mIsFire) return;
        MSC.currentState.Do();
    }

    public override void Update()
    {
        if (!mIsFire) return;
        MSC.currentState.Act();
        MSC.currentState.Reason();
    }
}

