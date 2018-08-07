using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaser : Turret {

    private LineRenderer mLine;
    private Light mLight;
    private Vector3 mCurrentTankPos;
    private float mMaxFollowdistance = 24;
    private float mTankMoveSpeed;
    private float mLaserValue;
    private bool mIsLaserOn;
    private Tank mLaserTarget;
    //private GameObject mAudioGO;
    public TurretLaser(GameObject gameObject,TurretAttr turretAttr) : base(gameObject,turretAttr)
    {
        mFireSpot = UnityTool.FindOneOfActiveChild(gameObject, "FireSpot").transform;
        mLine = mFireSpot.GetComponent<LineRenderer>();
        mLight = mFireSpot.GetComponent<Light>();
        mAudioSource.loop = true;
        mBullet = new Bullet();        
    }

    public override void Fire()
    {
        mBullet.SetBulletAttr(mHoldTime);
        mLaserValue = (1 + mBullet.Size)/(20+mBullet.Size*5); // 1/20 => 1/5
        mOwner.Attr.MoveSpeed = mTankMoveSpeed /(mLaserValue*5 + 1); //坦克移动速度,会随着伤害增加而降低
        mLine.widthMultiplier = mLaserValue; //渲染出来的宽度
        FiredBullet laser = FactoryManager.FiredBulletFactory.OpenFire(TurretType, mFireSpot, mBullet);
        laser.Update();        
    }

    public override void Init()
    {
        base.Init();
        mTankMoveSpeed = mOwner.Attr.MoveSpeed; //记录移动速度
    }

    public override void Update()
    {
        ChangeTarget();
        // 按下多久 发射
        if (mLaserTarget == null)//没有目标就返回
        {
            LaserOff();
            return;
        }
        else if (Input.GetKeyDown(mOwner.Attr.FireKey))
        {
            LaserOn();
        }
        else if (Input.GetKey(mOwner.Attr.FireKey)) //当开火键 按下，计时按下的时间
        {
            LaserHold();
        }
        else if (Input.GetKeyUp(mOwner.Attr.FireKey) || mLaserTarget == null) //当 开火键弹起，从Bullet得到 damage，size，speed，并实例化子弹
        {
            LaserOff();
        }        
    }

    /// <summary>
    /// 目标位置的获取和更换目标
    /// </summary>
    private void ChangeTarget()
    {
        if (mLaserTarget == null) //如果镭射炮台没有跟随的目标，就设置一个
        {
            if (mOwner.Target == null) return; //如果坦克的搜索范围内没有目标，就返回
            mLaserTarget = mOwner.Target; //有目标，更换目标
        }
        if (!mIsLaserOn) //如果镭射关闭
        {
            mLaserTarget = mOwner.Target; //更换目标（可能为null，由tank搜索决定）
        }
        if (mIsLaserOn && Vector3.Distance(mOwner.Position, mLaserTarget.Position) > mMaxFollowdistance) //镭射开启但是目标不在最大搜索范围内
        {
            mLaserTarget = null;
        }
    }

    private void GetTargetPosition()
    {
        mCurrentTankPos = mLaserTarget.Position; //获取目前目标坦克的位置
    }

    private void LaserOn()
    {
        //if (mLaserTarget == null) return; //没有目标就返回
        mLight.enabled = true;
        mLine.enabled = true;       //开启线渲染和音效
        mIsLaserOn = true;      //镭射开启，开启后不会更换目标
        mAudioSource.Play();                             
    }

    private void LaserHold()
    {
        //if (mLaserTarget == null) return; //没有目标就返回
        GetTargetPosition(); //获取目标位置
        mHoldTime += Time.deltaTime;
        mAnyTurret.transform.LookAt(mCurrentTankPos);//炮台朝向目标坦克
        mLine.SetPosition(0, mFireSpot.position); // 渲染起点   
        mLine.SetPosition(1, mCurrentTankPos);//渲染第二个点，目前是终点
        Fire();
    }

    private void LaserOff()
    {
        mHoldTime = 0;                    // 把按下的时间清零
        mLine.enabled = false;          //关闭灯光，线渲染，和音效
        mLight.enabled = false;
        mIsLaserOn = false;             //镭射关闭
        mAudioSource.Stop();
        mOwner.Attr.MoveSpeed = mTankMoveSpeed; //坦克恢复速度
    }
}
