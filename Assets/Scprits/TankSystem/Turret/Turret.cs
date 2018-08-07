using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Turret{

    protected Bullet mBullet;
    protected FeatureManager mFeatureManager;
    protected Transform mFireSpot;
    protected AudioSource mAudioSource;
    protected AudioClip mAudioClip;
    protected GameObject mAnyTurret;
    protected Tank mOwner;
    protected float mHoldTime;
    protected TurretAttr mTurretAttr;

    public Tank Owner { get { return mOwner; } set { mOwner = value; } }
    public GameObject AnyTuret { get { return mAnyTurret; } }
    public float MaxHoldTime { get { return mTurretAttr.MaxHoldTime; } }
    public TurretAttr TurretAttr { get { return mTurretAttr; } }

    public TurretType TurretType { get { return mTurretAttr.TurretType; } }
    public AudioType FireAudio { get { return mTurretAttr.FireAudio; } }

    public Turret(GameObject gameObject,TurretAttr turretAttr)
    {
        mAnyTurret = gameObject;
        mTurretAttr = turretAttr;
        mAudioSource = mAnyTurret.GetComponent<AudioSource>();
        mAudioClip = FactoryManager.assetFactory.LoadAudioClip(FireAudio.ToString());
        mAudioSource.clip = mAudioClip;
    }

    public abstract void Fire();
    public virtual void Init() { }
    public virtual void Update()
    {
        // 按下多久 发射
        if (Input.GetKey(mOwner.Attr.FireKey) && mHoldTime <= MaxHoldTime) //当开火键 按下，计时按下的时间
        {
            mHoldTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(mOwner.Attr.FireKey) || mHoldTime >= MaxHoldTime) //当 开火键弹起，从Bullet得到 damage，size，speed，并实例化子弹
        {
            Fire();
            mHoldTime = 0;                    // 把按下的时间清零
        }
    }
}
